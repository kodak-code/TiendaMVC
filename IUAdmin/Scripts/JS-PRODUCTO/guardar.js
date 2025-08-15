
	const btnGuardarProducto = document.getElementById("guardarProducto");

	if (btnGuardarProducto) {

		btnGuardarProducto.addEventListener("click", guardar);
	}

	async function guardar() {

		// validar con jquery
		if (!$("#contenedorProducto").valid()) {
			return;
		}

		// Obtener la imagen
		var imagenSeleccionada = $("#fileProducto")[0].files[0];
		
		var Producto = {
			IdProducto: $("#id").val(),
			Nombre: $("#nombre").val(),
			Descripcion: $("#descripcion").val(),
			Marca: {
				IdMarca: $("#marca option:selected").val(),
				Descripcion: $("#marca option:selected").text()
			},
			Categoria: {
				IdCategoria: $("#categoria option:selected").val(),
				Descripcion: $("#categoria option:selected").text()
			},
			Stock: $("#stock").val(),
			PrecioTexto: $("#precio").val(),
			Precio: $("#precio").val(),
			Activo: $("#activo").val() == 1 ? true : false
		};
		console.log(Producto);

		// Pasar archivos a metodos
		var request = new FormData();
		request.append("objeto", JSON.stringify(Producto)); // el mismo que del controller
		request.append("archivoImagen", imagenSeleccionada);

		try {

			$(".modal-body").LoadingOverlay("show", {
				imageResizeFactor: 2,
				text: "Cargando...",
				size: 14
			});

			const response = await fetch("/Mantenedor/GuardarProducto", {
				method: "POST",
				body: request
			});

			const data = await response.json();

			if (Producto.IdProducto == 0) {
				console.log(data);
				// CREAR PRODUCTO 
				if (data.idGenerado != 0) {
					Producto.IdProducto = data.idGenerado;
					tabledata.row.add(Producto).draw(false);

					$("#FormModal").modal("hide");
					swal("¡Producto Creado Exitosamente!", "Presiona OK para continuar", "success");
				} else {
					alert("ERROR")
					$("#msjError").text(data.mensaje);
					$("#msjError").show();
				}

			}
			else {
				// EDITAR PRODUCTO
				if (data.operacionExitosa) {
					tabledata.row(filaSeleccionada).data(Producto).draw(false);
					filaSeleccionada = null;

					$("#FormModal").modal("hide");
					swal("¡Producto Editado Exitosamente!", "Presiona OK para continuar", "success");
				} else {
					$("#msjError").text(data.mensaje);
					$("#msjError").show();
				}

			}

		} catch (error) {
			$(".modal-body").LoadingOverlay("hide");
			console.log(`Hubo un error ${error}`);
		} finally {
			$(".modal-body").LoadingOverlay("hide");
		}

			}