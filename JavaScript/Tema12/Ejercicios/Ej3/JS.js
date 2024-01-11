class Marcas {
    constructor(nombre, ListadoCoches) {
        this.nombre = nombre;
        this.ListadoCoches = ListadoCoches;
    }
    getNombre() {
        return this.nombre;
    }

    get ListadoCoches() {
        return this.ListadoCoches;
    }
}

function InicializarMarcas() {
    BMW = new Marcas("BMW", ["Serie 1", "Serie 2", "Serie 3"]);
    Audi = new Marcas("Audi", ["A1", "A2", "A3"]);
    Mercedes = new Marcas("Mercedes", ["Clase A", "Clase B", "Clase C"]);
}
