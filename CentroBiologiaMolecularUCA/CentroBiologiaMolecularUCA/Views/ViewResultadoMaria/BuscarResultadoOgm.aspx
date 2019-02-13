<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscarResultadoOgm.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.ViewResultadoMaria.BuscarResultadoOgm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card-header">
       <strong class="card-title">Orden ADN</strong>
        </div> 
           <!--Tabla de orden-->                               
                         <div class="content mt-3">
                        <div class="animated fadeIn">
                            <div class="row">
                                <div class="col-md-12 ">
                                    <div class="card">
                                        <div class="card-header">
                                            <strong class="card-title">Orden ADN humano</strong>
                                        </div>
                                        <div class="card-body">
                                            <table id="bootstrap-data-table" class="table table-striped table-bordered">
                                                <thead>
                                                    <tr>
                                                        <th>Codigo</th>
                                                         
                                                        <th>Analisis</th>
                                                        
                                                        <th>Opciones</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                     <%
                                                        while(getregistros().Read())
                                                        {
                                                            %>
                                                              <tr><td><%=getregistros()["Id_resultado"] %></td>
                                                                  
                                                                  <td><%=getregistros()["Analisis"] %></td>
                                                                  
                                                                  <td>
                                                                   <a title="Mostrar" onclick="mostrar" href="VerResultadoOgm.aspx?id=<%=getregistros()["Id_resultado"] %>">
                                                                       <i class="ti-eye"></i>
                                                                     </a>
                                                                     <a title="Editar" onclick="editar" href="ModificarResultadoOgm.aspx?id=<%=getregistros()["Id_resultado"] %>">
                                                                       <i class="ti-pencil-alt"></i>
                                                                    </a> 
                                                                      <a href="Eliminarresultado.aspx?id=<%=getregistros()["Id_resultado"] %>" onclick="Eliminar('Eliminarresultado.aspx?id=<%=getregistros()["Id_resultado"] %>');">
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
    <script type="text/javascript" src="../../Content/ListaOrdenOgm.js"></script>
</asp:Content>
