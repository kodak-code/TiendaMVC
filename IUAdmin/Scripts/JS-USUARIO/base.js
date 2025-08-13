
    document.addEventListener('DOMContentLoaded', () => {

        // lista de rutas de scrips del usuario
        const scripts = [
            '/Scripts/JS-USUARIO/datatable.js',
            '/Scripts/JS-USUARIO/modal.js',
            '/Scripts/JS-USUARIO/editar.js',
            '/Scripts/JS-USUARIO/guardar.js',
            '/Scripts/JS-USUARIO/eliminar.js'
        ];

        scripts.forEach(src => {
            const script = document.createElement('script');
            script.src = src; // asigno la ruta del archivo js al atributo src del script
            script.defer = true; // mejora rendimiento ya que espera que todo el html este cargado
            document.body.appendChild(script);
        });
    });