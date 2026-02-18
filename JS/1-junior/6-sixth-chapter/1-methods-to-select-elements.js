// select an element by its id (document.getElementById)
document.writeln(document.getElementById("one"));

// select several elements by tag name (document.getElementsByTagName) returns a HTMLCollection 
document.writeln(document.getElementsByTagName("h2")[2]);

// === like CSS ===
// select the first element with that class or id (querySelector)
document.writeln(document.querySelector(".two"));

// select all elements with that class (querySelectorAll)
document.writeln(document.querySelectorAll(".subtitle"));