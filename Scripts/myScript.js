
document.addEventListener("DOMContentLoaded", EquilizeTexAndImgSize());

function EquilizeTexAndImgSize() {


    let carTitleSize = 101;
    let card = document.getElementsByClassName('cardContainer');
    let imgElem = document.getElementsByClassName('cardImg');
    let textElem = document.getElementsByClassName('description');
    let imgHeightArray = [];

    for (var i = 0; i < card.length; i++) {

        imgHeightArray[i] = imgElem[i].offsetHeight;
        textElem[i].style.height = imgHeightArray[i] - carTitleSize + "px";

    }

}




//$('.dateselect').datepicker({
//    format: 'mm/dd/yyyy',
//    // startDate: '-3d'
//});