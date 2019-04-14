<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Addalz.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.Valz.Addalz" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

	  <script>
        function ADD() {
            swal({
                title: "Error",
                text: "Revisar Formulario",
                icon: "warning",
                button: "OK",
            });
    }</script>

     <script>
        function InsertarOrden(data) {
            swal({
                title: "Orden Agregada",
                text: "Correctamente",
                icon: "success",
            })
          .then((willDelete) => {
              if (willDelete) {
                  location.href = "../../Views/ViewOrdenMaria/BuscarMultiAdnOrden.aspx";
              } 
          });
        }
    </script>

	 <div class="content mt-3">
            <div class="animated">
    <div class="card">
                    <div class="card-header">      
                        <strong class="mr-2 fa fa-align-justify"> Orden del Cliente</strong>
                            </div>
                    <div class="card-body">
                         <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#mediumModal">
                   <i class="fa fa-search"></i> Seleccionar Cliente</button>
   
                    </div>
                </div>

                 <div class="modal fade" id="mediumModal" tabindex="-1" role="dialog" aria-labelledby="mediumModalLabel" aria-hidden="true">
                    <div class="modal-dialog modal-lg" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="mediumModalLabel">Clientes Activos</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                           <!--Buscar Cliente de la Orden-->
                    <div class="card-header">
                        <strong class="card-title">Buscar Cliente</strong>
                            </div> 
                
                    <div class="card-body">
                        <table id="bootstrap-data-table" class="table table-striped table-bordered" >
                            <thead>
                                <tr>
                                    <th>Id</th>                   
                                    <th>Nombre</th>
                                    <th>Apellido</th>
                                    <th>Cedula</th>
                                    <th>Seleccionar</th>

                                </tr>
                            </thead>
                            <tbody>
                                    <%
                                    while(getregistros().Read())
                                    {
                                        %>
                                            <tr><td><%=getregistros()["Id_cliente"] %></td>
                                                                  
                                                <td><%=getregistros()["Nombre"] %></td>

                                                <td><%=getregistros()["Apellido"] %></td>

                                                <td><%=getregistros()["Cedula"] %></td>

                                                <td>
                                                        <button id="btn" type="button" class="btn btn-success"  data-dismiss="modal"> <i class="ti-user"></i> Seleccionar</button>
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
          </div>
       </div>
    </div>

	<div class="card">
		<div class="card-body card-block">
			<form runat="server">
				 <div class="card-header">
                        <strong class="card-title">Orden del Cliente</strong>
                            </div>&nbsp;
                   <!--Obtener el Id del cliente que selecciono-->
          
                   <asp:HiddenField runat="server" ID="Id_cliente" /> 

                     <!--Obtener el nombre del cliente que selecciono-->
            <div class="row form-group ">
                <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Nombre Cliente</label></div>
                <div class="col-12 col-md-9">
                     <asp:TextBox ID="Mcliente" ReadOnly="true" runat="server" ToolTip="Nombre Cliente" CssClass="form-control"></asp:TextBox>   
                </div>
             </div>
                    <!--Obtener la cedula del cliente que selecciono-->
           <div class="row form-group ">
                <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Cedula</label></div>
                <div class="col-12 col-md-9">
                     <asp:TextBox ID="Mcedula" ReadOnly="true" runat="server" ToolTip="Cedula Cliente" CssClass="form-control"></asp:TextBox>      
                     </div>
             </div>

				 <div class="card-header">
                        <strong class="card-title">Datos de las personas de orden ADN </strong>
                            </div>  &nbsp;
                   <!--codigo de alzheimer-->  
                        <div class="row form-group ">
                <div class="col col-md-3 "><label for="password-input" class=" form-control-label">Código ADN</label></div>
                <div class="col-12 col-md-9">&nbsp;
                <asp:TextBox ID="Mcodigoalzheimer" runat="server" ReadOnly="true" ToolTip="codigodelamadre" CssClass="form-control" placeholder="codigo doctor"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Mcodigoalzheimer" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator>     
                    </div>
                </div>

                 <!--nombre del doctor-->  
                        <div class="row form-group ">
                <div class="col col-md-3 "><label for="password-input" class=" form-control-label">Nombre del doctor</label></div>
                <div class="col-12 col-md-9">&nbsp;
                <asp:TextBox ID="Mnombredeldoctor" runat="server" Text="" ToolTip="nombredeldoctor" CssClass="form-control" placeholder="Ingrese el nombre del doctor"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="Mnombredeldoctor" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator>     
                    </div>
                </div>
                <!--nombre del paciente-->  
                    <div class="row form-group ">
                <div class="col col-md-3 "><label for="password-input" class=" form-control-label">Nombre del paciente</label></div>
                <div class="col-12 col-md-9">&nbsp;
                <asp:TextBox ID="Mnombredelpaciente" runat="server" Text="" ToolTip="nombredelpaciente" CssClass="form-control" placeholder="Ingrese el nombre del paciente"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="Mnombredelpaciente" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator>     
                    </div>
                </div>

                 <!--fecha-->
                    

                   <div class="row form-group ">
                   <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Fecha</label></div>
                <div class="col-12 col-md-9">&nbsp; 
                    
                      <asp:Textbox ID="Mfechaalzheimer" runat="server" ToolTip="fecha" CssClass="form-control" placeholder="dd/mm/yyyy" type="date"></asp:Textbox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="Mfechaalzheimer" Display="Dynamic" ErrorMessage="Ingrese La Fecha" ForeColor="Red" Font-Italic="true"></asp:RequiredFieldValidator>     
                     </div>
                   </div>

                   <!--tipo caso-->
                    <div class="row form-group ">
                <div class="col col-md-3 "><label for="select" class=" form-control-label">Caso</label></div>
                <div class="col-12 col-md-9 ">&nbsp; 
                    <asp:DropDownList ID="Mtipocasoalzheimer" runat="server" ToolTip="caso" CssClass="form-control">
                    <asp:ListItem Value="0">SELECCIONE</asp:ListItem>
                    <asp:ListItem Value="1">Publico</asp:ListItem>
                    <asp:ListItem Value="2">Privado</asp:ListItem>
                        <asp:ListItem Value="3">No necesita</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator38" InitialValue="0" runat="server" ControlToValidate="Mtipocasoalzheimer" Display="Dynamic" ErrorMessage="Debe Seleccionar el tipo caso" ForeColor="Red" Font-Italic="true"></asp:RequiredFieldValidator>
                </div>
                </div>
                   <div class="card-header">
                        <strong class="card-title">Datos para el investigador </strong>
                            </div>  &nbsp;  

              
              
                 <!--observaciones-->                            
                    <div class="row form-group ">
                <div class="col col-md-3 "><label for="password-input" class=" form-control-label">Observaciones</label></div>
                <div class="col-12 col-md-9">&nbsp;
                <asp:TextBox ID="Mobservacionesalzheimer" runat="server" Text="" ToolTip="observaciones" CssClass="form-control" placeholder="Ingrese las observaciones"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="Mobservacionesalzheimer" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator>     
                    </div>
                </div>


                 <div class="card-header">
                        <strong class="card-title">Datos secundarios </strong>
                            </div>  &nbsp;  

                
                   <!--bouvher -->
                <div class="row form-group ">
                <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Boucher</label></div>
                <div class="col-12 col-md-9">&nbsp; 
                        <asp:TextBox ID="Mboucheralzheimer" runat="server" Text="" ToolTip="baucher" CssClass="form-control" placeholder="Ingrese el baucher"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="Mboucheralzheimer" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator>     
                </div>
                    </div>

              

                   <!--estado eliminado-->

               
                 <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                <asp:HiddenField runat="server" ID="HiddenField2" />
                <asp:Button id="insertarordenalzheimer" runat="server" Text="enviar" CssClass="btn btn-primary" OnClick="insertarordenalzheimer_Click"/>
            </div>
			</form>
		</div>
	</div>
	<script src="../../Content/Generic.js"></script>
</asp:Content>
