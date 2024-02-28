// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

window.onload = iniciar();

var personas = [];
var departamentos = [];

var modal = null;
var tipolista = null;
var modalDepartamento = null;

//Segun el select se muestra una tabla u otra
function cambiarTabla() {
    var select = document.getElementById("Lista");
    var tabla = document.getElementById("personas");
    var tablaDepartamentos = document.getElementById("departamentos");
    var añadirPersona = document.getElementById("btnInsertar");
    var añadirDepartamento = document.getElementById("btnInsertarDepartamento");
    var value = select.value;

    if (value == "personas") {
        tabla.style.display = "block";
        tablaDepartamentos.style.display = "none";
        añadirPersona.style.display = "block";
        añadirDepartamento.style.display = "none";
    } else {
        tabla.style.display = "none";
        tablaDepartamentos.style.display = "block";
        añadirPersona.style.display = "none";
        añadirDepartamento.style.display = "block";
    }
}
async function iniciar() {

    await pedirPersonas()
    await pedirDepartamentos()

    modal = document.getElementById("myModal");
    tipolista = document.getElementById("Lista");
    modalDepartamento = document.getElementById("myModalDepartamento");

    rellenarTabla()
    rellenarDepartamentos()
    cambiarTabla()

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

function rellenarTabla() {

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

    var select = document.getElementById("departamentoSelect")
    for (var i = 0; i < departamentos.length; i++) {
        var option = document.createElement("option");
        option.value = departamentos[i].id;
        option.text = departamentos[i].nombre;
        if (departamentos[i].id == persona.idDepartamento) {
            option.selected = true;
        }
        select.appendChild(option);
    }

    document.getElementById("id").value = persona.id;

    document.getElementById("btnGuardar").onclick = function () {
        sendData();
    }
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
        "idDepartamento": document.getElementById("departamentoSelect").value

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

    //Add an alert to confirm the delete
    if (!confirm("¿Estás seguro de que quieres borrar esta persona?")) {
        return;
    }

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

    var select = document.getElementById("departamentoSelect")
    var option = document.createElement("option");
    option.value = "0";
    option.text = "Elija un departamento";
    option.selected = true;
    select.appendChild(option);
    for (var i = 0; i < departamentos.length; i++) {
        var option = document.createElement("option");
        option.value = departamentos[i].id;
        option.text = departamentos[i].nombre;
        select.appendChild(option);
    }

    document.getElementById("id").value = "";
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
        "idDepartamento": document.getElementById("departamentoSelect").value
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

//Ahora con departamentos
function rellenarDepartamentos() {

    var tabla = document.getElementById("departamentos");

    for (var i = 0; i < departamentos.length; i++) {

        var tr = document.createElement("tr");

        // Creamos y añadimos las celdas para cada atributo del 
        var td = document.createElement("td");
        td.innerHTML = departamentos[i].id
        tr.appendChild(td);

        var td = document.createElement("td");
        td.innerHTML = departamentos[i].nombre;
        tr.appendChild(td);

        // Añadimos botón de editar
        var td = document.createElement("td");
        var botonEditar = document.createElement("button");
        botonEditar.innerHTML = "Editar";
        botonEditar.id = i;
        botonEditar.onclick = function () {
            editarDepartamento();
        };
        td.appendChild(botonEditar);
        tr.appendChild(td);

        // Añadimos botón de borrar
        var botonBorrar = document.createElement("button");
        botonBorrar.innerHTML = "Borrar";
        botonBorrar.onclick = function () {
            borrarDepartamento();
        };
        td.appendChild(botonBorrar);
        tr.appendChild(td);

        // Añadimos la fila a la tabla
        tabla.appendChild(tr);
    }
}

function editarDepartamento() {
    //find the id of the person
    var id = event.target.parentNode.parentNode.firstChild.innerHTML;

    modalDepartamento.style.display = "block";
    //rellenar modal con datos de la persona
    var departamento = departamentos.find(x => x.id == id);
    document.getElementById("nombreDepartamento").value = departamento.nombre;
    document.getElementById("idDept").value = departamento.id;

    document.getElementById("btnGuardarDepartamento").onclick = function () {
        sendDataDepartamento();
    }
}

window.onclick = function (event) {
    if (event.target == modalDepartamento) {
        modalDepartamento.style.display = "none";
    }
    if (event.target == modal) {
        modal.style.display = "none";
    }
}

async function sendDataDepartamento() {
    //get id from form
    var id = document.getElementById("idDept").value;
    data = {
        "nombre": document.getElementById("nombreDepartamento").value
    }
    modalDepartamento.style.display = "none";

    //var miLlamada = new XMLHttpRequest();
    //miLlamada.open("PUT", `https://crudmati.azurewebsites.net/api/departamentos/${id}`);
    //miLlamada.setRequestHeader("Content-Type", "application/json");
    //miLlamada.send(JSON.stringify(data));

    try {
        const response = await fetch(`https://crudmati.azurewebsites.net/api/departamentos/${id}`, {
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
    async function addDepartamento() {

        modalDepartamento.style.display = "block";

        document.getElementById("nombreDepartamento").value = "";

        document.getElementById("btnGuardarDepartamento").onclick = function () {
            postDepartamento();
        }
    }

    async function postDepartamento() {
        data = {
            "nombre": document.getElementById("nombreDepartamento").value,
        }
        modal.style.display = "none";

        //var miLlamada = new XMLHttpRequest();
        //miLlamada.open("POST", `https://crudmati.azurewebsites.net/api/departamentos`);
        //miLlamada.setRequestHeader("Content-Type", "application/json");
        //miLlamada.send(JSON.stringify(data));

        try {
            const response = await fetch(`https://crudmati.azurewebsites.net/api/departamentos`, {
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

function borrarDepartamento() {

    //Add an alert to confirm the delete
    if (!confirm("¿Estás seguro de que quieres borrar este departamento?")) {
        return;
    }

    //get id from form
    var id = event.target.parentNode.parentNode.firstChild.innerHTML;
    modalDepartamento.style.display = "none";

    var miLlamada = new XMLHttpRequest();
    miLlamada.open("DELETE", `https://crudmati.azurewebsites.net/api/departamentos/${id}`);
    miLlamada.onreadystatechange = function () {

        if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            window.location.reload();
        }
    }

    miLlamada.send();
}
