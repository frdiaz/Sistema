<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="CorreoDiario.aspx.cs" Inherits="pages_CorreoDiario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido" runat="Server">
    <link href='http://fonts.googleapis.com/css?family=Roboto+Slab:400,700' rel='stylesheet' type='text/css'>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script src="https://code.jquery.com/jquery-1.9.1.min.js"></script>
    <script src="bower_components/jquery/dist/jquery.min.js"></script>
    <link href="bower_components/toast/jquery.toast.css" rel="stylesheet" />
    <link href="bower_components/toast/jquery.toast.min.css" rel="stylesheet" />
    <script src="bower_components/toast/jquery.toast.min.js"></script>
    <script src="bower_components/toast/jquery.toast.js"></script>
    <script src="bower_components/toast/JavaScript.js"></script>

    <link href="css/correoDiario.css" rel="stylesheet" />
    <script src="js/CorreoDiario.js"></script>
    <!-- SCRIPT DE DATATABLES -->
    <%--<link href="bower_components/datatables/jquery.dataTables.css" rel="stylesheet" />
    <link href="bower_components/datatables/jquery.dataTables.min.css" rel="stylesheet" />
    <script src="bower_components/datatables/jquery.dataTables.js"></script>
    <script src="bower_components/datatables/dataTables.bootstrap.js"></script>
    <script src="bower_components/datatables/dataTables.buttons.min.js"></script>--%>
    <link rel="stylesheet" href="bower_components/bootstrap/dist/css/bootstrap.min.css">
    <link rel="stylesheet" href="bower_components/font-awesome/css/font-awesome.min.css">
    <link rel="stylesheet" href="bower_components/Ionicons/css/ionicons.min.css">
    <link rel="stylesheet" href="bower_components/datatables.net-bs/css/dataTables.bootstrap.min.css">

    <%--<link rel="stylesheet" href="bower_components/bootstrap/dist/css/bootstrap.min.css">
    <link rel="stylesheet" href="bower_components/font-awesome/css/font-awesome.min.css">
    <link rel="stylesheet" href="bower_components/Ionicons/css/ionicons.min.css">
    --%>

    <h3 style="margin-left: 20px; margin-top: 0px;">MailBox<small> Mensaje Diario</small></h3>
    <button type="button" class="btn btn-primary" onclick="enviarMensaje();" style="margin-left: 20px;">Buscar y Enviar</button>
    <button type="button" class="btn btn-primary" onclick="nuevoMensaje_show();" style="margin-left: 20px;">Nuevo Mensaje</button>
    <button type="button" class="btn btn-primary" onclick="tablaMensajesEnviados_show()" style="margin-left: 20px;">Mensajes Enviados</button>
    <section class="content">
        <div class="row" id="dvResumen">
            <div class="col-lg-3 col-xs-6" style="margin-left: 1.6% !important;">
                <div class="small-box bg-aqua">
                    <div class="inner">
                        <h3 id="h3_Enviados"></h3>
                        <p>Mensajes Enviados</p>
                    </div>
                    <div class="icon">
                        <i class="ion ion-bag"></i>
                    </div>
                    <a href="#" onclick="" class="small-box-footer">Mostrar detalle <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>
            <div class="col-lg-3 col-xs-6">
                <div class="small-box bg-green">
                    <div class="inner">
                        <h3 id="h3_Disponibles"></h3>
                        <p>Mensajes NO enviados</p>
                    </div>
                    <a href="#" class="small-box-footer">Mostrar detalle <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>
        </div>
        <div class="column" id="dvNuevoMensaje">
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Nuevo Mensaje</h3>
                    </div>
                    <div class="box-body">
                        <div class="form-group">
                            <label>Mensaje</label>
                            <label style="color: red">(*)</label>
                            <input type="text" class="form-control" id="txtMensaje" placeholder="Escriba su mensaje" maxlength="240">
                            <br />
                            <label>Adjuntar Imagen</label>
                            <label style="color: red">(No disponible)</label>
                            <input type="file" id="imgAdjunta" />
                        </div>
                    </div>
                    <div class="box-footer">
                        <label>Campos Obligatorios</label>
                        <label style="color: red">(*)</label>
                        <br />
                        <button type="button" class="btn btn-primary" onclick="nuevoMensaje();">Guardar</button>
                    </div>
                </div>
            </div>
        </div>
        <%--<div class="column">
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Enviar Mensaje</h3>
                    </div>
                    <div class="box-footer">
                        <button id="btnEnviarMensaje" type="button" class="btn btn-primary" onclick="enviarMensaje();">Buscar y Enviar</button>
                    </div>
                </div>
            </div>
        </div>--%>
    </section>

    <div id="dvTablaMensajesEnviados" style="margin-top: -240px;">
        <div id="opciones">
            <div class="box-body">
                <div class="form-group">
                    <div class="col-xs-12">
                        <div class="box">
                            <div class="box-header">
                                <h3 class="box-title">Ultimos Mensajes Enviados</h3>
                            </div>
                            <div class="box-body">
                                <table id="tblHistorico" class="table table-bordered table-hover">
                                    <thead>
                                        <tr>
                                            <th>Fecha</th>
                                            <th>Hora</th>
                                            <th>Mensaje</th>
                                        </tr>
                                    </thead>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <%--<script src="bower_components/jquery/dist/jquery.min.js"></script>
    <script src="bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="bower_components/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>
    <script src="bower_components/jquery-slimscroll/jquery.slimscroll.min.js"></script>
    <script src="bower_components/fastclick/lib/fastclick.js"></script>--%>
    
    

    <script src="bower_components/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>
    <script src="bower_components/jquery-slimscroll/jquery.slimscroll.min.js"></script>
</asp:Content>
