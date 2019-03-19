﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscarOrden.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.ViewOrden.BuscarOrden" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
<script src="../../../assets/js/vendor/jquery-2.1.4.min.js"></script>
    <%--   <script src="../../Scripts/jquery.signalR-2.2.3.min.js"></script>--%>
            <script src="../../../Scripts/jquery.signalR-2.2.3.js"></script>
                     <script src="/signalr/hubs"></script>
        <script src="../../../assets/sweetalert.min.js"></script>
    <form runat="server">
          <asp:ScriptManager runat="server" ID="Update">

    </asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="Update1">
        <ContentTemplate>
              <div class="content mt-3">
            <div class="animated fadeIn">
                <div class="row">

                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-title">Ordenes</strong>
                        </div>
                        <div class="card-body">
                            <!-- .Tabla donde se muestran las Ordenes Activas-->
                  <table id="bootstrap-data-table" class="table table-striped table-bordered">
                    <thead>
                        <th>Id Orden</th>
                        <th>Codigo</th>
                        <th>Baucher</th>
                        <th>Opciones</th>
                    </thead>
                    <tbody>
                    </tbody>
                  </table>
                        </div>
                    </div>
                </div>
                </div>
            </div><!-- .animated -->
        </div><!-- .content -->
        </ContentTemplate>

    </asp:UpdatePanel>
    </form>

 <script src="../../../TablesJS/TableOrden.js"></script> 

</asp:Content>
