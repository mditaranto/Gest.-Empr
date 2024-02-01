// Definir modelos por marca
  const modelosPorMarca = {
    Toyota: ["Corolla", "Camry", "Rav4"],
    Honda: ["Civic", "Accord", "CR-V"],
    Ford: ["Fiesta", "Focus", "Mustang"]
  };

  // Función para actualizar la lista de modelos según la marca seleccionada
  function actualizarModelos() {
    const marcaSeleccionada = document.getElementById("marca").value;
    const modelos = modelosPorMarca[marcaSeleccionada];
    const modeloDropdown = document.getElementById("modelo");

    // Limpiar la lista de modelos
    modeloDropdown.innerHTML = '<option value="0">Selecciona un modelo</option>';

    // Habilitar o deshabilitar el dropdown de modelos según la selección de la marca
    if (marcaSeleccionada !== "0") {
      modeloDropdown.disabled = false;
      // Agregar modelos a la lista de modelos
      modelos.forEach(function(modelo) {
        const opcion = document.createElement("option");
        opcion.text = modelo;
        opcion.value = modelo;
        modeloDropdown.add(opcion);
      });
    } else {
      modeloDropdown.disabled = true;
    }
  }