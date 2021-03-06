﻿var informe;
var id_PacienteEditar;
var id_PacienteFichaNutricional;
var id_Ficha;
var id_actulizarFicha = 0;
var id_fichaAnterior = 0;
var edad = 0;

$(document).ready(function () {
    ocultarTodo();
    calcularDiagnostico();
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

    completa = $('#tblCompleta').dataTable({
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
            $('#tblCompleta_wrapper').css('margin-bottom', '40px');
        }
    });
    cargarTipoConsulta();
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
                   "",
                ]);
            }
        },
        error: function () {

        }
    });
}

function historial(id_paciente) {
    ocultarTodo();
    historico_show();

    var data = '{id_paciente:"' + id_paciente + '"}';

    $.ajax({
        type: "POST",
        url: "Pacientes.aspx/cargarDatosHistoricos",
        contentType: "application/json; charset=utf-8",
        datatype: "jason",
        data, data,
        success: function (arg) {
            completa.fnClearTable();
            if (arg.d == "{}" | arg.d == "") {
                return;
            }
            var numero = 0;
            var objeto = arg.d;

            for (var i = objeto.length; i > 0; i--) {
                numero++;
                completa.fnAddData([
                    numero,
                    objeto[i - 1].fecha,
                    objeto[i - 1].peso,
                    objeto[i - 1].talla,
                    objeto[i - 1].cintura,
                    objeto[i - 1].imc
                ]);
            }
            cargarGrafico(objeto);

        },
        error: function () {

        }
    });
}

function cargarGrafico(objeto) {
    var valorObjeto = new Object();

    valorObjeto.uno = "";
    valorObjeto.dos = "";
    valorObjeto.tres = "";
    valorObjeto.cuatro = "";
    valorObjeto.cinco = "";
    valorObjeto.seis = "";

    var fechaObjeto = new Object();

    fechaObjeto.fecha1 = "";
    fechaObjeto.fecha2 = "";
    fechaObjeto.fecha3 = "";
    fechaObjeto.fecha4 = "";
    fechaObjeto.fecha5 = "";
    fechaObjeto.fecha6 = "";

    var cinturaObjeto = new Object();

    cinturaObjeto.cintura1 = "";
    cinturaObjeto.cintura2 = "";
    cinturaObjeto.cintura3 = "";
    cinturaObjeto.cintura4 = "";
    cinturaObjeto.cintura5 = "";
    cinturaObjeto.cintura6 = "";

    var i = 0;
    var cantidad = 0;
    var a = 0;

    for (i = objeto.length; i > 0; i--) {
        var numero = objeto[i - 1].peso;
        var cintura = objeto[i - 1].cintura;
        var fecha = objeto[i - 1].fecha;
        numero = numero.replace(",", ".");
        if (cantidad == 0) {
            valorObjeto.seis = numero;
            fechaObjeto.fecha6 = fecha;
            cinturaObjeto.cintura6 = cintura;
        } else if (cantidad == 1) {
            valorObjeto.cinco = numero;
            fechaObjeto.fecha5 = fecha;
            cinturaObjeto.cintura5 = cintura;
        } else if (cantidad == 2) {
            valorObjeto.cuatro = numero;
            fechaObjeto.fecha4 = fecha;
            cinturaObjeto.cintura4 = cintura;
        } else if (cantidad == 3) {
            valorObjeto.tres = numero;
            fechaObjeto.fecha3 = fecha;
            cinturaObjeto.cintura3 = cintura;
        } else if (cantidad == 4) {
            valorObjeto.dos = numero;
            fechaObjeto.fecha2 = fecha;
            cinturaObjeto.cintura2 = cintura;
        } else if (cantidad == 5) {
            valorObjeto.uno = numero;
            fechaObjeto.fecha1 = fecha;
            cinturaObjeto.cintura1 = cintura;
        }
        cantidad++;
    }


    Highcharts.chart('container', {
        title: {
            text: 'Resumen de Peso'
        },
        //subtitle: {
        //    text: 'Source: thesolarfoundation.com'
        //},
        yAxis: {
            title: {
                text: 'Peso en Kilogramos'
            }
        },
        legend: {
            layout: 'vertical',
            align: 'right',
            verticalAlign: 'middle'
        },
        //plotOptions: {
        //    series: {
        //        label: {
        //            connectorAllowed: false
        //        },
        //        pointStart: 2010
        //    }
        //}, + "Kg"
        xAxis: {
            categories: [fechaObjeto.fecha1, fechaObjeto.fecha2, fechaObjeto.fecha3, fechaObjeto.fecha4, fechaObjeto.fecha5, fechaObjeto.fecha6]
        },
        series: [{
            name: 'Peso',
            data: [[parseFloat(valorObjeto.uno)], [parseFloat(valorObjeto.dos)], [parseFloat(valorObjeto.tres)], [parseFloat(valorObjeto.cuatro)], [parseFloat(valorObjeto.cinco)], [parseFloat(valorObjeto.seis)]]
        },
        //{
        //    name: 'Cintura',
        //    data: [[parseFloat(cinturaObjeto.cintura1)], [parseFloat(cinturaObjeto.cintura2)], [parseFloat(cinturaObjeto.cintura3)], [parseFloat(cinturaObjeto.cintura4)], [parseFloat(cinturaObjeto.cintura5)], [parseFloat(cinturaObjeto.cintura6)]]
        //}
        ],
        responsive: {
            rules: [{
                condition: {
                    maxWidth: 500
                },
                chartOptions: {
                    legend: {
                        layout: 'horizontal',
                        align: 'center',
                        verticalAlign: 'bottom'
                    }
                }
            }]
        }
    });

    Highcharts.chart('container2', {
        title: {
            text: 'Resumen de Cintura'
        },
        yAxis: {
            title: {
                text: 'Cintura en Centimetros'
            }
        },
        legend: {
            layout: 'vertical',
            align: 'right',
            verticalAlign: 'middle'
        },
        xAxis: {
            categories: [fechaObjeto.fecha1, fechaObjeto.fecha2, fechaObjeto.fecha3, fechaObjeto.fecha4, fechaObjeto.fecha5, fechaObjeto.fecha6]
        },
        series: [{
            name: 'Cintura',
            data: [[parseFloat(cinturaObjeto.cintura1)], [parseFloat(cinturaObjeto.cintura2)], [parseFloat(cinturaObjeto.cintura3)], [parseFloat(cinturaObjeto.cintura4)], [parseFloat(cinturaObjeto.cintura5)], [parseFloat(cinturaObjeto.cintura6)]]
        }],
        responsive: {
            rules: [{
                condition: {
                    maxWidth: 500
                },
                chartOptions: {
                    legend: {
                        layout: 'horizontal',
                        align: 'center',
                        verticalAlign: 'bottom'
                    }
                }
            }]
        }
    });
}

