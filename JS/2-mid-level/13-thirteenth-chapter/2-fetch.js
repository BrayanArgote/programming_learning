const btnAdd1 = document.getElementById("btn-add1");
const formAddStudent = document.getElementById("form-add-student");
const formUpdateStudent = document.getElementById("form-update-student")
const btnsCancel = document.querySelectorAll(".btn-cancel");
const tbody = document.getElementById("tbody");

function CloseForms(){
    formAddStudent.style.display = "none";
    formAddStudent.reset();
    formUpdateStudent.style.display = "none";
    formUpdateStudent.reset();
}

btnsCancel.forEach(function(btn){
    btn.addEventListener("click", CloseForms)
})


btnAdd1.addEventListener("click", function(){
    formAddStudent.style.display = "block";
});


document.addEventListener("click", function(e){
    if(!formAddStudent.contains(e.target) && e.target != btnAdd1){
        formAddStudent.style.display = "none";
    }

    if(!formUpdateStudent.contains(e.target) && !e.target.classList.contains("btn-update")){
        formUpdateStudent.style.display = "none"
    }
});



function CreateStudent(students){
    tbody.innerHTML = "";
    if (students.length == 0){
        let tr = document.createElement("tr");
        tr.innerHTML = `<td colspan="5">There are no students</td>`;
        tbody.appendChild(tr);
    }
    else{
        for(st of students){
            let tr = document.createElement("tr");
            tr.innerHTML = 
            `
                <td>${st.id}</td>
                <td>${st.name}</td>
                <td>${st.age}</td>
                <td>${st.subject}</td>
                <td>
                    <button class="btn-delete">Delete</button>
                    <button class="btn-update">Update</button>
                </td>
            `
            tr.setAttribute("data-id", st.id);
            tbody.appendChild(tr);
        }
    }
}

function GetAllStudents(){
    fetch('https://localhost:7049/api/Students')
    .then(function(response){
        if(!response.ok){
            throw new Error("Error in request");
        }
        return response.json();
    })
    .then(function(data){
        CreateStudent(data);
    })
    
    .catch(function(error){
        console.log("Failed to load the students: ", error)
    })
}



const inputSearch = document.getElementById("input-search");
const btnSearch = document.getElementById("btn-search");

btnSearch.addEventListener("click", function(){
    let idSearch = inputSearch.value;

    if (idSearch === ""){
        GetAllStudents();
    }
    else{
        tbody.innerHTML = "";
        GetStudentById(idSearch)
    }
})

function GetStudentById(id){
    fetch('https://localhost:7049/api/Students/' + id, {
        method: "GET"
    })
    .then(function(response){
        if(response.status === 404){
            let tr = document.createElement("tr");
            tr.innerHTML = `<td colspan="5">Student was not found</td>`;
            tbody.appendChild(tr);
            throw new Error("Not found")
        }
        return response.json();
    })
    .then(function(data){
        let tr = document.createElement("tr");

        let id = document.createElement("td");
        id.textContent = data.id;

        let name = document.createElement("td");
        name.textContent = data.name;

        let age = document.createElement("td");
        age.textContent = data.age;

        let subject = document.createElement("td");
        subject.textContent = data.subject;

        let btnDelete = document.createElement("button");
        btnDelete.textContent = "Delete";
        btnDelete.classList.add("btn-delete");

        let btnUpdate = document.createElement("button");
        btnUpdate.textContent = "Update";
        btnUpdate.classList.add("btn-update");
        btnUpdate.style.marginLeft = "5px"

        let actions = document.createElement("td");
        actions.appendChild(btnDelete);
        actions.appendChild(btnUpdate);

        tr.appendChild(id);
        tr.appendChild(name);
        tr.appendChild(age);
        tr.appendChild(subject);
        tr.appendChild(actions);

        tr.setAttribute("data-id", data.id)
        tbody.appendChild(tr);
    })
    .catch(function(error){
        console.log("Failed to get the element: ", error)
    })
}


const inputName = document.getElementById("input-name");
const inputAge = document.getElementById("input-age");
const inputSubject = document.getElementById("input-subject");

function AddStudent(){
    fetch('https://localhost:7049/api/Students',{
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            name: inputName.value,
            age: inputAge.value,
            subject: inputSubject.value
        })
    })
    .then(function(response){
        if(response.status === 201){
            alert("Student added");
        }
    GetAllStudents();
    })
    .catch(function(error){
        console.log("Failed to add a student: ", error)
    },
formAddStudent.reset())
}

formAddStudent.addEventListener("submit", function(event){
    event.preventDefault(); 
    let age = Number(inputAge.value)  
    if (age < 18 || age > 100 ){
        alert("Age must smaller than 100 and greater than 18")
    }
    else{
    AddStudent();
    formAddStudent.style.display = "none"
    }

})



tbody.addEventListener("click", function(event){
    if(event.target.classList.contains("btn-delete")){
        let btnid = event.target.closest("tr").dataset.id;

        fetch('https://localhost:7049/api/Students/' + btnid,{
        method: "DELETE"
        })
        .then(function(response){
            if (response.status === 200){
            alert("Student was deleted")
            GetAllStudents();
            }
        })
        .catch(function(error){
            console.log("Fail to delete a student: " + error)
        })
    }
})


const idUpdate = document.getElementById("id-update");
const nameUpdate = document.getElementById("name-update");
const ageUpdate = document.getElementById("age-update");
const subjectUpdate = document.getElementById("subject-update");

tbody.addEventListener("click", function(event){
    if(event.target.classList.contains("btn-update")){
        formUpdateStudent.style.display = "block";

        let id = event.target.closest("tr").dataset.id;
        loadStudent(id);
    }
})

function loadStudent(id){
    fetch(`https://localhost:7049/api/Students/${id}`)
    .then(function(response){
        return response.json();
    })
    .then(function(studentResponse){
        fillForm(studentResponse);
    })
    .catch(function(error){
        console.log("ERROR: " + error)
    });
}

function fillForm(student){
    idUpdate.value = student.id;
    nameUpdate.value = student.name;
    ageUpdate.value = student.age;
    subjectUpdate.value = student.subject;
}

function updateStudent(id){
    fetch(`https://localhost:7049/api/Students/${id}`,{
        method: "PUT",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            id: idUpdate.value,
            name: nameUpdate.value,
            age: ageUpdate.value,
            subject: subjectUpdate.value
        })
    })
    .then(function (response){
        if(response.status === 200){
            alert("Student was update")
        }
        formUpdateStudent.reset();
        GetAllStudents();
    }
)
    .catch(function (error){
        console.log("Failed to update the student: " + error)
    })
}

const btnUpdate = document.getElementById("btn-update");

btnUpdate.addEventListener("click", function(event){
    event.preventDefault();
    let age = Number(ageUpdate.value);
    let id = idUpdate.value;
    if(nameUpdate.value.length == 0){
        alert("The name can not be empty");
    }
    else if(age < 18 || age > 100){
        alert("Age must smaller than 100 and greater than 18");
    }
    else if(subjectUpdate.value.length == 0){
        alert("The name subject can not be empty");
    }
    else{
        updateStudent(id);
        formUpdateStudent.style.display = "none";
    }
})