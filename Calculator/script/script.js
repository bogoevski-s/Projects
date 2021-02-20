// Calculator key selection
let calculator = $(".claculatorMain");
let keys = $(".number");
let operator = $(".operation");
let equal = $(".equal");
let clear = $(".clear");
let backspace = $(".del");

// Calculator display selection
let mainDisplay = $(".mainDisplay");
let currentDisplay = $(".currentDisplay");
let previousDisplay = $(".previousDisplay");

// Arrays numbers / operations
let stringNumbers = [];
let parsedNumbers = [];
let operations = [];
let results = [];

// numbers keys function
function numberKeys(number) {
    number = $(this).val();
    stringNumbers.push(number);
    currentDisplay.text(currentDisplay.text() + number);
}

// operations keys function
function operatorKeys(operation) {
    previousDisplay.text(currentDisplay.text())
    currentDisplay.text(``);
    if (stringNumbers.length === 0) stringNumbers.push(results[results.length - 1])

    operation = $(this).val();
    operations.push(operation)
    parsedNumbers.push(parseFloat(stringNumbers.join('')));
    stringNumbers = [];
}

// equal key operation
function equalKey(total) {
    total = $(this).val();
    previousDisplay.text(currentDisplay.text())
    currentDisplay.text(``);
    parsedNumbers.push(parseFloat(stringNumbers.join('')));
    if (operations[operations.length - 1] === '+') {
        let result = parsedNumbers[parsedNumbers.length - 2] + parsedNumbers[parsedNumbers.length - 1];
        result = Math.round(result * Math.pow(10,6)) / Math.pow(10,6)
        results.push(result)
        currentDisplay.text(currentDisplay.text() + result);
        console.log(parsedNumbers)
    }
    if (operations[operations.length - 1] === '-') {
        let result = parsedNumbers[parsedNumbers.length - 2] - parsedNumbers[parsedNumbers.length - 1];
        result = Math.round(result * Math.pow(10,6)) / Math.pow(10,6)
        results.push(result)
        currentDisplay.text(currentDisplay.text() + result);
    }
    if (operations[operations.length - 1] === '*') {
        let result = parsedNumbers[parsedNumbers.length - 2] * parsedNumbers[parsedNumbers.length - 1];
        result = Math.round(result * Math.pow(10,6)) / Math.pow(10,6)
        results.push(result)
        currentDisplay.text(currentDisplay.text() + result);
    }
    if (operations[operations.length - 1] === '/') {
        let result = parsedNumbers[parsedNumbers.length - 2] / parsedNumbers[parsedNumbers.length - 1];
        result = Math.round(result * Math.pow(10,6)) / Math.pow(10,6)
        results.push(result)
        currentDisplay.text(currentDisplay.text() + result);
    }
    stringNumbers = [];
    parsedNumbers = [];
}

// clear key function
function clearKey(clearAll) {
    clearAll = $(this).val();
    previousDisplay.text(``);
    currentDisplay.text(``);
    stringNumbers = [];
    parsedNumbers = [];
    operations = [];
    results = [];
}

// delete key function
function deleteKey(del) {
    del = $(this).val();
    if(currentDisplay.text() == results[results.length - 1]){
        results.pop();
        currentDisplay.text(currentDisplay.text().slice(0, currentDisplay.text().length -1));
        results.push(parseFloat(currentDisplay.text()))
    }else{
        stringNumbers.pop();
        currentDisplay.text(currentDisplay.text().slice(0, currentDisplay.text().length -1));
    }
}

// Listeners
keys.on("click", numberKeys)
operator.on("click", operatorKeys)
equal.on("click", equalKey)
clear.on("click", clearKey)
backspace.on("click", deleteKey)