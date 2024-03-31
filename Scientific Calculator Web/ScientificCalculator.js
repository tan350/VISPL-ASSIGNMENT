document.addEventListener("keydown", function (event) {
    if (event.key >= "0" && event.key <= "9") {
        var buttonNumber = parseInt(event.key);
        var button = document.getElementById("button" + buttonNumber);
        button.click();
        button.classList.add("active");
        setTimeout(function () {
            button.classList.remove("active");
        }, 100);

    }
    else if (event.key === "+") {
        document.getElementById("plus").click();

    }
    else if (event.key === "-") {
        document.getElementById("minus").click();

    }
    else if (event.key === "*") {
        document.getElementById("multiplication").click();

    }
    else if (event.key === "/") {
        document.getElementById("divide").click();

    }
    else if (event.key === ".") {
        document.getElementById("decimal").click();

    }
    else if (event.key === "Enter") {
        if (disableButtons) {
            EnableAllButtons();
        }
        event.preventDefault()
        document.getElementById("Enter").click();

    }
    else if (event.key === "Backspace") {

        let backspace = document.getElementById("backspace");
        backspace.click();
        backspace.classList.add("active");
        setTimeout(function () {
            backspace.classList.remove("active");
        }, 100);

    }
    else if (event.key === "Escape") {
        document.getElementById("clear").click();
    }
});
for (var i = 0; i <= 9; i++) {
    document.getElementById("button" + i).addEventListener("click", function () {
        appendToDisplay(this.textContent);
        if (disableButtons) {
            EnableAllButtons();
        }
    });
}
function trigoButtonsDropdown() {
    var moreTrigoButtons = document.getElementById('moreTrigo');
    if (moreTrigoButtons.style.display === 'none') {
        moreTrigoButtons.style.display = 'grid';
        moreTrignoFunctionFound = true;
    } else {
        moreTrigoButtons.style.display = 'none';
        moreTrignoFunctionFound = false;
    }
}
function functionButtonsDropdown() {
    let moreFunctionButtons = document.getElementById('moreFunctions');
    if (moreFunctionButtons.style.display === 'none') {
        moreFunctionButtons.style.display = 'grid';
    } else {
        moreFunctionButtons.style.display = 'none';
    }
}
function toggleNotation() {
    if (notation == false) {
        document.getElementById("notationButton").innerHTML = "<u>F-E</u>";
        document.getElementById('display2').innerText = ConvertToScientificNotation(parseFloat(document.getElementById('display2').innerText));
        notation = true;
    }
    else {
        document.getElementById("notationButton").innerText = "F-E";
        document.getElementById('display2').innerText = displayValue2;
        notation = false;
    }
}
function toggleAngleButton() {
    angleUnit = angleUnit + 1;
    switch (angleUnit) {
        case 1:
            document.getElementById("angleButton").innerText = "RAD";
            break;
        case 2:
            document.getElementById("angleButton").innerText = "GRAD";
            break;
        case 3:
            document.getElementById("angleButton").innerText = "DEG";
            angleUnit = 0;
            break;
    }
}
function secondbuttonInTrigoFunction() {
    if (_2ndBtnTrignoBoolean && hypBoolean) {
        document.getElementById('sin').innerHTML = "sin<sup>-1</sup>";
        document.getElementById('cos').innerHTML = "cos<sup>-1</sup>";
        document.getElementById('tan').innerHTML = "tan<sup>-1</sup>";
        document.getElementById('sec').innerHTML = "sec<sup>-1</sup>";
        document.getElementById('csc').innerHTML = "csc<sup>-1</sup>";
        document.getElementById('cot').innerHTML = "cot<sup>-1</sup>";
        _2ndBtnTrignoBoolean = false;
    }
    else if (_2ndBtnTrignoBoolean == false && hypBoolean) {
        document.getElementById('sin').innerHTML = "sin";
        document.getElementById('cos').innerHTML = "cos";
        document.getElementById('tan').innerHTML = "tan";
        document.getElementById('sec').innerHTML = "sec";
        document.getElementById('csc').innerHTML = "csc";
        document.getElementById('cot').innerHTML = "cot";
        _2ndBtnTrignoBoolean = true;
    }
    else if (hypBoolean == false && _2ndBtnTrignoBoolean) {
        document.getElementById('sin').innerHTML = "sinh<sup>-1</sup>";
        document.getElementById('cos').innerHTML = "cosh<sup>-1</sup>";
        document.getElementById('tan').innerHTML = "tanh<sup>-1</sup>";
        document.getElementById('sec').innerHTML = "sech<sup>-1</sup>";
        document.getElementById('csc').innerHTML = "csch<sup>-1</sup>";
        document.getElementById('cot').innerHTML = "coth<sup>-1</sup>";
        _2ndBtnTrignoBoolean = false;
    }
    else if (hypBoolean == false && _2ndBtnTrignoBoolean == false) {
        document.getElementById('sin').innerHTML = "sinh";
        document.getElementById('cos').innerHTML = "cosh";
        document.getElementById('tan').innerHTML = "tanh";
        document.getElementById('sec').innerHTML = "sech";
        document.getElementById('csc').innerHTML = "csch";
        document.getElementById('cot').innerHTML = "coth";
        _2ndBtnTrignoBoolean = true;
    }
}
function hyperBolicButtonInTrigoFunction() {
    if (hypBoolean) {
        document.getElementById('sin').innerHTML = "sinh";
        document.getElementById('cos').innerHTML = "cosh";
        document.getElementById('tan').innerHTML = "tanh";
        document.getElementById('sec').innerHTML = "sech";
        document.getElementById('csc').innerHTML = "csch";
        document.getElementById('cot').innerHTML = "coth";
        hypBoolean = false;
    }
    else {
        if (_2ndBtnTrignoBoolean = false) {
            document.getElementById('sin').innerHTML = "sin<sup>-1</sup>";
            document.getElementById('cos').innerHTML = "cos<sup>-1</sup>";
            document.getElementById('tan').innerHTML = "tan<sup>-1</sup>";
            document.getElementById('sec').innerHTML = "sec<sup>-1</sup>";
            document.getElementById('csc').innerHTML = "csc<sup>-1</sup>";
            document.getElementById('cot').innerHTML = "cot<sup>-1</sup>";
            _2ndBtnTrignoBoolean = true;
        }
        else {
            document.getElementById('sin').innerHTML = "sin";
            document.getElementById('cos').innerHTML = "cos";
            document.getElementById('tan').innerHTML = "tan";
            document.getElementById('sec').innerHTML = "sec";
            document.getElementById('csc').innerHTML = "csc";
            document.getElementById('cot').innerHTML = "cot";
            hypBoolean = true;
        }

    }

}
function secondButtonInMainScreen() {
    if (buttonClicked) {
        document.getElementById('XSquare').innerHTML = "x<sup>3</sup>";
        document.getElementById('underrootX').innerHTML = "<sup>3</sup><span>&#8730;</span>x";
        document.getElementById('xPower').innerHTML = "<sup>y</sup><span>&#8730;</span>x";
        document.getElementById('tenPower').innerHTML = "2<sup>x</sup>";
        document.getElementById('log').innerHTML = "log<sub>y</sub>x";
        document.getElementById('ln').innerHTML = "e<sup>x</sup>";
        buttonClicked = false;
    }
    else {
        document.getElementById('XSquare').innerHTML = "x<sup>2</sup>";
        document.getElementById('underrootX').innerHTML = "<sup>2</sup><span>&#8730;</span>x";
        document.getElementById('xPower').innerHTML = "x<sup>y</sup>";
        document.getElementById('tenPower').innerHTML = "10<sup>x</sup>";
        document.getElementById('log').innerHTML = "log";
        document.getElementById('ln').innerHTML = "ln";
        buttonClicked = true;
    }
}
function historyButtonClick() {
    let historyBlock = document.getElementById('historyBlock');
    let memoryBlock = document.getElementById('memoryBlock');
   
        if (historyBlock.style.display == 'none') {
            historyBlock.style.display = 'block';
            document.getElementById("history").classList.add('underline')
            memoryBlock.style.display = 'none';
        }
        else {
            historyBlock.style.display = 'none';
            document.getElementById("history").classList.remove('underline')

        }
    
}
function memoryButtonClick() {
    let memoryBlock = document.getElementById('memoryBlock');
    let historyBlock = document.getElementById('historyBlock');
    if (memoryBlock.style.display === 'none') {
        memoryBlock.style.display = 'block';
        historyBlock.style.display = 'none';
        document.getElementById("memory").classList.add('underline')

    } else {
        memoryBlock.style.display = 'none';
        document.getElementById("memory").classList.remove('underline')

    }
}
function DisableAllButtons() {
    const buttonIds = ['secondButton', 'pi', 'e', 'XSquare', 'oneByX', 'modX', 'exp', 'mod', 'underrootX', 'leftBracket', 'rightBracket', 'factorial', 'divide', 'xPower', 'multiplication', 'tenPower', 'minus', 'log', 'plus', 'ln', 'neogate', 'decimal', 'button_trigo', 'button_function'];
    for (let i = 0; i < buttonIds.length; i++) {
        const button = document.getElementById(buttonIds[i]);
        if (button) {
            button.disabled = true;
        }
    }
    disableButtons = true;
}
function EnableAllButtons() {
    const buttonIds = ['secondButton', 'pi', 'e', 'XSquare', 'oneByX', 'modX', 'exp', 'mod', 'underrootX', 'leftBracket', 'rightBracket', 'factorial', 'divide', 'xPower', 'multiplication', 'tenPower', 'minus', 'log', 'plus', 'ln', 'neogate', 'decimal', 'button_trigo', 'button_function'];

    for (let i = 0; i < buttonIds.length; i++) {
        const button = document.getElementById(buttonIds[i]);
        if (button) {
            button.disabled = false;
        }
    }
    document.getElementById('display1').innerText = '';
    document.getElementById('display2').innerText = '';
    displayValue1 = '';
    displayValue2 = '';
    EvaulatedValue = '';
    resetBooleans()
    disableButtons = false;
}
function resetBooleans() {
    operatorFound = false;
    buttonClicked = true;
    _2ndBtnTrignoBoolean = true;
    hypBoolean = true;
    functionAppliedFirst = 0;
    subFunction = '';
    subFunctionIndex = -1;
    pressedFunctionKey = false;
    decimalClickBoolean = false;
    functionClicked = false;
    leftBracketCount = 0;
    rightBracketCount = 0;
    xtoThePowerYBoolean = false;
    xtoThePowerYBooleanHelper = false;
}
function deleteHistoryButton() {
    document.getElementById('deleteHistoryButton').style.visibility = "hidden"
    var specificDiv = document.getElementById("historyBlock");

    var paragraphs = specificDiv.getElementsByTagName("p");

    for (var i = paragraphs.length - 1; i >= 0; i--) {
        paragraphs[i].parentNode.removeChild(paragraphs[i]);
    }
    var heading = specificDiv.getElementsByTagName("h2");

    for (var i = heading.length - 1; i >= 0; i--) {
        heading[i].parentNode.removeChild(heading[i]);
    }
    document.getElementById('historyBlockHeading').style.visibility = "visible"
    historyShow = false
}
function appendToDisplay(value) {
    if (value >= 0 && value <= 9 || value == '.') {
        if (functionClicked) {
            displayValue2 = value;
            functionClicked = false;
        }

        else if (decimalClickBoolean) {
            displayValue2 += value;
        }
        else {
            displayValue2 += value;
        }
        if (notation) {
            displayValue2 = ConvertToScientificNotation(parseFloat(displayValue2))
        }
        operatorFound = false;
        document.getElementById('display2').innerText = displayValue2;
    }
    else {
        if (value == '+' || value == '-' || value == '*' || value == '/' || value == '%' || value == '^' || value == 'log base') {
            functionClicked = false
            functionAppliedFirst = 0;
            decimalClickBoolean = false;
            if (isNaN(parseFloat(displayValue2))) {
                displayValue2 = '0'
            }
            if (xtoThePowerYBooleanHelper) {
                EvaulatedValue += displayValue2 + ')' + value;
                xtoThePowerYBooleanHelper = false;
                xtoThePowerYBoolean = false;
            }
            else {
                EvaulatedValue += displayValue2 + value;
            }
            if (logXbaseYBooleanHelper) {
                EvaulatedValue += displayValue2 + ')' + value;
                logXbaseYBooleanHelper = false;
                logXbaseYBoolean = false;
        
            }
            else {
                EvaulatedValue += displayValue2 + value;
            }
            if (value == '%') {
                if (pressedFunctionKey == true) {
                    displayValue1 += value;
                    pressedFunctionKey = false;
                }
                else {
                    displayValue1 += displayValue2 + 'Mod';
                }
            }
            else if (value == '/') {
                if (pressedFunctionKey == true) {
                    displayValue1 += value;
                    pressedFunctionKey = false;
                }
                else {
                    displayValue1 += displayValue2 + '÷';
                }
            }
            else if (value == '^' && xtoThePowerYBoolean && xtoThePowerYBooleanHelper == false) {
                EvaulatedValue += '(1/';
                displayValue1 += displayValue2 + 'yroot'
                xtoThePowerYBooleanHelper = true;
            }
            else if (value == 'log base' && logXbaseYBoolean && logXbaseYBooleanHelper == false) {
                let logx = Math.log(parseFloat(displayValue1));
                let basey = Math.log(parseFloat(displayValue2));
                EvaulatedValue += 'logx/logy';
                displayValue1 += displayValue2 + 'log base'
                logXbaseYBooleanHelper = true;
            }
            else {
                if (pressedFunctionKey == true) {
                    displayValue1 += value;
                    pressedFunctionKey = false;
                }
                else {
                    displayValue1 += displayValue2 + value;
                }
            }
        }
        else {
            displayValue1 += value;
        }
        displayValue2 = '';
        document.getElementById('display1').innerText = displayValue1;
    }
}
function clearDisplay() {
    if (disableButtons) {
        EnableAllButtons();
    }
    displayValue1 = '';
    displayValue2 = '';
    EvaulatedValue = '';
    functionAppliedFirst = 0;
    pressedFunctionKey = false;
    operatorFound = false
    subFunctionIndex = -1
    document.getElementById('display1').innerText = '';
    document.getElementById('display2').innerText = '0';
    resetBooleans();
}
function backspace() {
    if (disableButtons) {
        EnableAllButtons();

    }
    else {
        // if we click this after enter
        let tempValue = document.getElementById('display1').innerText;
        let lastIndex = tempValue.length - 1;
        if (tempValue[lastIndex] == '=') {
            document.getElementById('display1').innerText = '';
            displayValue1 = '';
            EvaulatedValue = '';
        }
        else {
            if (displayValue2.length == 0) {
                displayValue2 = '';
                if (notation) {
                    document.getElementById('display2').innerText = ConvertToScientificNotation(parseFloat(0))
                }
                else {
                    document.getElementById('display2').innerText = '0';
                }
            }
            else {
                displayValue2 = displayValue2.slice(0, -1);
                if (displayValue2.length == 0) {
                    displayValue2 = '';
                    if (notation) {
                        document.getElementById('display2').innerText = ConvertToScientificNotation(parseFloat(0))
                    }
                    else {
                        document.getElementById('display2').innerText = '0';
                    }

                }
                else {
                    if (notation) {
                        displayValue2 = ConvertToScientificNotation(parseFloat(displayValue2))
                    }
                    else {
                        document.getElementById('display2').innerText = displayValue2;
                    }

                }
            }

        }
    }

}
function calculate() {
    try {
        let lastIndex = EvaulatedValue.length - 1;
        let lastElement = EvaulatedValue[lastIndex]
        if (lastElement == '+' || lastElement == '-' || lastElement == '*' || lastElement == '/' || lastElement == '%' || lastElement == '^' || EvaulatedValue.length == 0) {
            if ((document.getElementById('display2').innerText)[0] == '-') {
                EvaulatedValue += '(' + document.getElementById('display2').innerText + ')';
                if (pressedFunctionKey == false) {
                    displayValue1 += document.getElementById('display2').innerText;
                }
            }
            else {
                EvaulatedValue += document.getElementById('display2').innerText;
                if (pressedFunctionKey == false) {
                    displayValue1 += document.getElementById('display2').innerText;
                }
            }
        }
        if (xtoThePowerYBoolean) {
            EvaulatedValue += ')'
        }
        console.log(EvaulatedValue)
        displayValue1 += '=';
        document.getElementById('display1').innerText = displayValue1;
        const result = bodmas(EvaulatedValue)

        if (historyShow == false) {
            document.getElementById('historyBlockHeading').style.visibility = "hidden";
            document.getElementById('deleteHistoryButton').style.visibility = "visible";
            historyShow = true;
        }
        document.getElementById('historyBlock').style.textAlign = "right";
        document.getElementById('historyBlock').innerHTML += `<p>${displayValue1}<br> <h2>${result}</h2></p><br>`
        displayValue2 = result.toString();
        EvaulatedValue = '';
        operatorFound = false
        xtoThePowerYBoolean = false;
        xtoThePowerYBooleanHelper = false;
        if (notation) {
            document.getElementById('display2').innerText = ConvertToScientificNotation(parseFloat(result));
        }
        else {
            document.getElementById('display2').innerText = result;
        }

        displayValue1 = '';
        functionAppliedFirst = 0;
        subFunctionIndex = -1;
    } catch (error) {
        displayValue1 = '';
        document.getElementById('display2').innerText = 'Error';
        DisableAllButtons();
    }
}