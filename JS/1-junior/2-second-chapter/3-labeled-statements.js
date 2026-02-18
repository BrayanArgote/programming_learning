let numbers = [
    [1, 2, 3],
    [4, 5, 6],
    [7, 8, 9]
];

let numberInput = prompt("Enter a number to search");
let flag = true;

firstFor:
for(let f = 0; f < numbers.length; f++){

    for(number of numbers[f]){
        if(number == numberInput){
            alert(`The number ${numberInput} exists in the dababase`);
            flag = false;
            break firstFor;
        }
    }
}

if(flag){
    alert(`The number ${numberInput} does not exists`)
}