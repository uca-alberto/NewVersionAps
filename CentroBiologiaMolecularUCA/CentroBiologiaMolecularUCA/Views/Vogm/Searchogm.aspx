<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Searchogm.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.Vogm.Searchogm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
