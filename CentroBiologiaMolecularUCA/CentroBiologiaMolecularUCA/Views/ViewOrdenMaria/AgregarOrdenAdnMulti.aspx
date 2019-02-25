<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarOrdenAdnMulti.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.ViewOrdenMaria.AgregarOrdenAdnMulti" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="card-header">
            <strong class="card-title" v-if="headerText">Crear Orden ADN</strong>
        </div>
    <div class="card">
    <div class="card-body card-block">
    <form id="form1" runat="server">
        
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <!-- index of view =0-->
            <asp:View ID="PaternidadView" runat="server">
                <h1>Paternidad</h1>
                <!--Comienzo de los formularios-->  
                <div class="card-header">
                        <strong class="card-title">Datos de las personas de orden ADN </strong>
                            </div>  &nbsp;
                  <!--nombre del padre-->  
                        <div class="row form-group ">
                <div class="col col-md-3 "><label for="password-input" class=" form-control-label">Nombre del padre</label></div>
                <div class="col-12 col-md-9">&nbsp;
                <asp:TextBox ID="Mnombrepadre" runat="server" Text="" ToolTip="nombredelpadre" CssClass="form-control" placeholder="Ingrese el nombre del padre"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Mnombrepadre" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator>     
                    </div>
                </div>
                    <!--nombre del hijo-->    
                       <div class="row form-group ">
                <div class="col col-md-3 "><label for="password-input" class=" form-control-label">Nombre del hijo</label></div>
                <div class="col-12 col-md-9">&nbsp;
                <asp:TextBox ID="Mnombrehijo" runat="server" Text="" ToolTip="nombrehijo" CssClass="form-control" placeholder="Ingrese el nombre del hijo"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Mnombrehijo" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator>     
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

                   <!--tipo caso-->
                    <div class="row form-group ">
                <div class="col col-md-3 "><label for="select" class=" form-control-label">Caso</label></div>
                <div class="col-12 col-md-9 ">&nbsp; 
                    <asp:DropDownList ID="Mtipocaso" runat="server" ToolTip="caso" CssClass="form-control">
                    <asp:ListItem Value="0">SELECCIONE</asp:ListItem>
                    <asp:ListItem Value="1">Publico</asp:ListItem>
                    <asp:ListItem Value="2">Privado</asp:ListItem>
                        <asp:ListItem Value="3">No necesita</asp:ListItem>
                    </asp:DropDownList>
                </div>
                </div>

                 <div class="card-header">
                        <strong class="card-title">Datos para el investigador </strong>
                            </div>  &nbsp;  

                        <!--Seleccion de tipo orden-->
                 <div class="row form-group ">
                <div class="col col-md-3 "><label for="select" class=" form-control-label">Tipo de examen</label></div>
                <div class="col-12 col-md-9 ">&nbsp; 
                        <asp:DropDownList ID="Mtipoorden" runat="server" ToolTip="tipo" CssClass="form-control"  OnSelectedIndexChanged="Mtipoorden_SelectedIndexChanged" AutoPostBack="true">
                         </asp:DropDownList> 
       
                </div>
                </div>
              
                 <!--observaciones-->                            
                    <div class="row form-group ">
                <div class="col col-md-3 "><label for="password-input" class=" form-control-label">Observaciones</label></div>
                <div class="col-12 col-md-9">&nbsp;
                <asp:TextBox ID="Mobservaciones" runat="server" Text="" ToolTip="observaciones" CssClass="form-control" placeholder="Ingrese las observaciones"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Mobservaciones" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator>     
                    </div>
                </div>
                            <div class="card-header">
                        <strong class="card-title">Datos secundarios de orden ADN </strong>
                            </div>  &nbsp;

                 <!--bouvher -->
                <div class="row form-group ">
                <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Boucher</label></div>
                <div class="col-12 col-md-9">&nbsp; 
                        <asp:TextBox ID="Mbaucher" runat="server" Text="" ToolTip="baucher" CssClass="form-control" placeholder="Ingrese el baucher"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Mbaucher" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator>     
                </div>
                    </div>

                 <!--no_orden-->
                <div class="row form-group ">
                <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Número orden</label></div>
                <div class="col-12 col-md-9">&nbsp; 
                        <asp:TextBox ID="Mnoorden" runat="server" Text="" ToolTip="noorden" CssClass="form-control" placeholder="Ingrese el número de orden"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="Mnoorden" ErrorMessage="Ingrese Solo numeros" ValidationExpression="^[0-9]*$" MaxLength="8"></asp:RegularExpressionValidator>   
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Mnoorden" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator>     
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


                
                
                <asp:Button ID="Button2" runat="server" Text="Paternidad" OnClick="Button2_Click" />&nbsp;
                <asp:Button ID="Button1" runat="server" Text="Maternidad" OnClick="Button1_Click"/>
               
                    
            </asp:View>

              <asp:View ID="View1" runat="server">
                  <h1>Maternidad</h1>
                  <div class="card-header">
                        <strong class="card-title">Datos de las personas de orden ADN </strong>
                            </div>  &nbsp;
                  <!--nombre de la madre-->  
                        <div class="row form-group ">
                <div class="col col-md-3 "><label for="password-input" class=" form-control-label">Nombre del padre</label></div>
                <div class="col-12 col-md-9">&nbsp;
                <asp:TextBox ID="Mnombredelamadre" runat="server" Text="" ToolTip="nombredelamadre" CssClass="form-control" placeholder="Ingrese el nombre de la madre"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="Mnombredelamadre" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator>     
                    </div>
                </div>
                    <!--nombre del hijo de la madre-->    
                       <div class="row form-group ">
                <div class="col col-md-3 "><label for="password-input" class=" form-control-label">Nombre del hijo</label></div>
                <div class="col-12 col-md-9">&nbsp;
                <asp:TextBox ID="Mnombrehijomadre" runat="server" Text="" ToolTip="nombrehijomadre" CssClass="form-control" placeholder="Ingrese el nombre del hijo"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="Mnombrehijomadre" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator>     
                    </div>
                </div>    
                
                  <asp:Button ID="Btnbackpaternidad" runat="server" Text="Paternidad" OnClick="Btnbackpaternidad_Click"  />&nbsp;
                  
           
                  </asp:View>
        </asp:MultiView>
    </form>
        </div>
        </div>
</asp:Content>
