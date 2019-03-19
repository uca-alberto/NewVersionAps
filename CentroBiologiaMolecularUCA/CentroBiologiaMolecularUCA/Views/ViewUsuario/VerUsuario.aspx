﻿<%@ Page Language="C#" MasterPageFile="~/Configuracion.Master" AutoEventWireup="true" CodeBehind="VerUsuario.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.ViewUsuario.VerUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">          
 <div class="card-header">
                        <i class="mr-2 fa fa-align-justify"></i>
                        <strong class="card-title" v-if="headerText">Crear</strong>
                    </div>
                    
               
  
                            
                                <!--Aqui Comienza el formulario dentro del modal-->                                
                     <div class="card">
                      <div class="card-body card-block">
                        <form action="" method="post" enctype="multipart/form-data" class="form-horizontal" runat="server">

                            
                            <!--Comienzo de los formulario-->
                              <!--nombre-->
                          <div class="row form-group">
                            <div class="col col-md-3"><label for="text-input" class=" form-control-label">Nombre de Usuario</label></div>
                            <div class="col-12 col-md-9">
                                 <asp:TextBox ID="Mnombre" runat="server" ReadOnly="true" Text="" ToolTip="Nombre de usuario" CssClass="form-control" ValidateRequestMode="Enabled"></asp:TextBox>
                               </div>
                          </div>
                            <!--Contraseña-->
                          <div class="row form-group">
                            <div class="col col-md-3"><label for="email-input" class=" form-control-label">Nombre Empleado</label></div>
                            <div class="col-12 col-md-9">
                                 <asp:TextBox ID="Mempleado" runat="server" ReadOnly="true" Text="" ToolTip="Nombre Empleado" CssClass="form-control" ValidateRequestMode="Enabled"></asp:TextBox>                                              
                                
                                
                            </div>
                          </div>
                         
                           
                            <!--Seleccion de Rol-->
                          <div class="row form-group">
                            <div class="col col-md-3"><label for="select" class=" form-control-label">Rol</label></div>
                            <div class="col-12 col-md-9">
                              <asp:DropDownList ID="Mrol1" runat="server" ReadOnly="true" ToolTip="Rol del usuario" CssClass="form-control"   AutoPostBack="true">
                               
                              </asp:DropDownList>
                            </div>
                          </div>
                         <div class="modal-footer">
                        
                              <asp:HiddenField runat="server" ID="id_usuario" />
                             <a class="btn btn-outline-sucess btn-lg btn-block" OnClick="javascript: return history.back()">Regresar</a>
                          </div>
                            
                        </form>
                      </div>
                    </div>

 <script type="text/javascript" src="../../Content/listausuario.js">
window.onload = function () {
    edit( '<%=us.Nombre%>',  '<%=us.Id_rol%>')
};
</script> 
</asp:Content>
