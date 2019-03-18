<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscarMultiAdnOrden.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.ViewOrdenMaria.BuscarMultiAdnOrden" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div class="card-header">
       <strong class="card-title">Orden ADN humano</strong>
        </div> 
   
     <script src="../../assets/js/vendor/jquery-2.1.4.min.js"></script>
    <%--   <script src="../../Scripts/jquery.signalR-2.2.3.min.js"></script>--%>
            <script src="../../Scripts/jquery.signalR-2.2.3.js"></script>
                     <script src="/signalr/hubs"></script>
        <script src="../../assets/sweetalert.min.js"></script>
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
                            <strong class="card-title">Ordenes ADN</strong>
                        </div>
                        <div class="card-body">
                  <table id="bootstrap-data-table" class="table table-striped table-bordered">
                    <thead>
                        <th>Codigo</th>
                        <th>Boucher</th>
                        <th>Hijo</th>
                        
                       
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
    <script src="../../TablesJS/TableAdnMulti.js"></script>  
</asp:Content>

