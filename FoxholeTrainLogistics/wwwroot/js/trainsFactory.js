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
        btn.style = "display: flex; justify-content: center";

        var img = btn.appendChild(document.createElement("img"));
        img.src = "./img/trains/" + car.Image;
        img.className = "ftl-icon";
        img["data-bs-toggle"] = "tooltip";
        img["data-bs-placement"] = "top";
        img.title = car.Type;

        if (this.interactable) {
            btn.onclick = () => {
                train.RemoveTrainCar(car.id);
                this.trainCrewChip.innerHTML = "Crew Capacity: " + train.Cars.map(c => c.Crew).reduce((a, c) => a + c);
            }
        }

        if (car.Type === "FlatbedCar" && car.Container) {

            btn.appendChild(this.createContainer(car.Container));
        }

        console.log('[TrainsFactory] Created ' + car.Type +": ",car);

        return btn;
    }

    createContainer(container) {
        const ShippingTypeInv = InvertEnum(ShippingType);

        var img = document.createElement("img");
        img.src = (ShippingTypeInv[container.Type] !== ShippingTypeInv.PackagedItem || container.isMPF ? "./img/containers/" : "") + container.Image;
        img.className = "ftl-icon ftl-shippable-icon";
        img.style = "position: absolute; margin-top: -10px; height: 60px";

        img["data-bs-toggle"] = "tooltip";
        img["data-bs-placement"] = "top";

        img.title = container.tooltip ?? container.Type;

        console.log('[TrainsFactory] Created ' + container.Type + ": ", container);

        return img;
    }

    addContainerToFlatcar(flatcar, container) {
        flatcar.element.appendChild(this.createContainer(container));
    }

    destroyTrainCar(car) {
        this.trainContainer.removeChild(car.element);
    }

    createFlatbedCar(containerType, containerContents = []) {

    }
}

const trainsFactory = new TrainsFactory();
