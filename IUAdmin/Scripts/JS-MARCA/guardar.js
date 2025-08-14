
	const btnGuardarMarca = document.getElementById("guardarMarca");

	if (btnGuardarMarca) {

		btnGuardarMarca.addEventListener("click", guardar);
	}

	async function guardar() {

		var Marca = {
			IdMarca: $("#id").val(),
			Descripcion: $("#descripcion").val(),
			Activo: $("#activo").val() == 1 ? true : false
		};
		console.log(Marca);
		try {

			$(".modal-body").LoadingOverlay("show", {
				imageResizeFactor: 2,
				text: "Cargando...",
				size: 14
			});

			const response = await fetch("/Mantenedor/GuardarMarca", {
				method: "POST",
				headers: {
					"Content-Type": "application/json; charset=utf-8"
				},
				body: JSON.stringify(Marca)
			});

			const data = await response.json();

			if (Marca.IdMarca == 0) {

				// CREAR MARCA 
				if (data.resultado != 0) {
					Marca.IdMarca = data.resultado;
					tabledata.row.add(Marca).draw(false);

					$("#FormModal").modal("hide");
					swal("¡Marca Creada Exitosamente!", "Presiona OK para continuar", "success");
				} else {
					$("#msjError").text(data.mensaje);
					$("#msjError").show();
				}

			}
			else {
				// EDITAR MARCA
				if (data.resultado) {
					tabledata.row(filaSeleccionada).data(Marca).draw(false);
					filaSeleccionada = null;

					$("#FormModal").modal("hide");
					swal("¡Marca Editada Exitosamente!", "Presiona OK para continuar", "success");
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