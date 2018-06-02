<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscarCliente.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.ViewCliente.BuscarCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
<%--     <script src="/assets/js/lib/data-table/datatables.min.js"></script>
    <script src="/assets/js/lib/data-table/dataTables.bootstrap.min.js"></script>
    <script src="/assets/js/lib/data-table/buttons.print.min.js"></script>
    <script src="/assets/js/lib/data-table/datatables-init.js"></script>--%>
        
                 <script src="../../Scripts/jquery-1.6.4.min.js"></script>
    <script src="../../Scripts/jquery.signalR-2.2.3.min.js"></script>
    <script src="/signalr/js"></script>


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
              var $tblEncabezado = $('#encabezadoTabla');
              var $tblContenido = $('#contenidoTabla');
              $.ajax({
                  url: 'BuscarCliente.aspx/GetData',
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
    

    <form id="form1" runat="server">
            <div class="card">
                <div class="card-header">
                    <strong class="card-title">Listado de Clientes</strong>
                </div>
                <div class="card-body">
                    <table id="datatable-fixed-header" class="table table-striped table-bordered">
                        <thead id="encabezadoTabla">
                        </thead>
                        <tbody id="contenidoTabla">
                        </tbody>
                    </table>
                </div>
            </div>
    </form>
</asp:Content>