function historico_show() {
    document.getElementById('dvVerHistorico').style.display = "block";
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
                    ocultarTodo();
                    Pacientes_show();
                    cargarPacientes();
                    vaciarCampos();
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

function vaciarCampos()
{
    document.getElementById('txtRut').value = "";
    document.getElementById('txtNombre').value = "";
    document.getElementById('txtApellidoPaterno').value = "";
    document.getElementById('txtApellidoMaterno').value = "";
    document.getElementById('txtFechaNacimiento').value = "";
    document.getElementById('slSexo').value = "";
    document.getElementById('txtEmail').value = "";
    document.getElementById('txtFono').value = "";
}

function cargarTablaResumen(id_paciente) {
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
    var tipoConsulta = document.getElementById('slTipoConsultaNuevo').value;
    var anamnesis = document.getElementById('txtAnamnesis').value;
    var diagnostico = document.getElementById('txtDiagnostico').value;
    var indicaciones = document.getElementById('txtIndicaciones').value;

    if (peso != "" && talla != "" && imc != "" && alcohol != "" && tabaco != "" && tipoConsulta != "" && anamnesis != ""
        && diagnostico != "" && indicaciones != "") {
        var data = '{id:"' + id_PacienteFichaNutricional
            + '", id_ficha:"' + id_actulizarFicha
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
                if (respuesta > 0) {
                    mostrarAlerta(2, 'Ficha Insertada');
                    cargarTablaResumen(id_PacienteFichaNutricional);
                    id_actulizarFicha = respuesta;
                    //Pacientes_show();
                }
                else {
                    mostrarAlerta(3, 'Ficha NO Insertada');
                    id_actulizarFicha = 0;
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
    id_actulizarFicha = 0;
    borrarDatos();
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
    document.getElementById('dvVerHistorico').style.display = "none";
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
    else {
        document.getElementById('txtIMC').value = "0";
    }
    setTimeout('actualizarIMC()', 1000);
}

function actualizarResumenIMC() {

    var peso = document.getElementById('txtResumenPeso').value;
    var talla = document.getElementById('txtResumenTalla').value;
    var imc;

    if (peso != "" && talla != "") {
        imc = peso / (talla * talla);
        document.getElementById('txtResumenIMC').value = imc.toFixed(2);
    }
    else {
        document.getElementById('txtResumenIMC').value = "0";
    }
    setTimeout('actualizarResumenIMC()', 1000);
}

function ingresarFicha(id_Paciente) {
    ocultarTodo();
    document.getElementById('dvResumen').style.display = "block";
    document.getElementById('dvFichaNutricional').style.display = "block";
    document.getElementById('dvVerResumen').style.display = "none";

    id_PacienteFichaNutricional = id_Paciente;
    cargarTablaResumen(id_Paciente);
    datosPrincipales(id_Paciente);

    setTimeout('actualizarIMC()', 1000);
}

function datosPrincipales(id) {
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
                document.getElementById('lblResumenNombre').innerText = 'Nombre: ' + objeto[i].nombre + ' ' + objeto[i].apellidoPaterno + ' ' + objeto[i].apellidoMaterno,
                document.getElementById('lblResumenEdad').innerText = 'Edad: ' + objeto[i].edad + ' años',
                edad = objeto[i].edad
            }
        },
        error: function () {

        }
    });
}

