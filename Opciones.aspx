<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Opciones.aspx.cs" Inherits="Opciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido" runat="Server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script src="js/Opciones.js"></script>
    <link href="bower_components/toast/jquery.toast.css" rel="stylesheet" />
    <link href="bower_components/toast/jquery.toast.min.css" rel="stylesheet" />
    <script src="bower_components/toast/jquery.toast.min.js"></script>
    <script src="bower_components/toast/jquery.toast.js"></script>
    <script src="bower_components/toast/JavaScript.js"></script>

    <h3 style="margin-left: 20px; margin-top: 0px;">Administración <small>Opciones Varias</small></h3>
    <section class="content">
        <div class="row" id="dvVarios">
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Valores</h3>
                    </div>
                    <div class="box-body">
                        <div class="form-group">
                            <label>Color del Banner</label>
                            <input type="text" class="form-control" id="txtColorBanner" maxlength="20">
                        </div>
                        <div class="form-group">
                            <label>Color de los Botones</label>
                            <input type="text" class="form-control" id="txtColorBotones" maxlength="10">
                        </div>
                    </div>
                    <div class="box-footer">
                        <button type="button" class="btn btn-primary" onclick="actualizarDatos();">Guardar</button>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>