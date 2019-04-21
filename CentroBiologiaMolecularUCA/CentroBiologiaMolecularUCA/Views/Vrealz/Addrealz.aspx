<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Addrealz.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.Vrealz.Addrealz" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../../assets/css_Editables/form-mouse.css" rel="stylesheet" />
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
        function InsertarResultado(data) {
            swal({
                title: "Resultado Agregado",
                text: "Correctamente",
                icon: "success",
            })
          .then((willDelete) => {
              if (willDelete) {
                  location.href = "../Vogm/Searchogm.aspx";
              } 
          });
        }
    </script>


         <div class="card-header">
            <strong class="card-title" >Resultado de Prueba Genetica Determicacion por Polomorfismo de ApoE</strong>&nbsp;
        </div>
    <div class="card">                       
            <div class="card-body card-block">
       <form id="myfrom" method="post" enctype="multipart/form-data" class="form-horizontal" runat="server">
 
                      
      <div class="card-header">
            <strong class="card-title" >Datos Generales</strong>
        </div>&nbsp;

            <!--Codigo de la Orden-->
                <div class="row form-group">
                <div class="col col-md-3 "><label for="text-input" class="form-control-label">Codigo</label></div>
                <div class="col-12 col-md-9">&nbsp;
                    <asp:TextBox ID="Mcodigo" runat="server" BackColor="White" ReadOnly="true"  ToolTip="Codigo Orden" CssClass="formcursor"></asp:TextBox>
                </div>
                    </div>
                       <!--Investigador-->
                <div class="row form-group">
                <div class="col col-md-3 "><label for="text-input" class="form-control-label">Investigador</label></div>
                <div class="col-12 col-md-9">&nbsp;
                    <asp:TextBox ID="Minvestigador" runat="server" BackColor="White" ReadOnly="true"  ToolTip="Investigador" CssClass="formcursor"></asp:TextBox>
                </div>
                    </div>

             <!--Fecha-->
               <div class="row form-group ">
                   <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Fecha toma Muestra</label></div>
                <div class="col-12 col-md-9">&nbsp;                     
                      <asp:Textbox ID="Mfecha" runat="server"  BackColor="White" ReadOnly="true" ToolTip="fecha" CssClass="formcursor"></asp:Textbox>
                     </div>
                   </div>
             <div class="card-header">
            <strong class="card-title" >Servicios realizados</strong>
        </div>&nbsp;


               <!--Nombre del Cliente-->
                 <div class="row form-group ">
                   <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Nombre del importador</label></div>
                <div class="col-12 col-md-9">&nbsp;                     
                      <asp:Textbox ID="Mcliente" ReadOnly="true" BackColor="White" runat="server" ToolTip="Nombre del Cliente" CssClass="formcursor"></asp:Textbox>
                     </div>
                   </div>
           <div class="card-header">
            <strong class="card-title" >Resultado Examen</strong>
        </div>&nbsp;
		           
                    <div class="row form-group">
                             <div class="col col-md-3"><label for="select" class=" form-control-label">Resultado Exmaen</label></div>
                              <div class="col-12 col-md-9">&nbsp; 
                               <asp:DropDownList ID="Mparametro" runat="server" CssClass="form-control">
                                 </asp:DropDownList>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator5" InitialValue="0" runat="server" ControlToValidate="Mparametro" Display="Dynamic" ErrorMessage="Debe Seleccionar el tipo de Muestra" ForeColor="Red" Font-Italic="true"></asp:RequiredFieldValidator>     
                            </div>
                          </div>

           <!--observaciones-->
           <div class="row form-group ">
                <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Analisis del Resultado</label></div>
                <div class="col-12 col-md-9">&nbsp;
                <asp:Textbox ID="Mobservaciones" runat="server" TextMode="multiline" Columns="50" Rows="5" ToolTip="observaciones" CssClass="form-control" placeholder="Ingrese las observaciones"></asp:Textbox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Mobservaciones" Display="Dynamic" ErrorMessage="Este Campo es requerido" ForeColor="Red" Font-Italic="true"></asp:RequiredFieldValidator>     
                    </div>
                </div> 

        
             <div class="modal-footer">
                <button type="button" class="btn btn-secondary" onclick="location.href='../Vogm/Searchogm.aspx'">Cancelar</button>
                <asp:HiddenField runat="server" ID="id_orden" />
                <asp:Button id="enviar" runat="server" Text="Guardar" OnClick="InsertarResultado" CssClass="btn btn-primary" />
            </div>   

            </form>
            </div>
        </div>
</asp:Content>


