const contenedor = document.querySelector(".flex-container");

function createKey(name, model, price){
    img = `<img src="key.jpg">`;
    name = `<h2>${name} </h2>`;
    model = `<h3>${model}</h3>`;
    price = `<p>Precio: <b>$${price}</b></p>`;
    return [img, name, model, price];
}

let documentFragment = document.createDocumentFragment();

for (var i = 1; i <= 20; i++){
    let modelRandom = Math.round(Math.random()*100000);
    let priceRandom = Math.round(Math.random()*10+30);
    let key = createKey(`key ${i}`, `modelo ${modelRandom}`, `${priceRandom}`);
    let div = document.createElement("div");
    div.classList.add(`item-${i}`, `flex-item`);
    div.innerHTML = key[0] + key[1] + key[2] + key[3];
    documentFragment.appendChild(div);
}

contenedor.appendChild(documentFragment);

