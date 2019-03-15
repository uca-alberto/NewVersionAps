<%@ Page Title="" Language="C#" MasterPageFile="~/configuration.Master" AutoEventWireup="true" CodeBehind="Updexa.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.OpcionesConfigurables.EditarExamenes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="card-header">
            <strong class="card-title" v-if="headerText">Modificar examen</strong>
        </div>
            <div class="card">
                                             
            <div class="card-body card-block">
    <form id="myfrom" method="post" enctype="multipart/form-data" class="form-horizontal" runat="server">
                            
                            <!--nombre-->
                            <div>
                                <div class="col col-md-1"><label for="text-input" class=" form-control-label">Nombres:</label></div>
                                <div class="col-12 col-md-3">&nbsp;
                                    <asp:TextBox ID="Mnombre" runat="server" Text="" ToolTip="Nombres" CssClass="form-control" ></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Mnombre" Display="Dynamic" ErrorMessage="Este Campo es requerido" BorderColor="#FF5050" BorderStyle="None" CssClass="form_hint" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="Mnombre" ErrorMessage="Datos Incorrectos" ValidationExpression="^[a-z &amp; A-Z]*$" BackColor="White" BorderColor="#FF5050" BorderStyle="None" Font-Bold="False" Font-Italic="False" ForeColor="Red"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                              <!--precio-->
                            <div>
                                <div class="col col-md-1"><label for="password-input" class=" form-control-label">Precio:</label></div>
                                <div class="col-12 col-md-3">&nbsp;
                                    <asp:TextBox ID="Mprecio" runat="server" Text="" ToolTip="Precio Examen" CssClass="form-control" ValidateRequestMode="Enabled"></asp:TextBox>       
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Mprecio" Display="Dynamic" ErrorMessage="Este Campo es requerido" ForeColor="#FF3300"></asp:RequiredFieldValidator>                                            
                                    </div>
                            </div>
                            

                                  <div class="modal-footer">
                                    <asp:Button runat="server" CssClass="btn btn-secondary" ID="Cancelar" Text="Cancelar" OnClick="Cancelar_Click" />
                                        <asp:HiddenField runat="server" ID="Id_cliente" />
                                       <asp:Button id="enviar" runat="server" Text="Modificar" CssClass="btn btn-primary" OnClick="EditarFormulario"/>
                                  </div>
                           
        </form>
                </div>
                </div>

    <script type="text/javascript" src="../../../Content/VerExamen.js"></script> 
    <script  type="text/javascript">
        window.onload = function () {
            edit('<%=exam.Nombre%>', '<%=exam.Precio_examen%>')
        };
    </script>
</asp:Content>
