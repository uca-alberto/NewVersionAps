﻿<%@ Page Title="" Language="C#" MasterPageFile="~/configuration.Master" AutoEventWireup="true" CodeBehind="Updemp.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.OpcionesConfigurables.Emp.EditEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <script>
        function ADD() {
            swal({
                title: "Error",
                text: "Revisar Formulario",
                icon: "warning",
                button: "OK",
            });
    }
    </script>     
    
    <script>
        function Modificarempleado(data) {
            swal({
                title: "Empleado Modificado",
                text: "Correctamente",
                icon: "success",
               // buttons: true,
                //dangerMode: true,
            })
          .then((willDelete) => {
              if (willDelete) {
                  location.href = "Searchemp.aspx";
              } 
          });
        }
    </script>

    <div class="card-header">
       <strong class="card-title"> Modificar Datos del Empleado </strong>
        </div>  
                <!--Aqui Comienza el formulario dentro del modal-->                                
                     <div class="card">
                      <div class="card-body card-block">
                          <form method="post" enctype="multipart/form-data" class="form-horizontal" runat="server">

                                <!--Comienzo de los formulario-->

                  <!--cedula-->

                <div>
                    <div class="col col-sm-3"><label for="password-input" class=" form-control-label">Cédula:</label></div>
                        <asp:TextBox ID="Mcedula" runat="server" Text="" ToolTip="Cedula Identidad" CssClass="form-control" ValidateRequestMode="Enabled" MaxLength="16"></asp:TextBox>       
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Mcedula" Display="Dynamic" ErrorMessage="Este Campo es requerido" ForeColor="#FF3300"></asp:RequiredFieldValidator>                                            
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="Mcedula" ErrorMessage="Datos Incorrectos" ValidationExpression="^[0-99\-]+[0-999999\-]+[0-999A-Z]*$" BorderColor="#FF3300" ForeColor="#FF3300"></asp:RegularExpressionValidator>
                </div>

                <div>                      
                    <!--Nombres-->
                    <div class="col col-sm-3"><label for="text-input" class=" form-control-label">Nombres:</label></div>
                        <asp:TextBox ID="Mnombre" runat="server" Text="" ToolTip="Nombres" CssClass="form-control" MaxLength="45"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Mnombre" Display="Dynamic" ErrorMessage="Este Campo es requerido" BorderColor="#FF5050" BorderStyle="None" CssClass="form_hint" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Mnombre" ErrorMessage="Datos Incorrectos" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]*$" BackColor="White" BorderColor="#FF5050" BorderStyle="None" Font-Bold="False" Font-Italic="False" ForeColor="Red"></asp:RegularExpressionValidator>
                </div> 

                     
                    <!--Apellidos-->
                     <div>  
                    <div class="col col-sm-3"><label for="email-input" class=" form-control-label">Apellidos:</label></div>
                        <asp:TextBox ID="Mapellido" runat="server" Text="" ToolTip="Apellidos" CssClass="form-control" MaxLength="45"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Mapellido" Display="Dynamic" ErrorMessage="Este Campo es requerido" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="Mapellido" ErrorMessage="Datos Incorrectos" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]*$" ForeColor="#FF3300"></asp:RegularExpressionValidator>              
                   </div>
							            <!--Cargo -->
                    <div class="col col-sm-3"><label for="email-input" class=" form-control-label">Cargo:</label></div>
					
					<asp:DropDownList ID="Mcargo" runat="server" CssClass="form-control">
						<asp:ListItem Value="Laboratorista">Laboratorista</asp:ListItem>
						<asp:ListItem Value="Recepcionista">Recepcionista </asp:ListItem>
						<asp:ListItem Value="Administrador">Administrador</asp:ListItem>
					</asp:DropDownList>
                             <div class="modal-footer">
                                     <asp:Button id="cancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="cancelar_Click" />
                                     <asp:HiddenField runat="server" ID="Id_Emp" />
                                   <asp:Button id="enviar" runat="server" Text="Modificar" CssClass="btn btn-primary" OnClick="EditarFormulario" />
                          </div>
                              </form>
                              </div>
                         </div>

	<script src="../../../Content/Generic.js"></script>
    <script  type="text/javascript">
window.onload = function () {
	editEmpleados('<%=emp.Cedula%>', '<%=emp.Nombre_Empleado%>', '<%=emp.Apellido%>','<%=emp.Cargo%>'
           )
};


</script>
</asp:Content>
