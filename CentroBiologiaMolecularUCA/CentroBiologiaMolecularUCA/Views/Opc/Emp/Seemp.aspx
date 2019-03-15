<%@ Page Title="" Language="C#" MasterPageFile="~/configuration.Master" AutoEventWireup="true" CodeBehind="Seemp.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.OpcionesConfigurables.Emp.SeeEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="card-header">
<strong class="card-title">Vista de Empleado</strong>
    </div> 
    <div class="card">
        <div class="card">
            <div class="card-body card-block">
       
                <form id="Form1" method="post" enctype="multipart/form-data" class="form-horizontal" runat="server">
               
                     <!--Comienzo de los formulario-->
                      <!--Cargo -->
                  <div>
                    <div class="col col-sm-3"><label for="email-input" class=" form-control-label">Cargo:</label></div>
                        <asp:TextBox ID="Mcargo" runat="server" Text="" ToolTip="cargo" CssClass="form-control" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Mcargo" Display="Dynamic" ErrorMessage="Este Campo es requerido" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="Mcargo" ErrorMessage="Datos Incorrectos" ValidationExpression="^[a-z &amp; A-Z]*$" ForeColor="#FF3300"></asp:RegularExpressionValidator>     
                      </div>

                  <!--cedula-->

                <div>
                    <div class="col col-sm-3"><label for="password-input" class=" form-control-label">Cédula:</label></div>
                        <asp:TextBox ID="Mcedula" runat="server" Text="" ToolTip="Cedula Identidad" CssClass="form-control" ValidateRequestMode="Enabled"></asp:TextBox>       
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Mcedula" Display="Dynamic" ErrorMessage="Este Campo es requerido" ForeColor="#FF3300"></asp:RequiredFieldValidator>                                            
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="Mcedula" ErrorMessage="Datos Incorrectos" ValidationExpression="^[0-99\-]+[0-999999\-]+[0-999A-Z]*$" BorderColor="#FF3300" ForeColor="#FF3300"></asp:RegularExpressionValidator>
                </div>

                <div>                      
                    <!--Nombres-->
                    <div class="col col-sm-3"><label for="text-input" class=" form-control-label">Nombres:</label></div>
                        <asp:TextBox ID="Mnombre" runat="server" Text="" ToolTip="Nombres" CssClass="form-control" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Mnombre" Display="Dynamic" ErrorMessage="Este Campo es requerido" BorderColor="#FF5050" BorderStyle="None" CssClass="form_hint" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Mnombre" ErrorMessage="Datos Incorrectos" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]*$" BackColor="White" BorderColor="#FF5050" BorderStyle="None" Font-Bold="False" Font-Italic="False" ForeColor="Red"></asp:RegularExpressionValidator>
                </div> 

                     
                    <!--Apellidos-->
                     <div>  
                    <div class="col col-sm-3"><label for="email-input" class=" form-control-label">Apellidos:</label></div>
                        <asp:TextBox ID="Mapellido" runat="server" Text="" ToolTip="Apellidos" CssClass="form-control" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Mapellido" Display="Dynamic" ErrorMessage="Este Campo es requerido" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="Mapellido" ErrorMessage="Datos Incorrectos" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]*$" ForeColor="#FF3300"></asp:RegularExpressionValidator>              
                   </div>

                           
            

                    <div class="modal-footer">
                       <asp:HiddenField runat="server" ID="Id_Emp" />
                      <a class="btn btn-outline-success btn-lg btn-block" href="Searchemp.aspx">Regresar</a>  
                </div>


                 </form>

            </div>
            </div>
        </div> 


       <script src="../../../Content/listaempleado.js"></script>

<script  type="text/javascript">
window.onload = function () {
    edit( '<%=emp.Cargo%>' ,'<%=emp.Cedula%>', '<%=emp.Nombre_Empleado%>', '<%=emp.Apellido%>'
           )
};
</script> 

</asp:Content>
