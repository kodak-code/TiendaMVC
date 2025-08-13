
	$("#tabla tbody").on("click", '.btn-eliminar', function () {

		var categoriaSeleccionada = $(this).closest("tr");

		var data = tabledata.row(categoriaSeleccionada).data();
		console.log(data);
		swal({
			title: "¿Esta Seguro?",
			text: "¿Queres Desactivar la Categoria?",
			type: "warning",
			showCancelButton: true,
			confirmButtonClass: "btn-primary",
			confirmButtonText: "Si",
			cancelButtonText: "No",
			closeOnConfirm: true
		},
			async function () {
				try {
					const response = await fetch("/Mantenedor/DesactivarCategoria", {
						method: "POST",
						headers: {
							"Content-Type": "application/json; charset=utf-8"
						},
						body: JSON.stringify({ id: data.IdCategoria })

					});

					if (!response.ok) {
						throw new Error("Error al realizar la solicitud al servidor.")
					}

					const result = await response.json();

					if (result.resultado) {
						data.Activo = false;
						tabledata.row(categoriaSeleccionada).data(data).draw(false);
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