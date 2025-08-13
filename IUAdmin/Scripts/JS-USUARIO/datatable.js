﻿
    tabledata = $('#tabla').DataTable({
        responsive: true,
        ordening: false,
        "ajax": {
            "url": urlListarUsuarios,
            "type": "GET",
            "datatype": "json",
            "complete": function () {
                $('#tabla').DataTable().columns.adjust().draw();
            }
        },
        "columns": [
            { "data": "Nombre" },
            { "data": "Apellido" },
            { "data": "Correo" },
            {
                "data": "Activo",
                "render": function (valor) {
                    return valor ? '<span class="badge bg-success"> SI</span>' : '<span class="badge bg-danger"> NO</span>'
                }
            },
            {
                "data": null,
                "defaultContent": '<div class="btn-group">' +
                    '<button class="btn btn-primary btn-sm rounded-2 btn-editar"><i class="fas fa-pen"></i></button>' +
                    '<button class="btn btn-danger btn-sm rounded-2 ms-2 btn-eliminar"><i class="fas fa-trash"></i></button>' +
                    '</div>',
                "orderable": false,
                "searchable": false
            }

        ],
        language: {
            url: '//cdn.datatables.net/plug-ins/2.3.1/i18n/es-ES.json',
        }
    });