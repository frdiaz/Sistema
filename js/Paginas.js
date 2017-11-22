var id_paginaEditar;

$(document).ready(function () {
    ocultarTodo();

    tblPaginas = $('#tblPaginas').dataTable({
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
            $('#tblPaginas_wrapper').css('margin-bottom', '40px');
        }
    });
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

function vaciarCampos() {
    document.getElementById('txtNombreMenu').value = "";
    document.getElementById('txtURL').value = "";
    document.getElementById('txtClass').value = "";
    document.getElementById('txtSubMenu').value = "";
}

function nuevaPagina_show() {
    ocultarTodo();
    document.getElementById('dvNuevaVentana').style.display = "block";
}

function ocultarTodo() {
    document.getElementById('dvNuevaVentana').style.display = "none";
    document.getElementById('dvTablaPaginas').style.display = "none";
    document.getElementById('dvEditarVentana').style.display = "none";
}

function Paginas_show() {
    ocultarTodo();
    cargarPaginas();
    document.getElementById('dvTablaPaginas').style.display = "block";
}

function editar_show() {
    ocultarTodo();
    document.getElementById('dvEditarVentana').style.display = "block";
}

function editarVentana(id) {
    var data = '{id:"' + id + '"}';
    id_paginaEditar = id;
    $.ajax({
        type: "POST",
        url: "Paginas.aspx/cargarEditarPaginas",
        contentType: "application/json; charset=utf-8",
        datatype: "jason",
        data, data,
        success: function (arg) {
            if (arg.d == "{}" | arg.d == "") {
                return;
            }
            var objeto = arg.d;
            for (var i = 0; i < objeto.length; i++) {
                document.getElementById('txtNombreMenuEditar').value = objeto[i].menu,
                document.getElementById('txtURLEditar').value = objeto[i].url,
                document.getElementById('txtClassEditar').value = objeto[i].clase,
                document.getElementById('txtSubMenuEditar').value = objeto[i].submenu,
                document.getElementById('slEstadoEditar').value = objeto[i].activo
            }
        },
        error: function () {

        }
    });
    editar_show();
}

function cargarPaginas() {
    $.ajax({
        type: "POST",
        url: "Paginas.aspx/cargarTablaPaginas",
        contentType: "application/json; charset=utf-8",
        datatype: "jason",
        success: function (arg) {
            tblPaginas.fnClearTable();
            if (arg.d == "{}" | arg.d == "") {
                return;
            }
            var objeto = arg.d;
            for (var i = 0; i < objeto.length; i++) {
                tblPaginas.fnAddData([
                   objeto[i].menu,
                   objeto[i].submenu,
                   objeto[i].url,
                   objeto[i].activa,
                   objeto[i].clase,
                   "<a class='btn btn-app' onclick='editarVentana(" + objeto[i].id_pagina + ");' style='height:30px !important; min-width:1px !important;'><i class='fa fa-edit'></i></a>",
                   "",
                ]);
            }
        },
        error: function () {

        }
    });
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

function actualizarVentana() {
    var menu = document.getElementById('txtNombreMenuEditar').value;
    var URL = document.getElementById('txtURLEditar').value;
    var activo = document.getElementById('slEstadoEditar').value;
    var clase = document.getElementById('txtClassEditar').value;
    var submenu = document.getElementById('txtSubMenuEditar').value;

    if (menu != "" && URL != "" && activo != "" && clase != "" && submenu != "") {

        var data = '{id_pagina:"' + id_paginaEditar
                + '",menu:"' + menu
                + '",URL:"' + URL
                + '",activo:"' + activo
                + '",clase:"' + clase
                + '",submenu:"' + submenu + '"}';
        $.ajax({
            type: "POST",
            url: "Paginas.aspx/actualizarPagina",
            contentType: "application/json; charset=utf-8",
            datatype: "jason",
            data: data,
            success: function (result) {
                var respuesta = result.d;
                if (respuesta = true) {
                    mostrarAlerta(2, 'Ventana Actualizada');
                    ocultarTodo();
                    vaciarCamposEditar();
                    Paginas_show();
                }
                else {
                    mostrarAlerta(3, 'Ventana no Actualizada');
                }
            },
            error: function () {
                mostrarAlerta(3, 'Ventana no Actualizada');
            }
        });
    }
}

function vaciarCamposEditar() {
    document.getElementById('txtNombreMenuEditar').value = "";
    document.getElementById('txtURLEditar').value = "";
    document.getElementById('txtClassEditar').value = ""
    document.getElementById('txtSubMenuEditar').value = "";
    document.getElementById('slEstadoEditar').value = "";
}