
    const btnCrearMarca = document.getElementById("crearNuevo");

    if (btnCrearMarca) {

        btnCrearMarca.addEventListener("click", () => abrirModal(null));
    }

    function abrirModal(json) {

        $("#id").val(0);
        $("#descripcion").val("");
        $("#activo").val(1);
        $("#msjError").hide();

        if (json != null) {

            $("#id").val(json.IdMarca);
            $("#descripcion").val(json.Descripcion);
            $("#activo").val(json.Activo == true ? 1 : 2);
        }

        $("#FormModal").modal("show");
    }