function calcularDiagnostico() {
    var imc = document.getElementById('txtIMC').value;
    imc = parseFloat(imc);

    if (edad > 0 && imc > 0) {
        if (edad > 17 && edad < 65) {
            if (imc < parseFloat('18,5')) {
                document.getElementById('txtDiagnostico').value = "Bajo Peso";
                console.log("1");
            } else if (imc > parseFloat('18,4') && imc < parseFloat('25')) {
                document.getElementById('txtDiagnostico').value = "Normal";
                console.log("2");
            } else if (imc < parseFloat('30')) {
                document.getElementById('txtDiagnostico').value = "Sobre Peso";
                console.log("3");
            } else if (imc >= parseFloat('30') && imc <= parseFloat('34,9')) {
                document.getElementById('txtDiagnostico').value = "Obesidad Moderada";
                console.log("4");
            } else if (imc >= parseFloat('35') && imc <= parseFloat('40')) {
                document.getElementById('txtDiagnostico').value = "Obesidad Severa";
                console.log("4");
            } else if (imc > parseFloat('40')) {
                document.getElementById('txtDiagnostico').value = "Obesidad Morbida";
                console.log("5");
            }
        }
    }
    setTimeout('calcularDiagnostico()', 1000);
}

function detalleFicha(id_Ficha) {
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
                   document.getElementById('slTipoConsultaEditar').value = objeto[i].idTipoConsulta,
                   id_fichaAnterior = objeto[i].id
                ]);
            }
        },
        error: function () {

        }
    });
}

function ocultarDetalleFicha() {
    document.getElementById('dvResumen').style.display = "block";
    document.getElementById('dvVerResumen').style.display = "none";
}

function cargarTipoConsulta() {
    $.ajax({
        type: "POST",
        url: "Pacientes.aspx/cargarTipoConsulta",
        contentType: "application/json; charset=utf-8",
        datatype: "jason",
        success: function (arg) {
            informe.fnClearTable();
            if (arg.d == "{}" | arg.d == "") {
                return;
            }

            var objeto = arg.d;
            for (var i = 0; i < objeto.length; i++) {
                var perfil = document.getElementById("slTipoConsultaNuevo");
                var option = document.createElement("option");
                option.text = objeto[i].nombre;
                option.value = objeto[i].id;
                perfil.add(option, perfil[i]);
            }

            for (var i = 0; i < objeto.length; i++) {
                var perfil = document.getElementById("slTipoConsultaEditar");
                var option = document.createElement("option");
                option.text = objeto[i].nombre;
                option.value = objeto[i].id;
                perfil.add(option, perfil[i]);
            }
        },
        error: function () {

        }
    });
}

