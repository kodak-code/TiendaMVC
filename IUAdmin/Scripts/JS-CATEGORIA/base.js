
    document.addEventListener('DOMContentLoaded', () => {

        const scripts = [
            '/Scripts/JS-CATEGORIA/datatable.js',
            '/Scripts/JS-CATEGORIA/modal.js',
            '/Scripts/JS-CATEGORIA/editar.js',
            '/Scripts/JS-CATEGORIA/guardar.js',
            '/Scripts/JS-CATEGORIA/eliminar.js'
        ];

        scripts.forEach(src => {
            const script = document.createElement('script');
            script.src = src; 
            script.defer = true; 
            document.body.appendChild(script);
        });
    });