// assignment operators (=. +=, -=, *=, /=, %=)
let n1 = 5;             
document.writeln(n1);   // n1 = 5

n1 += 5;                
document.writeln(n1);   // n1 = 10

n1 -= 5;                
document.writeln(n1);   // n1 = 5

n1 *=4;                 
document.writeln(n1);   // n1 = 20

n1 /= 2;               
document.writeln(n1);   // n1 = 10

n1 %= 9;                
document.writeln(n1);   // n1 = 1

// arithmetic operators ( +, -, *, /, %, ++, --, **)
let n2 = 10;
let n3 = 10;

let n4 = n2 + n3;       
document.writeln(n4);   // n3 = 20

n4 = n2 - n3;
document.writeln(n4);   // n4 = 0

n4 = n2 * n3;
document.writeln(n4);   // n4 = 100

n4 = n2 / n3;
document.writeln(n4);   // n4 = 1

n4 = n2 - n3;
document.writeln(n4);   // n4 = 0

n4 = ++n4;              // (n4 = n4 + 1))
document.writeln(n4);   // n4 = 1

n4 = n4++;              // (n4 = n4 + 1))
document.writeln(n4);   // n4 = 0

n4 = --n4;              // (n4 = n4 - 1)
document.writeln(n4);   // n4 = -1

n4 = n3**3;             // (10 * 10 * 10)
document.writeln(n4);   // n4 = 1000

