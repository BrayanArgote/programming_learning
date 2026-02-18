/* ==== COMPARISON OPETATORS ==== */
let n1 = 5;
let n2 = 10;

//  EQUAL   
n1 == n2;   // false

// NOT EQUAL
n1 != n2;   // true

// GREATER THAN
let bool = n1 > n2;    //false

// LESS THAN
n1 < n2;    // true

// GREATER THAN OR EQUAL TO
n1 >= n2;   // false

// LESS THAN OR EQUAL TO
n1 <= n2;   // true


let m1 = 5;
let m2 = "5";

// STRICT EQUAL 
m1 === m2;  // false

// STRINCT NOT EQUAL
m1 !== m2;  // false

alert(`Is 5 greater than 10? \n${bool}`);  // false


/* ==== LOGICAL OPERATORS ==== */
let b1 = false;
let b2 = true;

// AND: all must be true
b1 && b2;   // false

// OR: at least one must true     
b1 || b2    // true

// NOT: change the value
!b2;

document.writeln(b1 || b2);  // true