<%@ Page Title="" Language="C#" MasterPageFile="~/configuration.Master" AutoEventWireup="true" CodeBehind="Upduse.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.Opc.Use.Upduse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!--script de alerta-->
            <div class="content mt-3">
            <div class="animated">
    <div class="card">
                    <div class="card-header">      
                        <strong class="mr-2 fa fa-align-justify">Usuario del empleado</strong>
                            </div>
                    <div class="card-body">
                         <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#mediumModal">
                   <i class="fa fa-search"></i> Seleccionar Usuario</button>
   
                    </div>
                </div>

                 <div class="modal fade" id="mediumModal" tabindex="-1" role="dialog" aria-labelledby="mediumModalLabel" aria-hidden="true">
                    <div class="modal-dialog modal-lg" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="mediumModalLabel">Usuarios Activos</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                           <!--Buscar Empleado-->
                    <div class="card-header">
                        <strong class="card-title">Buscar Empleado</strong>
                            </div> 
                
                    <div class="card-body">
                        <table id="bootstrap-data-table" class="table table-striped table-bordered" >
                            <thead>
                                <tr>
                                    <th>Id</th>                   
                                    <th>Nombre</th>
                                    <th>Apellido</th>
                                    <th>Cedula</th>
                                    <th>Seleccionar</th>

                                </tr>
                            </thead>
                            <tbody>
                                    <%
                                    while(getregistros().Read())
                                    {
                                        %>
                                            <tr><td><%=getregistros()["Id_empleado"] %></td>
                                                                  
                                                <td><%=getregistros()["Nombre_empleado"] %></td>

                                                <td><%=getregistros()["Apellido"] %></td>

                                                <td><%=getregistros()["Cedula"] %></td>

                                                <td>
                                                        <button id="btn" type="button" class="btn btn-success"  data-dismiss="modal"> <i class="fa fa-user-plus"></i> Seleccionar</button>
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
                     </div>
                </div>
    </div>
      

        <strong class="card-title">Editar Usuario</strong>
           </div>  
             <div class="card">
               <div class="card-body card-block">
                  <form method="post" enctype="multipart/form-data" class="form-horizontal" runat="server">
                            
                                <!--Aqui Comienza el formulario dentro del modal-->                                
                     
                          <!--Obtener el Id del Empleado que selecciono-->
          
        <asp:HiddenField runat="server" ID="Idempleado" />

                     <!--Obtener el nombre del Empleado que selecciono-->
            <div class="row form-group ">
                <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Nombre Empleado</label></div>
                <div class="col-12 col-md-9">
                     <asp:TextBox ID="Musuario" ReadOnly="true" runat="server" ToolTip="Nombre Empleado" CssClass="form-control"></asp:TextBox>   
                </div>
             </div>
                    <!--Obtener la cedula del Empleado que selecciono-->
           <div class="row form-group ">
                <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Cedula</label></div>
                <div class="col-12 col-md-9">
                     <asp:TextBox ID="Mcedula" ReadOnly="true" runat="server" ToolTip="Cedula Empleado" CssClass="form-control"></asp:TextBox>      
                     </div>
             </div>


                    <div class="card-header">
                        <strong class="card-title">Datos Usuario</strong>
                            </div>&nbsp;

      
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
                                                        
  <script type="text/javascript" src="../../../Content/ListarUsuario.js"></script>

    <script type="text/javascript" src="../../../Content/listausuario.js"></script>     
<script  type="text/javascript">
       window.onload = function () {
            edit('<%=us.Nombre%>', '<%=us.Id_rol%>')
        };
    </script> 

</asp:Content>
