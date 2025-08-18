
    //Fechas
    $("#fechaInicio").datepicker({ dateFormat: 'dd/mm/yy' }).datepicker('setDate', new Date());
    $("#fechaFin").datepicker({ dateFormat: 'dd/mm/yy' }).datepicker('setDate', new Date());

    tabledata = $('#tablaIndex').DataTable({
        responsive: true,
        ordening: false,
        "ajax": {
            "url": urlVerHistorialVenta,
            "type": "GET",
            "datatype": "json",
            "complete": function () {
                $('#tabla').DataTable().columns.adjust().draw();
            }
        },
        "columns": [
            { "data": "FechaVenta" },
            { "data": "Cliente" },
            { "data": "Producto" },
            { "data": "Precio" },
            { "data": "Cantidad" },
            { "data": "Total" },
            { "data": "IdTransaccion" }
        ],
        language: {
            url: '//cdn.datatables.net/plug-ins/2.3.1/i18n/es-ES.json',
        }
    });