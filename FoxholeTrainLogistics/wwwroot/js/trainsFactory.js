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
        btn.className = "ftl-noselect ftl-interact ftl-button ftl-flex-container";

        var img = btn.appendChild(document.createElement("img"));
        img.id = car.id+"-car";
        img.src = "./img/trains/" + car.Image;
        img.className = "ftl-icon";
        img["data-bs-toggle"] = "tooltip";
        img["data-bs-placement"] = "top";
        img.title = car.DisplayName;

        if (car.Type === "FlatbedCar" && car.Container) {
            btn.appendChild(this.createContainer(car.Container));
        }

        if(!this.interactable)
            return btn;

        var topLeftSelection = btn.appendChild(document.createElement("div"));
        topLeftSelection.className = "ftl-selection-box selection-box-"+car.id;
        topLeftSelection.style = "left: 0; top: 0; border-width: 1px 0px 0px .1px";
        var topRightSelection = btn.appendChild(document.createElement("div"));
        topRightSelection.className = "ftl-selection-box selection-box-" + car.id;
        topRightSelection.style = "right: 0; top: 0; border-width: 1px 1px 0px 0px";
        var bottomLeftSelection = btn.appendChild(document.createElement("div"));
        bottomLeftSelection.className = "ftl-selection-box selection-box-" + car.id;
        bottomLeftSelection.style = "left: 0; bottom: 0; border-width: 0px 0px 1px 1px";
        var bottomRightSelection = btn.appendChild(document.createElement("div"));
        bottomRightSelection.className = "ftl-selection-box selection-box-" + car.id;
        bottomRightSelection.style = "right: 0; bottom: 0; border-width: 0px 1px 1px 0px";
        
        btn.onclick = function() {
            onSelectedTrainCarChanged(train.GetTrainCar(car.id));
        };

        return btn;
    }

    createContainer(container) {
        const ShippingTypeInv = InvertEnum(ShippingType);

        var img = document.createElement("img");
        img.src = (ShippingTypeInv[container.Type] !== ShippingTypeInv.PackagedItem || container.isMPF ? "./img/containers/" : "") + container.Image;
        img.className = "ftl-icon ftl-shippable-icon";
        img.style = "margin-top: -10px; height: 60px; position: absolute";

        img["data-bs-toggle"] = "tooltip";
        img["data-bs-placement"] = "top";

        img.title = container.DisplayName;

        console.log('[TrainsFactory] Created ' + container.Type + ": ", container);

        return img;
    }

    addContainerToFlatcar(flatcar, container) {
        const containerElement = this.createContainer(container);
        containerElement.id = flatcar.id+"-container";
        flatcar.element.appendChild(containerElement);

    }

    destroyTrainCar(car) {
        this.trainContainer.removeChild(car.element);
    }
}

const trainsFactory = new TrainsFactory();
