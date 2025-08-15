                                                                                                                                    
    const btnCrearProducto = document.getElementById("crearNuevo");

    if (btnCrearProducto) {

        btnCrearProducto.addEventListener("click", () => abrirModal(null));
    }

    async function imagenProducto(idProducto) {

        $("#imgProducto").LoadingOverlay("show", {
            imageResizeFactor: 2,
            text: "Cargando imagen...",
            size: 14
        });

        try {
            const response = await fetch('/Mantenedor/ImagenProducto', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ id: idProducto })
            });

            if (!response.ok) {
                throw new Error(`Error HTTP: ${response.status}`)
            }

            const { conversion, textoBase64, extension } = await response.json();

            if (conversion) {
                $("#imgProducto").LoadingOverlay("hide");
                $("#imgProducto").attr({ "src": "data:image/" + extension + ";base64," + textoBase64 });
            } else {
                $("#msjError").show().text("No se pudo convertir la imagen.");
            }
             
        } catch (error) {
            $("#msjError").show().text("Error al mostrar la imagen.");
        } finally {
            $("#imgProducto").LoadingOverlay("hide");
        }

    }



    async function abrirModal(json) {

        $("#id").val(0);
        $("#imgProducto").removeAttr("src"); // limpiar toda imagen q muesta la etiqueta imagen 
        $("#fileProducto").val("");
        $("#nombre").val("");
        $("#descripcion").val("");
        $("#marca").val("");
        $("#categoria").val("");
        $("#precio").val("");
        $("#activo").val(1);
        $("#msjError").hide();

        if (json != null) {

            $("#id").val(json.IdProducto);
            $("#nombre").val(json.Nombre);
            $("#descripcion").val(json.Descripcion);
            $("#marca").val(json.Marca.Descripcion);
            $("#categoria").val(json.Categoria.Descripcion);
            $("#precio").val(json.Precio);
            $("#activo").val(json.Activo == true ? 1 : 2);

            await imagenProducto(json.IdProducto);
        }

        $("#FormModal").modal("show");
    }