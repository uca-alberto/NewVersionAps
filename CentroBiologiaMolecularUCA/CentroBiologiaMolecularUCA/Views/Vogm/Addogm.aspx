<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Addogm.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.ViewOrden.AgregarOrdenOgm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../../assets/css_Editables/form-mouse.css" rel="stylesheet" />
    <!-- Añadir Script-->
                <script src="../../../assets/js/vendor/jquery-2.1.4.min.js"></script>
                <script src="../../assets/sweetalert.min.js"></script>

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
                  location.href = "Searchogm.aspx";
              } 
          });
        }
    </script>

    <!-- Probando Validar Checkboxlist(No esta terminado)-->
    <script type="text/javascript">

        function validarcheckbox(sender, args) {

<%--            var checkboxlist = document.getElementById("<%=Manalisis.ClientID%>");
            var checkboxes = checkboxlist.getElementsByTagName("input")
            var isValid = false;
            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i].checked) {
                    isValid = true;
                    break;
                }
            }
            args.IsValid = isValid;--%>
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
                                                        <button id="btn" type="button" class="btn btn-success"  data-dismiss="modal"> <i class="fa fa-user-plus"></i> Seleccionar</button>
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
                <form id="myfrom" method="post" enctype="multipart/form-data" class="form-horizontal" runat="server">
       
                    <div class="card-header">
                        <strong class="card-title">Orden del Cliente</strong>
                            </div>&nbsp;
                    <!--Obtener el Id del cliente que selecciono-->
          
           <asp:TextBox ID="Idcliente" Visible="false" runat="server"></asp:TextBox>    

                     <!--Obtener el nombre del cliente que selecciono-->
            <div class="row form-group ">
                <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Nombre Cliente</label></div>
                <div class="col-12 col-md-9">
                     <asp:TextBox ID="Mcliente" ReadOnly="true" runat="server" ToolTip="Nombre Cliente" CssClass="formcursor"></asp:TextBox>   
                </div>
             </div>
                    <!--Obtener la cedula del cliente que selecciono-->
           <div class="row form-group ">
                <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Cedula</label></div>
                <div class="col-12 col-md-9">
                     <asp:TextBox ID="Mcedula" ReadOnly="true" runat="server" ToolTip="Cedula Cliente" CssClass="formcursor"></asp:TextBox>      
                     </div>
             </div>


                    <div class="card-header">
                        <strong class="card-title">Datos Orden</strong>
                            </div>&nbsp;

        <!--Codigo de la Orden-->
                <div class="row form-group ">
                <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Codigo orden</label></div>
                <div class="col-12 col-md-9">&nbsp; 
                        <asp:TextBox ID="Mcodigo" runat="server" ReadOnly="true" ToolTip="Codigo Orden" CssClass="formcursor"></asp:TextBox>&nbsp; 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Mcodigo" Display="Dynamic" ErrorMessage="Este Campo es requerido" ForeColor="Red" Font-Italic="true"></asp:RequiredFieldValidator>       
                </div>
                    </div>

                     <!--Fecha-->
               <div class="row form-group ">
                   <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Fecha</label></div>
                <div class="col-12 col-md-9">&nbsp; 
                    
                      <asp:Textbox ID="Mfecha" runat="server" ToolTip="fecha" CssClass="form-control" placeholder="dd/mm/yyyy" type="date"></asp:Textbox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Mfecha" Display="Dynamic" ErrorMessage="Ingrese La Fecha" ForeColor="Red" Font-Italic="true"></asp:RequiredFieldValidator>     
                     </div>
                   </div>
                   

                    <!--Seleccion de Tipo de Analisis-->
                   
                <div class="row form-group ">
                <div class="col col-md-3 "><label for="select" class=" form-control-label">Tipo de Analisis</label></div>
                <div class="checkbox">&nbsp; 
                        <asp:CheckBoxList ID="Manalisis" runat="server" ToolTip="Seleccione los Tipo de Analisis"  OnSelectedIndexChanged="Manalisis_SelectedIndexChanged" AutoPostBack="false">
                         </asp:CheckBoxList>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="validarcheckbox" ErrorMessage="Debe Seleccionar al menos un examen" ForeColor="Red" Font-Italic="true"></asp:CustomValidator>
                </div>
                      </div>
                       

              <!--Seleccion de Tipo Muestra-->
                           <div class="row form-group">
                             <div class="col col-md-3"><label for="select" class=" form-control-label">Tipo Muestra</label></div>
                              <div class="col-12 col-md-9">&nbsp; 
                               <asp:DropDownList ID="Mmuestra" runat="server" CssClass="form-control">
                                 </asp:DropDownList>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator5" InitialValue="0" runat="server" ControlToValidate="Mmuestra" Display="Dynamic" ErrorMessage="Debe Seleccionar el tipo de Muestra" ForeColor="Red" Font-Italic="true"></asp:RequiredFieldValidator>     
                            </div>
                          </div>
              <!--observaciones-->                            
                    <div class="row form-group ">
                <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Observaciones</label></div>
                <div class="col-12 col-md-9">&nbsp;
                <asp:Textbox ID="Mobservaciones" runat="server" TextMode="multiline" Columns="50" Rows="5" ToolTip="observaciones" CssClass="form-control" placeholder="Ingrese las observaciones"></asp:Textbox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Mobservaciones" Display="Dynamic" ErrorMessage="Este Campo es requerido" ForeColor="Red" Font-Italic="true"></asp:RequiredFieldValidator>     
                    </div>
                </div> 

                         <div class="card-header">
                        <strong class="card-title">Datos secundarios de orden OGM </strong>
                            </div>  &nbsp;

                 <!--boucher -->
                <div class="row form-group ">
                <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Boucher</label></div>
                <div class="col-12 col-md-9">&nbsp; 
                        <asp:TextBox ID="Mbaucher" MaxLength="10" runat="server" Text="" ToolTip="baucher" CssClass="form-control" placeholder="Ingrese el baucher"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Mbaucher" Display="Dynamic" ErrorMessage="Este Campo es requerido" ForeColor="Red" Font-Italic="true"></asp:RequiredFieldValidator>     
                </div>
                    </div>

              <!--Seleccion de estado-->
                    <div class="row form-group ">
                <div class="col col-md-3 "><label for="select" class=" form-control-label">Estado</label></div>
                <div class="col-12 col-md-9 ">&nbsp; 
                    <asp:DropDownList ID="Mestado" runat="server" ToolTip="estado" CssClass="form-control">
                    <asp:ListItem Value="0">SELECCIONE</asp:ListItem>
                    <asp:ListItem Value="1">Activo</asp:ListItem>
                    <asp:ListItem Value="2">En espera</asp:ListItem>
                    </asp:DropDownList>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator7" InitialValue="0" runat="server" ControlToValidate="Mestado" Display="Dynamic" ErrorMessage="Debe Seleccionar el estado de la Orden" ForeColor="Red" Font-Italic="true"></asp:RequiredFieldValidator>     
                </div>
                </div>
                          
             <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                <asp:HiddenField runat="server" ID="id_orden" />
                <asp:Button id="enviar" runat="server" Text="enviar" CssClass="btn btn-primary" OnClick="InsertarOrden"/>
            </div>             
   </form>
    </div>
    </div>

        <script type="text/javascript" src="../../Content/ListaordenOgm.js"></script>

</asp:Content>