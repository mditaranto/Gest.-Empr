// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

window.onload = iniciar();


var personas = [];
var departamentos = [];

var form = null;

var modal = null;

async function iniciar() {


    await pedirPersonas()
    await pedirDepartamentos()
    form = document.querySelector('#formPersonas');
    modal = document.getElementById("myModal");

    rellenarTabla(personas, departamentos)

}


function pedirPersonas() {

    return new Promise((resolve, reject) => {

        var miLlamada = new XMLHttpRequest();

        miLlamada.open("GET", "https://crudmati.azurewebsites.net/api/persona");

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

        miLlamada.open("GET", "https://crudmati.azurewebsites.net/api/departamentos");

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

        // Creamos y añadimos las celdas para cada atributo de la persona
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

        // Creamos la celda para la foto
        var td = document.createElement("td");
        var img = document.createElement("img");
        img.src = personas[i].foto; // Establecemos la URL de la foto
        img.alt = "Foto de " + personas[i].nombre; // Agregamos un texto alternativo
        img.style.maxWidth = "100px"; // Limitamos el ancho de la imagen
        td.appendChild(img);
        tr.appendChild(td);

        var td = document.createElement("td");
        var fecha = personas[i].fechaNacimiento
        fecha = fecha.split("T");
        td.innerHTML = fecha[0] + " " + fecha[1];
        tr.appendChild(td);

        var td = document.createElement("td");
        td.innerHTML = departamentos.find(x => x.id == personas[i].idDepartamento).nombre;
        tr.appendChild(td);

        // Añadimos botón de editar
        var td = document.createElement("td");
        var botonEditar = document.createElement("button");
        botonEditar.innerHTML = "Editar";
        botonEditar.id = i;
        botonEditar.onclick = function () {
            editarPersona();
        };
        td.appendChild(botonEditar);
        tr.appendChild(td);

        // Añadimos botón de borrar
        var botonBorrar = document.createElement("button");
        botonBorrar.innerHTML = "Borrar";
        botonBorrar.onclick = function () {
            borrarPersona();
        };
        td.appendChild(botonBorrar);
        tr.appendChild(td);

        // Añadimos la fila a la tabla
        tabla.appendChild(tr);
        
        
    }

}

function editarPersona() {
    //find the id of the person
    var id = event.target.parentNode.parentNode.firstChild.innerHTML;

    modal.style.display = "block";
    //rellenar modal con datos de la persona
    var persona = personas.find(x => x.id == id);
    document.getElementById("nombre").value = persona.nombre;
    document.getElementById("apellido").value = persona.apellido;
    document.getElementById("telefono").value = persona.telefono;
    document.getElementById("direccion").value = persona.direccion;
    document.getElementById("foto").value = persona.foto;
    var fecha = persona.fechaNacimiento.split("T");
    document.getElementById("fechaNac").value = fecha[0];
    document.getElementById("departamento").value = departamentos.find(x => x.id == persona.idDepartamento).nombre;
    document.getElementById("id").value = persona.id;
    document.getElementById("idDepartamento").value = persona.idDepartamento;

    document.getElementById("btnGuardar").onclick = function () {
        sendData();
    }
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}

function borrarPersona(id) {
    alert("Borrar persona con id " + id);

}

async function sendData() {
    //get id from form
    var id = document.getElementById("id").value;
    data = {
        "id": id,
        "nombre": document.getElementById("nombre").value,
        "apellido": document.getElementById("apellido").value,
        "telefono": document.getElementById("telefono").value,
        "direccion": document.getElementById("direccion").value,
        "foto": document.getElementById("foto").value,
        "fechaNacimiento": document.getElementById("fechaNac").value,
        "idDepartamento": document.getElementById("idDepartamento").value


    }
    modal.style.display = "none";

    //var miLlamada = new XMLHttpRequest();
    //miLlamada.open("PUT", `https://crudmati.azurewebsites.net/api/persona/${id}`);
    //miLlamada.setRequestHeader("Content-Type", "application/json");
    //miLlamada.send(JSON.stringify(data));

    try {
        const response = await fetch(`https://crudmati.azurewebsites.net/api/persona/${id}`, {
            method: "PUT",
            headers: {
                "Content-Type": "application/json",
            },
            // Set the FormData instance as the request body
            body: JSON.stringify(data),
        });
        window.location.reload();
        
    } catch (e) {
        console.error(e);
    }
}

async function borrarPersona() {
    //get id from form
    var id = event.target.parentNode.parentNode.firstChild.innerHTML;
    modal.style.display = "none";

    var miLlamada = new XMLHttpRequest();
    miLlamada.open("DELETE", `https://crudmati.azurewebsites.net/api/persona/${id}`);
    miLlamada.onreadystatechange = function () {

        if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            window.location.reload();
        }
    }

    miLlamada.send();

    //try {
    //    const response = await fetch(`https://crudmati.azurewebsites.net/api/persona/${id}`, {
    //        method: "DELETE",
    //        headers: {
    //            "Content-Type": "application/json",
    //        },
    //    });
    //    window.location.reload();
    //} catch (e) {
    //    console.error(e);
    //}
    
}

async function addPersona() {
    
    modal.style.display = "block";

    document.getElementById("nombre").value = "";
    document.getElementById("apellido").value = "";
    document.getElementById("telefono").value = "";
    document.getElementById("direccion").value = "";
    document.getElementById("foto").value = "";
    document.getElementById("fechaNac").value = "";
    document.getElementById("departamento").value = "";
    document.getElementById("id").value = "";
    document.getElementById("idDepartamento").value = 1;
    document.getElementById("btnGuardar").onclick = function () {
        postData();
    }
}

async function postData() {
data = {
        "nombre": document.getElementById("nombre").value,
        "apellido": document.getElementById("apellido").value,
        "telefono": document.getElementById("telefono").value,
        "direccion": document.getElementById("direccion").value,
        "foto": document.getElementById("foto").value,
        "fechaNacimiento": document.getElementById("fechaNac").value,
        "idDepartamento": document.getElementById("idDepartamento").value
    }
    modal.style.display = "none";

    //var miLlamada = new XMLHttpRequest();
    //miLlamada.open("POST", `https://crudmati.azurewebsites.net/api/persona`);
    //miLlamada.setRequestHeader("Content-Type", "application/json");
    //miLlamada.send(JSON.stringify(data));

    try {
        const response = await fetch(`https://crudmati.azurewebsites.net/api/persona`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            // Set the FormData instance as the request body
            body: JSON.stringify(data),
        });
        window.location.reload();
    } catch (e) {
        console.error(e);
    }
}