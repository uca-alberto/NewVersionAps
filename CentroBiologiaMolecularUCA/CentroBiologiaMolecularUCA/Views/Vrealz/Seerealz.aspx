<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Seerealz.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.Vrealz.Seerealz" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

      <link href="../../assets/css_Editables/form-mouse.css" rel="stylesheet" />

         <div class="card-header">
            <strong class="card-title" >Resultado de Prueba Genetica Determicacion por Polomorfismo de ApoE</strong>
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

             <!--Fecha muestra-->
               <div class="row form-group ">
                   <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Fecha toma Muestra</label></div>
                <div class="col-12 col-md-9">&nbsp;                     
                      <asp:Textbox ID="Mfecha" runat="server"  BackColor="White" ReadOnly="true" ToolTip="fecha" CssClass="formcursor"></asp:Textbox>
                     </div>
                   </div>

                        <!--Fecha-->
               <div class="row form-group ">
                   <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Fecha Resultado</label></div>
                <div class="col-12 col-md-9">&nbsp;                     
                      <asp:Textbox ID="Mfechare" runat="server"  BackColor="White" ReadOnly="true" ToolTip="fecha" CssClass="formcursor"></asp:Textbox>
                     </div>
                   </div>
                        <!--Hora Recibido-->
               <div class="row form-group ">
                   <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Hora Resultado</label></div>
                <div class="col-12 col-md-9">&nbsp;                     
                      <asp:Textbox ID="Mhora" runat="server" BackColor="White" ReadOnly="true" ToolTip="Hora Recibido" CssClass="formcursor"></asp:Textbox>
                     </div>
                   </div>

             <div class="card-header">
            <strong class="card-title" >Servicios realizados</strong>
        </div>&nbsp;


               <!--Nombre del importador-->
                 <div class="row form-group ">
                   <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Nombre Cliente</label></div>
                <div class="col-12 col-md-9">&nbsp;                     
                      <asp:Textbox ID="Mcliente" ReadOnly="true" BackColor="White" runat="server" ToolTip="Nombre del importador" CssClass="formcursor"></asp:Textbox>
                     </div>
                   </div>

           <div class="card-header">
            <strong class="card-title" >Resultado Examen</strong>
        </div>&nbsp;

                <div class="row form-group">
                <div class="col col-md-3 "><label for="text-input" class="form-control-label">Resultado Examen</label></div>
                <div class="col-12 col-md-9">&nbsp;
                    <asp:TextBox ID="Mparametros" runat="server" BackColor="White" ReadOnly="true"  ToolTip="Resultado Examen" CssClass="formcursor"></asp:TextBox>
                </div>
                    </div>

           <!--observaciones-->
           <div class="row form-group ">
                <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Analisis del Resultado</label></div>
                <div class="col-12 col-md-9">&nbsp;
                <asp:Textbox ID="Mobservaciones" runat="server" BackColor="White" ReadOnly="true" TextMode="multiline" Columns="50" Rows="5" ToolTip="observaciones" CssClass="form-control" placeholder="Ingrese las observaciones"></asp:Textbox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Mobservaciones" Display="Dynamic" ErrorMessage="Este Campo es requerido" ForeColor="Red" Font-Italic="true"></asp:RequiredFieldValidator>     
                    </div>
                </div> 

                
               <div class="modal-footer">
                       <asp:HiddenField runat="server" ID="Id_orden" />
                      <a class="btn btn-outline-success btn-lg btn-block" OnClick="javascript: return history.back()">Regresar</a>  
                </div>        

            </form>
            </div>
        </div>

        <script type="text/javascript" src="../../Content/Generic.js"></script> 
</asp:Content>
