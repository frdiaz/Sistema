var informe;
var id_usuarioEditar;

$(document).ready(function () {
    ocultarTodo();
    cargarPerfiles();
    informe = $('#tblUsuarios').dataTable({
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
    Usuarios_show();
});

function cargarUsuarios() {
    $.ajax({
        type: "POST",
        url: "Usuarios.aspx/cargarTablaUsuarios",
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
                   objeto[i].rut,
                   objeto[i].nombre,
                   objeto[i].email,
                   objeto[i].activo,
                   "<a class='btn btn-app' onclick='editarUsuario(" + objeto[i].id + ");' style='height:30px !important; min-width:1px !important;'><i class='fa fa-edit'></i></a>",
                ]);
            }
        },
        error: function () {

        }
    });
}

function editarUsuario(id) {
    var data = '{id:"' + id + '"}';
    $.ajax({
        type: "POST",
        url: "Usuarios.aspx/cargarEditarUsuarios",
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
                   id_usuarioEditar = objeto[i].id,
                   document.getElementById('txtNombreEditar').value = objeto[i].nombre,
                   document.getElementById('txtApellidoPaternoEditar').value = objeto[i].apellidoPaterno,
                   document.getElementById('txtApellidoMaternoEditar').value = objeto[i].apellidoMaterno,
                   document.getElementById('txtRutEditar').value = objeto[i].rut,
                   document.getElementById('txtEmailEditar').value = objeto[i].email,
                   document.getElementById('txtDireccionEditar').value = objeto[i].direccion,
                   document.getElementById('txtFonoEditar').value = objeto[i].fono,
                   document.getElementById('slPerfilEditar').value = objeto[i].rol,
                   document.getElementById('slEstadoEditar').value = objeto[i].activo
                ]);
            }
        },
        error: function () {

        }
    });
    
    EditarUsuarios_show();
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

function nuevoUsuario() {
    var nombre = document.getElementById('txtNombre').value;
    var apellidoPaterno = document.getElementById('txtApellidoPaterno').value;
    var apellidoMaterno = document.getElementById('txtApellidoMaterno').value;
    var rut = document.getElementById('txtRut').value;
    var email = document.getElementById('txtEmail').value;
    var direccion = document.getElementById('txtDireccion').value;
    var fono = document.getElementById('txtFono').value;
    var password1 = document.getElementById('txtPassword1').value;
    var password2 = document.getElementById('txtPassword2').value;
    var perfil = document.getElementById('slPerfil').value;

    if (nombre != "" && apellidoPaterno != "" && apellidoMaterno != "" && rut != ""
        && email != "" && password1 != "" && password2 != "" && perfil >= 1) {
        if (password1 == password2) {
            var data = '{nombre:"' + nombre
                + '",apellidoPaterno:"' + apellidoPaterno
                + '",apellidoMaterno:"' + apellidoMaterno + '",rut:"' + rut
                + '",email:"' + email
                + '",direccion:"' + direccion
                + '",fono:"' + fono
                + '",password: "' + password1
                + '",rut:"' + rut
                + '",perfil:"' + perfil + '"}';
            $.ajax({
                type: "POST",
                url: "Usuarios.aspx/nuevoUsuario",
                contentType: "application/json; charset=utf-8",
                datatype: "jason",
                data: data,
                success: function (result) {
                    var respuesta = result.d;
                    if (respuesta = true) {
                        mostrarAlerta(2, 'Usuario creado');
                        cargarUsuarios();
                        ocultarTodo();
                        vaciarTodo();
                    }
                    else {
                        mostrarAlerta(3, 'Usuario no creado');
                    }
                },
                error: function () {
                    mostrarAlerta(3, 'Usuario no creado');
                }
            });
        }
        else {
            mostrarAlerta(3, "Las contraseñas deben ser iguales");
        }
    }
    else {
        mostrarAlerta(3, "Faltan campos por completar");
    }
}

