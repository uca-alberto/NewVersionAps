<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Addpap.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.Vpap.Addpap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

	     <script>
        function InsertarOrden(data) {
            swal({
                title: "Orden Agregada",
                text: "Correctamente",
                icon: "success",
            })
          .then((willDelete) => {
              if (willDelete) {
                  location.href = "../../Views/Vogm/Searchogm.aspx";
              } 
          });
        }
    </script>

	   <script>
        function ADD() {
            swal({
                title: "Error",
                text: "Revisar Formulario",
                icon: "warning",
                button: "OK",
            });
    }</script>

	 <div class="content mt-3">
            <div class="animated">
    <div class="card">
                    <div class="card-header">      
                      <strong class="mr-2 fa fa-align-justify"></strong>

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
				 <div class="card-header">
                      <strong class="mr-2 fa fa-align-justify">Cliente</strong>
                            </div>&nbsp;
                   <!--Obtener el Id del cliente que selecciono-->
	<form runat="server">
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
                        <strong class="card-title">Datos Principales </strong>
                            </div>  &nbsp;
		 <!--codigo de papiloma-->  
                        <div class="row form-group ">
                <div class="col col-md-3 "><label for="password-input" class=" form-control-label">Código ADN</label></div>
                <div class="col-12 col-md-9">&nbsp;
                <asp:TextBox ID="Mcodigopapiloma" runat="server" ReadOnly="true" ToolTip="codigodelamadre" CssClass="form-control" placeholder="codigo doctor"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Mcodigopapiloma" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator>     
                    </div>
                </div>

                <!--nombre del doctor-->  
                        <div class="row form-group ">
                <div class="col col-md-3 "><label for="password-input" class=" form-control-label">Nombre del doctor</label></div>
                <div class="col-12 col-md-9">&nbsp;
                <asp:TextBox ID="Mdoctorpapiloma" runat="server" Text="" ToolTip="nombredeldoctor" CssClass="form-control" placeholder="Ingrese el nombre del doctor"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="Mdoctorpapiloma" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator>     
                    </div>
                </div>
                <!--nombre del paciente-->  
                    <div class="row form-group ">
                <div class="col col-md-3 "><label for="password-input" class=" form-control-label">Nombre del paciente</label></div>
                <div class="col-12 col-md-9">&nbsp;
                <asp:TextBox ID="Mpacientepapiloma" runat="server" Text="" ToolTip="nombredelpaciente" CssClass="form-control" placeholder="Ingrese el nombre del paciente"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="Mpacientepapiloma" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator>     
                    </div>
                </div>

                  <!--fecha-->
                      
                
                   <div class="row form-group ">
                   <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Fecha</label></div>
                <div class="col-12 col-md-9">&nbsp; 
                    
                      <asp:Textbox ID="Mfechapapiloma" runat="server" ToolTip="fecha" CssClass="form-control" placeholder="dd/mm/yyyy" type="date"></asp:Textbox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="Mfechapapiloma" Display="Dynamic" ErrorMessage="Ingrese La Fecha" ForeColor="Red" Font-Italic="true"></asp:RequiredFieldValidator>     
                     </div>
                   </div>   

                   <!--tipo caso-->
                    <div class="row form-group ">
                <div class="col col-md-3 "><label for="select" class=" form-control-label">Caso</label></div>
                <div class="col-12 col-md-9 ">&nbsp; 
                    <asp:DropDownList ID="Mtipocasopapiloma" runat="server" ToolTip="caso" CssClass="form-control">
                    <asp:ListItem Value="0">SELECCIONE</asp:ListItem>
                    <asp:ListItem Value="1">Publico</asp:ListItem>
                    <asp:ListItem Value="2">Privado</asp:ListItem>
                        <asp:ListItem Value="3">No necesita</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator39" InitialValue="0" runat="server" ControlToValidate="Mtipocasopapiloma" Display="Dynamic" ErrorMessage="Debe Seleccionar el tipo caso" ForeColor="Red" Font-Italic="true"></asp:RequiredFieldValidator>
                </div>
                </div>
                   <div class="card-header">
                        <strong class="card-title">Datos para el investigador </strong>
                            </div>  &nbsp;  

               
              
                 <!--observaciones-->                            
                    <div class="row form-group ">
                <div class="col col-md-3 "><label for="password-input" class=" form-control-label">Observaciones</label></div>
                <div class="col-12 col-md-9">&nbsp;
                <asp:TextBox ID="Mobservacionespapiloma" runat="server" Text="" ToolTip="observaciones" CssClass="form-control" placeholder="Ingrese las observaciones"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="Mobservacionespapiloma" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator>     
                    </div>
                </div>


                 <div class="card-header">
                        <strong class="card-title">Datos secundarios </strong>
                            </div>  &nbsp;  

                
                   <!--bouvher -->
                <div class="row form-group ">
                <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Boucher</label></div>
                <div class="col-12 col-md-9">&nbsp; 
                        <asp:TextBox ID="Mboucherpapiloma" runat="server" Text="" ToolTip="baucher" CssClass="form-control" placeholder="Ingrese el baucher"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="Mboucherpapiloma" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator>     
                </div>
                    </div>

               

                   <!--estado eliminado-->

              
                 <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                <asp:HiddenField runat="server" ID="HiddenField3" />
                <asp:Button id="insertarordenpapiloma" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="insertarordenpapiloma_Click"/>
            </div>
		   </div>
		</div>
                   
	</form>
	<script src="../../Content/Generic.js"></script>           
</asp:Content>
