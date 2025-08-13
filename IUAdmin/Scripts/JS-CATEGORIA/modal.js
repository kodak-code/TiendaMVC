
    const btnCrearCategoria = document.getElementById("crearNuevo");

    if (btnCrearCategoria) {

        btnCrearCategoria.addEventListener("click", () => abrirModal(null));
    }

    function abrirModal(json) {

        $("#id").val(0);
        $("#descripcion").val("");
        $("#activo").val(1);
        $("#msjError").hide();

        if (json != null) {

            $("#id").val(json.IdCategoria);
            $("#descripcion").val(json.Descripcion);
            $("#activo").val(json.Activo == true ? 1 : 2);
        }

        $("#FormModal").modal("show");
    }