// JavaScript source code
function pedirDatos() {

    var miLlamada = new XMLHttpRequest();

    miLlamada.open("GET", "https://crudmati.azurewebsites.net/api/persona");

    //Definicion estados

    miLlamada.onreadystatechange = function () {

        if (miLlamada.readyState < 4) {

            //aquí se puede poner una imagen de un reloj o un texto “Cargando”

        }

        else

            if (miLlamada.readyState == 4 && miLlamada.status == 200) {

                var arrayPersonas = JSON.parse(miLlamada.responseText);

                departamentosCall = new XMLHttpRequest();

                departamentosCall.open("GET", "https://crudmati.azurewebsites.net/api/departamentos");

                if (departamentosCall.readyState < 4) {

                        //aquí se puede poner una imagen de un reloj o un texto “Cargando”

                }

                else

                if (departamentosCall.readyState == 4 && departamentosCall.status == 200) {

                            var arrayDepartamentos = JSON.parse(departamentosCall.responseText);

                            rellenarTabla(arrayPersonas, arrayDepartamentos);

                }



            }

    };

    miLlamada.send();

}

function rellenarTabla(arrayPersonas, arrayDepartamentos) {

    var table = document.getElementById("tablita");

    for (var i = 0; i < 10; i++) {

        table.innerHTML += "<tr><td>" + arrayPersonas[i].nombre + "</td>" +
            "<td>" + arrayPersonas[i].apellido + "</td>" +
           "<td>" + arrayDepartamentos[i].nombre + "</td></tr>";

    }

}