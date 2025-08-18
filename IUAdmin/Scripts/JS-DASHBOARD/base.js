
document.addEventListener('DOMContentLoaded', () => {

    const scripts = [
        '/Scripts/JS-DASHBOARD/historialVenta.js',
        '/Scripts/JS-DASHBOARD/reporte.js'
    ];

    scripts.forEach(src => {
        const script = document.createElement('script');
        script.src = src;
        script.defer = true;
        document.body.appendChild(script);
    });
});