function Train (trainCars) {

    const init = () => {
        if (typeof trainsFactory === undefined)
            throw new DOMException("ShippableToolbar requires prior existence of a trainsFactory");

        if (typeof trainCars === "string") {
            var trainCarsObj = JSON.parse(trainCars);
            console.log("trainCarsObj=", trainCarsObj);
        }

        console.log("trainCars=", trainCars);
    };

    init();

    return {
        foo: () => console.log("foo!"),
        loadItemOntoTrain: (item) => {
            const trainCars = JSON.parse("[" + localStorage.trainCars + "]");
            const flatbedCars = trainCars.filter(c => TrainCarType[c.Type] === "FlatbedCar");
            console.log("flatbeds=", flatbedCars);

            console.log("item=", item);
        }
    };
};