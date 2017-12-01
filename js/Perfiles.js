var informe;
var cantidad = "";
var paginaEditar = "";

$(document).ready(function () {
    informe = $('#tblPerfiles').dataTable({
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
            $('#tblPerfiles_wrapper').css('margin-bottom', '40px');
        }
    });

    //FUNCTION AL DAR SELECCION A ALGUN SELECTPICKER
    //$("#slPaginasEditar").change(function () {
    //    //console.log($(this).val());
    //    selectpickerEditar = $(this).val();
    //});

    ocultarTodo();
    Perfiles_show();
    cargarVentanas();
    cargarPerfiles();
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

function nuevoPerfil() {
    //var identificadores;
    //var numero = 0;
    //while (numero < cantidad.length) {
    //    console.log(cantidad[numero]);
    //    numero++;
    //}

    var nombre = document.getElementById('txtNombre').value;
    var descripcion = document.getElementById('txtDescripcion').value;
    var paginas = $('#slPaginas').selectpicker('val');

    if (nombre != "" && descripcion != "" && paginas != "") {
        var data = '{nombre:"' + nombre
            + '",descripcion:"' + descripcion
            + '",paginas:"' + paginas + '"}';
        $.ajax({
            type: "POST",
            url: "Perfiles.aspx/nuevoPerfil",
            contentType: "application/json; charset=utf-8",
            datatype: "jason",
            data: data,
            success: function (result) {
                var respuesta = result.d;
                if (respuesta = true) {
                    mostrarAlerta(2, 'Perfil creado');
                    ocultarTodo();
                    vaciarTodo();
                }
                else {
                    mostrarAlerta(3, 'Perfil no creado');
                }
            },
            error: function () {
                mostrarAlerta(3, 'Perfil no creado');
            }
        });
    }
    else {
        mostrarAlerta(3, "Las contraseñas deben ser iguales");
    }
}

function cargarPerfiles() {
    $.ajax({
        type: "POST",
        url: "Perfiles.aspx/cargarTablaPerfiles",
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
                   objeto[i].descripcion,
                   "<a class='btn btn-app' onclick='editarPerfil(" + objeto[i].id + ");' style='height:30px !important; min-width:1px !important;'><i class='fa fa-edit'></i></a>",
                ]);
            }
        },
        error: function () {

        }
    });
}

function cargarVentanas() {
    $.ajax({
        type: "POST",
        url: "Perfiles.aspx/cargarVentanas",
        contentType: "application/json; charset=utf-8",
        datatype: "jason",
        success: function (arg) {
            informe.fnClearTable();
            if (arg.d == "{}" | arg.d == "") {
                return;
            }

            var objeto = arg.d;
            for (var i = 0; i < objeto.length; i++) {
                var perfil = document.getElementById("slPaginas");
                var option = document.createElement("option");
                option.text = objeto[i].pagina;
                option.value = objeto[i].id;
                perfil.add(option, perfil[i]);
            }
            for (var i = 0; i < objeto.length; i++) {
                var perfilEditar = document.getElementById("slPaginasEditar");
                var option = document.createElement("option");
                option.text = objeto[i].pagina;
                option.value = objeto[i].id;
                perfilEditar.add(option, perfilEditar[i]);
            }
        },
        error: function () {

        }
    });
}

function editarPerfil(id) {
    ocultarTodo();
    paginaEditar = id;
    var data = '{id_perfil:"' + id + '"}';
    var selecciones = new Array();

    $.ajax({
        type: "POST",
        url: "Perfiles.aspx/cargarEditarPerfiles",
        contentType: "application/json; charset=utf-8",
        datatype: "jason",
        data, data,
        success: function (arg) {
            var objeto = arg.d;
            var paginas = "";
            for (var i = 0; i < objeto.length; i++) {
                document.getElementById('txtEditarNombre').value = objeto[i].nombre;
                document.getElementById('txtEditarDescripcion').value = objeto[i].descripcion;
                //document.getElementById('slEstadoEditar').value = objeto[i].estado;
                selecciones[i] = objeto[i].paginas;
            }
            $("#slPaginasEditar").selectpicker('val', [selecciones[0], selecciones[1], selecciones[2], selecciones[3], selecciones[4], selecciones[5], selecciones[6], selecciones[7], selecciones[8], selecciones[9], selecciones[10], selecciones[11], selecciones[12], selecciones[13], selecciones[14], selecciones[15], selecciones[16], selecciones[17], selecciones[18], selecciones[19]]);
        },
        error: function () {

        }
    });
    EditarPerfiles_show();
}

function actualizarPerfil() {
    var nombre = document.getElementById('txtEditarNombre').value;
    var descripcion = document.getElementById('txtEditarDescripcion').value;
    var estado = 1;
    var paginas = $('#slPaginasEditar').selectpicker('val');
    if (nombre != "" && estado != "" && paginas != "") {
        var data = '{id:' + paginaEditar
            + ',nombre:"' + nombre
            + '",descripcion:"' + descripcion
            + '",estado:"' + estado
            + '",paginas:"' + paginas + '"}';

        $.ajax({
            type: "POST",
            url: "Perfiles.aspx/actualizarPerfil",
            contentType: "application/json; charset=utf-8",
            datatype: "jason",
            data: data,
            success: function (result) {
                var respuesta = result.d;
                if (respuesta = true) {
                    mostrarAlerta(2, 'Datos Actualizados');
                    cargarPerfiles();
                    ocultarTodo();
                    Perfiles_show();
                }
                else {
                    mostrarAlerta(3, 'Error interno');
                }
            },
            error: function () {
                mostrarAlerta(3, 'Error interno');
            }
        });
    }
    else {
        mostrarAlerta(3, "Faltan campos por completar");
    }
}

function Perfiles_show() {
    ocultarTodo();
    document.getElementById('dvPerfiles').style.display = "block";
}

function ocultarTodo() {
    document.getElementById('dvPerfiles').style.display = "none";
    document.getElementById('dvNuevoPerfil').style.display = "none";
    document.getElementById('dvEditarPerfil').style.display = "none";
}

function EditarPerfiles_show() {
    ocultarTodo();
    document.getElementById('dvEditarPerfil').style.display = "block";
}

function NuevoPerfil_show() {
    ocultarTodo();
    document.getElementById('dvNuevoPerfil').style.display = "block";
}

function vaciarTodo()
{
    document.getElementById('txtNombre').value = "";
    document.getElementById('txtDescripcion').value = "";
    document.getElementById('slPaginas').value = "";
}