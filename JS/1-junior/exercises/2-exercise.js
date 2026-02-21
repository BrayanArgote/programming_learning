const persons = [
    {
        name: "Joe",
        age: 20,
        country: "Germany"
    },
    {
        name: "Laura",
        age: 42,
        country: "Italy"
    },
    {
        name: "Carlos",
        age: 19,
        country: "Ecuador"
    },
    {
        name: "Beto",
        age: 78,
        country: "Japan"
    }
]

const container = document.getElementById("container");

for(p of persons){
    let person = `
    <div class="container-person">
        <h2>Name: ${p.name}</h2>
        <h2>Age: ${p.age}</h2>
        <h2>Country: ${p.country}</h2>
    </div>`;

    container.innerHTML = container.innerHTML + person;
}


const containerGreen = document.getElementById("container-green")
const fragment = document.createDocumentFragment();

persons.forEach(function(p){
    let div = document.createElement("div");
    div.classList.add("container-person", "green");

    let name = document.createElement("h2");
    name.textContent = `Nombre: ${p.name}`;
    let age = document.createElement("h2");
    age.textContent = `Age: ${p.age}`;
    let country = document.createElement("h2");
    country.textContent = `Country: ${p.country}`;

    div.appendChild(name);
    div.appendChild(age);
    div.appendChild(country);

    fragment.appendChild(div);
})

containerGreen.appendChild(fragment);