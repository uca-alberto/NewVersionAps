<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Aprreall.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.Vreogm.Aprreall" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-------- Alerta de permisos ------>
     <script>
        function Acceso(data) {
            swal({
                title: "Usted no tiene acceso",
                text: "restricted access",
                icon: "error",
                
            })
          .then((willDelete) => {
              if (willDelete) {
                  location.href = "../../Views/Index.aspx";
              } 
          });
        }
    </script>
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
                            <strong class="card-title">Resultados Ordenes</strong>
                        </div>
                        <div class="card-body">
                  <table id="bootstrap-data-table" class="table table-striped table-bordered">
                    <thead>
                        <th>Id Resultado</th>
                        <th>Código</th>
                        <th>Examen</th>
                        <th>Estado Orden</th>
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

 <script src="../../../TablesJS/TableAprobar.js"></script>

</asp:Content>
