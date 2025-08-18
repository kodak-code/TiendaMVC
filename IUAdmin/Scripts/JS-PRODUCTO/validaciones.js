
    jQuery.validator.addMethod("preciodecimal", function (value, element) {
        return this.optional(element) || /^\d+(\.\d{1,2})?$/.test(value);
    }, "El formato correcto del precio es ##.##");


    $("#contenedorProducto").validate({
        rules: {
            nombre: {
                required: true
            },
            descripcion: {
                required: true
            },
            precio: {
                required: true,
                preciodecimal: true
            },
            stock: {
                required: true,
                number: true
            }
        },
        messages: {
            nombre: "- El campo nombre es obligatorio",
            descripcion: "- El campo descripcion es obligatorio",
            precio: {
                required: "- El campo precio es obligatorio",
                preciodecimal: "- El formato correcto del precio es ##.##"
            },
            stock: {
                required: "- El campo stock es obligatorio",
                preciodecimal: "- Debe ingresar solo numeros en el stock"
            }
        },
        errorElement: "div",
        errorLabelContainer: ".alert-danger"
    });


