

	const btnAgregarImagen = document.getElementById("fileProducto");

	if (btnAgregarImagen) {
		btnAgregarImagen.addEventListener("change", function () {
			mostrarImagen(this); 
		});
	}

	function mostrarImagen(input) {

		if (input.files) {

			var reader = new FileReader(); // leer archivos

			reader.onload = function (e) {
				$("#imgProducto").attr("src", e.target.result).width(200).height(197);
			}
			reader.readAsDataURL(input.files[0]);
		}
	}