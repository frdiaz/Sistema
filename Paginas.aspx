<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Paginas.aspx.cs" Inherits="Ventanas" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido" runat="Server">
    <script src="js/Paginas.js"></script>
    <link href="css/Paginas.css" rel="stylesheet" />
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

    <button type="button" class="btn btn-primary" onclick="nuevaPagina_show();" style="margin-left: 20px;">Nueva Ventana</button>
    <button type="button" class="btn btn-primary" onclick="Paginas_show();" style="margin-left: 20px;">Mostrar Ventanas</button>
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
                    </div>
                    <div class="box-footer">
                        <label>Campos Obligatorios</label>
                        <label style="color: red">(*)</label>
                        <br />
                        <button type="button" class="btn btn-primary" onclick="nuevaVentana();">Guardar</button>
                        <button type="button" class="btn btn-primary" style="background-color: red; border-color: red;" onclick="vaciarCampos();">Borrar</button>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <section class="content">
        <div class="row" id="dvTablaPaginas" style="margin-top: -250px;">
            <div class="col-xs-12">
                <div class="box box-primary">
                    <div class="box-header">
                        <h3 class="box-title">Ventanas</h3>
                    </div>
                    <div class="box-body">
                        <table id="tblPaginas" class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th>Menú</th>
                                    <th>Sub-Menú</th>
                                    <th>URL</th>
                                    <th>Activo</th>
                                    <th>Class</th>
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
        <div class="row" id="dvEditarVentana" style="margin-top:-500px !important;">
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Nueva Ventana</h3>
                    </div>
                    <div class="box-body">
                        <div class="form-group">
                            <label>Nombre Menú</label>
                            <label style="color: red">(*)</label>
                            <input type="text" class="form-control" id="txtNombreMenuEditar" placeholder="Nombre" maxlength="50" title="Nombre del Menú donde se integrara.">
                        </div>
                        <div class="form-group">
                            <label>URL</label>
                            <label style="color: red">(*)</label>
                            <input type="text" class="form-control" id="txtURLEditar" placeholder="URL" maxlength="25" title="Formulario al que corresponde">
                        </div>
                        <div class="form-group">
                            <label>Class</label>
                            <label style="color: red">(*)</label>
                            <input type="text" class="form-control" id="txtClassEditar" placeholder="Class" maxlength="25" title="Clase para la imagen">
                        </div>
                        <div class="form-group">
                            <label>Sub-menu</label>
                            <label style="color: red">(*)</label>
                            <input type="text" class="form-control" id="txtSubMenuEditar" placeholder="Sub-Menu" maxlength="25" title="Nombre que tendra este menú">
                        </div>
                        <div class="form-group">
                            <label>Estado</label>
                            <label style="color: red">(*)</label>
                            <select class="form-control" id="slEstadoEditar">
                                <option value="1">Activada</option>
                                <option value="0">Desactivada</option>
                            </select>
                        </div>
                    </div>
                    <div class="box-footer">
                        <label>Campos Obligatorios</label>
                        <label style="color: red">(*)</label>
                        <br />
                        <button type="button" class="btn btn-primary" onclick="actualizarVentana();">Guardar</button>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <script src="bower_components/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>
    <script src="bower_components/jquery-slimscroll/jquery.slimscroll.min.js"></script>
</asp:Content>
