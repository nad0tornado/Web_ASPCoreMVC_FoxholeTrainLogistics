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
        btn.style = "display: flex; justify-content: center; position: relative";

        var img = btn.appendChild(document.createElement("img"));
        img.src = "./img/trains/" + car.Image;
        img.className = "ftl-icon";
        img["data-bs-toggle"] = "tooltip";
        img["data-bs-placement"] = "top";
        img.title = car.Type;

        var topLeftSelection = btn.appendChild(document.createElement("div"));
            topLeftSelection.className = "ftl-selection-box";
            topLeftSelection.style = "left: 0; top: 0;";
        var topRightSelection = btn.appendChild(document.createElement("div"));
            topRightSelection.className = "ftl-selection-box";
            topRightSelection.style = "right: 0; top: 0";
        var bottomLeftSelection = btn.appendChild(document.createElement("div"));
            bottomLeftSelection.className = "ftl-selection-box";
            bottomLeftSelection.style = "left: 0; bottom: 0";
        var bottomRightSelection = btn.appendChild(document.createElement("div"));
            bottomRightSelection.className = "ftl-selection-box";
            bottomRightSelection.style = "right: 0; bottom: 0";
        

        /*  <div style="right:0 "></div>
            <div style="left : 0"></div>  
            <div style="left:0; bottom: 0 "></div>
            <div style="right:0; bottom: 0 "></div>
        */

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
