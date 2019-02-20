<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarOrdenOgm.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.ViewOrden.AgregarOrdenOgm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div class="card-header">
            <strong class="card-title" v-if="headerText">Crear Orden OGM</strong>
        </div>
              <div class="card">
                                  
            <div class="card-body card-block">
                <form id="myfrom" method="post" enctype="multipart/form-data" class="form-horizontal" runat="server">

            
                     <!--fecha-->
               <div class="row form-group ">
                   <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Fecha</label></div>
                <div class="col-12 col-md-9">&nbsp; 

                     <div class="input-group mb-3"> 
                         <div class="input-group">
                                    <div class="input-group-addon">
                                        <i class="fa fa-calendar"></i>
                                    </div>
                      <asp:Textbox ID="Mfecha" runat="server"  ToolTip="fecha"  CssClass="form-control" placeholder="dd/mm/yyyy" Width="30px"></asp:Textbox> 
                          </div>

                         </div>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Mfecha" Display="Dynamic" ErrorMessage="Este Campo es requerido" ForeColor="Red" Font-Italic="true"></asp:RequiredFieldValidator>     
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Mfecha" ErrorMessage="Siga este formato dd/mm/yyyy" ForeColor="Red" Font-Italic="true" ValidationExpression="^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$"></asp:RegularExpressionValidator>
                   
               
                     </div>
                   </div>

                    <!--Seleccion de Tipo de Examen-->
                   
                <div class="row form-group ">
                <div class="col col-md-3 "><label for="select" class=" form-control-label">Tipo de examen</label></div>
                <div class="col-12 col-md-9 ">&nbsp; 
                        <asp:DropDownList ID="Mexamen" runat="server" ToolTip="tipo" CssClass="form-control"  OnSelectedIndexChanged="Mexamen_SelectedIndexChanged" AutoPostBack="false">
                         </asp:DropDownList>
                </div>
                    
                      </div>
                       

              <!--Seleccion de Tipo Muestra-->
                           <div class="row form-group">
                             <div class="col col-md-3"><label for="select" class=" form-control-label">Tipo Muestra</label></div>
                              <div class="col-12 col-md-9">&nbsp; 
                               <asp:CheckBoxList ID="Mmuestr" runat="server"  OnSelectedIndexChanged="Mmuestra_SelectedIndexChanged" AutoPostBack="false">
                                 </asp:CheckBoxList>
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
                        <asp:TextBox ID="Mbaucher" runat="server" Text="" ToolTip="baucher" CssClass="form-control" placeholder="Ingrese el baucher"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Mbaucher" Display="Dynamic" ErrorMessage="Este Campo es requerido" ForeColor="Red" Font-Italic="true"></asp:RequiredFieldValidator>     
                </div>
                    </div>

              <!--no_orden-->
                <div class="row form-group ">
                <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Número orden</label></div>
                <div class="col-12 col-md-9">&nbsp; 
                        <asp:TextBox ID="Mnoorden" runat="server" Text="" ToolTip="noorden" CssClass="form-control" placeholder="Ingrese el número de orden"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Mnoorden" Display="Dynamic" ErrorMessage="Este Campo es requerido" ForeColor="Red" Font-Italic="true"></asp:RequiredFieldValidator>     
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="Mnoorden" ErrorMessage="Ingrese Solo numeros" ForeColor="Red" Font-Italic="true" ValidationExpression="^[0-9]*$" MaxLength="8"></asp:RegularExpressionValidator>   
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
