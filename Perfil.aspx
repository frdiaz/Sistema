<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Perfil.aspx.cs" Inherits="Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido" runat="Server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script src="js/Perfil.js"></script>
    <link href="bower_components/toast/jquery.toast.css" rel="stylesheet" />
    <link href="bower_components/toast/jquery.toast.min.css" rel="stylesheet" />
    <script src="bower_components/toast/jquery.toast.min.js"></script>
    <script src="bower_components/toast/jquery.toast.js"></script>
    <script src="bower_components/toast/JavaScript.js"></script>

    <h3 style="margin-left: 20px; margin-top: 0px;">Perfil<small></small></h3>
    <section class="content">
        <div class="row" id="dvEditarUsuario">
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Mis Datos</h3>
                    </div>
                    <img class="profile-user-img img-responsive img-circle" src="../../dist/img/user4-128x128.jpg" alt="User profile picture" style="width: 170px;">
                    <div class="box-body">
                        <div class="form-group">
                            <label>Nombre</label>
                            <input type="text" class="form-control" id="txtNombre" placeholder="Nombre" maxlength="20" disabled="disabled">
                        </div>
                        <div class="form-group">
                            <label>Rut</label>
                            <input type="text" class="form-control" id="txtRut" placeholder="Rut" maxlength="10" disabled="disabled">
                        </div>
                    </div>
                    <div class="box-footer">
                        <div class="form-group">
                            <label>Correo Electronico</label>
                            <input type="text" class="form-control" id="txtEmail" placeholder="Email" maxlength="29">
                        </div>
                        <div class="form-group">
                            <label>Dirección</label>
                            <input type="text" class="form-control" id="txtDireccion" placeholder="Dirección" maxlength="29">
                        </div>
                        <div class="form-group">
                            <label>Fono</label>
                            <input type="number" class="form-control" id="txtFono" placeholder="Telefono" maxlength="10">
                        </div>
                        <div class="box-footer">
                            <button type="button" class="btn btn-primary" onclick="actualizarDatos();">Guardar</button>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Actualizar Contraseña</h3>
                        <div class="box-footer">
                            <input type="password" class="form-control" id="txtPassword1" placeholder="Contraseña" maxlength="20">
                            <br />
                            <input type="password" class="form-control" id="txtPassword2" placeholder="Repetir Contraseña" maxlength="20">
                        </div>
                        <div class="box-footer">
                            <button type="button" class="btn btn-primary" onclick="actualizarPassword();">Actualizar Contraseña</button>
                        </div>

                    </div>
                </div>
            </div>
            <%--<div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Actualizar otros datos</h3>
                        <div class="box-footer">
                            <div class="form-group">
                                <label>Correo Electronico</label>
                                <input type="text" class="form-control" id="txtEmail" placeholder="Email" maxlength="29">
                            </div>
                            <div class="form-group">
                                <label>Dirección</label>
                                <input type="text" class="form-control" id="txtDireccion" placeholder="Dirección" maxlength="29">
                            </div>
                            <div class="form-group">
                                <label>Fono</label>
                                <input type="number" class="form-control" id="txtFono" placeholder="Telefono" maxlength="10">
                            </div>
                            <div class="box-footer">
                                <button type="button" class="btn btn-primary" onclick="">Guardar</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>--%>
        </div>
    </section>
</asp:Content>





