<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Ventanas.aspx.cs" Inherits="Ventanas" MasterPageFile="~/MasterPage.master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido" Runat="Server">
    <script src="js/Ventanas.js"></script>
    <link href="css/Ventanas.css" rel="stylesheet" />
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

    <h3 style="margin-left: 20px; margin-top: 0px;">Administración<small> Ventanas</small></h3>

    <button type="button" class="btn btn-primary" onclick="nuevaVentana_show();" style="margin-left: 20px;">Nueva Ventana</button>
    <section class="content">
        <div class="row" id="dvNuevaVentana">
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Nueva Ventana</h3>
                    </div>
                    <div class="box-body">
                        <div class="form-group">
                            <label>Nombre Menú</label>
                            <label style="color: red">(*)</label>
                            <input type="text" class="form-control" id="txtNombreMenu" placeholder="Nombre" maxlength="50" title="Nombre del Menú donde se integrara.">
                        </div>
                        <div class="form-group">
                            <label>URL</label>
                            <label style="color: red">(*)</label>
                            <input type="text" class="form-control" id="txtURL" placeholder="URL" maxlength="50" title="Formulario al que corresponde">
                        </div>
                        <div class="form-group">
                            <label>Class</label>
                            <input type="text" class="form-control" id="txtClass" placeholder="Class" maxlength="50" title="Clase para la imagen">
                        </div>
                        <div class="form-group">
                            <label>Sub-menu</label>
                            <label style="color: red">(*)</label>
                            <input type="text" class="form-control" id="txtSubMenu" placeholder="Sub-Menu" maxlength="50" title="Nombre que tendra este menú">
                        </div>
                        <%--<div class="form-group">
                            <label>Perfil</label>
                            <select class="form-control" id="slPerfil">
                                <option value="" selected="selected" title="Perfiles que tendran acceso a este menú">Seleccione</option>
                            </select>
                        </div>--%>
                    </div>
                    <div class="box-footer">
                        <label>Campos Obligatorios</label>
                        <label style="color: red">(*)</label>
                        <br />
                        <button type="button" class="btn btn-primary" onclick="nuevaVentana();">Guardar</button>
                        <button type="button" class="btn btn-primary" style="background-color: red; border-color:red;" onclick="vaciarCampos();">Borrar</button>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>