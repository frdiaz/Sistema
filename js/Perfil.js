$(document).ready(function () {
    cargarDatosPrincipales();
    //var hidden = $("[id*='hf_idUsuario']").val();
});

function cargarDatosPrincipales() {
    var data = '{id_usuario:"' + $("[id*='hf_idUsuario']").val() + '"}';
    $.ajax({
        type: "POST",
        url: "Perfil.aspx/cargarDatosPrincipales",
        contentType: "application/json; charset=utf-8",
        data: data,
        datatype: "jason",
        success: function (result) {
            var campos = result.d;
            campos = campos.split(",");

            var array = JSON.parse("[" + campos + "]");
            $.each(array, function (index, item) {
                document.getElementById('txtNombre').value = item.nombre + " " + item.apellidoPaterno + " " + item.apellidoMaterno;
                document.getElementById('txtRut').value = item.rut;
                document.getElementById('txtEmail').value = item.email;
                document.getElementById('txtDireccion').value = item.direccion;

                if (item.fono == 0) {
                    document.getElementById('txtFono').value = "";
                }
                else {
                    document.getElementById('txtFono').value = item.fono;
                }
            });
        },
        error: function () {

        }
    });
}

function mostrarAlerta(numeroAlerta, mensaje) {
    if (numeroAlerta == 1) {
        $.toast({
            heading: 'Información',
            text: mensaje,
            hideAfter: 5000,
            icon: 'info',
            loader: true,
            loaderBg: '#9EC600'
        });
    }
    else if (numeroAlerta == 2) {
        $.toast({
            heading: 'Éxito',
            text: mensaje,
            hideAfter: 5000,
            showHideTransition: 'slide',
            icon: 'success',
            loaderBg: '#32CD32'
        });
    }
    else if (numeroAlerta == 3) {
        $.toast({
            heading: 'Error',
            text: mensaje,
            hideAfter: 5000,
            showHideTransition: 'fade',
            icon: 'error'
        });
    }
}

function actualizarPassword() {
    var password1 = document.getElementById('txtPassword1').value;
    var password2 = document.getElementById('txtPassword2').value;

    if (password1 == password2) {
        var data = '{id_usuario:"' + $("[id*='hf_idUsuario']").val() + '", password:"' + password1 + '"}';

        $.ajax({
            type: "POST",
            url: "Perfil.aspx/actualizarPassword",
            contentType: "application/json; charset=utf-8",
            data: data,
            datatype: "jason",
            success: function (result) {
                var resultado = result.d;

                if (resultado == 1) {
                    mostrarAlerta(2, 'Contraseña Actualizada');
                    document.getElementById('txtPassword1').value = '';
                    document.getElementById('txtPassword2').value = '';
                }
                else {
                    mostrarAlerta(3, 'Contraseña NO Actualizada');
                }

            },
            error: function () {
                mostrarAlerta(2, 'Error Interno');
            }
        });
    }
    else {
        mostrarAlerta(3, 'Las contraseñas deben ser iguales');
    }
}

function actualizarDatos() {
    var email = document.getElementById('txtEmail').value;
    var direccion = document.getElementById('txtDireccion').value;
    var fono = document.getElementById('txtFono').value;

    var data = '{id_usuario:"' + $("[id*='hf_idUsuario']").val()
        + '", email:"' + email
        + '", direccion:"' + direccion
        + '",fono:"' + fono + '"}';

    $.ajax({
        type: "POST",
        url: "Perfil.aspx/actualizarDatos",
        contentType: "application/json; charset=utf-8",
        data: data,
        datatype: "jason",
        success: function (result) {
            var resultado = result.d;

            if (resultado == 1) {
                mostrarAlerta(2, 'Datos Actualizados');
                cargarDatosPrincipales();
            }
            else {
                mostrarAlerta(3, 'Datos no Actualizados');
            }
        },
        error: function () {
            mostrarAlerta(2, 'Error Interno');
        }
    });
}