// JavaScript source code

window.onload = iniciar();

var personas;
var dept;
    async function iniciar() {

        await pedirPersonas()
        await pedirDepartamentos()

        rellenarTabla(personas,dept);

    }


function pedirDatos() {

    // Solicitud GET (Request).
    fetch("https://crudjuanmasanchez.azurewebsites.net/api/personas")
        // Exito
        .then(fetch(""))
        .then(response => response.json())  // convertir a json
        .then(json => console.log(json))    //imprimir los datos en la consola
        .catch(err => console.log('Solicitud fallida', err)); // Capturar errore
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

                    dept = JSON.parse(miLlamada.responseText);
                    resolve();

                } else {
                    reject();
                }
            }

        };

        miLlamada.send();
    });

}

function rellenarTabla(arrayPersonas, arrayDepartamentos) {

    var table = document.getElementById("tablita");

    //Rellenar la tabla con las personas y el nombre del departamento
    for (var i = 0; i < arrayPersonas.length; i++) {
        var tr = document.createElement("tr");
        var td = document.createElement("td");
        td.innerHTML = arrayPersonas[i].nombre;
        tr.appendChild(td);
        td = document.createElement("td");
        td.innerHTML = arrayPersonas[i].apellido;
        tr.appendChild(td);
        td = document.createElement("td");
        td.innerHTML = arrayDepartamentos[arrayPersonas[i].idDepartamento - 1].nombre;
        tr.appendChild(td);
        table.appendChild(tr);
    }

}