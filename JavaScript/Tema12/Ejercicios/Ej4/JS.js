    function recorrerCeldas() {
        const tabla = document.getElementById("miTabla");
        let contenidoCeldas = "";

        // Recorrer todas las filas y celdas de la tabla
        for (let i = 0; i < tabla.rows.length; i++) {
            for (let j = 0; j < tabla.rows[i].cells.length; j++) {
                contenidoCeldas += tabla.rows[i].cells[j].innerText + ", ";
            }
        }
            
        // Eliminar la coma final
        contenidoCeldas = contenidoCeldas.slice(0, -2);

        // Mostrar el contenido de las celdas en un alert
        alert(contenidoCeldas);
};

    function añadirFila() {
        const tabla = document.getElementById("miTabla");
        const nuevaFila = tabla.insertRow(-1); // Insertar una fila al final de la tabla

        // Añadir celdas a la nueva fila
        const celda1 = nuevaFila.insertCell(0);
        const celda2 = nuevaFila.insertCell(1);

        // Asignar contenido a las nuevas celdas
        const nuevaCelda1Contenido = "Celda" + (tabla.rows.length + 1) + "1";
        const nuevaCelda2Contenido = "Celda" + (tabla.rows.length + 1) + "2";

        celda1.innerText = nuevaCelda1Contenido;
        celda2.innerText = nuevaCelda2Contenido;
};

    function borrarFila() {
        const tabla = document.getElementById("miTabla");

        // Verificar que haya al menos dos filas para borrar
        if (tabla.rows.length > 1) {
            tabla.deleteRow(-1); // Borrar la última fila de la tabla
        } else {
            alert("No se pueden borrar más filas.");
        }
    }
