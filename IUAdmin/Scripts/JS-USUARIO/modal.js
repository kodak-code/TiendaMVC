
    const btnCrearUsuario = document.getElementById("crearNuevo");

    if (btnCrearUsuario) {

        btnCrearUsuario.addEventListener("click", () => abrirModal(null));
    }

    function abrirModal(json) {

        $("#id").val(0);
        $("#nombre").val("");
        $("#apellido").val("");
        $("#correo").val("");
        $("#activo").val(1);
        $("#msjError").hide();


        if (json != null) {

            $("#id").val(json.IdUsuario);
            $("#nombre").val(json.Nombre);
            $("#apellido").val(json.Apellido);
            $("#correo").val(json.Correo);
            $("#activo").val(json.Activo == true ? 1 : 2);
        }

        $("#FormModal").modal("show");
    }