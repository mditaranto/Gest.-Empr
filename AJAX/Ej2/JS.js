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

                rellenarDiv(arrayPersonas);

            }

    };

    miLlamada.send();

}

function rellenarDiv(arrayPersonas) {

    var div = document.getElementById("div1");

    for (var i = 0; i < 10; i++) {

        div.innerHTML += "<p>" + arrayPersonas[i].nombre + " " + arrayPersonas[i].apellido + "</p>";

    }

}