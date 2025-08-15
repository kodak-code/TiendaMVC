
	$("#tabla tbody").on("click", '.btn-editar', function () {

		filaSeleccionada = $(this).closest("tr");

		var data = tabledata.row(filaSeleccionada).data();

		console.log(data);
		abrirModal(data);
	});