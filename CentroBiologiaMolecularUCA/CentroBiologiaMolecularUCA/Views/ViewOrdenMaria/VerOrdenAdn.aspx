<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerOrdenAdn.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.ViewOrdenMaria.VerOrdenAdn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="card-header">
<strong class="card-title">Vista de Orden ADN</strong>
    </div>  
        <div class="card">
        <div class="card-body card-block">
            <form action="get" method="post" enctype="multipart/form-data" class="form-horizontal" runat="server">
                <!--Comienzo de los formulario-->
                        <!--tipo caso-->
                        <div class="row form-group ">
                    <div class="col col-md-3 "><label for="select" class=" form-control-label">Caso</label></div>
                    <div class="col-12 col-md-9 ">
                        <asp:DropDownList ID="Mtipocaso" runat="server" ToolTip="caso" CssClass="form-control">
                        <asp:ListItem Value="0">SELECCIONE</asp:ListItem>
                        <asp:ListItem Value="1">Publico</asp:ListItem>
                        <asp:ListItem Value="2">Privado</asp:ListItem>
                            <asp:ListItem Value="3">No necesita</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    </div>
                            <!--Seleccion de tipo orden-->
                    <div class="row form-group ">
                    <div class="col col-md-3 "><label for="select" class=" form-control-label">Tipo de examen</label></div>
                    <div class="col-12 col-md-9 ">
                            <asp:DropDownList ID="Mtipoorden" runat="server" ToolTip="tipo" CssClass="form-control"  >    
                        </asp:DropDownList> 

                    </div>
                    </div>  
                    <!--bouvher-->
                    <div class="row form-group ">
                    <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Boucher</label></div>
                    <div class="col-12 col-md-9">
                            <asp:TextBox ID="Mbaucher" runat="server" Text="" ToolTip="baucher" CssClass="form-control"  ValidateRequestMode="Enabled" ReadOnly="true"></asp:TextBox>
                    </div>
                        </div>

                    <!--no_orden-->
                    <div class="row form-group ">
                    <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Número ordenr</label></div>
                    <div class="col-12 col-md-9">
                            <asp:TextBox ID="Mnoorden" runat="server" Text="" ToolTip="noorden" CssClass="form-control"  ValidateRequestMode="Enabled" ReadOnly="true"></asp:TextBox>
                    </div>
                        </div>
                          
                    <!--Seleccion de estado-->

                        <div class="row form-group ">
                    <div class="col col-md-3 "><label for="select" class=" form-control-label">Estado</label></div>
                    <div class="col-12 col-md-9 ">
                        <asp:DropDownList ID="Mestado" runat="server" ToolTip="estado" CssClass="form-control">
                        <asp:ListItem Value="0">SELECCIONE</asp:ListItem>
                        <asp:ListItem Value="1">Activo</asp:ListItem>
                        <asp:ListItem Value="2">En espera</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    </div>

                <!--fecha-->
                    <div class="row form-group ">
                            <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Fecha</label></div>
                            <div class="col-12 col-md-9">&nbsp; 
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <i class="fa fa-calendar"></i>
                                    </div>
                                

                                 <asp:TextBox ID="Mfecha" CssClass="form-control" BackColor="Wheat" Font-Bold="false" data-inputmask="'alias':'dd/mm/yyyy'"
                                    data-mask="" runat="server"></asp:TextBox> 
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Mfecha" ErrorMessage="Siga este formato dd/mm/yyyy" ValidationExpression="^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$"></asp:RegularExpressionValidator>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Mfecha" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator> 
                                     
                          </div>
                               </div>
                                    </div>
                                <!--observaciones-->                            
                        <div class="row form-group ">
                    <div class="col col-md-3 "><label for="password-input" class=" form-control-label">Observaciones</label></div>
                    <div class="col-12 col-md-9">
                    <asp:TextBox ID="Mobservaciones" runat="server" Text="" ToolTip="observaciones" CssClass="form-control"  ValidateRequestMode="Enabled" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>

                <div class="modal-footer">
                       <asp:HiddenField runat="server" ID="Id_orden" />
                      <a class="btn btn-outline-success btn-lg btn-block" href="../../Views/ViewOrdenMaria/AgregarOrden.aspx">Regresar</a>  
                </div>
            </form>
          </div>
      </div>
            
    <script type="text/javascript" src="../../Content/Listaorden.js"></script>

<script  type="text/javascript">
window.onload = function () {
    edit( '<%=ord.Tipo_caso%>', '<%=ord.Tipo_orden%>', '<%=ord.Observaciones%>','<%=ord.Baucher%>',
            '<%=ord.No_orden%>','<%=ord.Estado%>','<%=ord.Fecha%>')
};


</script> 
    <script src="../../js/plugins/input-mask/jquery.inputmask.js"></script>
                       
                       <script src="../../js/plugins/input-mask/jquery.inputmask.date.extensions.js"></script>
                       
                       <script src="../../js/plugins/timepicker/bootstrap-timepicker.min.js"></script>
                       <script src="../../js/plugins/moment/moment.min.js"></script>   
</asp:Content>
