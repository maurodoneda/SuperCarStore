
var carArray = ["1", "2", "3"];

console.log(carArray);

async function readTextFile() {

    let response = await fetch("Content/carList/carList.txt");
    let data = await response.text();

    carArray.push(data.split("\n"));

}

readTextFile();

let carArray2 = carArray.map(item => `888888888  ${item} 8888888888`);

console.log(carArray);
console.log(carArray2);


let carMake = [];
let carModel = [];
for (var i = 0; i < carArray.length; i++) {
    var make = carArray[i].split(" ");
    carMake.push(make[0]);
    var model = carArray[i].shift();
    carModel.push(model);
}

console.log(carMake);
console.log(carModel);