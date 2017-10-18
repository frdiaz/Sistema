var informe;
var id_PacienteEditar;
var id_PacienteFichaNutricional;
var id_Ficha;

$(document).ready(function () {
    ocultarTodo();
    informe = $('#tblPacientes').dataTable({
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
            $('#tblPacientes_wrapper').css('margin-bottom', '40px');
        }
    });

    fichaResumen = $('#tblResumen1').dataTable({
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
            $('#tblResumen1_wrapper').css('margin-bottom', '40px');
        }
    });
    Pacientes_show();
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

function cargarPacientes() {
    $.ajax({
        type: "POST",
        url: "Pacientes.aspx/cargarTablaPacientes",
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
                   "<a class='btn btn-app' onclick='editarPaciente(" + objeto[i].id + ");' style='height:30px !important; min-width:1px !important;'><i class='fa fa-edit'></i></a>",
                   "<a class='btn btn-app' onclick='ingresarFicha(" + objeto[i].id + ");' style='height:30px !important; min-width:1px !important;'><i class='fa fa-edit'></i></a>",
                   "<a class='btn btn-app' onclick='historial(" + objeto[i].id + ");' style='height:30px !important; min-width:1px !important;'><i class='fa fa-edit'></i></a>",
                ]);
            }
        },
        error: function () {

        }
    });
}

function editarPaciente(id) {
    var data = '{id:"' + id + '"}';
    $.ajax({
        type: "POST",
        url: "Pacientes.aspx/cargarEditarPacientes",
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
                    id_PacienteEditar = objeto[i].id,
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
    EditarPaciente_show();
}

function nuevoPaciente() {
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
            url: "Pacientes.aspx/nuevoPaciente",
            contentType: "application/json; charset=utf-8",
            datatype: "jason",
            data: data,
            success: function (result) {
                var respuesta = result.d;
                if (respuesta = true) {
                    mostrarAlerta(2, 'Paciente Creado');
                    //cargarUsuarios();
                    ocultarTodo();
                    //vaciarTodo();
                }
                else {
                    mostrarAlerta(3, 'Paciente NO Creado');
                }
            },
            error: function () {
                mostrarAlerta(3, 'Paciente NO Creado');
            }
        });
    }
    else {
        mostrarAlerta(3, "Faltan campos por completar");
    }
}

function cargarTablaResumen(id_paciente) {
    //var data = '{id_paciente:"' + id_PacienteFichaNutricional + '"}';
    var data = '{id_paciente:"' + id_paciente + '"}';
    $.ajax({
        type: "POST",
        url: "Pacientes.aspx/cargarTablaFichaResumenPacientes",
        contentType: "application/json; charset=utf-8",
        datatype: "jason",
        data: data,
        success: function (arg) {
            fichaResumen.fnClearTable();
            if (arg.d == "{}" | arg.d == "") {
                return;
            }
            var objeto = arg.d;
            var numero = 1;
            for (var i = 0; i < objeto.length; i++) {
                fichaResumen.fnAddData([
                   numero++,
                   objeto[i].Fecha,
                   objeto[i].Peso.toFixed(2),
                   objeto[i].IMC.toFixed(2),
                   "<a class='btn btn-app' onclick='detalleFicha(" + objeto[i].ID + ");' style='height:30px !important; min-width:1px !important;'><i class='fa fa-edit'></i></a>",
                ]);
            }
        },
        error: function () {

        }
    });
}

function insertarFichaNutricional() {
    var peso = document.getElementById('txtPeso').value;
    var talla = document.getElementById('txtTalla').value;
    var cintura = document.getElementById('txtCintura').value;
    var imc = document.getElementById('txtIMC').value;
    var alcohol = document.getElementById('txtAlcohol').value;
    var tabaco = document.getElementById('txtTabaco').value;
    var tipoConsulta = document.getElementById('slTipoConsulta').value;
    var anamnesis = document.getElementById('txtAnamnesis').value;
    var diagnostico = document.getElementById('txtDiagnostico').value;
    var indicaciones = document.getElementById('txtIndicaciones').value;

    if (peso != "" && talla != "" && imc != "" && alcohol != "" && tabaco != "" && tipoConsulta != "" && anamnesis != ""
        && diagnostico != "" && indicaciones != "") {
        var data = '{id:"' + id_PacienteFichaNutricional
            + '",peso:"' + peso
            + '",talla:"' + talla
            + '",cintura:"' + cintura
            + '",imc:"' + imc
            + '",alcohol:"' + alcohol
            + '",tabaco:"' + tabaco
            + '",tipoConsulta:"' + tipoConsulta
            + '",anamnesis:"' + anamnesis
            + '",diagnostico:"' + diagnostico
            + '",indicaciones:"' + indicaciones + '"}';

        $.ajax({
            type: "POST",
            url: "Pacientes.aspx/insertarFichaNutricional",
            contentType: "application/json; charset=utf-8",
            datatype: "jason",
            data: data,
            success: function (result) {
                var respuesta = result.d;
                if (respuesta = true) {
                    mostrarAlerta(2, 'Ficha Insertada');
                    cargarTablaResumen();
                }
                else {
                    mostrarAlerta(3, 'Ficha NO Insertada');
                }
            },
            error: function () {
                mostrarAlerta(3, 'Ficha NO Insertada, Problemas internos');
            }
        });
    }
    else {
        mostrarAlerta(3, "Faltan campos por completar");
    }
}

