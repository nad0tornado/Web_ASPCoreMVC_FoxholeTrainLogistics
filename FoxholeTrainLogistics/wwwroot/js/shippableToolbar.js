const ShippableToolbar = (() => {
    const init = () => {
        if (typeof trainsFactory === undefined)
            throw new DOMException("ShippableToolbar requires prior existence of a trainsFactory");
    };

    const loadItemOntoTrain = (item) => {
        const trainCars = JSON.parse("[" + localStorage.trainCars + "]");
        const flatbedCars = trainCars.filter(c => TrainCarType[c.Type] === "FlatbedCar");
        console.log("flatbeds=", flatbedCars);

        console.log("item=", item);
    }

    init();

    return {
        loadItemOntoTrain
    };
})();


