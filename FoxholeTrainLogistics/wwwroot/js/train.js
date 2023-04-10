function Train(train, isInteractable=false) {

    const Init = () => {
        if (typeof train !== "object")
            throw new DOMException(`train must be an object`);

        trainsFactory.init(train, isInteractable);
        this.train = { ...train, Cars: [] };
        train.Cars.forEach(c => AddTrainCar(c));
    };

    const AddTrainCar = (car) => {
        const carId = Date.now();
        const newCar = { ...car, id: carId };
        const trainCarElement = trainsFactory.createTrainCar(newCar);
        const newCarWithElement = { ...newCar, element: trainCarElement };
        this.train.Cars.push(newCarWithElement)
        console.log("updatedTrainCars=", this.train.Cars);

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

    const getFlatbedCars() => this.train.Cars.filter(c => c.Type === "FlatbedCar");

    const LoadItem = (item) => {
        if (!item)
            throw new DOMException("item cannot be null");

        console.log("item=", item);

        const isPackagedItem = item.ShippingType === "PackagedItem";

        if (isPackagedItem)
            loadPackagedItem(item);
        else
            loadMultiContainerItem(item);
    }

    const loadPackagedItem = (item) => {
        const 
    }

    const loadMultiContainerItem = (item) => {
        const flatbedCars = getFlatbedCars();
        const flatbedCarsWithRightContainer = flatbedCars.filter(fb => fb.Container && fb.Container.Type === item.ShippingType);
        const flatbedCarsWithFreeSpace = flatbedCarsWithRightContainer.filter(fb => fb.Container.Contents.length < fb.Container.Capacity);
        const emptyFlatbedCars = flatbedCars.filter(fb => fb.Container == null);

        // .. also take into account any empty flatbeds. if a flatbed is empty AND there's no space in another container,
        // .. add a container to the empty flatbed rather than making a new flatbed every time

        if (flatbedCarsWithFreeSpace.length === 0) {
            const newContainer = new MultiItemContainerTemplates[item.ShippingType];
            const newFlatbed = { ...TrainCarTemplates.FlatbedCar, Container: newContainer };
            AddTrainCar(newFlatbed);
        }
        else {
            const flatbedWithFreeSpace = flatbedCarsWithFreeSpace[0];
            flatbedWithFreeSpace.Container.Contents.push(item);
        }

        console.log("updated flat cars=", flatbedCars);
    }

    Init();

    return {
        ...this.train,
        AddTrainCar,
        RemoveTrainCar,
        LoadItem
    };
};