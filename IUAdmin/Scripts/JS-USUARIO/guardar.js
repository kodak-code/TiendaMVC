
	const btnGuardarUsuario = document.getElementById("guardarUsuario");

	if (btnGuardarUsuario) {

		btnGuardarUsuario.addEventListener("click", guardar);
	}

	async function guardar() {

		var Usuario = {
			IdUsuario: $("#id").val(),
			Nombre: $("#nombre").val(),
			Apellido: $("#apellido").val(),
			Correo: $("#correo").val(),
			Activo: $("#activo").val() == 1 ? true : false
		};

		try {

			$(".modal-body").LoadingOverlay("show", {
				imageResizeFactor: 2,
				text: "Cargando...",
				size: 14
			});

			const response = await fetch("/Home/GuardarUsuarios", {
				method: "POST",
				headers: {
					"Content-Type": "application/json; charset=utf-8"
				},
				body: JSON.stringify(Usuario)
			});

			const data = await response.json();

			if (Usuario.IdUsuario == 0) {

				// CREAR USUARIO 
				if (data.resultado != 0) {
					Usuario.IdUsuario = data.resultado;
					tabledata.row.add(Usuario).draw(false);

					$("#FormModal").modal("hide");
					swal("¡Usuario Creado Exitosamente!", "Presiona OK para continuar", "success");
				} else {
					$("#msjError").text(data.mensaje);
					$("#msjError").show();
				}

			}
			else {
				// EDITAR USUARIO
				if (data.resultado) {
					tabledata.row(filaSeleccionada).data(Usuario).draw(false);
					filaSeleccionada = null;
					
					$("#FormModal").modal("hide");
					swal("¡Usuario Editado Exitosamente!", "Presiona OK para continuar", "success");
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