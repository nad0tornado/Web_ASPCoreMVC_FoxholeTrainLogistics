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

    const AddItem = (item) => {
        if (!item)
            throw new DOMException("item cannot be null");

        console.log("item=", item);

        const isMPFOrSinglePackage = item.ShippingType === "CrateOrPackage";
        var updatedFlatcar = undefined;

        if (isMPFOrSinglePackage)
            updatedFlatcar = addPackagedItem(item);
        else
            updatedFlatcar = addMultiContainerItem(item);

        console.log("[Train] Updated Flat Car:", updatedFlatcar);
    }

    const addPackagedItem = (item) => {
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

    const addMultiContainerItem = (item) => {
        const flatbedCars = getFlatbedCars();
        const flatbedCarsWithRightContainer = flatbedCars.filter(fb => fb.Container && fb.Container.Type === item.ShippingType);
        const flatbedCarsWithFreeSpace = flatbedCarsWithRightContainer.filter(fb => fb.Container.Contents.length < fb.Container.Capacity);
        const flatbedCarsWithoutContainer = flatbedCars.filter(fb => fb.Container == null);

        var updatedFlatcar = undefined;
        if (flatbedCarsWithFreeSpace.length > 0) {
            const flatbedWithFreeSpace = flatbedCarsWithFreeSpace[0];
            flatbedWithFreeSpace.Container.Contents.push(item);

            updatedFlatcar = flatbedWithFreeSpace;
        }
        else if (flatbedCarsWithoutContainer.length > 0) {
            const newContainer = { ...MultiItemContainerTemplates[item.ShippingType] };
            newContainer.Contents.push(item);

            const flatCar = flatbedCarsWithoutContainer[0];
            flatCar.Container = newContainer;
            trainsFactory.addContainerToFlatcar(flatCar, newContainer);

            updatedFlatcar = flatCar;
        }
        else if (flatbedCarsWithFreeSpace.length === 0) {
            const newContainer = { ...MultiItemContainerTemplates[item.ShippingType] };
            newContainer.Contents.push(item);

            const newFlatcar = { ...TrainCarTemplates.FlatbedCar, Container: newContainer };
            updatedFlatcar = AddTrainCar(newFlatcar);
        }

        updatedFlatcar.Container.Contents = updatedFlatcar.Container.Contents.sort((a, b) => {
            if (a.DisplayName < b.DisplayName) {
                return -1;
            }
            if (a.DisplayName > b.DisplayName) {
                return 1;
            }
            return 0;
        });
        return updatedFlatcar;
    }

    const RemoveItem = (item, flatcar) => {
        if (item === undefined)
            throw new DOMException("item cannot be undefined");
        if (flatcar === undefined)
            throw new DOMException("flatcar cannot be undefined");

        const flatcarContainer = flatcar.Container;

        if (flatcarContainer === undefined)
            throw new DOMException("The given flatcar doesn't have a container");
        if (!flatcarContainer.Contents.some(i => i.Type === item.Type))
            throw new DOMException("No item of the given type exists in this flatbed car's container");

        const itemToRemoveIndex = flatcarContainer.Contents.indexOf(item);
        flatcarContainer.Contents = flatcarContainer.Contents.filter((_, i) => i !== itemToRemoveIndex);
        
    }
    Init();

    return {
        ...this.train,
        GetTrainCar,
        AddTrainCar,
        RemoveTrainCar,
        AddItem,
        RemoveItem
    };
};