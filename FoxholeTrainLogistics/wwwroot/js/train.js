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
        const flatbedCars = getFlatbedCars();
        const emptyFlatbedCars = flatbedCars.filter()
        

        console.log("item=", item);
    }

    const loadPackagedItem = (item) => {
        const 
    }

    const loadMultiContainerItem = (item) => {
        const flatbedCars = getFlatbedCars();
        const flatbedCarsWithRightContainer = flatbedCars.filter(fb => fb.Container !== null && fb.Container.Type === item.ShippingType);
        const flatbedCarsWithFreeSpace = flatbedCarsWithRightContainer.filter(fb => fb.Container.Contents.length < fb.Container.Capacity);

        if (flatbedCarsWithFreeSpace.length === 0) {
            const newContainer = new MultiItemContainerTemplates[item.ShippingType];
            const newFlatbed = { ...TrainCarTemplates.FlatbedCar, Container: newContainer };
            AddTrainCar(newFlatbed);
        }
        else {
            const container = containersWithAvailableSpace[0];
            container.Contents.push(item);
            // const flatbed = 
            // ... add the item to the container on the flatbed and update the flatbed in the train cars list
        }
    }

    Init();

    return {
        ...this.train,
        AddTrainCar,
        RemoveTrainCar,
        LoadItem
    };
};