// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

class persona {
    constructor(id, nombre, apellido, telefono, direccion, foto, fechaNacimineto, idDepartamento) {
        this.id = id;
        this.nombre = nombre;
        this.apellido = apellido;
        this.telefono = telefono;
        this.direccion = direccion;
        this.foto = foto;
        this.fechaNacimineto = fechaNacimineto;
        this.idDepartamento = idDepartamento;
    };
};

class departamento {
    constructor(idDepartamento, nombre) {
        this.idDepartamento = idDepartamento;
        this.nombre = nombre;
    };
};

window.onload = iniciar();


var personas = [];
var departamentos = [];

async function iniciar() {


    await pedirPersonas()
    await pedirDepartamentos()

    rellenarTabla(personas, departamentos);


}


function pedirPersonas() {

    return new Promise((resolve, reject) => {

        var miLlamada = new XMLHttpRequest();

        miLlamada.open("GET", "https://crudjuanmasanchez.azurewebsites.net/api/personas");

        //Definicion estados
        miLlamada.onreadystatechange = function () {

            if (miLlamada.readyState < 4) {

                //aquí se puede poner una imagen de un reloj o un texto “Cargando”

            } else {

                if (miLlamada.readyState == 4 && miLlamada.status == 200) {

                    personas = JSON.parse(miLlamada.responseText);
                    resolve();

                } else {
                    reject();
                }
            }

        };

        miLlamada.send();
    });

}

function pedirDepartamentos() {

    return new Promise((resolve, reject) => {

        var miLlamada = new XMLHttpRequest();

        miLlamada.open("GET", "https://crudjuanmasanchez.azurewebsites.net/api/departamentos");

        //Definicion estados
        miLlamada.onreadystatechange = function () {

            if (miLlamada.readyState < 4) {

                //aquí se puede poner una imagen de un reloj o un texto “Cargando”

            } else {

                if (miLlamada.readyState == 4 && miLlamada.status == 200) {

                    departamentos = JSON.parse(miLlamada.responseText);
                    resolve();

                } else {
                    reject();
                }
            }

        };

        miLlamada.send();
    });

}

function rellenarTabla(personas, departamentos) {

    var tabla = document.getElementById("personas");

    for (var i = 0; i < personas.length; i++) {

        var tr = document.createElement("tr");
        var td = document.createElement("td");
        td.innerHTML = personas[i].id;
        tr.appendChild(td);
        var td = document.createElement("td");
        td.innerHTML = personas[i].nombre;
        tr.appendChild(td);
        var td = document.createElement("td");
        td.innerHTML = personas[i].apellido;
        tr.appendChild(td);
        var td = document.createElement("td");
        td.innerHTML = personas[i].telefono;
        tr.appendChild(td);
        var td = document.createElement("td");
        td.innerHTML = personas[i].direccion;
        tr.appendChild(td);
        var td = document.createElement("td");
        td.innerHTML = personas[i].foto;
        tr.appendChild(td);
        var td = document.createElement("td");
        td.innerHTML = personas[i].fechaNacimineto;
        tr.appendChild(td);
        var td = document.createElement("td");
        td.innerHTML = departamentos.find(x => x.idDepartamento == personas[i].idDepartamento).nombre;
        tr.appendChild(td);
        var td = document.createElement("td");
        var boton = document.createElement("button");
        boton.innerHTML = "Editar";
        boton.onclick = function () {
            editarPersona(personas[i].id);
        };
        td.appendChild(boton);
        tr.appendChild(td);
        var td = document.createElement("td");
        var boton = document.createElement("button");
        boton.innerHTML = "Borrar";
        boton.onclick = function () {
            borrarPersona(personas[i].id);
        };
        td.appendChild(boton);
        tr.appendChild(td);

        tabla.appendChild(tr);
    }
}