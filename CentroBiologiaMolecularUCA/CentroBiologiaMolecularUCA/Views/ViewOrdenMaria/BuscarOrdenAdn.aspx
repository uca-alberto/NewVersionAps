<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscarOrdenAdn.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.ViewOrdenMaria.BuscarOrdenAdn" %>
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
                                                         
                                    <th>baucher</th>
                                                        
                                    <th>Opciones</th>
                                </tr>
                            </thead>
                            <tbody>
                                    <%
                                    while(getregistros().Read())
                                    {
                                        %>
                                            <tr><td><%=getregistros()["Id_orden"] %></td>
                                                                  
                                                <td><%=getregistros()["Baucher"] %></td>
                                                                  
                                                <td>
                                                    <a title="Mostrar" onclick="mostrar" href="VerOrdenAdn.aspx?id=<%=getregistros()["Id_orden"] %>">
                                                    <i class="ti-eye"></i>
                                                    </a>
                                                    <a title="Editar" onclick="editar" href="ModificarOrden.aspx?id=<%=getregistros()["Id_orden"] %>">
                                                    <i class="ti-pencil-alt"></i>
                                                </a> 
                                                    <a href="EliminarOrden.aspx?id=<%=getregistros()["Id_orden"] %>" onclick="Eliminar('EliminarOrden.aspx?id=<%=getregistros()["Id_orden"] %>');">
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

    <script type="text/javascript" src="../../Content/Listaorden.js"></script>
</asp:Content>
