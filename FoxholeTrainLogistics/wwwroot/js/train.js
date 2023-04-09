function Train(train, isInteractable=false) {

    const init = () => {
        if (typeof train !== "object")
            throw new DOMException(`train must be an object`);

        trainsFactory.init(train, isInteractable);
        this.train = { ...train, Cars: [] };
        train.Cars.forEach(c => addTrainCar(c));
    };

    const addTrainCar = (car) => {
        const trainCarElement = trainsFactory.createTrainCar(car);
        this.train.Cars.push({ ...car, element: trainCarElement })
        console.log("updatedTrainCars=", this.train.Cars);
    }

    const loadItemOntoTrain = (item) => {
        const trainCars = JSON.parse("[" + localStorage.trainCars + "]");
        const flatbedCars = trainCars.filter(c => TrainCarType[c.Type] === "FlatbedCar");
        console.log("flatbeds=", flatbedCars);

        console.log("item=", item);
    }

    init();

    return {
        ...this.train,
        addTrainCar,
        loadItemOntoTrain
    };
};