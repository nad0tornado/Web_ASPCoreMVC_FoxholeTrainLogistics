// Train Creation Factory

class TrainsFactory {

    constructor(trainId, interactable = true) {
        this.interactable = interactable;
        this.trainId = trainId;
    }

    getTrainContainer() {
        var container = document.getElementById("train-container-" + this.trainId);

        if (container === null)
            throw new DOMException("Unable to locate trainContainer - was this script ran before the trainContainer was created?");

        return container;
    }

    createTrainCar(car) {

        const trainCars = localStorage.trainCars ? JSON.parse('['+localStorage.trainCars+']') : [];
        const trainContainer = this.getTrainContainer();
        const btn = trainContainer.appendChild(document.createElement("button"));
        btn.className = "ftl-noselect ftl-interact ftl-button";

        console.log('adding ' + car.Type);

        var img = btn.appendChild(document.createElement("img"));
        img.src = "./img/"+car.Image;

        img.className = "ftl-icon";

        console.log(trainCars);
        trainCars.push(car);
        localStorage.trainCars = JSON.stringify(trainCars).replace(/[\[\]']+/g, '');

        if (this.interactable) {
            btn.onclick = () => {
                trainContainer.removeChild(btn);

                trainCars[trainCars.indexOf(car)] = undefined;
                var updatedTrainCars = trainCars.filter(t => t !== undefined);
                localStorage.trainCars = JSON.stringify(updatedTrainCars).replace(/[\[\]']+/g, '');

                const trainCrewChip = document.getElementById("train-crew-" + this.trainId);
                trainCrewChip.innerHTML = "Crew Capacity: " + updatedTrainCars.map(c => c.Crew).reduce((a, c) => a + c);
            }
        }
        
        return btn;
    }
}

var trainsFactory = new TrainsFactory();
