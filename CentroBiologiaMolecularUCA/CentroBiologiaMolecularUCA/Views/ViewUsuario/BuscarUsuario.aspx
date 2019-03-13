<%@ Page Language="C#" MasterPageFile="~/configuration.Master" AutoEventWireup="true" CodeBehind="BuscarUsuario.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.ViewUsuario.BuscarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card-header">
       <strong class="card-title">Orden ADN</strong>
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
                                                              <tr>
                                                                  <td><%=getregistros()["Nombre_Usuario"] %></td>
                                                                  <td><%=getregistros()["Id_Rol"] %></td>
                                                                 
                                                                  <td>
                                                                     <a title="Mostrar" onclick="mostrar" href="../../Views/ViewUsuario/VerUsuario.aspx?id=<%=getregistros()["Id_usuario"] %>">
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