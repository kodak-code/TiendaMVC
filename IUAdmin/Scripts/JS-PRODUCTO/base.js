
    document.addEventListener('DOMContentLoaded', () => {

        const scripts = [
            '/Scripts/JS-PRODUCTO/datatable.js',
            '/Scripts/JS-PRODUCTO/modal.js',
            '/Scripts/JS-PRODUCTO/editar.js',
            '/Scripts/JS-PRODUCTO/guardar.js',
            '/Scripts/JS-PRODUCTO/eliminar.js',
            '/Scripts/JS-PRODUCTO/imagen.js',
            '/Scripts/JS-PRODUCTO/marcasYcategorias.js',
            '/Scripts/JS-PRODUCTO/validaciones.js'
        ];

        scripts.forEach(src => {
            const script = document.createElement('script');
            script.src = src; 
            script.defer = true; 
            document.body.appendChild(script);
        });
    });