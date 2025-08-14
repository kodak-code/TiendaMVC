
	$("#tabla tbody").on("click", '.btn-eliminar', function () {

		var marcaSeleccionada = $(this).closest("tr");

		var data = tabledata.row(marcaSeleccionada).data();
		console.log(data);
		swal({
			title: "¿Esta Seguro?",
			text: "¿Queres Desactivar la Marca?",
			type: "warning",
			showCancelButton: true,
			confirmButtonClass: "btn-primary",
			confirmButtonText: "Si",
			cancelButtonText: "No",
			closeOnConfirm: true
		},
			async function () {
				try {
					const response = await fetch("/Mantenedor/DesactivarMarca", {
						method: "POST",
						headers: {
							"Content-Type": "application/json; charset=utf-8"
						},
						body: JSON.stringify({ id: data.IdMarca })

					});

					if (!response.ok) {
						throw new Error("Error al realizar la solicitud al servidor.")
					}

					const result = await response.json();

					if (result.resultado) {
						data.Activo = false;
						tabledata.row(marcaSeleccionada).data(data).draw(false);
					} else {
						Swal.fire({
							icon: "error",
							title: "No se pudo eliminar",
							text: result.mensaje
						});
					}

				} catch (error) {
					$("#msjError").text("Error con fetch");
					swal("Error", error, "error");
				}
			});

	});	