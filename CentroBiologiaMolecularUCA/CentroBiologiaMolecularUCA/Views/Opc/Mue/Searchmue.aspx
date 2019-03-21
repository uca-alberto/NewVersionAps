<%@ Page Title="" Language="C#" MasterPageFile="~/configuration.Master" AutoEventWireup="true" CodeBehind="Searchmue.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.Opc.Searchmue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../assets/js/vendor/jquery-2.1.4.min.js"></script>
    <%--   <script src="../../Scripts/jquery.signalR-2.2.3.min.js"></script>--%>
            <script src="../../../Scripts/jquery.signalR-2.2.3.js"></script>
                     <script src="/signalr/hubs"></script>
<%--     <div class="content mt-3">
            <div class="animated">
    <div class="card">
                    <div class="card-header">
                        <i class="mr-2 fa fa-align-justify"></i>
                        <strong class="card-title" v-if="headerText">Crear</strong>
                    </div>
                    <div class="card-body">
                         <button type="button" class="btn-success" data-toggle="modal" data-target="#mediumModal">
                   <i class="menu-icon fa fa-plus-circle"></i> Nueva Muestra </button>
   
                    </div>
                </div>--%>
    <%-- <div class="modal fade" id="mediumModal" tabindex="-1" role="dialog" aria-labelledby="mediumModalLabel" aria-hidden="true">
                    <div class="modal-dialog modal-lg" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="mediumModalLabel">Datos De la Muestra</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                            
                                <!--Aqui Comienza el formulario dentro del modal-->                                
                     <div class="card">
                      <div class="card-body card-block">
                        <form method="post" enctype="multipart/form-data" class="form-horizontal" runat="server">
                              <!--nombre-->
                          <div class="row form-group">
                            <div class="col col-md-3"><label for="text-input" class=" form-control-label">Muestra</label></div>
                            <div class="col-12 col-md-9">
                                 <asp:TextBox ID="Mmuestra" runat="server" Text="" ToolTip="Muestra" CssClass="form-control" ValidateRequestMode="Enabled"></asp:TextBox>
                            </div>
                          </div>
                         <div class="modal-footer">
                          <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                              <asp:HiddenField runat="server" ID="id_usuario" />
                              <asp:Button id="Aceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary" OnClick="Aceptar_Click"/>
                          </div>
                            
                        </form>
                      </div>
                    </div>
                            <!--Botones del Modal-->                               
                    </div>
                        </div>
                    </div>
                </div>--%>
                <!--Tabla de Usuario-->                               
      <div class="content mt-3">
                        <div class="animated fadeIn">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="card">
                                        <div class="card-header">
                                            <strong class="card-title">Muestras</strong>
                                        </div>
                                        <div class="card-body">
                                            <table id="bootstrap-data-table" class="table table-striped table-bordered">
                                                <thead>
                                                    <tr>
                                                       
                                                        <th>Id Muestra</th>
                                                        <th>Descripcion</th>
                                                        <th>Opciones</th>
                                                    </tr>
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

                    <%-- MODAL UTILIZADO PARA MODIFICAR DATOS --%>
 <div class="modal fade" id="mediumModal" tabindex="-1" role="dialog" aria-labelledby="mediumModalLabel" aria-hidden="true">
                    <div class="modal-dialog modal-lg" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="mediumModalLabel">Datos De la Muestra</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                            
                                <!--Aqui Comienza el formulario dentro del modal-->                                
                     <div class="card">
                      <div class="card-body card-block">
                        <form method="post" enctype="multipart/form-data" class="form-horizontal" runat="server">
                              <!--nombre-->
                          <div class="row form-group">
                            <div class="col col-md-3"><label for="text-input" class=" form-control-label">Muestra</label></div>
                            <div class="col-12 col-md-9">
                                 <asp:TextBox ID="Mmuestra" runat="server" Text="" ToolTip="Muestra" CssClass="form-control" ValidateRequestMode="Enabled"></asp:TextBox>
                            </div>
                          </div>
                         <div class="modal-footer">
                          <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                              <asp:HiddenField runat="server" ID="id_usuario" />
                              <asp:Button id="Aceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary" />
                          </div>
                            
                        </form>
                      </div>
                    </div>
                            <!--Botones del Modal-->                               
                    </div>
                        </div>
                    </div>
                </div>
    <script src="../../../TablesJS/TableMuestra.js"></script>
</asp:Content>