function actualizarPaciente() {
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
        var data = '{id:"' + id_PacienteEditar
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
            url: "Pacientes.aspx/actualizarPaciente",
            contentType: "application/json; charset=utf-8",
            datatype: "jason",
            data: data,
            success: function (result) {
                var respuesta = result.d;
                if (respuesta = true) {
                    mostrarAlerta(2, 'Paciente Actualizado');
                    cargarPacientes();
                    ocultarTodo();
                }
                else {
                    mostrarAlerta(3, 'Paciente NO Actualizado');
                }
            },
            error: function () {
                mostrarAlerta(3, 'Paciente NO Actualizado');
            }
        });
    }
    else {
        mostrarAlerta(3, "Faltan campos por completar");
    }
}

function Pacientes_show() {
    ocultarTodo();
    cargarPacientes();
    document.getElementById('dvPacientes').style.display = "block";
}

function ocultarTodo() {
    document.getElementById('dvNuevoPaciente').style.display = "none";
    document.getElementById('dvPacientes').style.display = "none";
    document.getElementById('dvEditarPaciente').style.display = "none";
    document.getElementById('dvResumen').style.display = "none";
    document.getElementById('dvFichaNutricional').style.display = "none";
    document.getElementById('dvVerResumen').style.display = "none";
    //document.getElementById('dvDatos').style.display = "none";
    //document.getElementById('dvIngresarFicha').style.display = "none";

}

function nuevoPaciente_show() {
    ocultarTodo();
    document.getElementById('dvNuevoPaciente').style.display = "block";
}

function EditarPaciente_show() {
    ocultarTodo();
    document.getElementById('dvEditarPaciente').style.display = "block";
}

function actualizarIMC() {
    
    var peso = document.getElementById('txtPeso').value;
    var talla = document.getElementById('txtTalla').value;
    var imc;

    if (peso != "" && talla != "") {
        imc = peso / (talla * talla);
        document.getElementById('txtIMC').value = imc.toFixed(2);
    }
    else
    {
        document.getElementById('txtIMC').value = "0";
    }
    setTimeout('actualizarIMC()', 1000);
}

function ingresarFicha(id_Paciente) {
    ocultarTodo();
    document.getElementById('dvResumen').style.display = "block";
    document.getElementById('dvFichaNutricional').style.display = "block";
    document.getElementById('dvVerResumen').style.display = "none";
    //document.getElementById('dvDatos').style.display = "block";
    //document.getElementById('dvIngresarFicha').style.display = "block";

    id_PacienteFichaNutricional = id_Paciente;
    cargarTablaResumen(id_Paciente);
    setTimeout('actualizarIMC()', 1000);
}

function detalleFicha(id_Ficha)
{
    document.getElementById('dvResumen').style.display = "none";
    document.getElementById('dvVerResumen').style.display = "block";
    var data = '{id_Ficha:"' + id_Ficha + '"}';
    $.ajax({
        type: "POST",
        url: "Pacientes.aspx/cargarFichaResumen",
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
                   id_Ficha = objeto[i].id,
                   document.getElementById('txtResumenPeso').value = objeto[i].peso,      
                   document.getElementById('txtResumenTalla').value = objeto[i].talla,
                   document.getElementById('txtResumenCintura').value = objeto[i].cintura,
                   document.getElementById('txtResumenIMC').value = objeto[i].imc,
                   document.getElementById('txtResumenAlcohol').value = objeto[i].alcohol,
                   document.getElementById('txtResumenTabaco').value = objeto[i].tabaco,
                   document.getElementById('txtResumenAnamnesis').value = objeto[i].anamnesis,
                   document.getElementById('txtResumenDiagnostico').value = objeto[i].diagnostico,
                   document.getElementById('txtResumenIndicaciones').value = objeto[i].indicaciones,
                   document.getElementById('h3FechaResumen').value = objeto[i].fechaRegistro,
                ]);
            }
        },
        error: function () {

        }
    });

}

function ocultarDetalleFicha()
{
    document.getElementById('dvResumen').style.display = "block";
    document.getElementById('dvVerResumen').style.display = "none";
}
