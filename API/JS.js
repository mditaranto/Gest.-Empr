// JavaScript source code
window.onload = iniciar();

var modelos = [];
var marcas = [];

function iniciar() {
    cargarModelos();
    cargarMarcas();
}

function cargarModelos() {
var xhr = new XMLHttpRequest();
    xhr.open('GET', 'https://localhost:44351/api/Modelos', true);
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4 && xhr.status == 200) {
            var datos = JSON.parse(xhr.responseText);
            for (var i = 0; i < datos.length; i++) {
                modelos.push(datos[i]);
            }
        }
    }
    xhr.send();
}

function cargarMarcas() {
    var xhr = new XMLHttpRequest();
    xhr.open('GET', 'https://localhost:44351/api/Marcas', true);
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4 && xhr.status == 200) {
            var datos = JSON.parse(xhr.responseText);
            for (var i = 0; i < datos.length; i++) {
                var option = document.createElement("option");
                marcas.push(datos[i]);
            }
        }
    }
    xhr.send();
}

function rellenarSelect() {
    var select = document.getElementById("marca");
    for (var i = 0; i < marcas.length; i++) {
        var option = document.createElement("option");
        option.text = marcas[i].nombre;
        option.value = marcas[i].id;
        select.appendChild(option);
    }
}

//si se selecciona una marca, se rellena el select de modelos
function rellenarModelos() {
    var select = document.getElementById("modelo");
    var idMarca = document.getElementById("marca").value;
    select.innerHTML = "";
    for (var i = 0; i < modelos.length; i++) {
        if (modelos[i].idMarca == idMarca) {
            var option = document.createElement("option");
            option.text = modelos[i].nombre;
            option.value = modelos[i].id;
            select.appendChild(option);
        }
    }
}