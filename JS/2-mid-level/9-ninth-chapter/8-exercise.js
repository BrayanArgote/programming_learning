let students = [
    {
        student_name: "Jose Alvares",
        email: "jose@gmail.com",
        subject: "Tics"
    },
    {
        student_name: "Pedro Alvares",
        email: "pedro@gmail.com",
        subject: "Maths"
    },
    {
        student_name: "Laura Lopez",
        email: "lopez@gmail.com",
        subject: "Tics"
    },
    {
        student_name: "Juan Urrutia",
        email: "urrutia@gmail.com",
        subject: "Spanish"
    },
    {
        student_name: "Dana Cruz",
        email: "dana@gmail.com",
        subject: "Tics"
    },
];

const tbody = document.getElementById("tbody");

for (s in students){
    let data = students[s];

    let student_name = data["student_name"];
    let email = data["email"];
    let subject = data["subject"]

    let HTMLCode = `
    <tr>
        <td>${student_name}</td>
        <td>${email}</td>
        <td>${subject}</td>
        <td>
            <input list="weeks" id="optionsWeek">
            <datalist id="weeks">
                <option value="Week 1">
                <option value="Week 2">
                <option value="Week 3">
            </datalist>
        </td>
    </tr>
    `
    document.getElementById("tbody").innerHTML+= HTMLCode;
}

const btnSend = document.getElementById("btnSend");

btnSend.addEventListener("click", function(){
    let oW = document.getElementById("optionWeek");
    let ow = document.getElementById("weeks");
    for (o in oW){
        week = oW[o];
        week.innerHTML = "hello"
    }
})