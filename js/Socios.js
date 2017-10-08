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

function Socios_show() {
    ocultarTodo();
    cargarSocios();
    document.getElementById('dvSocios').style.display = "block";
}

function ocultarTodo() {
    document.getElementById('dvNuevoSocio').style.display = "none";
    document.getElementById('dvSocios').style.display = "none";
    document.getElementById('dvEditarSocio').style.display = "none";
}

function nuevoSocio_show() {
    ocultarTodo();
    document.getElementById('dvNuevoSocio').style.display = "block";
}

function EditarSocio_show() {
    ocultarTodo();
    document.getElementById('dvEditarSocio').style.display = "block";
}