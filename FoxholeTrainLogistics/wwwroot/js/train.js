function Train(_train, isInteractable=false) {

    const Init = () => {
        if (typeof _train !== "object")
            throw new DOMException(`train must be an object`);

        trainsFactory.init(_train, isInteractable);
        this.train = { ..._train, Cars: [] };
        _train.Cars.forEach(c => AddTrainCar(c));
    };

    const GetTrainCar = (carId) => {
        const trainCar = train.Cars.find(c => c.id === carId);

        if (trainCar === undefined)
            throw new DOMException('[Train] No train car exists with id ' + carId);
            
        return trainCar;
    }

    const AddTrainCar = (car) => {
        const carId = Date.now();
        const newCar = { ...car, id: carId };
        const trainCarElement = trainsFactory.createTrainCar(newCar);
        const newCarWithElement = { ...newCar, element: trainCarElement };
        this.train.Cars.push(newCarWithElement)

        return newCarWithElement;
    }

    const RemoveTrainCar = (carId) => {
        const car = this.train.Cars.find(c => c.id === carId);

        if (!car)
            throw new DOMException('[Train] No train car exists with id ' + carId);

        this.train.Cars = this.train.Cars.filter(c => c.id !== carId);
        trainsFactory.destroyTrainCar(car);
        console.log(this.train.Cars);
    }

    const getFlatbedCars = () => this.train.Cars.filter(c => c.Type === "FlatbedCar");

    const LoadItem = (item) => {
        if (!item)
            throw new DOMException("item cannot be null");

        console.log("item=", item);

        const isMPFOrSinglePackage = item.ShippingType === "CrateOrPackage";
        var updatedFlatcar = undefined;

        if (isMPFOrSinglePackage)
            updatedFlatcar = loadPackagedItem(item);
        else
            updatedFlatcar = loadMultiContainerItem(item);

        console.log("[Train] Updated Flat Car:", updatedFlatcar);
    }

    const loadPackagedItem = (item) => {
        const flatbedCars = getFlatbedCars();
        const flatbedCarsWithoutContainer = flatbedCars.filter(fb => fb.Container == null);

        if (!localStorage.packageOption)
            throw new DOMException("packageOption cannot be undefined");

        const isMPF = InvertEnum(PackageType)[localStorage.packageOption] == InvertEnum(PackageType).mpfCrate;

        console.log(InvertEnum(PackageType)[localStorage.packageOption], ",", InvertEnum(PackageType).mpfCrate)

        const newContainerImage = isMPF ? "Crate.png" : item.IconName;
        const newContainerContents = isMPF ? [item, item, item] : [item];
        const newContainer = { ...PackagedItemContainerTemplate, isMPF, Image: newContainerImage, Contents: newContainerContents };

        newContainer.tooltip = (isMPF ? "Crate of 3x " : "") + item.DisplayName;

        if (flatbedCarsWithoutContainer.length > 0) {
            const flatcar = flatbedCarsWithoutContainer[0];
            flatcar.Container = newContainer;
            trainsFactory.addContainerToFlatcar(flatcar, newContainer);

            return flatcar;
        }
        else {
            const newFlatbed = { ...TrainCarTemplates.FlatbedCar, Container: newContainer };
            return AddTrainCar(newFlatbed);
        }
    }

    const loadMultiContainerItem = (item) => {
        const flatbedCars = getFlatbedCars();
        const flatbedCarsWithRightContainer = flatbedCars.filter(fb => fb.Container && fb.Container.Type === item.ShippingType);
        const flatbedCarsWithFreeSpace = flatbedCarsWithRightContainer.filter(fb => fb.Container.Contents.length < fb.Container.Capacity);
        const flatbedCarsWithoutContainer = flatbedCars.filter(fb => fb.Container == null);

        if (flatbedCarsWithFreeSpace.length > 0) {
            const flatbedWithFreeSpace = flatbedCarsWithFreeSpace[0];
            flatbedWithFreeSpace.Container.Contents.push(item);

            return flatbedWithFreeSpace;
        }
        else if (flatbedCarsWithoutContainer.length > 0) {
            const newContainer = { ...MultiItemContainerTemplates[item.ShippingType] };
            newContainer.Contents.push(item);
            //newContainer.tooltip = 

            const flatCar = flatbedCarsWithoutContainer[0];
            flatCar.Container = newContainer;
            trainsFactory.addContainerToFlatcar(flatCar, newContainer);

            return flatCar;
        }
        else if (flatbedCarsWithFreeSpace.length === 0) {
            const newContainer = { ...MultiItemContainerTemplates[item.ShippingType] };
            newContainer.Contents.push(item);

            const newFlatcar = { ...TrainCarTemplates.FlatbedCar, Container: newContainer };
            return AddTrainCar(newFlatcar);
        }
    }

    Init();

    return {
        ...this.train,
        GetTrainCar,
        AddTrainCar,
        RemoveTrainCar,
        LoadItem
    };
};