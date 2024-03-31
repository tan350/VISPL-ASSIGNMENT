//Memory Functions
function mc() {
    memoryValue = '';
    document.getElementById('memoryBlock').style.textAlign = "left";
    document.getElementById('memoryBlock').innerText = "There's nothing saved in your memory."
    document.getElementById('mc').disabled = true;
    document.getElementById('mr').disabled = true;
}

function mr() {
    displayValue2 = memoryValue;
    if (notation) {
        document.getElementById('display2').innerText = ConvertToScientificNotation(displayValue2);
    }
    else {
        document.getElementById('display2').innerText = displayValue2;
    }

}

function mPlus() {
    let tempMemory = parseFloat(memoryValue);
    if (isNaN(tempMemory)) {
        memoryValue = document.getElementById('display2').innerText;
    }
    else {
        memoryValue = tempMemory + (parseFloat(document.getElementById('display2').innerText))
    }
    document.getElementById('memoryBlock').style.textAlign = "right";
    document.getElementById('memoryBlock').innerText = memoryValue;
    document.getElementById('mc').disabled = false;
    document.getElementById('mr').disabled = false;
}

function mMinus() {
    let tempMemory = parseFloat(memoryValue);
    if (isNaN(tempMemory)) {
        memoryValue = document.getElementById('display2').innerText;
    }
    else {
        memoryValue = tempMemory - (parseFloat(document.getElementById('display2').innerText))
    }
    document.getElementById('memoryBlock').style.textAlign = "right";
    document.getElementById('memoryBlock').innerText = memoryValue;
    document.getElementById('mc').disabled = false;
    document.getElementById('mr').disabled = false;
}

function ms() {
    memoryValue = document.getElementById('display2').innerText;
    document.getElementById('memoryBlock').style.textAlign = "right";
    document.getElementById('memoryBlock').innerText = memoryValue;
    document.getElementById('mc').disabled = false;
    document.getElementById('mr').disabled = false;
}