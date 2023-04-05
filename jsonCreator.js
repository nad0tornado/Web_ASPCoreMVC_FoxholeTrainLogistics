const fs = require("fs");

const template = {
  displayId: 1,
  faction: ["neutral", "colonial", "warden"],
  imgName: "BasicMaterials.png",
  itemName: "Basic Materials",
  itemDesc: "",
  itemCategory: "supplies",
  numberProduced: 100,
  isTeched: false,
  isMpfCraftable: false,
  craftLocation: ["factory", "mpf"],
  cost: {
    bmat: 250,
  },
};

const files = fs
  .readdirSync("./")
  .filter((f) => f !== "jsonCreator.js" && f !== "items.json");

const romanNumerals = {
  1: "I",
  2: "II",
  3: "III",
  4: "IV",
  5: "V",
};

const getDisplayNameFromFileName = (fileName) => {
  const fileNameWords = fileName
    .split(/(?=[A-Z|0-9])/g)
    .join(" ")
    .replace(/[0-9]/, (m) => romanNumerals[m])
    .replace(".png", "");
  console.log(fileNameWords);
  return fileNameWords;
};

const jsonArray = files.map((f) => ({
  ...template,
  imgName: f,
  itemName: getDisplayNameFromFileName(f),
}));

fs.writeFileSync("./items.json", JSON.stringify(jsonArray));
