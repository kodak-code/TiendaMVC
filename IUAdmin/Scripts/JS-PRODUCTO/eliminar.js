
	$("#tabla tbody").on("click", '.btn-eliminar', function () {

		var productoSeleccionado = $(this).closest("tr");

		var data = tabledata.row(productoSeleccionado).data();
		console.log(data);
		swal({
			title: "¿Esta Seguro?",
			text: "¿Queres Desactivar el Producto?",
			type: "warning",
			showCancelButton: true,
			confirmButtonClass: "btn-primary",
			confirmButtonText: "Si",
			cancelButtonText: "No",
			closeOnConfirm: true
		},
			async function () {
				try {
					const response = await fetch("/Mantenedor/DesactivarProducto", {
						method: "POST",
						headers: {
							"Content-Type": "application/json; charset=utf-8"
						},
						body: JSON.stringify({ id: data.IdProducto })

					});

					if (!response.ok) {
						throw new Error("Error al realizar la solicitud al servidor.")
					}

					const result = await response.json();

					if (result.resultado) {
						data.Activo = false;
						tabledata.row(productoSeleccionado).data(data).draw(false);
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