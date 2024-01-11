class persona {
    constructor(nombre, apellido) {
        this.nombre = nombre;
        this.apellido = apellido;
    }
}

function imprimirPersona() {
    persona = new persona(document.getElementById("nombre").value, document.getElementById("apellido").value);
    alert(persona.nombre + " " + persona.apellido);
}