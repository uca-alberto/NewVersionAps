<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Searchcli.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.ViewCliente.BuscarCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

            <script src="../../../assets/js/vendor/jquery-2.1.4.min.js"></script>
    <%--   <script src="../../Scripts/jquery.signalR-2.2.3.min.js"></script>--%>
            <script src="../../../Scripts/jquery.signalR-2.2.3.js"></script>
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
                            <strong class="card-title">Clientes Activos</strong>
                        </div>
                        <div class="card-body">
                  <table id="bootstrap-data-table" class="table table-striped table-bordered">
                    <thead>
                        <th>Codigo</th>
                        <th>Nombres</th>
                        <th>Apellidos</th>
                        <th>Correo</th>
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
  
    
           

          <%--  <asp:MultiView ID="ViewCliente" runat="server">
    <asp:View ID="ClientesActivos" runat="server">
            <script src="../../Content/global.js"></script>
    <script>
        $(function () {            
            getData();
        });
    </script>
    <form id="form1" runat="server">
            <div class="card">
                <div class="card-header">
                    <strong class="card-title">Listado de Clientes</strong>&nbsp;&nbsp;<asp:Button ID="Button1" CssClass="btn btn-warning btn-sm" runat="server" OnClick="TablaClientesDesactivos" Text="Ver Clientes Eliminados"/>
                </div>
                <div class="card-body">
                    <table id="bootstrap-data-table" class="table table-striped table-bordered">
                        <thead id="encabezadoTabla">
                        </thead>
                        <tbody id="contenidoTabla">
                        </tbody>
                    </table>
                </div>
            </div>
        </form>
                </asp:View>
                 <asp:View ID="ClientesDesactivos" runat="server">
                    <script type="text/javascript">
        $(function () {

            // Proxy created on the fly
            var job = $.connection.myHub;

            // Declare a function on the job hub so the server can invoke it
            job.client.displayStatus = function () {
                getData();
            };

            // Start the connection
            $.connection.hub.start();
            getData();
        });

          function getData() {
              var $tblEncabezado = $('#encabezadoTablaDesactivado');
              var $tblContenido = $('#contenidoTablaDesactivado');
              $.ajax({
                  url: 'BuscarCliente.aspx/GetDataDesactivados',
                  contentType: "application/json; charset=utf-8",
                  dataType: "json",
                  type: "POST",
                  success: function (data) {
                      debugger;
                      if (data.d.length > 0) {
                          var newdata = data.d;

                          $tblEncabezado.empty();
                          $tblEncabezado.append('<tr><th scope="col">Código</th><th scope="col">Nombres</th><th scope="col">Apellidos</th><th scope="col">Correo Electrónico</th><th scope="col">Opciones</th></tr>');
                          
                          $tblContenido.empty();
                          var rows = [];
                          for (var i = 0; i < newdata.length; i++) {
                              
                              rows.push('<tr><th scope="row">' + newdata[i].Id_Cliente + '</th><td>' + newdata[i].Nombres + '</td><td>' + newdata[i].Apellidos + '</td><td>' + newdata[i].Correo + '</td><td><a title="Mostrar" href="VerCliente.aspx?id=' + newdata[i].Id_Cliente + '"><i class="ti-eye"></i></a><a title="Editar" href="EditarCliente.aspx?id=' + newdata[i].Id_Cliente + '"><i class="ti-pencil-alt"></i></a><a href="delete.aspx?id=' + newdata[i].Id_Cliente + '" onclick="eliminar(delete.aspx?id=' + newdata[i].Id_Cliente + ')"><i class="menu-icon fa fa-trash-o"></i></a> </td></tr>');
                          }
                          $tblContenido.append(rows.join(''));
                      }
                  }
              });
          }
      
     </script>
    

    <form id="form2" runat="server">
            <div class="card">
                <div class="card-header">
                    <strong class="card-title">Listado de Clientes</strong> <asp:Button ID="Button2" CssClass="btn btn-success btn-sm" runat="server" OnClick="TablaClienteActivos" Text="Ver Clientes Activos" />
                </div>
                <div class="card-body">
                    <table id="table" class="table table-striped table-bordered">
                        <thead id="encabezadoTablaDesactivado">
                        </thead>
                        <tbody id="contenidoTablaDesactivado">
                        </tbody>
                    </table>
                </div>
            </div>
        </form>

                </asp:View>
            </asp:MultiView>--%>

    <script src="../../TablesJS/TableCliente.js"></script>          
    
</asp:Content>
