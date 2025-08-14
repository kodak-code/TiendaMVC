
    document.addEventListener('DOMContentLoaded', () => {

        const scripts = [
            '/Scripts/JS-MARCA/datatable.js',
            '/Scripts/JS-MARCA/modal.js',
            '/Scripts/JS-MARCA/editar.js',
            '/Scripts/JS-MARCA/guardar.js',
            '/Scripts/JS-MARCA/eliminar.js'
        ];

        scripts.forEach(src => {
            const script = document.createElement('script');
            script.src = src; 
            script.defer = true; 
            document.body.appendChild(script);
        });
    });