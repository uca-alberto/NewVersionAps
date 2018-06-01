<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarUsuario.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.ViewUsuario.AgregarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="content mt-3">
            <div class="animated">
    <div class="card">
                    <div class="card-header">
                        <i class="mr-2 fa fa-align-justify"></i>
                        <strong class="card-title" v-if="headerText">Crear</strong>
                    </div>
                    <div class="card-body">
                         <button type="button" class="btn-success" data-toggle="modal" data-target="#mediumModal">
                   <i class="menu-icon fa fa-plus-circle"></i> Nuevo Usuario </button>
   
                    </div>
                </div>
     <div class="modal fade" id="mediumModal" tabindex="-1" role="dialog" aria-labelledby="mediumModalLabel" aria-hidden="true">
                    <div class="modal-dialog modal-lg" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="mediumModalLabel">Datos Del Usuario</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                            
                                <!--Aqui Comienza el formulario dentro del modal-->                                
                     <div class="card">
                      <div class="card-body card-block">
                        <form action="" method="post" enctype="multipart/form-data" class="form-horizontal" runat="server">

                            
                            <!--Comienzo de los formulario-->
                          
                              <!--nombre-->
                          <div class="row form-group">
                            <div class="col col-md-3"><label for="text-input" class=" form-control-label">Nombre de Usuario</label></div>
                            <div class="col-12 col-md-9">
                                 <asp:TextBox ID="Mnombre" runat="server" Text="" ToolTip="Nombre de usuario" CssClass="form-control" ValidateRequestMode="Enabled"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Mnombre" Display="Dynamic" ErrorMessage="Este Campo es requerido" BorderColor="#FF5050" BorderStyle="None" CssClass="form_hint" ForeColor="Red"></asp:RequiredFieldValidator>
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Mnombre" ErrorMessage="Nombre incorrecto"></asp:RegularExpressionValidator>
                            </div>
                          </div>
                            <!--Contraseña-->
                          <div class="row form-group">
                            <div class="col col-md-3"><label for="email-input" class=" form-control-label">Contraseña</label></div>
                            <div class="col-12 col-md-9">
                                 <asp:TextBox ID="Mcontrasena" runat="server" Text="" ToolTip="Contraseña" CssClass="form-control" ValidateRequestMode="Enabled"></asp:TextBox>                                              
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Mnombre" Display="Dynamic" ErrorMessage="Este Campo es requerido" BorderColor="#FF5050" BorderStyle="None" CssClass="form_hint" ForeColor="Red"></asp:RequiredFieldValidator>
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="Mcontrasena" ErrorMessage="Contraseña incorrecta"></asp:RegularExpressionValidator>
                            </div>
                          </div>
                         
                           
                            <!--Seleccion de Rol-->
                          <div class="row form-group">
                            <div class="col col-md-3"><label for="select" class=" form-control-label">Rol</label></div>
                            <div class="col-12 col-md-9">
                              <asp:DropDownList ID="Mrol" runat="server" ToolTip="Rol del usuario" CssClass="form-control"   AutoPostBack="true">
                               
                              </asp:DropDownList>
                            </div>
                          </div>
                         <div class="modal-footer">
                          <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                              <asp:HiddenField runat="server" ID="id_usuario" />
                              <asp:Button id="Aceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary" OnClick="InsertarUsuario"/>
                          </div>
                            
                        </form>
                      </div>
                    </div>
                            <!--Botones del Modal-->                               
                    </div>
                        </div>
                    </div>
                </div>
                     </div>
        </div>
                            <!--Tabla de Usuario-->                               
      <div class="content mt-3">
                        <div class="animated fadeIn">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="card">
                                        <div class="card-header">
                                            <strong class="card-title">Usuarios</strong>
                                        </div>
                                        <div class="card-body">
                                            <table id="bootstrap-data-table" class="table table-striped table-bordered">
                                                <thead>
                                                    <tr>
                                                        <th>Id del Usuario</th>
                                                        <th>Nombre del Usuario</th>
                                                        <th>Rol</th>
                                                        <th>Opciones</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <%
                                                        while(getregistros().Read())
                                                        {
                                                            %>
                                                              <tr><td><%=getregistros()["Id_usuario"] %></td>
                                                                  <td><%=getregistros()["Nombre_Usuario"] %></td>
                                                                  <td><%=getregistros()["Id_Rol"] %></td>
                                                                 
                                                                  <td>
                                                                     <a title="Mostrar" onclick="mostrar" href="VerUsuario.aspx?id=<%=getregistros()["Id_usuario"] %>">
                                                                       <i class="ti-eye"></i>
                                                                     </a>
                                                                     <a title="Editar" onclick="editar" href="EditarUsuario.aspx?id=<%=getregistros()["Id_usuario"] %>">
                                                                       <i class="ti-pencil-alt"></i>
                                                                    </a> 
                                                                      <a href="delete.aspx?id=<%=getregistros()["Id_usuario"] %>" onclick="Eliminar('EliminarUsuario.aspx?id=<%=getregistros()["Id_usuario"] %>');">
                                                                      <i class="menu-icon fa fa-trash-o"></i>
                                                                      </a> 
                                                                      </td>
                                                             </tr>
                                                            <%
                                                        }
                                                    %>                                           
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div><!-- .animated -->
                    </div><!-- .content -->
    <script type="text/javascript" src="../../Content/listausuario.js"></script>
</asp:Content>
