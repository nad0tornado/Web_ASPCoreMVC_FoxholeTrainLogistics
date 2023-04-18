function Train(_train, isInteractable=false) {

    const Init = () => {
        if (typeof _train !== "object")
            throw new DOMException(`train must be an object`);

        trainsFactory.init(_train, isInteractable);
        this.train = { ..._train, Cars: [] };
        _train.Cars.forEach(c => AddTrainCar(c));
    };

    const getTrainCars = () => this.train.Cars;
    const getFlatbedCars = () => this.train.Cars.filter(c => c.Type === "FlatbedCar");

    const GetTrainCarById = (carId) => {
        const trainCar = getTrainCars().find(c => c.id === carId);

        if (trainCar === undefined)
            throw new DOMException('[Train] No train car exists with id ' + carId);
            
        return trainCar;
    }

    const GetTrainCarAt = (index) => {
        const trainCars = getTrainCars();
        const trainCar = trainCars.find((_, i) => i === index);

        if (trainCar === undefined)
            throw new DOMException('[Train] No train car exists at position ' + index);

        return trainCars[index % trainCars.length];
    }

    const GetTrainCarIndex = (car) => {
        const index = getTrainCars().indexOf(car);

        if (index === -1)
            throw new DOMException(`[Train] Train car ${car.id} (${car.Type}) isn't a part of train ${this.train.TrainId}`);

        return index;
    }

    const AddTrainCar = (car) => {
        const carId = Utils.GenerateUniqueId();
        const newCar = { ...car, id: carId };
        const trainCarElement = trainsFactory.createTrainCar(newCar);
        const newCarWithElement = { ...newCar, element: trainCarElement };
        getTrainCars().push(newCarWithElement)

        return newCarWithElement;
    }

    const RemoveTrainCar = (carId) => {
        const trainCars = getTrainCars();
        const car = trainCars.find(c => c.id === carId);

        if (!car)
            throw new DOMException('[Train] No train car exists with id ' + carId);

        trainsFactory.destroyTrainCar(car);
        this.train.Cars = this.train.Cars.filter(c => c.id !== carId);
    }

    const AddItem = (item) => {
        if (!item)
            throw new DOMException("item cannot be null");

        const isMPFOrSinglePackage = item.ShippingType === "CrateOrPackage";
        var updatedFlatcar = undefined;

        if (isMPFOrSinglePackage)
            updatedFlatcar = addPackagedItem(item);
        else
            updatedFlatcar = addMultiContainerItem(item);

        return updatedFlatcar;
    }

    const addPackagedItem = (item) => {
        const flatbedCars = getFlatbedCars();
        const flatbedCarsWithoutContainer = flatbedCars.filter(fb => fb.Container == null);

        if (!localStorage.packageOption)
            throw new DOMException("packageOption cannot be undefined");

        const isMPF = InvertEnum(PackageType)[localStorage.packageOption] == InvertEnum(PackageType).mpfCrate;

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
            const newFlatcar = AddTrainCar({ ...TrainCarTemplates.FlatbedCar, Container: newContainer });
            return newFlatcar;
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

            const newFlatcar = AddTrainCar({ ...TrainCarTemplates.FlatbedCar, Container: newContainer });
            updatedFlatcar = newFlatcar;
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

    const RemoveTrainCarContainer = (flatcar) => {
        if (flatcar === undefined || flatcar?.Type !== "FlatbedCar")
            throw new DOMException("the given train car is not a flat car");

        if (flatcar.Container === undefined || flatcar.Container === null)
            return;

        flatcar.Container = undefined;
        trainsFactory.destroyFlatCarContainer(flatcar);
    }

    Init();

    return {
        ...this.train,
        GetTrainCarById,
        GetTrainCarAt,
        GetTrainCarIndex,
        AddTrainCar,
        RemoveTrainCar,
        RemoveTrainCarContainer,
        AddItem,
        RemoveItem
    };
};