// Train Creation Factory

class TrainsFactory {

    init(train, interactable = true) {
        this.interactable = interactable;
        this.train = train;
        this.trainContainer = document.getElementById("train-container-" + train.TrainId);
        this.trainCrewChip = document.getElementById("train-crew-" + train.TrainId);
    }

    createTrainCar(car) {
        if (!this.trainContainer)
            throw new DOMException("A train container must exist");

        const btn = this.trainContainer.appendChild(document.createElement("button"));
        btn.className = "ftl-noselect ftl-interact ftl-button";

        console.log('adding ' + car.Type);

        var img = btn.appendChild(document.createElement("img"));
        img.src = "./img/trains/" + car.Image;
        img.className = "ftl-icon";

        if (this.interactable) {
            btn.onclick = () => {
                this.trainContainer.removeChild(btn);

                var updatedTrainCars = this.train.Cars.filter(c => this.train.Cars.indexOf(c) !== this.train.Cars.indexOf(car));

                console.log("updatedTrainCars = ", updatedTrainCars);

                this.trainCrewChip.innerHTML = "Crew Capacity: " + updatedTrainCars.map(c => c.Crew).reduce((a, c) => a + c);
            }
        }

        return btn;
    }

    createFlatbedCar(containerType, containerContents = []) {

    }
}
