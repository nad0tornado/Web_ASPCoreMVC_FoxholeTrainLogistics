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

        var img = btn.appendChild(document.createElement("img"));
        img.src = "./img/trains/" + car.Image;
        img.className = "ftl-icon";

        if (this.interactable) {
            btn.onclick = () => {
                train.removeTrainCar(car.id);

                this.trainCrewChip.innerHTML = "Crew Capacity: " + train.Cars.map(c => c.Crew).reduce((a, c) => a + c);
            }
        }

        console.log('[TrainsFactory] Created ' + car.Type);

        return btn;
    }

    destroyTrainCar(car) {
        this.trainContainer.removeChild(car.element);
    }

    createFlatbedCar(containerType, containerContents = []) {

    }
}

const trainsFactory = new TrainsFactory();
