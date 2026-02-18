let age = prompt("What is your age?");

if(age < 18 && age > 0){
    alert("You are not an adult")
}
else if(age >= 18 && age < 140){
    alert("You are an adult")
}
else{
    alert(`Please type a valid age: ${age}`)
}