<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerCliente.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.ViewCliente.VerCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <div class="card-header">
        <strong class="card-title">Vista de Cliente</strong>
           </div>  
            <div class="card">
                        <div class="card-body card-block">
                            <form id="myfrom" method="post" enctype="multipart/form-data" class="form-horizontal" runat="server">
                                <!--Comienzo de los formulario-->
                                                   
                                <!--cedula-->
                            <div>
                                <div class="col col-md-1"><label for="password-input" class=" form-control-label">Cedula:</label></div>
                                <div class="col-12 col-md-3">&nbsp;
                                    <asp:TextBox ID="Mcedula" runat="server" Text="" ToolTip="Cedula Identidad" CssClass="form-control" ValidateRequestMode="Enabled" ReadOnly="true"></asp:TextBox>                                              
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="Mcedula" ErrorMessage="Datos Incorrectos" ValidationExpression="^[a-z &amp; A-Z]*$" BorderColor="#FF3300" ForeColor="#FF3300"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Mcedula" Display="Dynamic" ErrorMessage="Este Campo es requerido" ForeColor="#FF3300"></asp:RequiredFieldValidator>     
                                    </div>
                            </div>
                                                
                                <!--nombre-->
                            <div>
                                <div class="col col-md-1"><label for="text-input" class=" form-control-label">Nombres:</label></div>
                                <div class="col-12 col-md-3">&nbsp;
                                    <asp:TextBox ID="Mnombre" runat="server" Text="" ToolTip="Nombres" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Mnombre" ErrorMessage="Datos Incorrectos" ValidationExpression="^[a-z &amp; A-Z]*$" BackColor="White" BorderColor="#FF5050" BorderStyle="None" Font-Bold="False" Font-Italic="False" ForeColor="Red"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Mnombre" Display="Dynamic" ErrorMessage="Este Campo es requerido" BorderColor="#FF5050" BorderStyle="None" CssClass="form_hint" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                                <!--apelldio-->
                            <div class="row form-group"  >
                                <div class="col col-md-3"><label for="email-input" class=" form-control-label">Apellidos:</label></div>
                                <div class="col-12 col-md-8">&nbsp;
                                    <asp:TextBox ID="Mapellido" runat="server" Text="" ToolTip="Apellidos" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="Mapellido" ErrorMessage="Datos Incorrectos" ValidationExpression="^[a-z &amp; A-Z]*$" ForeColor="#FF3300"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Mapellido" Display="Dynamic" ErrorMessage="Este Campo es requerido" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                                  
                                </div>
                            </div>
                                <div class="card-header">
                                  <strong class="card-title">Datos Primarios </strong>
                                     </div>  &nbsp;
                                <!--Sexo-->
                                <div  class="row form-group">
                                <div class="col col-md-1"><label for="select" class=" form-control-label"> &nbsp; &nbsp;Sexo</label></div>
                                <div class="col-12 col-md-3">&nbsp;
                                                
                                    <asp:DropDownList ID="Msexo" runat="server" ToolTip="Sexo" CssClass="form-control" ReadOnly="true">
                                        <asp:ListItem Value="0">SELECCIONE</asp:ListItem>
                                        <asp:ListItem Value="1">Maculino</asp:ListItem>
                                        <asp:ListItem Value="2">Femenino</asp:ListItem>
                                    </asp:DropDownList>  

                                </div>
                            </div>
                      
                               <!--Seleccion de departamento-->
                            <div >
                                <div class="col col-md-1"><label for="select" class=" form-control-label">Departamento:</label></div>
                                <div class="col-12 col-md-3"> &nbsp;
                                    <asp:DropDownList ID="Mdepartamento" runat="server" ToolTip="Departamento" CssClass="form-control" AutoPostBack="true" DataTextField="Departamento" DataValueField="Id_departamento">
                                    </asp:DropDownList>
                                </div>
                            </div>
                      
                                <!--Seleccion de Municipio-->
                            <div class="row form-group">
                                <div class="col col-md-1"><label for="select" class=" form-control-label">Municipio:</label></div>
                                <div class="col-12 col-md-4"> &nbsp;
                                <asp:DropDownList ID="Mmunicipio" runat="server" ToolTip="Municipio" CssClass="form-control" DataTextField="Municipio" DataValueField="Id_Municipio">
                                                       
                                        </asp:DropDownList>

                                </div>
                            </div>
                                    <!--Direccion-->
                            <div class="row form-group">
                                &nbsp; &nbsp;<div class="col col-md-1"><label for="text-input" class=" form-control-label">&nbsp;Direccion:</label></div>
                                <div class="col-12 col-md-9">&nbsp;
                                    <asp:TextBox ID="Mdireccion" runat="server" Text="" ToolTip="Direccion" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="Mdireccion" ErrorMessage="Datos Incorrectos" ValidationExpression="^[a-z &amp; A-Z]*$" ForeColor="#FF3300"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Mdireccion" Display="Dynamic" ErrorMessage="Este Campo es requerido" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                </div>&nbsp;
                            </div>
                                <div class="card-header">
                                  <strong class="card-title">Contacto</strong>
                                     </div>  &nbsp;
                                <!--telefono-->                            
                                <div >
                                <div class="col col-md-1"><label for="Ntelefono" class=" form-control-label">Telefono:</label></div>
                                <div class="col-12 col-md-3">&nbsp;
                                    <asp:TextBox ID="Mtelefono" runat="server" type="text" ToolTip="Telefono" CssClass="form-control" placeholder="505 0000-0000" ReadOnly="true"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="Mtelefono" ErrorMessage="Datos Incorrectos" ValidationExpression="^[0-9]*$" MaxLength="8" ForeColor="#FF3300"></asp:RegularExpressionValidator>                                                  
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Mtelefono" Display="Dynamic" ErrorMessage="Este Campo es requerido" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                                <!--correo-->
                            <div class="row form-group">
                                <div class="col col-md-1"><label for="disabled-input" class=" form-control-label">Correo:</label></div>
                                <div class="col-12 col-md-5">&nbsp;
                                    <asp:TextBox ID="Mcorreo" runat="server" Text="" ToolTip="Correo" CssClass="form-control" placeholder="ejemplo@gmail.com" ReadOnly="true"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" BorderColor="Red" BorderStyle="None" ControlToValidate="Mcorreo" ErrorMessage="Correo Incorrecto" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Mcorreo" Display="Dynamic" ErrorMessage=" Este Campo es requerido" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                                <br />
                               <div class="modal-footer">
                                <asp:HiddenField runat="server" ID="Id_cliente" />
                                <a class="btn btn-outline-success btn-lg btn-block" href="../../Views/ViewCliente/BuscarCliente.aspx">Regresar</a>  
                                </div>
                            </form>
                        </div>
                        </div>
                 

    
    <script type="text/javascript" src="../../Content/VerCliente.js"></script> 
    <script  type="text/javascript">
        window.onload = function () {
            edit('<%=cli.Cedula%>', '<%=cli.Nombres%>', '<%=cli.Apellidos%>', '<%=cli.Departamento%>', '<%=cli.Municipio%>',
                '<%=cli.Sexo%>','<%=cli.Telefono%>','<%=cli.Correo%>','<%=cli.Dirreccion %>')
        };
    </script>    
</asp:Content>
