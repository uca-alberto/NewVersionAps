<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarOrden.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.ViewOrden.ModificarOrden" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
     <!-- Script Para el Date Picker -->
 <script type="text/javascript">
      $(document).ready( function() {
          $("input[id$='Mfecha']").attr('readOnly', 'true').datepicker({
              showOn: 'button',
              buttonImageOnly: true,
              buttonImage: '../../assets/imagenes/calendar.png',
              maxDate: 'Today',
              buttonText: 'Mostrar Calendario',
              
          });  
      });
 </script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <!--Añadimos el Script-->
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

    <!--script de alerta-->

   <%-- <script>
       function ModificarOrden() {
           swal("La Orden ha sido Modificada!", "Clik Para Continuar!", "success");
           location.href = "../../Views/ViewOrdenMaria/BuscarOrdenAdn.aspx";
    }
    </script>--%>
    <script>
        function ModificarOrden(data) {
            swal({
                title: "Orden ha sido Modificada",
                text: "Correctamente",
                icon: "success",
            })
          .then((willDelete) => {
              if (willDelete) {
                  location.href = "../../Views/ViewOrdenMaria/BuscarOrdenAdn.aspx";
              } 
          });
        }
    </script>



    <div class="card-header">
            <strong class="card-title" v-if="headerText">Modificar Orden OGM</strong>
        </div>
              <div class="card">
                                  
            <div class="card-body card-block">
                <form id="myfrom" method="post" enctype="multipart/form-data" class="form-horizontal" runat="server">

        <!--Codigo de la Orden-->
                <div class="row form-group ">
                <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Codigo orden</label></div>
                <div class="col-12 col-md-9">&nbsp; 
                        <asp:TextBox ID="Mcodigo" runat="server" ReadOnly="true" ToolTip="Codigo Orden" CssClass="form-control"></asp:TextBox>&nbsp;        
                </div>
                    </div>

                     <!--fecha-->
               <div class="row form-group ">
                   <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Fecha</label></div>
                <div class="col-12 col-md-9">&nbsp; 
                    
                      <asp:Textbox ID="Mfecha" runat="server" ToolTip="fecha" placeholder="dd/mm/yyyy"></asp:Textbox>
                    
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Mfecha" Display="Dynamic" ErrorMessage="Ingrese La Fecha" ForeColor="Red" Font-Italic="true"></asp:RequiredFieldValidator>     
                     </div>
                   </div>

                    <!--Seleccion de Tipo de Analisis-->
                   
                <div class="row form-group ">
                <div class="col col-md-3 "><label for="select" class=" form-control-label">Tipo de Analisis</label></div>
                <div class="col-12 col-md-9 ">&nbsp; 
                        <asp:CheckBoxList ID="Manalisis" runat="server" ToolTip="Seleccione los Tipo de Analisis" AutoPostBack="false">
                         </asp:CheckBoxList>
                </div>
                      </div>
                       

              <!--Seleccion de Tipo Muestra-->
                           <div class="row form-group">
                             <div class="col col-md-3"><label for="select" class=" form-control-label">Tipo Muestra</label></div>
                              <div class="col-12 col-md-9">&nbsp; 
                               <asp:DropDownList ID="Mmuestra" runat="server" CssClass="form-control" AutoPostBack="false">
                                 </asp:DropDownList>
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
                </div>
                </div>

                     <div class="modal-footer">
                            <button type="button" OnClick="javascript: return history.back()" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                            <asp:HiddenField runat="server" ID="Id_orden" />
                            <asp:Button id="enviar" runat="server" Text="Modificar" CssClass="btn btn-primary" OnClick="EditarFormulario" />
                            </div>
        </form>
    </div>
    </div>

<script type="text/javascript" src="../../Content/ListaordenOgm.js"></script>

<script  type="text/javascript">
window.onload = function () {
    edit( '<%=ord.Id_codigo%>','<%=ord.Fecha%>','<%=ord.Id_analisis%>','<%=ord.Tipo_muestra%>','<%=ord.Observaciones%>','<%=ord.Baucher%>','<%=ord.Estado%>'
           )
};
</script> 


</asp:Content>

