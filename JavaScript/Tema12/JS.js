// JavaScript source code
alert("Quien dijo amigos")

function inicializaEventos() {
    
    document.getElementById("miBoton").addEventListener("click", cambiarTitulo,false);
    
    }

function cambiarTitulo() {

    var miBoton = document.getElementById("miBoton");

    var h1Elements = document.getElementsByTagName("h1");
    
    h1Elements[0].innerHTML = "Quien dijo amigos";  
    h1Elements[1].innerHTML = "Si te conozco más";
    h1Elements[2].innerHTML = "desnuda que con ropa";

    miBoton.value = "Cambiado";
    miBoton.disabled = true;
    
}