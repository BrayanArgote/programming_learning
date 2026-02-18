/*
Create a program for a party that only allows
adults to enter.
The first person who enters after 2 a.m. in 
the morning gets in for free 
*/
let free = true;

const securityGuard = (age, time) =>{
    if (age >= 18){

        if(time >= 2 && free){
            free = false;
            return "You can enter and you don't have to pay";
        }

        return "You can enter but first you have to pay";
    }

    return "You can not enter, you are not an adult";
}

for(let f = 0; f < 5; f++){
    let name = prompt("Enter your name");
    let age = Number(prompt(`Hello ${name}, please enter your age`));
    alert(securityGuard(age, f, free));
}
