const btnAdd1 = document.getElementById("btn-add1");
const formAddStudent = document.getElementById("form-add-student");
const btnCancel = document.querySelector(".btn-cancel");

btnAdd1.addEventListener("click", function(){
    formAddStudent.style.display = "block";
});

btnCancel.addEventListener("click", function(){
    formAddStudent.style.display = "none"
});

document.addEventListener("click", function(e){
    if(!formAddStudent.contains(e.target) && e.target != btnAdd1){
        formAddStudent.style.display = "none";
    }
});

function CreateStudent(students){
    const tbody = document.getElementById("tbody");
    let tr = document.createElement("tr");
    for(student of students){
        tr.innerHTML = 
        `
            <td>${student.id}</td>
            <td>${student.name}</td>
            <td>${student.subject}</td>
            <td>
                <button>Delete<button>
            </td>
        `
        tbody.appendChild(tr);
    }
}

function GetAllStudents(){
    fetch('https://localhost:7049/api/Students')
    .then(function(response){
        return response.json();
    })
    .then(function(data){
        return
    })
}