function editarFicha() {
    actualizarResumenIMC();
    document.getElementById('txtResumenPeso').disabled = false;
    document.getElementById('txtResumenTalla').disabled = false;
    document.getElementById('txtResumenCintura').disabled = false;
    document.getElementById('txtResumenIMC').disabled = true;
    document.getElementById('txtResumenAlcohol').disabled = false;
    document.getElementById('txtResumenTabaco').disabled = false;
    document.getElementById('txtResumenAnamnesis').disabled = false;
    document.getElementById('txtResumenDiagnostico').disabled = true;
    document.getElementById('txtResumenIndicaciones').disabled = false;
    document.getElementById('h3FechaResumen').disabled = false;
    document.getElementById('slTipoConsultaEditar').disabled = false;
    document.getElementById('btnGuardarFichaAnterior').disabled = false;
}

function bloquearCampos() {
    document.getElementById('txtResumenPeso').disabled = true;
    document.getElementById('txtResumenTalla').disabled = true;
    document.getElementById('txtResumenCintura').disabled = true;
    document.getElementById('txtResumenIMC').disabled = true;
    document.getElementById('txtResumenAlcohol').disabled = true;
    document.getElementById('txtResumenTabaco').disabled = true;
    document.getElementById('txtResumenAnamnesis').disabled = true;
    document.getElementById('txtResumenDiagnostico').disabled = true;
    document.getElementById('txtResumenIndicaciones').disabled = true;
    document.getElementById('slTipoConsultaEditar').disabled = true;
    document.getElementById('btnGuardarFichaAnterior').disabled = true;
}

function borrarDatos() {
    document.getElementById('txtPeso').value = "";
    document.getElementById('txtTalla').value = "";
    document.getElementById('txtCintura').value = "";
    document.getElementById('txtIMC').value = "";
    document.getElementById('txtAlcohol').value = "";
    document.getElementById('txtTabaco').value = "";
    document.getElementById('txtAnamnesis').value = "";
    document.getElementById('txtDiagnostico').value = "";
    document.getElementById('txtIndicaciones').value = "";
}

function guardarYCerrar() {
    insertarFichaNutricional();
    //Pacientes_show();
    id_actulizarFicha = 0;
}

function actualizarFichaAnterior() {
    var peso = document.getElementById('txtResumenPeso').value;
    var talla = document.getElementById('txtResumenTalla').value;
    var cintura = document.getElementById('txtResumenCintura').value;
    var imc = document.getElementById('txtResumenIMC').value;
    var alcohol = document.getElementById('txtResumenAlcohol').value;
    var tabaco = document.getElementById('txtResumenTabaco').value;
    var tipoConsulta = document.getElementById('slTipoConsultaEditar').value;
    var anamnesis = document.getElementById('txtResumenAnamnesis').value;
    var diagnostico = document.getElementById('txtResumenDiagnostico').value;
    var indicaciones = document.getElementById('txtResumenIndicaciones').value;

    if (peso != "" && talla != "" && imc != "" && alcohol != "" && tabaco != "" && tipoConsulta != "" && anamnesis != ""
        && diagnostico != "" && indicaciones != "") {
        var data = '{id_ficha:"' + id_fichaAnterior
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
            url: "Pacientes.aspx/actualizarFichaAnterior",
            contentType: "application/json; charset=utf-8",
            datatype: "jason",
            data: data,
            success: function (result) {
                var respuesta = result.d;
                if (respuesta = true) {
                    mostrarAlerta(2, 'Ficha Actualizada');
                    cargarTablaResumen(id_PacienteFichaNutricional);
                    bloquearCampos();
                    ocultarDetalleFicha();
                }
                else {
                    mostrarAlerta(3, 'Ficha NO Actualizada');
                    id_fichaAnterior = 0;
                }
            },
            error: function () {
                mostrarAlerta(3, 'Ficha NO Actualizada, Problemas internos');
                id_fichaAnterior = 0;
            }
        });
    }
    else {
        mostrarAlerta(3, "Faltan campos por completar");
    }
}