<%@ Page Title="" Language="C#" MasterPageFile="~/configuration.Master" AutoEventWireup="true" CodeBehind="VerExamen.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.OpcionesConfigurables.VerExamen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="card-header">
            <strong class="card-title" v-if="headerText">Agregar examen</strong>
        </div>
            <div class="card">
                                             
            <div class="card-body card-block">
                <form id="myfrom" method="post" enctype="multipart/form-data" class="form-horizontal" runat="server">
                    <!--Comienzo de los formularios--> 
                    
                                                                    
                    <!--nombre-->
                <div class="form-group">
                    <div class="col col-md-1"><label for="text-input" class=" form-control-label">Nombre examen:</label></div>
                    <div class="col-12 col-md-3">&nbsp;
                        <asp:TextBox ID="Mnombre" ReadOnly="true" runat="server" Text="" ToolTip="Nombres" CssClass="form-control" ></asp:TextBox>
                            
                    </div>
                </div>

                    <!--precio-->
                <div class="form-group">
                    <div class="col col-md-1"><label for="password-input" class=" form-control-label">Precio examen:</label></div>
                    <div class="col-12 col-md-3">&nbsp;
                        <asp:TextBox ID="Mprecio" ReadOnly="true" runat="server" Text="" ToolTip="Precio" CssClass="form-control" ></asp:TextBox>
                            
                    </div>

                    <div class="modal-footer">
                                <asp:HiddenField runat="server" ID="Id_Examen" />
                                <a class="btn btn-outline-success btn-lg btn-block" href="BuscarExamenes.aspx">Regresar</a>  
                                </div>

                </div>
                    </form>
                    </div>
                </div>
    

                                

    <script type="text/javascript" src="../../Content/VerExamen.js"></script> 
    <script  type="text/javascript">
        window.onload = function () {
            edit('<%=exam.Nombre%>', '<%=exam.Precio_examen%>')
        };
    </script> 
</asp:Content>
