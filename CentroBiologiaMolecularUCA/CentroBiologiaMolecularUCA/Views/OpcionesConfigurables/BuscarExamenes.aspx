<%@ Page Title="" Language="C#" MasterPageFile="~/configuration.Master" AutoEventWireup="true" CodeBehind="BuscarExamenes.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.OpcionesConfigurables.BuscarExamenes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="card-header">
       <strong class="card-title">Examenes</strong>
        </div> 
     <!--Tabla de orden-->                               
        <div class="content mt-3">
    <div class="animated fadeIn">
        <div class="row">
            <div class="col-md-12 ">
                <div class="card">
                    <div class="card-header">
                        <strong class="card-title">Examenes</strong>
                    </div>
                    <div class="card-body">
                        <table id="bootstrap-data-table" class="table table-striped table-bordered">
                            <thead>
                                <tr>
                                    <th>Codigo</th>
                                                         
                                    <th>Nombre</th>

                                    <th>Precio</th>
                                                        
                                    <th>Opciones</th>
                                </tr>
                            </thead>
                            <tbody>
                                    <%
                                    while(getregistros().Read())
                                    {
                                        %>
                                            <tr><td><%=getregistros()["Id_examenes"] %></td>
                                                                  
                                                <td><%=getregistros()["Nombre"] %></td>

                                                <td><%=getregistros()["Precio_examen"] %></td>
                                                                  
                                                <td>
                                                    <a title="Mostrar" onclick="mostrar" href="VerExamen.aspx?id=<%=getregistros()["Id_examenes"] %>">
                                                    <i class="ti-eye"></i>
                                                    </a>
                                                    <a title="Editar" onclick="editar" href="EditarExamenes.aspx?id=<%=getregistros()["Id_examenes"] %>">
                                                    <i class="ti-pencil-alt"></i>
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

    <script type="text/javascript" src="../../Content/ListaExamen.js"></script>
</asp:Content>
