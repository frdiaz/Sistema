var informe;

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
    ocultarTodo();
    Perfiles_show();
    cargarPerfiles();
});

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

function editarPerfil(id)
{
    ocultarTodo();
    EditarPerfiles_show();
}

function actualizarPerfil()
{

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