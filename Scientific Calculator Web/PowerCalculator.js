// Power Functions
function piValue() {
    functionClicked = true;
    displayValue2 = Math.PI;
    document.getElementById('display2').innerText = displayValue2;
    document.getElementById('display1').innerText = displayValue1;
}
function eValue() {
    functionClicked = true;
    displayValue2 = Math.E;
    document.getElementById('display2').innerText = displayValue2;
    document.getElementById('display1').innerText = displayValue1;
}
function log_base_10() {
    if (document.getElementById('ln').innerText == 'ln') {
    displayValue2 = document.getElementById('display2').innerText;
    formating();
    displayValue1 += 'log(' + subFunction + ')';
    let tempValue = Math.log10(displayValue2);
    displayValue2 = tempValue;
    subFunction = 'log(' + subFunction + ')';
    document.getElementById('display2').innerText = displayValue2;
    document.getElementById('display1').innerText = displayValue1;
    }
    else{
        logXbaseYBoolean = true;
        appendToDisplay('log base');
    }
}
function natural_log() {
    if (document.getElementById('ln').innerText == 'ln') {
        displayValue2 = document.getElementById('display2').innerText;
        formating();
        displayValue1 += 'ln(' + subFunction + ')';
        let tempValue = Math.log(displayValue2);
        displayValue2 = tempValue;
        subFunction = 'ln(' + subFunction + ')';
        document.getElementById('display2').innerText = displayValue2;
        document.getElementById('display1').innerText = displayValue1;
    }
    else {
        displayValue2 = document.getElementById('display2').innerText;
        formating();
        displayValue1 += 'e^(' + subFunction + ')';
        let tempValue = Math.exp(displayValue2);
        displayValue2 = tempValue;
        subFunction = 'e^(' + subFunction + ')';
        document.getElementById('display2').innerText = displayValue2;
        document.getElementById('display1').innerText = displayValue1;
    }

}
function squareroot() {
    if (document.getElementById('underrootX').innerHTML == '<sup>2</sup>√x') {
        displayValue2 = document.getElementById('display2').innerText;
        let tempnumber = parseFloat(displayValue2)
        formating();
        try {
            displayValue1 += '√(' + subFunction + ')';
            document.getElementById('display1').innerText = displayValue1;
            if (tempnumber < 0) {
                throw new Error("Invalid input");
            }
            let tempValue = Math.sqrt(tempnumber);
            displayValue2 = tempValue
            subFunction = '√(' + subFunction + ')';
            document.getElementById('display2').innerText = displayValue2;

        }
        catch {
            displayValue1 = '';
            displayValue2 = '';
            EvaulatedValue = '';
            document.getElementById('display2').innerText = 'Invalid Input';
            DisableAllButtons();
        }
    }
    else {

        displayValue2 = document.getElementById('display2').innerText;
        let tempnumber = parseFloat(displayValue2)
        formating();
        displayValue1 += 'cuberoot(' + subFunction + ')';
        let tempValue = Math.cbrt(tempnumber);
        displayValue2 = tempValue
        subFunction = 'cuberoot(' + subFunction + ')';
        document.getElementById('display2').innerText = displayValue2;
        document.getElementById('display1').innerText = displayValue1;
    }
}
function sqaure() {
    if (document.getElementById('XSquare').innerHTML == "x<sup>2</sup>") {
        displayValue2 = document.getElementById('display2').innerText;
        formating();
        displayValue1 += 'sqr(' + subFunction + ')';
        let tempValue = Math.pow(displayValue2, 2);
        displayValue2 = tempValue;
        subFunction = 'sqr(' + subFunction + ')';
        document.getElementById('display2').innerText = displayValue2;
        document.getElementById('display1').innerText = displayValue1;
    }
    else {
        displayValue2 = document.getElementById('display2').innerText;
        formating();
        displayValue1 += 'cube(' + subFunction + ')';
        let tempValue = Math.pow(displayValue2, 3);
        displayValue2 = tempValue;
        subFunction = 'cube(' + subFunction + ')';
        document.getElementById('display2').innerText = displayValue2;
        document.getElementById('display1').innerText = displayValue1;
    }
}
function inverse() {
    displayValue2 = document.getElementById('display2').innerText;
    formating();
    displayValue1 += '1/(' + subFunction + ')';
    document.getElementById('display1').innerText = displayValue1;
    let tempValue = 1 / displayValue2;;
    displayValue2 = tempValue;
    subFunction = '1/(' + subFunction + ')';
    document.getElementById('display2').innerText = displayValue2;
}
function abs() {
    displayValue2 = document.getElementById('display2').innerText;
    formating();
    displayValue1 += 'abs(' + subFunction + ')';
    let tempValue = Math.abs(displayValue2);
    displayValue2 = tempValue;
    subFunction = 'abs(' + subFunction + ')';
    document.getElementById('display2').innerText = displayValue2;
    document.getElementById('display1').innerText = displayValue1;
}
function leftBracket() {
    leftBracketCount++;
    document.getElementById('leftBracket').innerHTML = `(<sub>${leftBracketCount}</sub>`;
    if (EvaulatedValue.length == 0) {
        EvaulatedValue = '(';
        displayValue1 = '('
    }
    else {
        EvaulatedValue += '(';
        displayValue1 += '('
    }
    document.getElementById('display1').innerText = displayValue1;
}
function rightBracket() {
    if (rightBracketCount < leftBracketCount) {
        rightBracketCount++;

        if (leftBracketCount - rightBracketCount == 0) {
            rightBracketCount = 0;
            leftBracketCount = 0;
            document.getElementById('leftBracket').innerHTML = `(`;

            let lastOp = EvaulatedValue[EvaulatedValue.length - 1]
            if (lastOp >= '0' && lastOp <= '9' || lastOp == ')') {
                EvaulatedValue += ')';
                displayValue1 += ')'
            }
            else {
                displayValue1 += document.getElementById('display2').innerText;
                EvaulatedValue += document.getElementById('display2').innerText;
                EvaulatedValue += ')';
                displayValue1 += ')'
            }
        }
        else if (leftBracketCount >= 0) {
            document.getElementById('leftBracket').innerHTML = `(<sub>${leftBracketCount - rightBracketCount}</sub>`;
            let lastOp = EvaulatedValue[EvaulatedValue.length - 1]
            if (lastOp >= '0' && lastOp <= '9' || lastOp == ')') {
                displayValue1
                EvaulatedValue += ')';
                displayValue1 += ')'
            }
            else {
                displayValue1 += document.getElementById('display2').innerText;
                EvaulatedValue += document.getElementById('display2').innerText;
                EvaulatedValue += ')';
                displayValue1 += ')'
            }
        }
        document.getElementById('display1').innerText = displayValue1;

    }
}
function xtoThePowerY() {
    if (document.getElementById('xPower').innerHTML == "x<sup>y</sup>") {
        appendToDisplay('^');
    }
    else {
        xtoThePowerYBoolean = true;
        appendToDisplay('^');
    }
}
function negate() {
    displayValue2 = document.getElementById('display2').innerText;
    formating();
    displayValue1 += 'negate(' + subFunction + ')';
    if (parseFloat(displayValue2)) {
        if (displayValue2 <= 0) {
            displayValue2 = Math.abs(displayValue2)
        }
        else {
            displayValue2 = 0 - displayValue2;
        }
    }
    subFunction = 'negate(' + subFunction + ')';
    document.getElementById('display2').innerText = displayValue2;
    document.getElementById('display1').innerText = displayValue1;

}
function formating() {
    pressedFunctionKey = true;
    if (functionAppliedFirst == 0) {
        subFunction = displayValue2;
        subFunctionIndex = displayValue1.length;
    }
    if (displayValue1.length - subFunction.length >= 0 && functionAppliedFirst != 0) {
        displayValue1 = displayValue1.slice(0, displayValue1.length - subFunction.length);
    }
    functionAppliedFirst++;
}
function Factorial() {
    displayValue2 = document.getElementById('display2').innerText;
    let tempnumber = parseFloat(displayValue2)
    let tempnumber2 = parseInt(displayValue2)
    formating();
    try {
        displayValue1 += 'fact(' + subFunction + ')';
        if (tempnumber < 0) {
            throw new Error("Invalid input");
        }
        let tempValue = GammaFunction(tempnumber + 1);
        if (tempnumber == tempnumber2) {
            displayValue2 = Math.round(tempValue)
        }
        else {
            displayValue2 = tempValue
        }
        subFunction = 'fact(' + subFunction + ')';
        document.getElementById('display2').innerText = displayValue2;
        document.getElementById('display1').innerText = displayValue1;
    }
    catch {
        displayValue1 = '';
        displayValue2 = '';
        EvaulatedValue = '';
        document.getElementById('display2').innerText = 'Invalid Input';
        DisableAllButtons();
    }
}
function rand() {
    displayValue2 = Math.random();
    document.getElementById('display2').innerText = displayValue2;
}
function floor() {
    displayValue2 = document.getElementById('display2').innerText;
    formating();
    displayValue1 += 'floor(' + subFunction + ')';
    let tempValue = Math.floor(displayValue2);
    displayValue2 = tempValue;
    subFunction = 'floor(' + subFunction + ')';
    document.getElementById('display2').innerText = displayValue2;
    document.getElementById('display1').innerText = displayValue1;
}
function ceiling() {
    displayValue2 = document.getElementById('display2').innerText;
    formating();
    displayValue1 += 'ceil(' + subFunction + ')';
    let tempValue = Math.ceil(displayValue2);
    displayValue2 = tempValue;
    subFunction = 'ceil(' + subFunction + ')';
    document.getElementById('display2').innerText = displayValue2;
    document.getElementById('display1').innerText = displayValue1;
}
function tensPower() {
    if (document.getElementById('tenPower').innerHTML == "10<sup>x</sup>") {
        displayValue2 = document.getElementById('display2').innerText;
        formating();
        displayValue1 += '10^(' + subFunction + ')';
        let tempValue = Math.pow(10, parseFloat(displayValue2));
        displayValue2 = tempValue;
        subFunction = '10^(' + subFunction + ')';
        document.getElementById('display2').innerText = displayValue2;
        document.getElementById('display1').innerText = displayValue1;
    }
    else {
        displayValue2 = document.getElementById('display2').innerText;
        formating();
        displayValue1 += '2^(' + subFunction + ')';
        let tempValue = Math.pow(2, parseFloat(displayValue2));
        displayValue2 = tempValue;
        subFunction = '2^(' + subFunction + ')';
        document.getElementById('display2').innerText = displayValue2;
        document.getElementById('display1').innerText = displayValue1;
    }
}
function dms() {
    displayValue2 = document.getElementById('display2').innerText;
    formating();
    displayValue1 += 'dms(' + subFunction + ')';
    let tempValue = ConvertToDMS(displayValue2);
    displayValue2 = tempValue;
    subFunction = 'dms(' + subFunction + ')';
    document.getElementById('display2').innerText = displayValue2;
    document.getElementById('display1').innerText = displayValue1;
}
function deg() {
    displayValue2 = document.getElementById('display2').innerText;
    formating();
    displayValue1 += 'degrees(' + subFunction + ')';
    let tempValue = DMSToDegree(displayValue2);
    displayValue2 = tempValue;
    subFunction = 'degrees(' + subFunction + ')';
    document.getElementById('display2').innerText = displayValue2;
    document.getElementById('display1').innerText = displayValue1;
}

