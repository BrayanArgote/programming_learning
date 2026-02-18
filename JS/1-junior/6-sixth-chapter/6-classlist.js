/*
    + .add() = add a class.
    + .remove() = remove a class.
    + .contains() = checks if the element contains the class.
    + .toggle() = if the class exists, it removes it otherwise it add it. It can take  a second parameter (false - true).
    + .replace() = replaces one class with another.
*/

const box = document.querySelector(".normal-box");

let message = `
1. Check if the box has a class
2. Blue Box 
3. Green Box 
4. Reset Box`

let option = prompt(" ==== Type a number ===" + message)

switch(option){
    case "1":
        let classInput = prompt("Enter the name of the class ");
            document.writeln(`<h3>Does the box contain the class ${classInput}? <span>${box.classList.contains(classInput)? "YES" : "NO"}</span></h3>`)
        break;
    
    case "2":
        box.classList.add("blue-box");
        document.writeln(`<h1>BLUE BOX</h1>`);
        break;

    case "3":
        box.classList.add("green-box");
        document.writeln(`<h1>GREEN BOX</h1>`);
        break;

    case "4":
        box.classList.remove("round-box");
        document.writeln(`<h1>ORIGINAL BOX</h1>`);
        break;

    default:
        document.writeln(`<h1>Invalid option</h1>`);
        break;

}
