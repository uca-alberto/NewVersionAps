<%@ Page Title="" Language="C#" MasterPageFile="~/configuration.Master" AutoEventWireup="true" CodeBehind="Searchemp.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.OpcionesConfigurables.Emp.Searchemp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                            <strong class="card-title">Empleados Activos</strong>
                        </div>
                        <div class="card-body">
                            <!-- .Tabla donde se muestran los empleados Activos -->
                  <table id="bootstrap-data-table" class="table table-striped table-bordered">
                    <thead>
                        <th>Codigo</th>
                        <th>Nombres</th>
                        <th>Apellidos</th>
                        <th>Cargo</th>
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


    <script src="../../../TablesJS/TableEmpleado.js"></script> <!-- .referencia al script por el cual se muestran todos los empleados activos en la BD -->
    
</asp:Content>