function exp(){
    document.getElementById('display2').innerText = formatToScientificNotation(parseFloat(document.getElementById('display2').innerText));     
}

function ConvertToDMS(angle1) {
    let degrees = Math.floor(angle1);
    let minutes = (angle1 - degrees) * 60;
    let minutesInt = Math.floor(minutes);
    let seconds = (minutes - minutesInt) * 60;
    let result = degrees + minutesInt / 100.0 + seconds / 10000.0;
    return result;
}

function DMSToDegree(angle1) {
    let degrees = Math.floor(angle1);
    let minutes = (angle1 - degrees);
    let result = degrees + (minutes / 60);
    return result;
}

function ConvertToScientificNotation(number) {
    return number.toExponential();
}

function formatToScientificNotation(number) {
    const formattedCoefficient = parseFloat(number).toLocaleString('en-US', {maximumFractionDigits: 20});
    return `${formattedCoefficient}.e+0`;
}

function GammaFunction(z) {
    if (z < 0.5) {
        return Math.PI / (Math.sin(Math.PI * z) * GammaFunction(1 - z));
    }
    z -= 1;
    let x = p[0];
    for (let i = 1; i < g + 2; i++) {
        x += p[i] / (z + i);
    }
    let t = z + g + 0.5;
    return Math.sqrt(2 * Math.PI) * Math.pow(t, z + 0.5) * Math.exp(-t) * x;
}
