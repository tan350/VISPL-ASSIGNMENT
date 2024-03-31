//Arithmetic Operations
function operations(a, b, operator) {
    switch (operator) {
        case '+':
            return a + b;
        case '-':
            return a - b;
        case '*':
            return a * b;
        case '/':
            if (b === 0) {
                throw new Error("Cannot divide by zero.");
            }
            return a / b;
        case '^':
            return Math.pow(a, b);
        case '%':
            if (b === 0) {
                throw new Error("Cannot perform modulus operation with divisor as zero.");
            }
            return a % b;
        default:
            throw new Error("Invalid operator: " + operator + " " + a + " " + b);
    }
}

function precedence(op1, op2) {
    var precedence = {
        '(': 0,
        '+': 1,
        '-': 1,
        '*': 2,
        '/': 2,
        '%': 2,
        '^': 3,
    };
    return precedence[op1] < precedence[op2];
}

class Stack {
    constructor() {
        this.items = [];
    }

    push(element) {
        this.items.push(element);
    }

    pop() {
        if (this.isEmpty()) {
            return "Underflow";
        }
        return this.items.pop();
    }
    peek() {
        return !this.isEmpty() ? this.items[this.items.length - 1] : undefined;
    }

    isEmpty() {
        return this.items.length === 0;
    }
    size() {
        return this.items.length;
    }

    clear() {
        this.items = [];
    }
}

function bodmas(Expression) {
   
    let length = Expression.Length;
    let expressionIndex = 0;
    let operators = new Stack();
    let operands = new Stack();
    let numberIsNext = true;
    let number = "";
    let isCbracket = false;

    if (length === 0) {
        throw new Error("You have not entered any expression");
    }

    while (expressionIndex < Expression.length) {
        if ((Expression[expressionIndex] >= '0' && Expression[expressionIndex] <= '9') || Expression[expressionIndex] === '.') {
            number += Expression[expressionIndex];
            if (expressionIndex === Expression.length - 1 || (expressionIndex < Expression.length - 1 && !((Expression[expressionIndex + 1] >= '0' && Expression[expressionIndex + 1] <= '9') || Expression[expressionIndex + 1] === '.'))) {
                numberIsNext = false;
            }
            if (numberIsNext === false) {
                operands.push(parseFloat(number));
                number = "";
                numberIsNext = true;
            }

        } else if (Expression[expressionIndex] === '+' || Expression[expressionIndex] === '-' || Expression[expressionIndex] === '/' || Expression[expressionIndex] === '*' || Expression[expressionIndex] === '^' || Expression[expressionIndex] === '%') {
            if (operands.size() === 0 || Expression[expressionIndex - 1] === '(') {
                operands.push(0);
            }
            if (operators.size() === 0)
            {           
                operators.push(Expression[expressionIndex]);
            }
            else
            {
                if (precedence(operators.peek(), Expression[expressionIndex]) === true)
                {
                    operators.push(Expression[expressionIndex]);
                } else {
                    while (operators.size() !== 0 && (precedence(operators.peek(), Expression[expressionIndex]) === false)) {
                        let b = operands.pop();
                        let a = operands.pop();
                        operands.push(operations(a, b, operators.peek()));
                        operators.pop();
                    }
                    operators.push(Expression[expressionIndex]);
                }
            }

        } else if (Expression[expressionIndex] === '(' || Expression[expressionIndex] === ')') {
            
            if (Expression[expressionIndex] === '(') {
                isCbracket = true;
                operators.push(Expression[expressionIndex]);

            } else {

                while (operators.peek() !== '(' && isCbracket === true) {
                    let b = operands.pop();
                    let a = operands.pop();
                    operands.push(operations(a, b, operators.peek()));
                    operators.pop();
                }
                isCbracket = false;
                operators.pop();
            }

        }
        expressionIndex++;
        if (expressionIndex === Expression.length && operators.size() !== 0) {
            if (isCbracket === true) {
                throw new Error('Closing bracket not found ${Expression}');
            }
            while (operators.size() !== 0) {
                let b = operands.pop();
                let a = operands.pop();
                operands.push(operations(a, b, operators.peek()));
                operators.pop();
            }
        }
    }
    return operands.peek();
}

function plusClick() {
    if (operatorFound == false) {
        appendToDisplay('+');
        operatorFound = true;
    }
    else {
        let lastOp = EvaulatedValue[EvaulatedValue.length - 1]
        if (lastOp == '%') {
            displayValue1 = (document.getElementById('display1').innerText).slice(0, -3);
            displayValue1 += '+'
        }
        else {
            displayValue1 = (document.getElementById('display1').innerText).slice(0, -1);
            displayValue1 += '+'
        }

        EvaulatedValue = EvaulatedValue.slice(0, -1)
        EvaulatedValue += '+';
        document.getElementById('display1').innerText = displayValue1;
    }
}

function minusClick() {
    if (operatorFound == false) {
        appendToDisplay('-');
        operatorFound = true;
    }
    else {
        let lastOp = EvaulatedValue[EvaulatedValue.length - 1]
        if (lastOp == '%') {
            displayValue1 = (document.getElementById('display1').innerText).slice(0, -3);
            displayValue1 += '-'
        }
        else {
            displayValue1 = (document.getElementById('display1').innerText).slice(0, -1);
            displayValue1 += '-'
        }

        EvaulatedValue = EvaulatedValue.slice(0, -1)
        EvaulatedValue += '-';
        document.getElementById('display1').innerText = displayValue1;
    }
}

function multiplicationClick() {
    if (operatorFound == false) {
        appendToDisplay('*');
        operatorFound = true;
    }
    else {
        let lastOp = EvaulatedValue[EvaulatedValue.length - 1]
        if (lastOp == '%') {
            displayValue1 = (document.getElementById('display1').innerText).slice(0, -3);
            displayValue1 += '*'
        }
        else {
            displayValue1 = (document.getElementById('display1').innerText).slice(0, -1);
            displayValue1 += '*'
        }

        EvaulatedValue = EvaulatedValue.slice(0, -1)
        EvaulatedValue += '*';
        document.getElementById('display1').innerText = displayValue1;
    }
}

function divideClick() {
    if (operatorFound == false) {
        appendToDisplay('/');
        operatorFound = true;
    }
    else {
        let lastOp = EvaulatedValue[EvaulatedValue.length - 1]
        if (lastOp == '%') {
            displayValue1 = (document.getElementById('display1').innerText).slice(0, -3);
            displayValue1 += '÷'
        }
        else {
            displayValue1 = (document.getElementById('display1').innerText).slice(0, -1);
            displayValue1 += '÷'
        }

        EvaulatedValue = EvaulatedValue.slice(0, -1)
        EvaulatedValue += '/';
        document.getElementById('display1').innerText = displayValue1;
    }
}

function modClick() {
    if (operatorFound == false) {
        appendToDisplay('%');
        operatorFound = true;
    }
    else {
        let lastOp = EvaulatedValue[EvaulatedValue.length - 1]
        if (lastOp == '%') {
            displayValue1 = (document.getElementById('display1').innerText).slice(0, -3);
            displayValue1 += 'Mod'
        }
        else {
            displayValue1 = (document.getElementById('display1').innerText).slice(0, -1);
            displayValue1 += 'Mod'
        }
        EvaulatedValue = EvaulatedValue.slice(0, -1)
        EvaulatedValue += '%';
        document.getElementById('display1').innerText = displayValue1;
    }
}

function decimalClick() {
    if (decimalClickBoolean == false) {
        appendToDisplay('.');
        decimalClickBoolean = true;
    }
    else {

    }
}