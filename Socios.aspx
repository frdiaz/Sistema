<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Socios.aspx.cs" Inherits="Socios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido" runat="Server">
    <script src="js/Socios.js"></script>
    <link href="css/Socios.css" rel="stylesheet" />
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

    <h3 style="margin-left: 20px; margin-top: 0px;">Nutrición<small> Pacientes</small></h3>

    <button type="button" class="btn btn-primary" onclick="nuevoSocio_show();" style="margin-left: 20px;">Nuevo Paciente</button>
    <button type="button" class="btn btn-primary" onclick="Socios_show();" style="margin-left: 20px;">Mostrar Pacientes</button>
    <section class="content">
        <div class="row" id="dvSocios">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">Pacientes</h3>
                    </div>
                    <div class="box-body">
                        <table id="tblSocios" class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th>Nombre</th>
                                    <th>Editar</th>
                                    <th>Ingresar Ficha</th>
                                    <th>Ver Historial</th>
                                </tr>
                            </thead>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <section class="content">
        <div class="row" id="dvNuevoSocio">
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Nuevo Socio</h3>
                    </div>
                    <div class="box-body">
                        <div class="form-group">
                            <label>Rut</label>
                            <label style="color: red">(*)</label>
                            <input type="text" class="form-control" id="txtRut" placeholder="Rut" maxlength="10">
                        </div>
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
                            <label>Fecha de Nacimiento</label>
                            <label style="color: red">(*)</label>
                            <input type="date" class="form-control" id="txtFechaNacimiento">
                        </div>
                        <div class="form-group">
                            <label>Sexo</label>
                            <select class="form-control" id="slSexo">
                                <option value="2">Seleccione</option>
                                <option value="0">Femenino</option>
                                <option value="1">Masculino</option>
                            </select>
                        </div>
                        <div class="form-group">
                            <label>Correo Electronico</label>
                            <label style="color: red">(*)</label>
                            <input type="text" class="form-control" id="txtEmail" placeholder="Email" maxlength="29">
                        </div>
                        <div class="form-group">
                            <label>Fono</label>
                            <input type="number" class="form-control" id="txtFono">
                        </div>
                    </div>
                    <div class="box-footer">
                        <label>Campos Obligatorios</label>
                        <label style="color: red">(*)</label>
                        <br />
                        <button type="button" class="btn btn-primary" onclick="nuevoSocio();">Guardar</button>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <section class="content">
        <div class="row" id="dvEditarSocio">
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Editar Socio</h3>
                    </div>
                    <div class="box-body">
                        <div class="form-group">
                            <label>Rut</label>
                            <label style="color: red">(*)</label>
                            <input type="text" class="form-control" id="txtRutEditar" placeholder="Rut" maxlength="10" disabled="disabled">
                        </div>
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
                            <label>Fecha de Nacimiento</label>
                            <label style="color: red">(*)</label>
                            <input type="date" class="form-control" id="txtFechaNacimientoEditar">
                        </div>
                        <div class="form-group">
                            <label>Sexo</label>
                            <select class="form-control" id="slSexoEditar">
                                <option value="2">Seleccione</option>
                                <option value="0">Femenino</option>
                                <option value="1">Masculino</option>
                            </select>
                        </div>
                        <div class="form-group">
                            <label>Fono</label>
                            <input type="number" class="form-control" id="txtFonoEditar">
                        </div>
                        <div class="form-group">
                            <label>Correo Electronico</label>
                            <label style="color: red">(*)</label>
                            <input type="text" class="form-control" id="txtEmailEditar" placeholder="Email" maxlength="29">
                        </div>
                        <div class="box-footer">
                            <label>Campos Obligatorios</label>
                            <label style="color: red">(*)</label>
                            <br />
                            <button type="button" class="btn btn-primary" onclick="actualizarSocio();">Guardar</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </section>
    <section class="content ingresarFicha">
        <div class="col" id="dvResumen">
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Resumen Historico</h3>
                    </div>
                    <div class="box-body">
                        <table id="tblResumen1" class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th>Fecha</th>
                                    <th>Peso</th>
                                    <th>IMC</th>
                                    <th>Ver</th>
                                </tr>
                            </thead>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <div class="col" id="dvFichaNutricional">
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Ficha Nutricional</h3>
                    </div>
                    <div class="box-body">
                        <div class="row">
                            <div class="col-xs-3">
                                <label>Peso</label>
                                <input type="number" class="form-control" id="txtPeso" title="Valor en Kilos, ejm: 77,2">
                            </div>
                            <div class="col-xs-3">
                                <label>Talla</label>
                                <input type="number" class="form-control" id="txtTalla" title="Valor en Metros, ejm: 1,75">
                            </div>
                            <div class="col-xs-3">
                                <label>Cintura</label>
                                <input type="number" class="form-control" id="txtCintura" title="Valor en Centimetros: ejm 125">
                            </div>
                            <div class="col-xs-3">
                                <label>IMC</label>
                                <input type="text" class="form-control" id="txtIMC" placeholder="IMC" maxlength="10" disabled="disabled">
                            </div>
                            <hr />
                            <div class="col-xs-3">
                                <label>Alcohol</label>
                                <input type="number" class="form-control" id="txtAlcohol" title="Valor semanal. Si es 'NO' poner '0'">
                            </div>
                            <div class="col-xs-3">
                                <label>Tabaco</label>
                                <input type="number" class="form-control" id="txtTabaco" title="Valor semanal. Si es 'NO' poner '0'">
                            </div>
                            <div class="col-xs-5">
                                <label>Tipo Consulta</label>
                                <select class="form-control" id="slTipoConsulta">
                                    <option value="2">Seleccione</option>
                                    <option value="0">Femenino</option>
                                    <option value="1">Masculino</option>
                                </select>
                            </div>
                        </div>
                        <div class="box-body">
                            <div class="form-group">
                                <label>Ananmesis</label>
                                <textarea class="form-control" rows="3" placeholder="Enter ..."></textarea>
                            </div>
                            <div class="form-group">
                                <label>Diagnostico</label>
                                <textarea class="form-control" rows="3" placeholder="Enter ..." disabled></textarea>
                            </div>
                        </div>

                        <div class="box-footer">
                            <button type="button" class="btn btn-primary" onclick="">Guardar</button>
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
