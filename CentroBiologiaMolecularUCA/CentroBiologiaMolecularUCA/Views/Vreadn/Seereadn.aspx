﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Seereadn.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.Vreadn.Seereadn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
         <link href="../../assets/css_Editables/form-mouse.css" rel="stylesheet" />
         <div class="card-header">
            <strong class="card-title" >REGISTRO DE ANALISIS DE EXAMEN DE ADN </strong>
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
                   <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Fecha</label></div>
                <div class="col-12 col-md-9">&nbsp;                     
                      <asp:Textbox ID="Mfecha" runat="server"  BackColor="White" ReadOnly="true" ToolTip="fecha" CssClass="formcursor"></asp:Textbox>
                     </div>
                   </div>
                        <!--Hora Recibido-->
               <div class="row form-group ">
                   <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Hora Recibido</label></div>
                <div class="col-12 col-md-9">&nbsp;                     
                      <asp:Textbox ID="Mhora" runat="server" BackColor="White" ReadOnly="true" ToolTip="Hora Recibido" CssClass="formcursor"></asp:Textbox>
                     </div>
                   </div>

             <div class="card-header">
            <strong class="card-title" >Servicios realizados</strong>
        </div>&nbsp;


               <!--Nombre del cliente-->
                 <div class="row form-group ">
                   <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Nombre del cliente</label></div>
                <div class="col-12 col-md-9">&nbsp;                     
                      <asp:Textbox ID="Mcliente" ReadOnly="true" BackColor="White" runat="server" ToolTip="Nombre del importador" CssClass="formcursor"></asp:Textbox>
                     </div>
                   </div>
            <!--Nombre del acompañante-->
                 <div class="row form-group ">
                   <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Nombre del padre/madre</label></div>
                <div class="col-12 col-md-9">&nbsp;                     
                      <asp:Textbox ID="Mpareja" ReadOnly="true" BackColor="White" runat="server" ToolTip="Nombre del padre/madre" CssClass="formcursor"></asp:Textbox>
                     </div>
                   </div>
            <!--Nombre del menor-->
                 <div class="row form-group ">
                   <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Nombre del menor</label></div>
                <div class="col-12 col-md-9">&nbsp;                     
                      <asp:Textbox ID="Mmenor" ReadOnly="true" BackColor="White" runat="server" ToolTip="Nombre del menor" CssClass="formcursor"></asp:Textbox>
                     </div>
                   </div>

            <!--Seleccion de estado-->
                    <div class="row form-group ">
                <div class="col col-md-3 "><label for="select" class=" form-control-label">Tipo Caso: </label></div>
                <div class="col-12 col-md-9 ">&nbsp; 
                    <asp:DropDownList ID="Mtipocaso"  Enabled="false" BackColor="White" runat="server" ToolTip="estado" CssClass="form-control">
                  <asp:ListItem Value="0">Seleccione</asp:ListItem>

                    <asp:ListItem Value="1">Publico</asp:ListItem>

                    <asp:ListItem Value="2">Privado</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" InitialValue="0" runat="server" ControlToValidate="Mresultado" Display="Dynamic" ErrorMessage="Seleccione el Resultado del Examen" ForeColor="Red" Font-Italic="true"></asp:RequiredFieldValidator>
                </div>
                </div>
           <!--- Resultados de ADN --->
           <div class="card-header">
            <strong class="card-title" >Resultados</strong>
        </div>&nbsp;
           <!--imagen-->                            
                    <div class="row form-group ">
						   <asp:Image ID="Image1"  runat="server" ImageUrl="../../ImagesClientes/User-placeholder.jpg" style="height:300px;width:700px;margin-top:auto; margin-left:auto;"/>
					  </div>

            
             <!--observaciones-->                            
                    <div class="row form-group ">
                <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Observaciones</label></div>
                <div class="col-12 col-md-9">&nbsp;
                <asp:Textbox ID="Mobservaciones" ReadOnly="true" BackColor="White" runat="server" TextMode="multiline" Columns="50" Rows="5" ToolTip="observaciones" CssClass="form-control" placeholder="Ingrese las observaciones"></asp:Textbox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Mobservaciones" Display="Dynamic" ErrorMessage="Este Campo es requerido" ForeColor="Red" Font-Italic="true"></asp:RequiredFieldValidator>     
                    </div>
                </div> 

           
              <!--Seleccion de estado-->
                    <div class="row form-group ">
                <div class="col col-md-3 "><label for="select" class=" form-control-label">Porcentaje de probabilidad: </label></div>
                <div class="col-12 col-md-9 ">&nbsp; 
                    <asp:DropDownList ID="Mresultado" Enable="false" runat="server" ToolTip="estado" CssClass="form-control">
                    <asp:ListItem Value="0">Seleccione</asp:ListItem>
                    <asp:ListItem Value="3">99.9%</asp:ListItem>
                    <asp:ListItem Value="4">0.00%</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" InitialValue="0" runat="server" ControlToValidate="Mresultado" Display="Dynamic" ErrorMessage="Seleccione el Resultado del Examen" ForeColor="Red" Font-Italic="true"></asp:RequiredFieldValidator>
                </div>
                </div>
                                     
             <div class="modal-footer">
                     <asp:HiddenField runat="server" ID="Id_orden" />
                      <a class="btn btn-outline-success btn-lg btn-block" OnClick="javascript: return history.back()">Regresar</a>  
                </div>
        
        </form>
       
        <script type="text/javascript" src="../../Content/Generic.js"></script>

    <script  type="text/javascript">
window.onload = function () {
    edit( '<%=res.Fecha_procesamiento%>','<%=res.Observaciones%>'
           )
};
</script>
</asp:Content>
