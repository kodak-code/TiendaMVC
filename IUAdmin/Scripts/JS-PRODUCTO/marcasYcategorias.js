
	async function categorias() {

		try {
			const selectCategoria = document.getElementById("categoria");
			const response = await fetch('/Mantenedor/ListarCategorias');

			if (!response.ok) {
				throw new Error(`Error HTTP: ${response.status}`);
			}

			// mejorar legibilidad con destructuring
			const { data } = await response.json();

			console.log({ data });

			if (Array.isArray(data) && data.length > 0) {

				data.forEach(({ IdCategoria, Descripcion }) => {
					const option = document.createElement("option");
					option.value = IdCategoria;
					option.textContent = Descripcion;
					selectCategoria.appendChild(option);
				});
			} else {
				console.warn("No se encontraron marcas.");
			}

		} catch (error) {
			console.log(`Error al cargar marcas ${error}`);
		}

	}

	async function marcas() {

		try {
			const selectMarca = document.getElementById("marca");
			const response = await fetch('/Mantenedor/ListarMarcas');

			if (!response.ok) {
				throw new Error(`Error HTTP: ${response.status}`);
			}

			const { data } = await response.json();

			console.log({ data });

			if (Array.isArray(data) && data.length > 0) {
				data.forEach(({ IdMarca, Descripcion }) => {
					const option = document.createElement("option");
					option.value = IdMarca;
					option.textContent = Descripcion;
					selectMarca.appendChild(option);
				});
			} else {
				console.warn("No se encontraron marcas");
			}

		} catch (error) {
			console.log(`Error al cargar marcas ${error}`);
		}

	}

	marcas();
	categorias();