function actualizarUsuario() {
    var nombre = document.getElementById('txtNombreEditar').value;
    var apellidoPaterno = document.getElementById('txtApellidoPaternoEditar').value;
    var apellidoMaterno = document.getElementById('txtApellidoMaternoEditar').value;
    var rut = document.getElementById('txtRutEditar').value;
    var email = document.getElementById('txtEmailEditar').value;
    var direccion = document.getElementById('txtDireccionEditar').value;
    var fono = document.getElementById('txtFonoEditar').value;
    var perfil = document.getElementById('slPerfilEditar').value;
    var estado = document.getElementById('slEstadoEditar').value;
    
    if (nombre != "" && apellidoPaterno != "" && apellidoMaterno != "" && rut != ""
        && email != "" && perfil >= 1) {
        var data = '{id:' + id_usuarioEditar
            + ',nombre:"' + nombre
            + '",apellidoPaterno:"' + apellidoPaterno
            + '",apellidoMaterno:"' + apellidoMaterno
            + '",rut:"' + rut
            + '",email:"' + email
            + '",direccion:"' + direccion
            + '",fono:"' + fono
            + '",estado:"' + estado
            + '",perfil:"' + perfil + '"}';
        $.ajax({
            type: "POST",
            url: "Usuarios.aspx/actualizarUsuario",
            contentType: "application/json; charset=utf-8",
            datatype: "jason",
            data: data,
            success: function (result) {
                var respuesta = result.d;
                if (respuesta = true) {
                    mostrarAlerta(2, 'Datos Actualizados');
                    cargarUsuarios();
                    ocultarTodo();
                    vaciarTodo();
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

function vaciarTodo() {
    document.getElementById('txtNombre').value = "";
    document.getElementById('txtApellidoPaterno').value = "";
    document.getElementById('txtApellidoMaterno').value = "";
    document.getElementById('txtRut').value = "";
    document.getElementById('txtEmail').value = "";
    document.getElementById('txtDireccion').value = "";
    document.getElementById('txtFono').value = "";
    document.getElementById('txtPassword1').value = "";
    document.getElementById('txtPassword2').value = "";
    document.getElementById('slPerfil').value;
}

function cargarPerfiles() {
    $.ajax({
        type: "POST",
        url: "Usuarios.aspx/cargarPerfiles",
        contentType: "application/json; charset=utf-8",
        datatype: "jason",
        success: function (arg) {
            informe.fnClearTable();
            if (arg.d == "{}" | arg.d == "") {
                return;
            }

            var objeto = arg.d;
            for (var i = 0; i < objeto.length; i++) {
                var perfil = document.getElementById("slPerfil");
                var option = document.createElement("option");
                option.text = objeto[i].nombre;
                option.value = objeto[i].id;
                perfil.add(option, perfil[i]);
            }

            for (var i = 0; i < objeto.length; i++) {
                var perfilEditar = document.getElementById("slPerfilEditar");
                var option = document.createElement("option");
                option.text = objeto[i].nombre;
                option.value = objeto[i].id;
                perfilEditar.add(option, perfilEditar[i]);
            }
        },
        error: function () {

        }
    });
}

function resetearPassword() {

    var data = '{id_usuario:"' + id_usuarioEditar + '"}';
    $.ajax({
        type: "POST",
        url: "Usuarios.aspx/resetearPassword",
        contentType: "application/json; charset=utf-8",
        datatype: "jason",
        data: data,
        success: function (result) {
            var respuesta = result.d;

            if (respuesta == true) {
                mostrarAlerta(2, 'Contraseña Reseteada.');
            }
            else {
                mostrarAlerta(3, 'Problemas Internos');
            }
        },
        error: function () {
            mostrarAlerta(3, 'Problemas Internos');
        }
    });
}

function nuevoUsuario_show() {
    ocultarTodo();
    document.getElementById('dvNuevoUsuario').style.display = "block";
}

function ocultarTodo() {
    document.getElementById('dvNuevoUsuario').style.display = "none";
    document.getElementById('dvUsuarios').style.display = "none";
    document.getElementById('dvEditarUsuario').style.display = "none";
}

function Usuarios_show() {
    ocultarTodo();
    cargarUsuarios();
    document.getElementById('dvUsuarios').style.display = "block";
}

function EditarUsuarios_show() {
    ocultarTodo();
    document.getElementById('dvEditarUsuario').style.display = "block";
}