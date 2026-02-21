const name = document.getElementById("name");
const email = document.getElementById("email");
const subjetc = document.getElementById("subject");
const btn_send = document.getElementById("btn-send");
const message = document.getElementById("message");

btn_send.addEventListener("click", function(e){
    e.preventDefault()
    let error = validateFields();
    if(error[0]){
        message.innerHTML = error[1];
        message.classList.add("red");
    }
    else{
        message.innerHTML = "Sent successfully";
        message.classList.add("green");
    }
})

const validateFields = function(){
    let error = [];
    if(name.value.length > 30){
        error[0] = true;
        error[1] = "The name can not be longer than 30 characters."
        return error;
        }

    else if(name.value.length < 5){
        error[0] = true;
        error[1] = "The name can not shorter than 5 characters."
        return error;
        }
}