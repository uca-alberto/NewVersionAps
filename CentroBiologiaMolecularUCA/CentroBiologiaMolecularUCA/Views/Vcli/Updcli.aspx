<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Updcli.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.ViewCliente.EditarCliente" %>
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
        function ModificarCliente(data) {
            swal({
                title: "Cliente Modificado",
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
 <div class="card-header">
        <strong class="card-title">Edicion Cliente</strong>
         </div>  
            <div class="card">
            <div class="card-body card-block">
                <form id="myfrom" method="post" enctype="multipart/form-data" class="form-horizontal" runat="server">
                    <!--Comienzo de los formulario-->                       
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
                             <asp:HiddenField runat="server" ID="Id_cliente" />
                        <asp:Button id="alert" runat="server" Text="Modificar" CssClass="btn btn-primary" OnClick="EditarFormulario"/>
                        
                    </div>
                </form>
            </div>
         </div>   
   

    <script type="text/javascript" src="../../Content/listacliente.js"></script>    
     
    <script  type="text/javascript">
        window.onload = function () {
            edit('<%=cli.Cedula%>', '<%=cli.Nombres%>', '<%=cli.Apellidos%>', '<%=cli.Municipio%>','<%=cli.Departamento%>',
                '<%=cli.Sexo%>','<%=cli.Telefono%>','<%=cli.Correo%>','<%=cli.Dirreccion %>')
        };
    </script>               
</asp:Content>
