<%@ Page Title="" Language="C#" MasterPageFile="~/configuration.Master" AutoEventWireup="true" CodeBehind="Seexa.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.OpcionesConfigurables.VerExamen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="card-header">
            <strong class="card-title" v-if="headerText">Examen</strong>
        </div>
             <!--Aqui Comienza el formulario dentro del modal-->                                
                     <div class="card">
                      <div class="card-body card-block">
                        <form method="post" enctype="multipart/form-data" class="form-horizontal" runat="server">
                              <!--nombre-->
                      
                          <div class="row form-group">
                            <div class="col col-md-3"><label for="text-input" class=" form-control-label">Nombre Examen</label></div>
                            <div class="col-12 col-md-9">
                                 <asp:TextBox ID="Mnombre" runat="server" Text="" ToolTip="Nombres" CssClass="form-control" required="required" ></asp:TextBox>
                               </div>
                          </div>
                            <!--Precio-->
                            <div class="row form-group">
                            <div class="col col-md-3"><label for="text-input" class=" form-control-label">Precio Examen</label></div>
                                 <div class="col-12 col-md-9">
                            <asp:TextBox ID="Mprecio" runat="server" Text="" ToolTip="Precio" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                 </div>
                         <div class="modal-footer">
                              <asp:HiddenField runat="server" ID="Id_Examen" />
                                <a class="btn btn-outline-success btn-lg btn-block" href="Searchexa.aspx">Regresar</a>               

                          </div>
                            
                        </form>
                      </div>
                    </div>

    <script type="text/javascript" src="../../../Content/VerExamen.js"></script> 
    <script  type="text/javascript">
        window.onload = function () {
            edit('<%=exam.nombre%>', '<%=exam.precio_examen%>')
        };
    </script> 
</asp:Content>
