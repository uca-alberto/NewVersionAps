<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Addcli.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.ViewCliente.AgregarCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
        function Advertenciaimg() {
            swal({
                title: "Error",
                text: "Imagen Demasiado Grande",
                icon: "warning",
                button: "OK",
            });
    }
    </script>
   
     <script>
        function InsertarCliente(data) {
            swal({
                title: "Cliente Agregado",
                text: "Correctamente",
                icon: "success",
               // buttons: true,
                //dangerMode: true,
            })
          .then((willDelete) => {
              if (willDelete) {
                  location.href = "Searchcli.aspx";
              } 
          });
        }
    </script>

    <!-------- Alerta de permisos ------>
     <script>
        function Acceso(data) {
            swal({
                title: "Usted no tiene acceso",
                text: "restricted access",
                icon: "error",
                
            })
          .then((willDelete) => {
              if (willDelete) {
                  location.href = "../../Views/Index.aspx";
              } 
          });
        }
    </script>



    <!--script de alerta-->
    
    <div class="card-header">
        <strong class="card-title">Nuevo Cliente</strong>
         </div>  
            <div class="card">
            <div class="card-body card-block">
                <form id="myfrom" method="post" enctype="multipart/form-data" class="form-horizontal" runat="server">
                    <!--Comienzo de los formulario-->   
						<div>
                        <div class="col col-sm-3"><label for="disabled-input" class=" form-control-label">Imagen:</label></div>
						  <asp:FileUpload ID="FileUpload1" runat="server" />
						  <asp:label runat="server" ID="Urlimagen"/>
						  </div>
					<br />
                    <!--cedula-->
                <div>
                    <div class="col col-sm-3"><label for="password-input" class=" form-control-label">Cedula:</label></div>
                        <asp:TextBox ID="Mcedula" runat="server" Text="" ToolTip="Cedula Identidad" CssClass="form-control" ValidateRequestMode="Enabled"></asp:TextBox>       
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Mcedula" Display="Dynamic" ErrorMessage="Este Campo es requerido" ForeColor="#FF3300"></asp:RequiredFieldValidator>                                            
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="Mcedula" ErrorMessage="Datos Incorrectos" ValidationExpression="^[0-99\-]+[0-999999\-]+[0-999A-Z]*$" BorderColor="#FF3300" ForeColor="#FF3300"></asp:RegularExpressionValidator>
                </div>
                <div>                      
                    <!--nombre-->
                    <div class="col col-sm-3"><label for="text-input" class=" form-control-label">Nombres:</label></div>
                        <asp:TextBox ID="Mnombre" runat="server" Text="" ToolTip="Nombres" CssClass="form-control" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Mnombre" Display="Dynamic" ErrorMessage="Este Campo es requerido" BorderColor="#FF5050" BorderStyle="None" CssClass="form_hint" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Mnombre" ErrorMessage="Datos Incorrectos" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]*$" BackColor="White" BorderColor="#FF5050" BorderStyle="None" Font-Bold="False" Font-Italic="False" ForeColor="Red"></asp:RegularExpressionValidator>
                </div> 
                    <!--apelldio-->
                    <div class="col col-sm-3"><label for="email-input" class=" form-control-label">Apellidos:</label></div>
                        <asp:TextBox ID="Mapellido" runat="server" Text="" ToolTip="Apellidos" CssClass="form-control" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Mapellido" Display="Dynamic" ErrorMessage="Este Campo es requerido" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="Mapellido" ErrorMessage="Datos Incorrectos" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]*$" ForeColor="#FF3300"></asp:RegularExpressionValidator>              
                    <div class="card-header">
                        <strong class="card-title">Datos Primarios </strong>
                            </div>  &nbsp;
                           
                    <div><!--Sexo-->
                              <div class="col col-sm-3"><label>Sexo:</label>
                                  <asp:DropDownList ID="Msexo" runat="server" ToolTip="Sexo" CssClass="form-control" required="">
                                      <asp:ListItem Value="1">Maculino</asp:ListItem>
                                      <asp:ListItem Value="2">Femenino</asp:ListItem>
                                    </asp:DropDownList>  
                             </div>
                         </div> 
                  
                     <asp:ScriptManager runat="server" ID="scriptmanager1"></asp:ScriptManager>
                      <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                          <ContentTemplate> 
                <div><!--departamento-->
                 <div class="col col-sm-3"><label>Departamento</label>
                      <asp:DropDownList ID="Mdepartamento" runat="server" required=""  ToolTip="Departamento" CssClass="form-control" OnSelectedIndexChanged="Mdepartamento_SelectedIndexChanged" AutoPostBack="true" DataTextField="Departamento" DataValueField="Id_departamento">
                         </asp:DropDownList>

                 </div>
                </div>
                  <div>
                      <div class="col col-sm-3"><label>Municipio:</label>
                         <asp:DropDownList ID="Mmunicipio" runat="server" ToolTip="Municipio" required=""  CssClass="form-control" DataTextField="Municipio" DataValueField="Id_Municipio">
                         </asp:DropDownList>
                      </div>
                  </div> 
                              </ContentTemplate>
                          </asp:UpdatePanel>

                        <!--Direccion-->     
                    <div>
                     <div class="col col-sm-3"><label>Dirrección:</label>
                          <asp:TextBox ID="Mdireccion" runat="server" Text="" ToolTip="Direccion" CssClass="form-control" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Mdireccion" Display="Dynamic" ErrorMessage="Este Campo es requerido" ForeColor="#FF3300">
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="Mdireccion" ErrorMessage="Datos Incorrectos" ValidationExpression="^[a-z &amp; A-Z]*$" ForeColor="#FF3300">
                                </asp:RegularExpressionValidator>

                     </div>
                 </div> 

                    <div class="card-header">
                        <strong class="card-title">Contacto</strong>
                            </div>  &nbsp;
                    <!--telefono-->                            
                    <div >
                    <div class="col col-md-1"><label for="Ntelefono" class=" form-control-label">Telefono:</label></div>
                        <asp:TextBox ID="Mtelefono" runat="server" type="text" ToolTip="Telefono" CssClass="form-control" placeholder="505 0000-0000"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Mtelefono" Display="Dynamic" ErrorMessage="Este Campo es requerido" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="Mtelefono" ErrorMessage="Datos Incorrectos" ValidationExpression="^[0-9]*$" MaxLength="8" ForeColor="#FF3300"></asp:RegularExpressionValidator>                                                   
                </div>
                    <!--correo-->
                    <div>
                        <div class="col col-sm-3"><label for="disabled-input" class=" form-control-label">Correo:</label></div>
                        <asp:TextBox ID="Mcorreo" runat="server" Text="" ToolTip="Correo" CssClass="form-control" placeholder="ejemplo@gmail.com"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Mcorreo" Display="Dynamic" ErrorMessage=" Este Campo es requerido" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" BorderColor="Red" BorderStyle="None" ControlToValidate="Mcorreo" ErrorMessage="Correo Incorrecto" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>    
                    </div>
                
                    <br />
                    <div class="modal-footer">
                        <asp:Button id="cancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="cancelar_Click" />
                        <asp:HiddenField runat="server" ID="id_cliente" />
                        <asp:Button id="alert" runat="server" Text="Registrar" CssClass="btn btn-primary" OnClick="InsertarCliente"/>
                        
                    </div>
                </form>
            </div>
         </div>   

                 


                  
   
   
</asp:Content>
