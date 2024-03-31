function AngleConverter(angle, status) {
    if (status === "DEG") {
        if (angle >= 360) {
            angle %= 360;
        }
        angle = (angle * Math.PI) / 180;
    } else if (status === "GRAD") {
        if (angle >= 400) {
            angle %= 400;
        }
        angle = (angle * Math.PI) / 200;
    } else {
        if (angle >= (2 * Math.PI)) {
            angle %= (2 * Math.PI);
        }
    }
    return angle;
}

function ValueChanger(angle, status) {
    if (status === "DEG") {
        angle *= 180 / Math.PI;
    } else if (status === "GRAD") {
        angle *= 200 / Math.PI;
    }
    return angle;
}

// Trigonometric Function
function Sine(angle, Status) {
    angle = AngleConverter(angle, Status);
    return Math.sin(angle);
}

function Cosine(angle, Status) {
    angle = AngleConverter(angle, Status);
    return Math.cos(angle);
}

function Tangent(angle, Status) {
    angle = AngleConverter(angle, Status);
    let tempValue = Math.tan(angle);
    if (tempValue > -58.0 && tempValue < 58.0) {
        return tempValue;
    } else {
        return NaN;
    }
}

function Cot(angle, Status) {
    let tempValue = Tangent(angle, Status);
    if (isNaN(tempValue)) {
        return 0;
    }
    return 1 / tempValue;
}

function Sec(angle, Status) {
    return 1 / Cosine(angle, Status);
}

function Cosec(angle, Status) {
    return 1 / Sine(angle, Status);
}

// Inverse Trigonometric Function
function SineInverse(angle, Status) {
    let temp = Math.asin(angle);
    return ValueChanger(temp, Status);
}

function CosineInverse(angle, Status) {
    let temp = Math.acos(angle);
    return ValueChanger(temp, Status);
}

function TangentInverse(angle, Status) {
    let temp = Math.atan(angle);
    return ValueChanger(temp, Status);
}

function CotInverse(angle, Status) {
    return TangentInverse(1 / angle, Status);
}

function SecInverse(angle, Status) {
    return CosineInverse(1 / angle, Status);
}

function CosecInverse(angle, Status) {
    return SineInverse(1 / angle, Status);
}

// Hyperbolic Function
function SineHyp(angle) {
    return Math.sinh(angle);
}

function CosineHyp(angle) {
    return Math.cosh(angle);
}

function TangentHyp(angle) {
    return Math.tanh(angle);
}

function CotHyp(angle) {
    return 1 / TangentHyp(angle);
}

function SecHyp(angle) {
    return 1 / CosineHyp(angle);
}

function CosecHyp(angle) {
    return 1 / SineHyp(angle);
}

// Inverse Hyperbolic Function
function SineHypInverse(angle) {
    return Math.asinh(angle);
}

function CosineHypInverse(angle) {
    return Math.acosh(angle);
}

function TangentHypInverse(angle) {
    return Math.atanh(angle);
}

function CotHypInverse(angle) {
    return 1 / TangentHypInverse(angle);
}

function SecHypInverse(angle) {
    return CosineHypInverse(1 / angle);
}

function CosecHypInverse(angle) {
    return SineHypInverse(1 / angle);
}



