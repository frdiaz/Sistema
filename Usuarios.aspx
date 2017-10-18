<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Usuarios.aspx.cs" Inherits="Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido" runat="Server">
    <script src="js/Usuarios.js"></script>
    <link href="css/Usuarios.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script src="https://code.jquery.com/jquery-1.9.1.min.js"></script>
    <script src="bower_components/jquery/dist/jquery.min.js"></script>
    <link href="bower_components/toast/jquery.toast.css" rel="stylesheet" />
    <link href="bower_components/toast/jquery.toast.min.css" rel="stylesheet" />
    <script src="bower_components/toast/jquery.toast.min.js"></script>
    <script src="bower_components/toast/jquery.toast.js"></script>
    <script src="bower_components/toast/JavaScript.js"></script>

    <link rel="stylesheet" href="bower_components/bootstrap/dist/css/bootstrap.min.css">
    <link rel="stylesheet" href="bower_components/font-awesome/css/font-awesome.min.css">
    <link rel="stylesheet" href="bower_components/Ionicons/css/ionicons.min.css">
    <link rel="stylesheet" href="bower_components/datatables.net-bs/css/dataTables.bootstrap.min.css">

    <h3 style="margin-left: 20px; margin-top: 0px;">Administración<small> Usuarios</small></h3>

    <button type="button" class="btn btn-primary" onclick="nuevoUsuario_show();" style="margin-left: 20px;">Nuevo Usuario</button>
    <button type="button" class="btn btn-primary" onclick="Usuarios_show();" style="margin-left: 20px;">Mostrar Usuarios</button>
    <section class="content">
        <div class="row" id="dvUsuarios">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">Usuarios</h3>
                    </div>
                    <div class="box-body">
                        <table id="tblUsuarios" class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th>Rut</th>
                                    <th>Nombre</th>
                                    <th>Email</th>
                                    <th>Estado Cuenta</th>
                                    <th>Editar</th>
                                </tr>
                            </thead>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <section class="content">
        <div class="row" id="dvNuevoUsuario">
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Nuevo Usuario</h3>
                    </div>
                    <div class="box-body">
                        <div class="form-group">
                            <label>Nombre</label>
                            <label style="color: red">(*)</label>
                            <input type="text" class="form-control" id="txtNombre" placeholder="Nombre" maxlength="20">
                        </div>
                        <div class="form-group">
                            <label>Apellido Paterno</label>
                            <label style="color: red">(*)</label>
                            <input type="text" class="form-control" id="txtApellidoPaterno" placeholder="Apellido Paterno" maxlength="20">
                        </div>
                        <div class="form-group">
                            <label>Apellido Materno</label>
                            <label style="color: red">(*)</label>
                            <input type="text" class="form-control" id="txtApellidoMaterno" placeholder="Apellido Materno" maxlength="20">
                        </div>
                        <div class="form-group">
                            <label>Rut</label>
                            <label style="color: red">(*)</label>
                            <input type="text" class="form-control" id="txtRut" placeholder="Rut" maxlength="10">
                        </div>
                        <div class="form-group">
                            <label>Correo Electronico</label>
                            <label style="color: red">(*)</label>
                            <input type="text" class="form-control" id="txtEmail" placeholder="Email" maxlength="29">
                        </div>
                        <div class="form-group">
                            <label>Dirección</label>
                            <input type="text" class="form-control" id="txtDireccion" placeholder="Dirección" maxlength="29">
                        </div>
                        <div class="form-group">
                            <label>Fono</label>
                            <input type="number" class="form-control" id="txtFono" <%--placeholder="Telefono"--%> <%--maxlength="10"--%>>
                        </div>
                        <div class="form-group">
                            <label>Password</label>
                            <label style="color: red">(*)</label>
                            <input type="password" class="form-control" id="txtPassword1" placeholder="Password" maxlength="20">
                            <br />
                            <input type="password" class="form-control" id="txtPassword2" placeholder="Repetir Password" maxlength="20">
                        </div>
                        <div class="form-group">
                            <label>Perfil</label>
                            <label style="color: red">(*)</label>
                            <select class="form-control" id="slPerfil">
                                <option value="" selected="selected">Seleccione</option>
                            </select>
                        </div>
                    </div>
                    <div class="box-footer">
                        <label>Campos Obligatorios</label>
                        <label style="color: red">(*)</label>
                        <br />
                        <button type="button" class="btn btn-primary" onclick="nuevoUsuario();">Guardar</button>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <section class="content">
        <div class="row" id="dvEditarUsuario">
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Editar Usuario</h3>
                    </div>
                    <div class="box-body">
                        <div class="form-group">
                            <label>Nombre</label>
                            <label style="color: red">(*)</label>
                            <input type="text" class="form-control" id="txtNombreEditar" placeholder="Nombre" maxlength="20">
                        </div>
                        <div class="form-group">
                            <label>Apellido Paterno</label>
                            <label style="color: red">(*)</label>
                            <input type="text" class="form-control" id="txtApellidoPaternoEditar" placeholder="Apellido Paterno" maxlength="20">
                        </div>
                        <div class="form-group">
                            <label>Apellido Materno</label>
                            <label style="color: red">(*)</label>
                            <input type="text" class="form-control" id="txtApellidoMaternoEditar" placeholder="Apellido Materno" maxlength="20">
                        </div>
                        <div class="form-group">
                            <label>Rut</label>
                            <label style="color: red">(*)</label>
                            <input type="text" class="form-control" id="txtRutEditar" placeholder="Rut" maxlength="10" disabled="disabled">
                        </div>
                        <div class="form-group">
                            <label>Correo Electronico</label>
                            <label style="color: red">(*)</label>
                            <input type="text" class="form-control" id="txtEmailEditar" placeholder="Email" maxlength="29">
                        </div>
                        <div class="form-group">
                            <label>Dirección</label>
                            <input type="text" class="form-control" id="txtDireccionEditar" placeholder="Dirección" maxlength="29">
                        </div>
                        <div class="form-group">
                            <label>Fono</label>
                            <input type="number" class="form-control" id="txtFonoEditar" placeholder="Telefono" maxlength="10">
                        </div>
                        <div class="form-group">
                            <label>Estado</label>
                            <label style="color: red">(*)</label>
                            <select class="form-control" id="slEstadoEditar">
                                <option value="0">Desactivada</option>
                                <option value="1">Activada</option>
                            </select>
                        </div>
                        <div class="form-group">
                            <label>Perfil</label>
                            <label style="color: red">(*)</label>
                            <select class="form-control" id="slPerfilEditar">
                                <option value="" selected="selected">Seleccione</option>
                            </select>
                        </div>
                    </div>
                    <div class="box-footer">
                        <label>Campos Obligatorios</label>
                        <label style="color: red">(*)</label>
                        <br />
                        <button type="button" class="btn btn-primary" onclick="actualizarUsuario();">Guardar</button>
                    </div>
                    
                </div>
            </div>
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Opciones Rapidas</h3>
                        <div class="box-footer">
                        <label>Resetear Password</label>
                        <button type="button" class="btn btn-primary" onclick="resetearPassword();" style="margin-left: 20px;">Resetear</button>
                    </div>
                    </div>
                </div>
            </div>
        </div>

    </section>
    <script src="bower_components/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>
    <script src="bower_components/jquery-slimscroll/jquery.slimscroll.min.js"></script>
</asp:Content>