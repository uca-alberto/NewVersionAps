<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarOrdenOgm.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.ViewOrden.AgregarOrdenOgm" %>

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
    
     <link href="../../assets/css_Editables/form-mouse.css" rel="stylesheet" />
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

    <script>
        function InsertarOrden(data) {
            swal({
                title: "Orden Agregada",
                text: "Correctamente",
                icon: "success",
            })
          .then((willDelete) => {
              if (willDelete) {
                  location.href = "BuscarOrden.aspx";
              } 
          });
        }
    </script>

    
     <div class="card-header">
            <strong class="card-title" v-if="headerText">Crear Orden OGM</strong>
        </div>
              <div class="card">
                                  
            <div class="card-body card-block">
                <form id="myfrom" method="post" enctype="multipart/form-data" class="form-horizontal" runat="server">

        <!--Codigo de la Orden-->
                <div class="row form-group ">
                <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Codigo orden</label></div>
                <div class="col-12 col-md-9">&nbsp; 
                        <asp:TextBox ID="Mcodigo" runat="server" ReadOnly="true" ToolTip="Codigo Orden" CssClass="formcursor"></asp:TextBox>&nbsp; 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Mcodigo" Display="Dynamic" ErrorMessage="Este Campo es requerido" ForeColor="Red" Font-Italic="true"></asp:RequiredFieldValidator>       
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
                <div class="checkbox">&nbsp; 
                        <asp:CheckBoxList ID="Manalisis" runat="server" ToolTip="Seleccione los Tipo de Analisis"  OnSelectedIndexChanged="Manalisis_SelectedIndexChanged" AutoPostBack="false">
                         </asp:CheckBoxList>
                </div>
                      </div>
                       

              <!--Seleccion de Tipo Muestra-->
                           <div class="row form-group">
                             <div class="col col-md-3"><label for="select" class=" form-control-label">Tipo Muestra</label></div>
                              <div class="col-12 col-md-9">&nbsp; 
                               <asp:DropDownList ID="Mmuestra" runat="server" CssClass="form-control"  OnSelectedIndexChanged="Mmuestra_SelectedIndexChanged" AutoPostBack="false">
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
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                <asp:HiddenField runat="server" ID="id_orden" />
                <asp:Button id="enviar" runat="server" Text="enviar" CssClass="btn btn-primary" OnClick="InsertarOrden"/>
            </div>              
   </form>
    </div>
    </div>

</asp:Content>