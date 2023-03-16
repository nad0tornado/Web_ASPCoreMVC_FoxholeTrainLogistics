// Train Creation Factory
function createTrainCar(trainCarType) {
    const trainContainer = document.getElementById("train-container");

    if (trainContainer === null)
        throw new DOMException("Unable to locate trainContainer - was this script ran before the trainContainer was created?");

    const btn = trainContainer.appendChild(document.createElement("button"));
    btn.className = "ftl-interact ftl-button";
    btn.onclick = () => trainContainer.removeChild(btn);

    console.log('adding ' + trainCarType);

    var img = undefined;
    switch (trainCarType) {
        case "Engine": {
            img = btn.appendChild(document.createElement("img"));
            img.src = "./img/trainBlack_side.png";
            break;
        }
        case "CoalCar": {
            img = btn.appendChild(document.createElement("img"));
            img.src = "./img/coalCarBlack_side.png";
            break;
        }
        default:
            throw new DOMException("Invalid train car type \"" + trainCarType + "\"");
    }

    img.className = "ftl-icon";
}
function removeTrainCar(id) {
    const trainContainer = document.getElementById("train-container");

}