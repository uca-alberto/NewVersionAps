<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerOrden.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.ViewOrden.VerOrden" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <link href="../../assets/css_Editables/form-mouse.css" rel="stylesheet" />

     <div class="card-header">
            <strong class="card-title" v-if="headerText">Ver Orden OGM</strong>
        </div>
              <div class="card">
                                  
            <div class="card-body card-block">
                <form id="myfrom" method="post" enctype="multipart/form-data" class="form-horizontal" runat="server">
                    
                <!--Codigo de la Orden-->
                <div class="row form-group ">
                <div class="col col-md-3 "><label for="text-input" class="form-control-label">Codigo orden</label></div>
                <div class="col-12 col-md-9">&nbsp; 
                        <asp:TextBox ID="Mcodigo" runat="server" BackColor="White" ReadOnly="true"  ToolTip="Codigo Orden" CssClass="formcursor"></asp:TextBox>&nbsp; 
                </div>
                    </div>

                     <!--fecha-->
               <div class="row form-group ">
                   <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Fecha</label></div>
                <div class="col-12 col-md-9">&nbsp; 
                      <asp:Textbox ID="Mfecha" runat="server" BackColor="White"  ToolTip="fecha" CssClass="formcursor" ReadOnly="true" placeholder="dd/mm/yyyy"></asp:Textbox>
                     </div>
                   </div>

                    <!--Seleccion de Tipo de Analisis-->
                   
                <div class="row form-group ">
                <div class="col col-md-3 "><label for="select" class=" form-control-label">Tipo de Analisis</label></div>
                <div class="checkbox">&nbsp; 
                        <asp:CheckBoxList ID="Manalisis" BackColor="White" Enabled="false" runat="server" ToolTip="Seleccione los Tipo de Analisis" AutoPostBack="false">
                         </asp:CheckBoxList>
                </div>
                      </div>
                       

              <!--Seleccion de Tipo Muestra-->
                           <div class="row form-group">
                             <div class="col col-md-3"><label for="select" class=" form-control-label">Tipo Muestra</label></div>
                              <div class="col-12 col-md-9">&nbsp; 
                               <asp:DropDownList ID="Mmuestra" BackColor="White" CssClass="formcursor" Enabled="false" runat="server" AutoPostBack="false">
                                 </asp:DropDownList>
                            </div>
                          </div>
              <!--observaciones-->                            
                    <div class="row form-group ">
                <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Observaciones</label></div>
                <div class="col-12 col-md-9">&nbsp;
                <asp:Textbox ID="Mobservaciones" runat="server" BackColor="White" ReadOnly="true" TextMode="multiline" Columns="50" Rows="5" ToolTip="observaciones" CssClass="formcursor"></asp:Textbox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" BackColor="White" runat="server" ControlToValidate="Mobservaciones" Display="Dynamic" ErrorMessage="Este Campo es requerido" ForeColor="Red" Font-Italic="true"></asp:RequiredFieldValidator>     
                    </div>
                </div> 

                         <div class="card-header">
                        <strong class="card-title">Datos secundarios de orden OGM </strong>
                            </div>  &nbsp;

                 <!--boucher -->
                <div class="row form-group ">
                <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Boucher</label></div>
                <div class="col-12 col-md-9">&nbsp; 
                        <asp:TextBox ID="Mbaucher" BackColor="White" ReadOnly="true" runat="server" Text="" ToolTip="baucher" CssClass="formcursor"></asp:TextBox>
                </div>
                    </div>

              <!--Seleccion de estado-->
                    <div class="row form-group ">
                <div class="col col-md-3 "><label for="select" class=" form-control-label">Estado</label></div>
                <div class="col-12 col-md-9 ">&nbsp; 
                    <asp:DropDownList ID="Mestado" BackColor="White" Enabled="false" runat="server" ToolTip="estado" CssClass="formcursor">
                    <asp:ListItem Value="0">SELECCIONE</asp:ListItem>
                    <asp:ListItem Value="1">Activo</asp:ListItem>
                    <asp:ListItem Value="2">En espera</asp:ListItem>
                    </asp:DropDownList>
                </div>
                </div>
                          
               <div class="modal-footer">
                       <asp:HiddenField runat="server" ID="Id_orden" />
                      <a class="btn btn-outline-success btn-lg btn-block" OnClick="javascript: return history.back()">Regresar</a>  
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