//Display Trigno functions
function sinFunction() {
    if (document.getElementById('sin').innerText == 'sin') {
        let status = document.getElementById('angleButton').innerText;
        displayValue2 = document.getElementById('display2').innerText;
        let symbol = '';
        formating();
        if (status == 'DEG') {
            symbol = 'sin₀'
        }
        else if (status == 'RAD') {
            symbol = 'sinᵣ'
        }
        else {
            symbol = 'sin₉'
        }
        displayValue1 += symbol + '(' + subFunction + ')';
        let tempValue = Sine(parseFloat(displayValue2), status);
        displayValue2 = tempValue;
        subFunction = symbol + '(' + subFunction + ')';
        document.getElementById('display2').innerText = displayValue2;
        document.getElementById('display1').innerText = displayValue1;
    }
    else if (document.getElementById('sin').innerHTML == 'sin<sup>-1</sup>') {
        let status = document.getElementById('angleButton').innerText;
        displayValue2 = document.getElementById('display2').innerText;
        let symbol = '';
        formating();
        if (status == 'DEG') {
            symbol = 'sin₀⁻¹'
        }
        else if (status == 'RAD') {
            symbol = 'sinᵣ⁻¹'
        }
        else {
            symbol = 'sin₉⁻¹'
        }
        displayValue1 += symbol + '(' + subFunction + ')';
        let tempValue = SineInverse(parseFloat(displayValue2), status);
        displayValue2 = tempValue;
        subFunction = symbol + '(' + subFunction + ')';
        document.getElementById('display2').innerText = displayValue2;
        document.getElementById('display1').innerText = displayValue1;
    }
    else if (document.getElementById('sin').innerText == 'sinh') {
        displayValue2 = document.getElementById('display2').innerText;
        let symbol = 'sinh';
        formating();
        displayValue1 += symbol + '(' + subFunction + ')';
        let tempValue = SineHyp(parseFloat(displayValue2));
        displayValue2 = tempValue;
        subFunction = symbol + '(' + subFunction + ')';
        document.getElementById('display2').innerText = displayValue2;
        document.getElementById('display1').innerText = displayValue1;
    }
    else if (document.getElementById('sin').innerHTML == 'sinh<sup>-1</sup>') {
        displayValue2 = document.getElementById('display2').innerText;
        let symbol = 'sinh⁻¹';
        formating();
        displayValue1 += symbol + '(' + subFunction + ')';
        let tempValue = SineHypInverse(parseFloat(displayValue2));
        displayValue2 = tempValue;
        subFunction = symbol + '(' + subFunction + ')';
        document.getElementById('display2').innerText = displayValue2;
        document.getElementById('display1').innerText = displayValue1;
    }
}
function cosFunction() {
    if (document.getElementById('cos').innerText == 'cos') {
        let status = document.getElementById('angleButton').innerText;
        displayValue2 = document.getElementById('display2').innerText;
        let symbol = '';
        formating();
        if (status == 'DEG') {
            symbol = 'cos₀'
        }
        else if (status == 'RAD') {
            symbol = 'cosᵣ'
        }
        else {
            symbol = 'cos₉'
        }
        displayValue1 += symbol + '(' + subFunction + ')';
        let tempValue = Cosine(parseFloat(displayValue2), status);
        displayValue2 = tempValue;
        subFunction = symbol + '(' + subFunction + ')';
        document.getElementById('display2').innerText = displayValue2;
        document.getElementById('display1').innerText = displayValue1;
    }
    else if (document.getElementById('cos').innerHTML == 'cos<sup>-1</sup>') {
        let status = document.getElementById('angleButton').innerText;
        displayValue2 = document.getElementById('display2').innerText;
        let symbol = '';
        formating();
        if (status == 'DEG') {
            symbol = 'cos₀⁻¹'
        }
        else if (status == 'RAD') {
            symbol = 'cosᵣ⁻¹'
        }
        else {
            symbol = 'cos₉⁻¹'
        }
        displayValue1 += symbol + '(' + subFunction + ')';
        let tempValue = CosineInverse(parseFloat(displayValue2), status);
        displayValue2 = tempValue;
        subFunction = symbol + '(' + subFunction + ')';
        document.getElementById('display2').innerText = displayValue2;
        document.getElementById('display1').innerText = displayValue1;
    }
    else if (document.getElementById('cos').innerText == 'cosh') {
        displayValue2 = document.getElementById('display2').innerText;
        let symbol = 'cosh';
        formating();
        displayValue1 += symbol + '(' + subFunction + ')';
        let tempValue = CosineHyp(parseFloat(displayValue2));
        displayValue2 = tempValue;
        subFunction = symbol + '(' + subFunction + ')';
        document.getElementById('display2').innerText = displayValue2;
        document.getElementById('display1').innerText = displayValue1;
    }
    else if (document.getElementById('cos').innerHTML == 'cosh<sup>-1</sup>') {
        displayValue2 = document.getElementById('display2').innerText;
        let symbol = 'cosh⁻¹';
        formating();
        displayValue1 += symbol + '(' + subFunction + ')';
        let tempValue = CosineHypInverse(parseFloat(displayValue2));
        displayValue2 = tempValue;
        subFunction = symbol + '(' + subFunction + ')';
        document.getElementById('display2').innerText = displayValue2;
        document.getElementById('display1').innerText = displayValue1;
    }
}
function tanFunction() {
    if (document.getElementById('tan').innerText == 'tan') {
        let status = document.getElementById('angleButton').innerText;
        displayValue2 = document.getElementById('display2').innerText;
        let symbol = '';
        formating();
        if (status == 'DEG') {
            symbol = 'tan₀'
        }
        else if (status == 'RAD') {
            symbol = 'tanᵣ'
        }
        else {
            symbol = 'tan₉'
        }
        displayValue1 += symbol + '(' + subFunction + ')';
        let tempValue = Tangent(parseFloat(displayValue2), status);
        displayValue2 = tempValue;
        subFunction = symbol + '(' + subFunction + ')';
        document.getElementById('display2').innerText = displayValue2;
        document.getElementById('display1').innerText = displayValue1;
    }
    else if (document.getElementById('tan').innerHTML == 'tan<sup>-1</sup>') {
        let status = document.getElementById('angleButton').innerText;
        displayValue2 = document.getElementById('display2').innerText;
        let symbol = '';
        formating();
        if (status == 'DEG') {
            symbol = 'tan₀⁻¹'
        }
        else if (status == 'RAD') {
            symbol = 'tanᵣ⁻¹'
        }
        else {
            symbol = 'tan₉⁻¹'
        }
        displayValue1 += symbol + '(' + subFunction + ')';
        let tempValue = TangentInverse(parseFloat(displayValue2), status);
        displayValue2 = tempValue;
        subFunction = symbol + '(' + subFunction + ')';
        document.getElementById('display2').innerText = displayValue2;
        document.getElementById('display1').innerText = displayValue1;
    }
    else if (document.getElementById('tan').innerText == 'tanh') {
        displayValue2 = document.getElementById('display2').innerText;
        let symbol = 'tanh';
        formating();
        displayValue1 += symbol + '(' + subFunction + ')';
        let tempValue = TangentHyp(parseFloat(displayValue2));
        displayValue2 = tempValue;
        subFunction = symbol + '(' + subFunction + ')';
        document.getElementById('display2').innerText = displayValue2;
        document.getElementById('display1').innerText = displayValue1;
    }
    else if (document.getElementById('tan').innerHTML == 'tanh<sup>-1</sup>') {
        displayValue2 = document.getElementById('display2').innerText;
        let symbol = 'tanh';
        formating();
        displayValue1 += symbol + '(' + subFunction + ')';
        let tempValue = TangentHypInverse(parseFloat(displayValue2));
        displayValue2 = tempValue;
        subFunction = symbol + '(' + subFunction + ')';
        document.getElementById('display2').innerText = displayValue2;
        document.getElementById('display1').innerText = displayValue1;
    }

}
function cotFunction() {
    if (document.getElementById('cot').innerText == 'cot') {
        let status = document.getElementById('angleButton').innerText;
        displayValue2 = document.getElementById('display2').innerText;
        let symbol = '';
        formating();
        if (status == 'DEG') {
            symbol = 'cot₀'
        }
        else if (status == 'RAD') {
            symbol = 'cotᵣ'
        }
        else {
            symbol = 'cot₉'
        }
        displayValue1 += symbol + '(' + subFunction + ')';
        let tempValue = Cot(parseFloat(displayValue2), status);
        displayValue2 = tempValue;
        subFunction = symbol + '(' + subFunction + ')';
        document.getElementById('display2').innerText = displayValue2;
        document.getElementById('display1').innerText = displayValue1;
    }
    if (document.getElementById('cot').innerHTML == 'cot<sup>-1</sup>') {
        let status = document.getElementById('angleButton').innerText;
        displayValue2 = document.getElementById('display2').innerText;
        let symbol = '';
        formating();
        if (status == 'DEG') {
            symbol = 'cot₀⁻¹'
        }
        else if (status == 'RAD') {
            symbol = 'cotᵣ⁻¹'
        }
        else {
            symbol = 'cot₉⁻¹'
        }
        displayValue1 += symbol + '(' + subFunction + ')';
        let tempValue = CotInverse(parseFloat(displayValue2), status);
        displayValue2 = tempValue;
        subFunction = symbol + '(' + subFunction + ')';
        document.getElementById('display2').innerText = displayValue2;
        document.getElementById('display1').innerText = displayValue1;
    }
    else if (document.getElementById('cot').innerText == 'coth') {
        displayValue2 = document.getElementById('display2').innerText;
        let symbol = 'coth';
        displayValue1 += symbol + '(' + subFunction + ')';
        let tempValue = CotHyp(parseFloat(displayValue2));
        displayValue2 = tempValue;
        subFunction = symbol + '(' + subFunction + ')';
        document.getElementById('display2').innerText = displayValue2;
        document.getElementById('display1').innerText = displayValue1;
    }
    if (document.getElementById('cot').innerHTML == 'coth<sup>-1</sup>') {
        displayValue2 = document.getElementById('display2').innerText;
        let symbol = 'coth⁻¹';
        formating();
        displayValue1 += symbol + '(' + subFunction + ')';
        let tempValue = CotHypInverse(parseFloat(displayValue2), status);
        displayValue2 = tempValue;
        subFunction = symbol + '(' + subFunction + ')';
        document.getElementById('display2').innerText = displayValue2;
        document.getElementById('display1').innerText = displayValue1;
    }
}
function secFunction() {
    if (document.getElementById('sec').innerText == 'sec') {
        let status = document.getElementById('angleButton').innerText;
        displayValue2 = document.getElementById('display2').innerText;
        let symbol = '';
        formating();
        if (status == 'DEG') {
            symbol = 'sec₀'
        }
        else if (status == 'RAD') {
            symbol = 'secᵣ'
        }
        else {
            symbol = 'sec₉'
        }
        displayValue1 += symbol + '(' + subFunction + ')';
        let tempValue = Sec(parseFloat(displayValue2), status);
        displayValue2 = tempValue;
        subFunction = symbol + '(' + subFunction + ')';
        document.getElementById('display2').innerText = displayValue2;
        document.getElementById('display1').innerText = displayValue1;
    }
    else if (document.getElementById('sec').innerHTML == 'sec<sup>-1</sup>') {
        let status = document.getElementById('angleButton').innerText;
        displayValue2 = document.getElementById('display2').innerText;
        let symbol = '';
        formating();
        if (status == 'DEG') {
            symbol = 'sec₀⁻¹'
        }
        else if (status == 'RAD') {
            symbol = 'secᵣ⁻¹'
        }
        else {
            symbol = 'sec₉⁻¹'
        }
        displayValue1 += symbol + '(' + subFunction + ')';
        let tempValue = SecInverse(parseFloat(displayValue2), status);
        displayValue2 = tempValue;
        subFunction = symbol + '(' + subFunction + ')';
        document.getElementById('display2').innerText = displayValue2;
        document.getElementById('display1').innerText = displayValue1;
    }
    else if (document.getElementById('sec').innerText == 'sech') {
        displayValue2 = document.getElementById('display2').innerText;
        let symbol = 'sech';
        formating();
        displayValue1 += symbol + '(' + subFunction + ')';
        let tempValue = SecHyp(parseFloat(displayValue2));
        displayValue2 = tempValue;
        subFunction = symbol + '(' + subFunction + ')';
        document.getElementById('display2').innerText = displayValue2;
        document.getElementById('display1').innerText = displayValue1;
    }
    else if (document.getElementById('sec').innerHTML == 'sech<sup>-1</sup>') {
        displayValue2 = document.getElementById('display2').innerText;
        let symbol = 'sech⁻¹';
        formating();
        displayValue1 += symbol + '(' + subFunction + ')';
        let tempValue = SecHypInverse(parseFloat(displayValue2));
        displayValue2 = tempValue;
        subFunction = symbol + '(' + subFunction + ')';
        document.getElementById('display2').innerText = displayValue2;
        document.getElementById('display1').innerText = displayValue1;
    }
}
function cscFunction() {
    if (document.getElementById('csc').innerText == 'csc') {
        let status = document.getElementById('angleButton').innerText;
        displayValue2 = document.getElementById('display2').innerText;
        let symbol = '';
        formating();
        if (status == 'DEG') {
            symbol = 'csc₀'
        }
        else if (status == 'RAD') {
            symbol = 'cscᵣ'
        }
        else {
            symbol = 'csc₉'
        }
        displayValue1 += symbol + '(' + subFunction + ')';
        let tempValue = Cosec(parseFloat(displayValue2), status);
        displayValue2 = tempValue;
        subFunction = symbol + '(' + subFunction + ')';
        document.getElementById('display2').innerText = displayValue2;
        document.getElementById('display1').innerText = displayValue1;
    }
    else if (document.getElementById('csc').innerHTML == 'csc<sup>-1</sup>') {
        let status = document.getElementById('angleButton').innerText;
        displayValue2 = document.getElementById('display2').innerText;
        let symbol = '';
        formating();
        if (status == 'DEG') {
            symbol = 'csc₀⁻¹'
        }
        else if (status == 'RAD') {
            symbol = 'cscᵣ⁻¹'
        }
        else {
            symbol = 'csc₉⁻¹'
        }
        displayValue1 += symbol + '(' + subFunction + ')';
        let tempValue = CosecInverse(parseFloat(displayValue2), status);
        displayValue2 = tempValue;
        subFunction = symbol + '(' + subFunction + ')';
        document.getElementById('display2').innerText = displayValue2;
        document.getElementById('display1').innerText = displayValue1;
    }
    else if (document.getElementById('csc').innerText == 'csch') {
        displayValue2 = document.getElementById('display2').innerText;
        let symbol = 'csch';
        formating();
        displayValue1 += symbol + '(' + subFunction + ')';
        let tempValue = CosecHyp(parseFloat(displayValue2));
        displayValue2 = tempValue;
        subFunction = symbol + '(' + subFunction + ')';
        document.getElementById('display2').innerText = displayValue2;
        document.getElementById('display1').innerText = displayValue1;
    }
    else if (document.getElementById('csc').innerHTML == 'csch<sup>-1</sup>') {
        displayValue2 = document.getElementById('display2').innerText;
        let symbol = 'csch⁻¹';
        displayValue1 += symbol + '(' + subFunction + ')';
        let tempValue = CosecHypInverse(parseFloat(displayValue2));
        displayValue2 = tempValue;
        subFunction = symbol + '(' + subFunction + ')';
        document.getElementById('display2').innerText = displayValue2;
        document.getElementById('display1').innerText = displayValue1;
    }


}
