var informe;
var id_SocioEditar;

$(document).ready(function () {
    ocultarTodo();
    informe = $('#tblSocios').dataTable({
        language: {
            url: 'bower_components/datatables/locale/es_ES.txt'
        },
        "bPaginate": true,
        "bLengthChange": false,
        "bSort": false,
        "bInfo": false,
        "colReorder": true,
        "bAutoWidth": false,
        "bDeferRender": true,
        "bFilter": false,
        "bSort": true,
        "initComplete": function (settings, json) {
            $('#tblUsuarios_wrapper').css('margin-bottom', '40px');
        }
    });
    Socios_show();
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

function cargarSocios() {
    $.ajax({
        type: "POST",
        url: "Socios.aspx/cargarTablaSocios",
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
                   objeto[i].nombre,
                   "<a class='btn btn-app' onclick='editarSocio(" + objeto[i].id + ");' style='height:30px !important; min-width:1px !important;'><i class='fa fa-edit'></i></a>",
                   "<a class='btn btn-app' onclick='ingresarFicha(" + objeto[i].id + ");' style='height:30px !important; min-width:1px !important;'><i class='fa fa-edit'></i></a>",
                   "<a class='btn btn-app' onclick='historial(" + objeto[i].id + ");' style='height:30px !important; min-width:1px !important;'><i class='fa fa-edit'></i></a>",
                ]);
            }
        },
        error: function () {

        }
    });
}

function editarSocio(id) {
    var data = '{id:"' + id + '"}';
    $.ajax({
        type: "POST",
        url: "Socios.aspx/cargarEditarSocios",
        contentType: "application/json; charset=utf-8",
        datatype: "jason",
        data, data,
        success: function (arg) {
            informe.fnClearTable();
            if (arg.d == "{}" | arg.d == "") {
                return;
            }
            var objeto = arg.d;
            for (var i = 0; i < objeto.length; i++) {
                informe.fnAddData([
                    id_SocioEditar = objeto[i].id,
                    document.getElementById('txtRutEditar').value = objeto[i].rut,
                    document.getElementById('txtNombreEditar').value = objeto[i].nombre,
                    document.getElementById('txtApellidoPaternoEditar').value = objeto[i].apellidoPaterno,
                    document.getElementById('txtApellidoMaternoEditar').value = objeto[i].apellidoMaterno,
                    document.getElementById('txtFechaNacimientoEditar').value = objeto[i].fechaNacimiento,
                    document.getElementById('slSexoEditar').value = objeto[i].sexo,
                    document.getElementById('txtFonoEditar').value = objeto[i].fono,
                    document.getElementById('txtEmailEditar').value = objeto[i].email,
                ]);
            }
        },
        error: function () {

        }
    });
    EditarSocio_show();
}

function nuevoSocio() {
    var rut = document.getElementById('txtRut').value;
    var nombre = document.getElementById('txtNombre').value;
    var apellidoPaterno = document.getElementById('txtApellidoPaterno').value;
    var apellidoMaterno = document.getElementById('txtApellidoMaterno').value;
    var fechaNacimiento = document.getElementById('txtFechaNacimiento').value;
    var sexo = document.getElementById('slSexo').value;
    var email = document.getElementById('txtEmail').value;
    var fono = document.getElementById('txtFono').value;

    if (rut != "" && nombre != "" && apellidoPaterno != "" && apellidoMaterno != "" && fechaNacimiento != "" &&
        sexo != "") {
        var data = '{rut:"' + rut
            + '",nombre:"' + nombre
            + '",apellidoPaterno:"' + apellidoPaterno
            + '",apellidoMaterno:"' + apellidoMaterno
            + '",fechaNacimiento:"' + fechaNacimiento
            + '",sexo:"' + sexo
            + '",email: "' + email
            + '",fono:"' + fono + '"}';
        $.ajax({
            type: "POST",
            url: "Socios.aspx/nuevoSocio",
            contentType: "application/json; charset=utf-8",
            datatype: "jason",
            data: data,
            success: function (result) {
                var respuesta = result.d;
                if (respuesta = true) {
                    mostrarAlerta(2, 'Socio Creado');
                    cargarUsuarios();
                    ocultarTodo();
                    vaciarTodo();
                }
                else {
                    mostrarAlerta(3, 'Socio NO Creado');
                }
            },
            error: function () {
                mostrarAlerta(3, 'Socio NO Creado');
            }
        });
    }
    else {
        mostrarAlerta(3, "Faltan campos por completar");
    }
}

function actualizarSocio() {
    var rut = document.getElementById('txtRutEditar').value;
    var nombre = document.getElementById('txtNombreEditar').value;
    var apellidoPaterno = document.getElementById('txtApellidoPaternoEditar').value;
    var apellidoMaterno = document.getElementById('txtApellidoMaternoEditar').value;
    var fechaNacimiento = document.getElementById('txtFechaNacimientoEditar').value;
    var sexo = document.getElementById('slSexoEditar').value;
    var email = document.getElementById('txtEmailEditar').value;
    var fono = document.getElementById('txtFonoEditar').value;

    if (rut != "" && nombre != "" && apellidoPaterno != "" && apellidoMaterno != "" && fechaNacimiento != "" &&
        sexo != "") {
        var data = '{id:"' + id_SocioEditar
            + '",rut:"' + rut
            + '",nombre:"' + nombre
            + '",apellidoPaterno:"' + apellidoPaterno
            + '",apellidoMaterno:"' + apellidoMaterno
            + '",fechaNacimiento:"' + fechaNacimiento
            + '",sexo:"' + sexo
            + '",email:"' + email
            + '",fono:"' + fono + '"}';

        $.ajax({
            type: "POST",
            url: "Socios.aspx/actualizarSocio",
            contentType: "application/json; charset=utf-8",
            datatype: "jason",
            data: data,
            success: function (result) {
                var respuesta = result.d;
                if (respuesta = true) {
                    mostrarAlerta(2, 'Socio Actualizado');
                    cargarSocios();
                    ocultarTodo();
                }
                else {
                    mostrarAlerta(3, 'Socio NO Actualizado');
                }
            },
            error: function () {
                mostrarAlerta(3, 'Socio NO Actualizado');
            }
        });
    }
    else {
        mostrarAlerta(3, "Faltan campos por completar");
    }
}

function Socios_show() {
    ocultarTodo();
    cargarSocios();
    document.getElementById('dvSocios').style.display = "block";
}

function ocultarTodo() {
    document.getElementById('dvNuevoSocio').style.display = "none";
    document.getElementById('dvSocios').style.display = "none";
    document.getElementById('dvEditarSocio').style.display = "none";
    document.getElementById('dvResumen').style.display = "none";
    document.getElementById('dvFichaNutricional').style.display = "none";
}

function nuevoSocio_show() {
    ocultarTodo();
    document.getElementById('dvNuevoSocio').style.display = "block";
}

function EditarSocio_show() {
    ocultarTodo();
    document.getElementById('dvEditarSocio').style.display = "block";
}

function ingresarFicha()
{
    ocultarTodo();
    document.getElementById('dvResumen').style.display = "block";
    document.getElementById('dvFichaNutricional').style.display = "block";
}