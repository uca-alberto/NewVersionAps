<%@ Page Title="" Language="C#" MasterPageFile="~/configuration.Master" AutoEventWireup="true" CodeBehind="Upduse.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.Opc.Use.Upduse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card-header">
        <strong class="card-title">Editar Usuario</strong>
           </div>  
             <div class="card">
               <div class="card-body card-block">
                  <form method="post" enctype="multipart/form-data" class="form-horizontal" runat="server">
                            
                                <!--Aqui Comienza el formulario dentro del modal-->                                
                     

                             <!--Comienzo de los formulario-->
                          
                              <!--nombre-->
                          <div class="row form-group">
                            <div class="col col-md-3"><label for="text-input" class=" form-control-label">Nombre de Usuario</label></div>
                            <div class="col-12 col-md-9">
                                 <asp:TextBox ID="Mnombre" runat="server" Text="" ToolTip="Nombre de usuario" CssClass="form-control" ValidateRequestMode="Enabled"></asp:TextBox>                                              
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Mnombre" ErrorMessage="Nombre incorrecto"></asp:RegularExpressionValidator>
                            </div>
                          </div>
                            <!--Password-->
                          <div class="row form-group">
                            <div class="col col-md-3"><label for="text-input" class=" form-control-label">Contraseña</label></div>
                            <div class="col-12 col-md-9">
                                <asp:TextBox ID="Mcontrasena" runat="server" Text="" ToolTip="Contrasena" CssClass="form-control" ValidateRequestMode="Enabled"></asp:TextBox>                                              
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="Mcontrasena" ErrorMessage="Contraseña incorrecta"></asp:RegularExpressionValidator>
                            </div>
                          </div>
                           
                           
                            <!--Seleccion de Rol-->
                          <div class="row form-group">
                            <div class="col col-md-3"><label for="select" class=" form-control-label">Rol</label></div>
                            <div class="col-12 col-md-9">
                              <asp:DropDownList ID="Mrol" runat="server" ToolTip="Rol del usuario" CssClass="form-control">
                               
                              </asp:DropDownList>
                            </div>
                          </div>

                          <div class="modal-footer">
                          <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                          <asp:HiddenField runat="server" ID="Id_usuario" />
                          <asp:Button id="enviar" runat="server" Text="Modificar" CssClass="btn btn-primary" OnClick="EditarFormulario" />
                            </div>
                        </form>
                      </div>
                    </div>
                                                        
                    
    <script type="text/javascript" src="../../../Content/listausuario.js"></script>     
<script  type="text/javascript">
       window.onload = function () {
            edit('<%=us.Nombre%>', '<%=us.Id_rol%>')
        };
    </script> 
</asp:Content>
