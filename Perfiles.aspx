<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Perfiles.aspx.cs" Inherits="Perfiles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido" runat="Server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script src="https://code.jquery.com/jquery-1.9.1.min.js"></script>
    <script src="js/Perfiles.js"></script>
    <script src="bower_components/jquery/dist/jquery.min.js"></script>
    <link href="bower_components/toast/jquery.toast.css" rel="stylesheet" />
    <link href="bower_components/toast/jquery.toast.min.css" rel="stylesheet" />
    <script src="bower_components/toast/jquery.toast.min.js"></script>
    <script src="bower_components/toast/jquery.toast.js"></script>
    <script src="bower_components/toast/JavaScript.js"></script>
    <link href="css/Perfiles.css" rel="stylesheet" />
    <link rel="stylesheet" href="bower_components/bootstrap/dist/css/bootstrap.min.css">
    <link rel="stylesheet" href="bower_components/font-awesome/css/font-awesome.min.css">
    <link rel="stylesheet" href="bower_components/Ionicons/css/ionicons.min.css">
    <link rel="stylesheet" href="bower_components/datatables.net-bs/css/dataTables.bootstrap.min.css">

    <link href="bower_components/Bootstrap-select/bootstrap-select.css" rel="stylesheet" />
    <script src="bower_components/Bootstrap-select/bootstrap-select.min.js"></script>

    <h3 style="margin-left: 20px; margin-top: 0px;">Administración<small> Perfiles</small></h3>
    <button type="button" class="btn btn-primary" onclick="NuevoPerfil_show();" style="margin-left: 20px;">Nuevo Perfil</button>
    <button type="button" class="btn btn-primary" onclick="Perfiles_show();" style="margin-left: 20px;">Mostrar Perfiles</button>
    <%--TABLA QUE MUESTRA LOS PERFILES - INICIO--%>
    <section class="content">
        <div class="row" id="dvPerfiles">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">Perfiles</h3>
                    </div>
                    <div class="box-body">
                        <table id="tblPerfiles" class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th>Nombre</th>
                                    <th>Descripción</th>
                                    <th>Editar</th>
                                </tr>
                            </thead>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <%--TABLA QUE MUESTRA LOS PERFILES - TERMINO--%>
    <%--NUEVO PERFIL - INICIO--%>
    <section class="content">
        <div class="row" id="dvNuevoPerfil">
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Nuevo Perfil</h3>
                    </div>
                    <div class="box-body">
                        <div class="form-group">
                            <label>Nombre</label>
                            <label style="color: red">(*)</label>
                            <input type="text" class="form-control" id="txtNombre" placeholder="Nombre" maxlength="20">
                        </div>
                        <div class="form-group">
                            <label>Descripción</label>
                            <input type="text" class="form-control" id="txtDescripcion" placeholder="Descripción" maxlength="49">
                        </div>
                        <div class="form-group">
                            <label>Paginas</label>
                            <select class="form-control selectpicker" name="slPaginas" id="slPaginas" <%--onclick="multiples();"--%> multiple="multiple">
                            </select>
                        </div>
                        <div class="box-footer">
                            <label>Campos Obligatorios</label>
                            <label style="color: red">(*)</label>
                            <br />
                            <button type="button" class="btn btn-primary" onclick="nuevoPerfil();">Guardar</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <%--NUEVO PERFIL - TERMINO--%>
    <%--EDITAR PERFIL - INICIO--%>
    <section class="content">
        <div class="row" id="dvEditarPerfil">
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Editar Perfil</h3>
                    </div>
                    <div class="box-body">
                        <div class="form-group">
                            <label>Nombre</label>
                            <label style="color: red">(*)</label>
                            <input type="text" class="form-control" id="txtEditarNombre" placeholder="Nombre" maxlength="20">
                        </div>
                        <div class="form-group">
                            <label>Descripcion</label>
                            <input type="text" class="form-control" id="txtEditarDescripcion" placeholder="Descripción" maxlength="49">
                        </div>
                        <div class="form-group">
                            <label>Paginas</label>
                            <select class="form-control selectpicker" id="slPaginasEditar" onclick="multiples();" multiple="multiple">
                                <script>
                                    $('#slPaginas').change(function () {
                                        var valores = $(this).val();
                                        console.log(valores);
                                        cantidad = valores;
                                    });
                                </script>
                            </select>
                        </div>
                        <div class="box-footer">
                            <label>Campos Obligatorios</label>
                            <label style="color: red">(*)</label>
                            <br />
                            <button type="button" class="btn btn-primary" onclick="editarPerfil();">Guardar</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <%--EDITAR PERFIL - TERMINO--%>
    <script src="bower_components/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>
    <script src="bower_components/jquery-slimscroll/jquery.slimscroll.min.js"></script>
    
</asp:Content>
