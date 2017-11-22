var informe;
var datatable;

$(document).ready(function () {
    ocultarTodo();
    mensajesEnviados();
    mensajesDisponibles();

    informe = $('#tblHistorico').dataTable({
        language: {
            url: 'bower_components/datatables/locale/es_ES.txt'
        },
        "bPaginate": true,
        "bLengthChange": false,
        "bSort": false,
        "bInfo": false,
        "bAutoWidth": false,
        "bDeferRender": true,
        "bFilter": false,
        "bSort": true,
        "initComplete": function (settings, json) {
            $('#tblHistorico_wrapper').css('margin-bottom', '40px');
        }
    });

    listaMensajesEnviados();
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

function mensajesDisponibles() {
    $.ajax({
        type: "POST",
        url: "CorreoDiario.aspx/mensajesDisponibles",
        contentType: "application/json; charset=utf-8",
        datatype: "jason",
        success: function (result) {
            var resultado = result.d;
            document.getElementById('h3_Disponibles').innerHTML = resultado;
        },
        error: function () {
        }
    });
}

function mensajesEnviados() {
    $.ajax({
        type: "POST",
        url: "CorreoDiario.aspx/mensajesEnviados",
        contentType: "application/json; charset=utf-8",
        datatype: "jason",
        success: function (result) {
            var resultado = result.d;
            document.getElementById('h3_Enviados').innerHTML = resultado;
        },
        error: function () {
        }
    });
}

function enviarMensaje() {
    $("#btnEnviarMensaje").prop("disabled", true);
    mostrarAlerta(1, 'Enviando mensaje');
    $.ajax({
        type: "POST",
        url: "CorreoDiario.aspx/enviarMensaje",
        contentType: "application/json; charset=utf-8",
        datatype: "jason",
        success: function (result) {
            var resultado = result.d;
            if (resultado = true) {
                mensajesEnviados();
                mensajesDisponibles();
                listaMensajesEnviados();
                mostrarAlerta(2, 'Mensaje enviado correctamente');
                $("#btnEnviarMensaje").removeAttr('disabled');
            }
        },
        error: function () {
            mostrarAlerta(3, 'Error al enviar el mensaje');
            $("#btnEnviarMensaje").removeAttr('disabled');
        }
    });
}

function listaMensajesEnviados() {
    $.ajax({
        type: "POST",
        url: "CorreoDiario.aspx/listaMensajesEnviados",
        contentType: "application/json; charset=utf-8",
        datatype: "jason",
        success: function (arg) {
            informe.fnClearTable();
            if (arg.d == "{}" | arg.d == "") {
                return;
            }

            var objeto = arg.d;
            for (var i = 0; i < objeto.length; i++) {
                informe.fnAddData([
                   objeto[i].fecha,
                   objeto[i].hora,
                   objeto[i].mensaje
                ]);
            }
        },
        error: function () {

        }
    });
}

function nuevoMensaje() {
    var Mensaje = document.getElementById('txtMensaje').value;
    var data = '{mensaje:"' + Mensaje + '"}';

    if (Mensaje != '') {
        $.ajax({
            type: "POST",
            url: "CorreoDiario.aspx/nuevoMensaje",
            contentType: "application/json; charset=utf-8",
            datatype: "jason",
            data: data,
            success: function (result) {
                var respuesta = result.d;
                if (respuesta = true) {
                    mostrarAlerta(2, 'Mensaje creado');
                    mensajesDisponibles();
                    mensajesEnviados();
                    document.getElementById('txtMensaje').value = '';
                }
                else {
                    mostrarAlerta(3, 'Mensaje no creado');
                }
            },
            error: function () {
                mostrarAlerta(3, 'Mensaje no creado');
            }
        });
    }
    else {
        mostrarAlerta(1, 'Falta Ingresar Mensaje a Enviar.');
    }
}

function ocultarTodo() {
    document.getElementById('dvResumen').style.display = "none";
    document.getElementById('dvNuevoMensaje').style.display = "none";
    document.getElementById('dvTablaMensajesEnviados').style.display = "none";
}

function tablaMensajesEnviados_show() {
    ocultarTodo();
    document.getElementById('dvTablaMensajesEnviados').style.display = "block";
}

function nuevoMensaje_show() {
    ocultarTodo();
    document.getElementById('dvResumen').style.display = "block";
    document.getElementById('dvNuevoMensaje').style.display = "block";
}