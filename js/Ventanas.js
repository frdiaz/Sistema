$(document).ready(function () {
    ocultarTodo();
});

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

function nuevaVentana() {
    var nombreMenu = document.getElementById('txtNombreMenu').value;
    var URL = document.getElementById('txtURL').value;
    var clas = document.getElementById('txtClass').value;
    var submenu = document.getElementById('txtSubMenu').value;

    if (nombreMenu != "" && URL != "" && clas != "" && submenu != "") {

        var data = '{nombreMenu:"' + nombreMenu
                + '",URL:"' + URL
                + '",clas:"' + clas
                + '",submenu:"' + submenu + '"}';

        $.ajax({
            type: "POST",
            url: "Ventanas.aspx/nuevaVentana",
            contentType: "application/json; charset=utf-8",
            datatype: "jason",
            data: data,
            success: function (result) {
                var respuesta = result.d;
                if (respuesta = true) {
                    mostrarAlerta(2, 'Ventana Creada');
                    ocultarTodo();
                    vaciarCampos(); 
                }
                else {
                    mostrarAlerta(3, 'Ventana no creada');
                }
            },
            error: function () {
                mostrarAlerta(3, 'Ventana no creada');
            }
        });
    }
}

function vaciarCampos()
{
    document.getElementById('txtNombreMenu').value = "";
    document.getElementById('txtURL').value = "";
    document.getElementById('txtClass').value = "";
    document.getElementById('txtSubMenu').value = "";
}

function nuevaVentana_show() {
    ocultarTodo();
    document.getElementById('dvNuevaVentana').style.display = "block";
}

function ocultarTodo() {
    document.getElementById('dvNuevaVentana').style.display = "none";
    //document.getElementById('dvNuevoUsuario').style.display = "none";
    //document.getElementById('dvUsuarios').style.display = "none";
    //document.getElementById('dvEditarUsuario').style.display = "none";
}