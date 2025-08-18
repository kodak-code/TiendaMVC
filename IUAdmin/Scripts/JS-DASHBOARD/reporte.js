
    async function cargarReportes() {

        try {

            const response = await fetch('/Home/VerReporte');

            if (!response.ok) {
                throw new Error(`Error HTPP:${response.status}`);
            }

            const data = await response.json();

            if (data) {
                return data.data[0];
            }
            else {
                console.warn("No hay reportes")
            }

        } catch (error) {
            console.log(error);
        }

    }

    async function mostrarReportes() {

        const cantidadClientes = document.getElementById("totalClientes");
        const cantidadVentas = document.getElementById("totalVentas");
        const cantidadProductos = document.getElementById("totalProductos");

        const { TotalCliente, TotalVenta, TotalProducto } = await cargarReportes();

        cantidadClientes.textContent = TotalCliente;
        cantidadVentas.textContent = TotalVenta;
        cantidadProductos.textContent = TotalProducto;

    }
    mostrarReportes();
