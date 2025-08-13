
	const btnGuardarCategoria = document.getElementById("guardarCategoria");

	if (btnGuardarCategoria) {

		btnGuardarCategoria.addEventListener("click", guardar);
	}

	async function guardar() {

		var Categoria = {
			IdCategoria: $("#id").val(),
			Descripcion: $("#descripcion").val(),
			Activo: $("#activo").val() == 1 ? true : false
		};
		console.log(Categoria);
		try {

			$(".modal-body").LoadingOverlay("show", {
				imageResizeFactor: 2,
				text: "Cargando...",
				size: 14
			});

			const response = await fetch("/Mantenedor/GuardarCategorias", {
				method: "POST",
				headers: {
					"Content-Type": "application/json; charset=utf-8"
				},
				body: JSON.stringify(Categoria)
			});

			const data = await response.json();

			if (Categoria.IdCategoria == 0) {

				// CREAR CATEGORIA 
				if (data.resultado != 0) {
					Categoria.IdCategoria = data.resultado;
					tabledata.row.add(Categoria).draw(false);

					$("#FormModal").modal("hide");
					swal("¡Categoria Creada Exitosamente!", "Presiona OK para continuar", "success");
				} else {
					$("#msjError").text(data.mensaje);
					$("#msjError").show();
				}

			}
			else {
				// EDITAR CATEGORIA
				if (data.resultado) {
					tabledata.row(filaSeleccionada).data(Categoria).draw(false);
					filaSeleccionada = null;

					$("#FormModal").modal("hide");
					swal("¡Categoria Editada Exitosamente!", "Presiona OK para continuar", "success");
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