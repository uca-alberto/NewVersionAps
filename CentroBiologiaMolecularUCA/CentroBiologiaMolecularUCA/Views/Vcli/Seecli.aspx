<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Seecli.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.ViewCliente.VerCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">    
     <div class="card-header">
        <strong class="card-title">Cliente</strong>
         </div>  
            <div class="card">
            <div class="card-body card-block">
                <form id="Form1" method="post" enctype="multipart/form-data" class="form-horizontal" runat="server">
                    <!--Comienzo de los formulario-->  
					<!--imagen -->
					<div>
						   <asp:Image ID="Image2" CssClass="user-avatar rounded-circle" runat="server" ImageUrl="../../ImagesClientes/User-placeholder.jpg" style="height:100px;width:100px;"/>
					
					  <div>
                        <div class="col col-sm-10"><h2 class="text-center" style="margin-left:70px;">Centro de Biología Molecular UCA</h2></div>
						   <asp:Image ID="Image1" CssClass="user-avatar rounded-circle" runat="server" ImageUrl="../../ImagesClientes/User-placeholder.jpg" style="height:100px;width:100px;margin-top:auto; margin-left:auto;"/>
					  </div>
						</div>
                    <!--cedula-->
                <div>
                    <div class="col col-sm-3"><label for="password-input" class=" form-control-label">Cedula:</label></div>
                        <asp:TextBox ID="Mcedula" runat="server" Text="" ToolTip="Cedula Identidad" ReadOnly="true" CssClass="form-control" ValidateRequestMode="Enabled"></asp:TextBox>       
                </div>
                <div>                      
                    <!--nombre-->
                    <div class="col col-sm-3"><label for="text-input" class=" form-control-label">Nombres:</label></div>
                        <asp:TextBox ID="Mnombre" runat="server" Text="" ToolTip="Nombres" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div> 
                    <!--apelldio-->
                    <div class="col col-sm-3"><label for="email-input" class=" form-control-label">Apellidos:</label></div>
                        <asp:TextBox ID="Mapellido" runat="server" Text="" ToolTip="Apellidos" CssClass="form-control" ReadOnly="true" ></asp:TextBox>
                    <div class="card-header">
                        <strong class="card-title">Datos Primarios </strong>
                            </div>  &nbsp;
                           
                    <div><!--Sexo-->
                              <div class="col col-sm-3"><label>Sexo:</label>
                                  <asp:DropDownList ID="Msexo" runat="server" ToolTip="Sexo" CssClass="form-control" ReadOnly="true">
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
                      <asp:DropDownList ID="Mdepartamento" runat="server" required="" ReadOnly="true"  ToolTip="Departamento" CssClass="form-control" DataTextField="Departamento" DataValueField="Id_departamento">
                         </asp:DropDownList>

                 </div>
                </div>
                  <div>
                      <div class="col col-sm-3"><label>Municipio:</label>
                         <asp:DropDownList ID="Mmunicipio" runat="server" ToolTip="Municipio" ReadOnly="true" required=""  CssClass="form-control" DataTextField="Municipio" DataValueField="Id_Municipio">
                         </asp:DropDownList>
                      </div>
                  </div> 
                              </ContentTemplate>
                          </asp:UpdatePanel>

                        <!--Direccion-->     
                    <div>
                     <div class="col col-sm-3"><label>Dirrección:</label>
                          <asp:TextBox ID="Mdireccion" runat="server" Text="" ToolTip="Direccion" ReadOnly="true" CssClass="form-control" ></asp:TextBox>

                     </div>
                 </div> 

                    <div class="card-header">
                        <strong class="card-title">Contacto</strong>
                            </div>  &nbsp;
                    <!--telefono-->                            
                    <div >
                    <div class="col col-md-1"><label for="Ntelefono" class=" form-control-label">Telefono:</label></div>
                        <asp:TextBox ID="Mtelefono" runat="server" ReadOnly="true" type="text" ToolTip="Telefono" CssClass="form-control" placeholder="505 0000-0000"></asp:TextBox>
                </div>
                    <!--correo-->
                    <div>
                        <div class="col col-sm-3"><label for="disabled-input" class=" form-control-label">Correo:</label></div>
                        <asp:TextBox ID="Mcorreo" runat="server" Text="" ReadOnly="true" ToolTip="Correo" CssClass="form-control" placeholder="ejemplo@gmail.com"></asp:TextBox>
                    </div>
                
                    <br />
                    <div class="modal-footer">
                             <asp:HiddenField runat="server" ID="Id_cliente" />
                                <a class="btn btn-outline-success btn-lg btn-block" href="Searchcli.aspx">Regresar</a>               
                    </div>
                </form>
            </div>
         </div>   
   

    <script type="text/javascript" src="../../Content/listacliente.js"></script>    
     
    <script  type="text/javascript">
        window.onload = function () {
            edit('<%=cli.Cedula%>', '<%=cli.Nombres%>', '<%=cli.Apellidos%>', '<%=cli.Municipio%>','<%=cli.Departamento%>',
                '<%=cli.Sexo%>','<%=cli.Telefono%>','<%=cli.Correo%>','<%=cli.Dirreccion %>','<%=cli.imagen%>')
        };
    </script>    
</asp:Content>
