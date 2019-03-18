<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarOrdenAdnMulti.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.ViewOrdenMaria.AgregarOrdenAdnMulti" %>

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

      <script type="text/javascript">
         $(document).ready(function () {
             
          $("input[id$='Mfechamaternidad']").attr('readOnly', 'true').datepicker({
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

     <script>
        function InsertarOrden(data) {
            swal({
                title: "Orden Agregada",
                text: "Correctamente",
                icon: "success",
            })
          .then((willDelete) => {
              if (willDelete) {
                  location.href = "../../Views/ViewOrdenMaria/BuscarMultiAdnOrden.aspx";
              } 
          });
        }
    </script>
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
                 <asp:Button ID="Button2" runat="server" Text="Papiloma" CssClass="btn btn-primary" OnClick="Button2_Click" />&nbsp;
                <asp:Button ID="Button1" runat="server" Text="Maternidad" CssClass="btn btn-primary" OnClick="Button1_Click"/>&nbsp;
                <asp:Button ID="Btnabuelidad" runat="server" Text="Abuelidad" CssClass="btn btn-primary" OnClick="Btnabuelidad_Click"/>&nbsp;
                <asp:Button ID="Btnalzheimer" runat="server" Text="Alzheimer" CssClass="btn btn-primary" OnClick="Btnalzheimer_Click"/>
               
                <!--Comienzo de los formularios-->  
                <div class="card-header">
                        <strong class="card-title">Datos de las personas de orden ADN </strong>
                            </div>  &nbsp;
                 <!----------------------------------------paternidad-----------------------------------------------------> 
                <!--Codigo de la Orden-->
                <div class="row form-group ">
                <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Codigo orden</label></div>
                <div class="col-12 col-md-9">&nbsp; 
                        <asp:TextBox ID="Mcodigo" runat="server" ReadOnly="true" ToolTip="Codigo Orden" CssClass="form-control"></asp:TextBox>&nbsp; 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="Mcodigo" Display="Dynamic" ErrorMessage="Este Campo es requerido" ForeColor="Red" Font-Italic="true"></asp:RequiredFieldValidator>       
                </div>
                    </div>

                  <!--nombre del padre-->  
                        <div class="row form-group ">
                <div class="col col-md-3 "><label for="password-input" class=" form-control-label">Nombre del padre</label></div>
                <div class="col-12 col-md-9">&nbsp;
                <asp:TextBox ID="Mnombrepareja" runat="server" Text="" ToolTip="nombrepareja" CssClass="form-control" placeholder="Ingrese el nombre del padre"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Mnombrepareja" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator>     
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
                    
                      <asp:Textbox ID="Mfecha" runat="server" ToolTip="fecha" placeholder="dd/mm/yyyy"></asp:Textbox>
                    
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Mfecha" Display="Dynamic" ErrorMessage="Ingrese La Fecha" ForeColor="Red" Font-Italic="true"></asp:RequiredFieldValidator>     
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

                <div class="modal-footer">
                 
                    
                </div>
               
                    
            </asp:View>
             <!---------------------------------------maternidad------------------------------------------------------> 
              <asp:View ID="View1" runat="server">
                  <h1>Maternidad</h1>
                  
                  
                  <div class="card-header">
                        <strong class="card-title">Datos de las personas de orden ADN </strong>
                            </div>  &nbsp;
                  <!--codigo de la madre-->  
                        <div class="row form-group ">
                <div class="col col-md-3 "><label for="password-input" class=" form-control-label">Nombre de la madre</label></div>
                <div class="col-12 col-md-9">&nbsp;
                <asp:TextBox ID="Mcodigomadre" runat="server" Text="" ToolTip="codigodelamadre" CssClass="form-control" placeholder="Ingrese el nombre de la madre"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="Mcodigomadre" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator>     
                    </div>
                </div>

                      <!--nombre del hijo de la madre-->    
                       <div class="row form-group ">
                <div class="col col-md-3 "><label for="password-input" class=" form-control-label">Nombre del hijo</label></div>
                <div class="col-12 col-md-9">&nbsp;
                <asp:TextBox ID="Mnombremadre" runat="server" Text="" ToolTip="nombremadre" CssClass="form-control" placeholder="Ingrese el nombre del hijo"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Mnombremadre" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator>     
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



                   <!--fecha-->
                           <div class="row form-group ">
                          <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Fecha</label></div>
                <div class="col-12 col-md-9">&nbsp; 
                    
                      <asp:Textbox ID="Mfechamaternidad" runat="server" ToolTip="fecha" placeholder="dd/mm/yyyy"></asp:Textbox>
                    
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="Mfechamaternidad" Display="Dynamic" ErrorMessage="Ingrese La Fecha" ForeColor="Red" Font-Italic="true"></asp:RequiredFieldValidator>     
                     </div>
                                    </div>
                   <!--tipo caso-->
                    <div class="row form-group ">
                <div class="col col-md-3 "><label for="select" class=" form-control-label">Caso</label></div>
                <div class="col-12 col-md-9 ">&nbsp; 
                    <asp:DropDownList ID="Mtipocasomadre" runat="server" ToolTip="caso" CssClass="form-control">
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

                
              
                 <!--observaciones-->                            
                    <div class="row form-group ">
                <div class="col col-md-3 "><label for="password-input" class=" form-control-label">Observaciones</label></div>
                <div class="col-12 col-md-9">&nbsp;
                <asp:TextBox ID="Mobservacionesmadre" runat="server" Text="" ToolTip="observaciones" CssClass="form-control" placeholder="Ingrese las observaciones"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="Mobservacionesmadre" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator>     
                    </div>
                </div>


                 <div class="card-header">
                        <strong class="card-title">Datos secundarios </strong>
                            </div>  &nbsp;  

                
                   <!--bouvher -->
                <div class="row form-group ">
                <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Boucher</label></div>
                <div class="col-12 col-md-9">&nbsp; 
                        <asp:TextBox ID="baouchermaternidad" runat="server" Text="" ToolTip="baucher" CssClass="form-control" placeholder="Ingrese el baucher"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="baouchermaternidad" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator>     
                </div>
                    </div>

             

                   <!--Seleccion de estado-->

                    <div class="row form-group ">
                <div class="col col-md-3 "><label for="select" class=" form-control-label">Estado</label></div>
                <div class="col-12 col-md-9 ">&nbsp; 
                    <asp:DropDownList ID="Mestadomaternidad" runat="server" ToolTip="estado" CssClass="form-control">
                    <asp:ListItem Value="0">SELECCIONE</asp:ListItem>
                    <asp:ListItem Value="1">Activo</asp:ListItem>
                    <asp:ListItem Value="2">En espera</asp:ListItem>
                    </asp:DropDownList>
                </div>
                </div>
                 <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                <asp:HiddenField runat="server" ID="idorden_maternidad" />
                <asp:Button id="insertarordenmaternidad" runat="server" Text="enviar" CssClass="btn btn-primary" OnClick="insertarordenmaternidad_Click"/>
            </div>

                  <asp:Button class="btn btn-outline-success btn-lg btn-block" ID="Btnbackpaternidad" runat="server" Text="Regresar a ordenes" OnClick="Btnbackpaternidad_Click"  />&nbsp;
                  
                  </asp:View>
            
           <asp:View ID="View2" runat="server">
                  <h1>Abuelidad</h1>
              
                  
                  <div class="card-header">
                        <strong class="card-title">Datos de las personas de orden ADN </strong>
                            </div>  &nbsp;
                <!-----------------------------------abuelidad----------------------------------------------------------> 
                  <!--nombre de la abuela-->  
                        <div class="row form-group ">
                <div class="col col-md-3 "><label for="password-input" class=" form-control-label">Nombre de la abuela</label></div>
                <div class="col-12 col-md-9">&nbsp;
                <asp:TextBox ID="Mnombredelaabuela" runat="server" Text="" ToolTip="nombredelaabuela" CssClass="form-control" placeholder="Ingrese el nombre de la abuela"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="Mnombredelaabuela" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator>     
                    </div>
                </div>

                    <div class="row form-group ">
                <div class="col col-md-3 "><label for="password-input" class=" form-control-label">Nombre del nieto</label></div>
                <div class="col-12 col-md-9">&nbsp;
                <asp:TextBox ID="nombrenieto" runat="server" Text="" ToolTip="nombredelnieto" CssClass="form-control" placeholder="Ingrese el nombre del nieto"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="Mnombredelaabuela" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator>     
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
                                

                                 <asp:TextBox ID="Mfechaabuelidad" CssClass="form-control" BackColor="Wheat" Font-Bold="false" data-inputmask="'alias':'dd/mm/yyyy'"
                                    data-mask="" runat="server"></asp:TextBox> 
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="Mfecha" ErrorMessage="Siga este formato dd/mm/yyyy" ValidationExpression="^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$"></asp:RegularExpressionValidator>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="Mfecha" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator> 
                                     
                          </div>
                               </div>
                                    </div>
                   <!--tipo caso-->
                    <div class="row form-group ">
                <div class="col col-md-3 "><label for="select" class=" form-control-label">Caso</label></div>
                <div class="col-12 col-md-9 ">&nbsp; 
                    <asp:DropDownList ID="Mtipocasoabuelidad" runat="server" ToolTip="caso" CssClass="form-control">
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

                
              
                 <!--observaciones-->                            
                    <div class="row form-group ">
                <div class="col col-md-3 "><label for="password-input" class=" form-control-label">Observaciones</label></div>
                <div class="col-12 col-md-9">&nbsp;
                <asp:TextBox ID="Mobservacionesabuelidad" runat="server" Text="" ToolTip="observaciones" CssClass="form-control" placeholder="Ingrese las observaciones"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="Mobservacionesabuelidad" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator>     
                    </div>
                </div>


                 <div class="card-header">
                        <strong class="card-title">Datos secundarios </strong>
                            </div>  &nbsp;  

                
                   <!--bouvher -->
                <div class="row form-group ">
                <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Boucher</label></div>
                <div class="col-12 col-md-9">&nbsp; 
                        <asp:TextBox ID="Mboucherabuelidad" runat="server" Text="" ToolTip="baucher" CssClass="form-control" placeholder="Ingrese el baucher"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="Mboucherabuelidad" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator>     
                </div>
                    </div>

                 <!--no_orden-->
                <div class="row form-group ">
                <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Número orden</label></div>
                <div class="col-12 col-md-9">&nbsp; 
                        <asp:TextBox ID="Mnumerorodenabuelidad" runat="server" Text="" ToolTip="noorden" CssClass="form-control" placeholder="Ingrese el número de orden"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="Mnumerorodenabuelidad" ErrorMessage="Ingrese Solo numeros" ValidationExpression="^[0-9]*$" MaxLength="8"></asp:RegularExpressionValidator>   
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="Mnumerorodenabuelidad" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator>     
                </div>
                    </div>

                   <!--Seleccion de estado-->

                    <div class="row form-group ">
                <div class="col col-md-3 "><label for="select" class=" form-control-label">Estado</label></div>
                <div class="col-12 col-md-9 ">&nbsp; 
                    <asp:DropDownList ID="Mestadoabuelidad" runat="server" ToolTip="estado" CssClass="form-control">
                    <asp:ListItem Value="0">SELECCIONE</asp:ListItem>
                    <asp:ListItem Value="1">Activo</asp:ListItem>
                    <asp:ListItem Value="2">En espera</asp:ListItem>
                    </asp:DropDownList>
                </div>
                </div>
                 <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                <asp:HiddenField runat="server" ID="HiddenField1" />
                <asp:Button id="insertarordenabuelidad" runat="server" Text="enviar" CssClass="btn btn-primary" OnClick="insertarordenabuelidad_Click"/>
            </div>
               
               <asp:Button class="btn btn-outline-success btn-lg btn-block" ID="Btnbackabuelidad" runat="server" Text="Regresar a ordenes" OnClick="Btnbackabuelidad_Click"  />&nbsp;
                  
                  </asp:View>
             <!-------------------------alzheimer--------------------------------------------------------------------> 
            <asp:View ID="View3" runat="server">
                  <h1>Alzheimer</h1>
                
                  
                  <div class="card-header">
                        <strong class="card-title">Datos de las personas de orden ADN </strong>
                            </div>  &nbsp;
                 <!--nombre del doctor-->  
                        <div class="row form-group ">
                <div class="col col-md-3 "><label for="password-input" class=" form-control-label">Nombre del doctor</label></div>
                <div class="col-12 col-md-9">&nbsp;
                <asp:TextBox ID="Mnombredeldoctor" runat="server" Text="" ToolTip="nombredeldoctor" CssClass="form-control" placeholder="Ingrese el nombre del doctor"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="Mnombredeldoctor" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator>     
                    </div>
                </div>
                <!--nombre del paciente-->  
                    <div class="row form-group ">
                <div class="col col-md-3 "><label for="password-input" class=" form-control-label">Nombre del paciente</label></div>
                <div class="col-12 col-md-9">&nbsp;
                <asp:TextBox ID="Mnombredelpaciente" runat="server" Text="" ToolTip="nombredelpaciente" CssClass="form-control" placeholder="Ingrese el nombre del paciente"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="Mnombredelpaciente" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator>     
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
                                

                                 <asp:TextBox ID="Mfechaalzheimer" CssClass="form-control" BackColor="Wheat" Font-Bold="false" data-inputmask="'alias':'dd/mm/yyyy'"
                                    data-mask="" runat="server"></asp:TextBox> 
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="Mfechaalzheimer" ErrorMessage="Siga este formato dd/mm/yyyy" ValidationExpression="^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$"></asp:RegularExpressionValidator>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="Mfechaalzheimer" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator> 
                                     
                          </div>
                               </div>
                                    </div>
                   <!--tipo caso-->
                    <div class="row form-group ">
                <div class="col col-md-3 "><label for="select" class=" form-control-label">Caso</label></div>
                <div class="col-12 col-md-9 ">&nbsp; 
                    <asp:DropDownList ID="Mtipocasoalzheimer" runat="server" ToolTip="caso" CssClass="form-control">
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

              
              
                 <!--observaciones-->                            
                    <div class="row form-group ">
                <div class="col col-md-3 "><label for="password-input" class=" form-control-label">Observaciones</label></div>
                <div class="col-12 col-md-9">&nbsp;
                <asp:TextBox ID="Mobservacionesalzheimer" runat="server" Text="" ToolTip="observaciones" CssClass="form-control" placeholder="Ingrese las observaciones"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="Mobservacionesalzheimer" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator>     
                    </div>
                </div>


                 <div class="card-header">
                        <strong class="card-title">Datos secundarios </strong>
                            </div>  &nbsp;  

                
                   <!--bouvher -->
                <div class="row form-group ">
                <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Boucher</label></div>
                <div class="col-12 col-md-9">&nbsp; 
                        <asp:TextBox ID="Mboucheralzheimer" runat="server" Text="" ToolTip="baucher" CssClass="form-control" placeholder="Ingrese el baucher"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="Mboucheralzheimer" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator>     
                </div>
                    </div>

                 <!--no_orden-->
                <div class="row form-group ">
                <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Número orden</label></div>
                <div class="col-12 col-md-9">&nbsp; 
                        <asp:TextBox ID="Mnumeroordenalzheimer" runat="server" Text="" ToolTip="noorden" CssClass="form-control" placeholder="Ingrese el número de orden"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="Mnumeroordenalzheimer" ErrorMessage="Ingrese Solo numeros" ValidationExpression="^[0-9]*$" MaxLength="8"></asp:RegularExpressionValidator>   
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="Mnumeroordenalzheimer" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator>     
                </div>
                    </div>

                   <!--Seleccion de estado-->

                    <div class="row form-group ">
                <div class="col col-md-3 "><label for="select" class=" form-control-label">Estado</label></div>
                <div class="col-12 col-md-9 ">&nbsp; 
                    <asp:DropDownList ID="Mestadoalzheimer" runat="server" ToolTip="estado" CssClass="form-control">
                    <asp:ListItem Value="0">SELECCIONE</asp:ListItem>
                    <asp:ListItem Value="1">Activo</asp:ListItem>
                    <asp:ListItem Value="2">En espera</asp:ListItem>
                    </asp:DropDownList>
                </div>
                </div>
                 <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                <asp:HiddenField runat="server" ID="HiddenField2" />
                <asp:Button id="insertarordenalzheimer" runat="server" Text="enviar" CssClass="btn btn-primary" OnClick="insertarordenalzheimer_Click"/>
            </div>
                 <asp:Button class="btn btn-outline-success btn-lg btn-block" ID="Btnbackmaternidad" runat="server" Text="Regresar a ordenes" OnClick="Btnbackmaternidad_Click"  />&nbsp;
                </asp:View>
             <!-------------------------------------papiloma--------------------------------------------------------> 
            <asp:View ID="View4" runat="server">
                 <h1>Papiloma</h1>
                
                  
                 <div class="card-header">
                        <strong class="card-title">Datos de las personas de orden ADN </strong>
                            </div>  &nbsp;
                <!--nombre del doctor-->  
                        <div class="row form-group ">
                <div class="col col-md-3 "><label for="password-input" class=" form-control-label">Nombre del doctor</label></div>
                <div class="col-12 col-md-9">&nbsp;
                <asp:TextBox ID="Mdoctorpapiloma" runat="server" Text="" ToolTip="nombredeldoctor" CssClass="form-control" placeholder="Ingrese el nombre del doctor"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="Mdoctorpapiloma" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator>     
                    </div>
                </div>
                <!--nombre del paciente-->  
                    <div class="row form-group ">
                <div class="col col-md-3 "><label for="password-input" class=" form-control-label">Nombre del paciente</label></div>
                <div class="col-12 col-md-9">&nbsp;
                <asp:TextBox ID="Mpacientepapiloma" runat="server" Text="" ToolTip="nombredelpaciente" CssClass="form-control" placeholder="Ingrese el nombre del paciente"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="Mpacientepapiloma" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator>     
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
                                

                                 <asp:TextBox ID="Mfechapapiloma" CssClass="form-control" BackColor="Wheat" Font-Bold="false" data-inputmask="'alias':'dd/mm/yyyy'"
                                    data-mask="" runat="server"></asp:TextBox> 
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="Mfechapapiloma" ErrorMessage="Siga este formato dd/mm/yyyy" ValidationExpression="^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$"></asp:RegularExpressionValidator>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="Mfechapapiloma" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator> 
                                     
                          </div>
                               </div>
                                    </div>
                   <!--tipo caso-->
                    <div class="row form-group ">
                <div class="col col-md-3 "><label for="select" class=" form-control-label">Caso</label></div>
                <div class="col-12 col-md-9 ">&nbsp; 
                    <asp:DropDownList ID="Mtipocasopapiloma" runat="server" ToolTip="caso" CssClass="form-control">
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

               
              
                 <!--observaciones-->                            
                    <div class="row form-group ">
                <div class="col col-md-3 "><label for="password-input" class=" form-control-label">Observaciones</label></div>
                <div class="col-12 col-md-9">&nbsp;
                <asp:TextBox ID="Mobservacionespapiloma" runat="server" Text="" ToolTip="observaciones" CssClass="form-control" placeholder="Ingrese las observaciones"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="Mobservacionespapiloma" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator>     
                    </div>
                </div>


                 <div class="card-header">
                        <strong class="card-title">Datos secundarios </strong>
                            </div>  &nbsp;  

                
                   <!--bouvher -->
                <div class="row form-group ">
                <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Boucher</label></div>
                <div class="col-12 col-md-9">&nbsp; 
                        <asp:TextBox ID="Mboucherpapiloma" runat="server" Text="" ToolTip="baucher" CssClass="form-control" placeholder="Ingrese el baucher"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="Mboucherpapiloma" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator>     
                </div>
                    </div>

                 <!--no_orden-->
                <div class="row form-group ">
                <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Número orden</label></div>
                <div class="col-12 col-md-9">&nbsp; 
                        <asp:TextBox ID="Mnumeroordenpapiloma" runat="server" Text="" ToolTip="noorden" CssClass="form-control" placeholder="Ingrese el número de orden"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="Mnumeroordenpapiloma" ErrorMessage="Ingrese Solo numeros" ValidationExpression="^[0-9]*$" MaxLength="8"></asp:RegularExpressionValidator>   
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="Mnumeroordenpapiloma" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator>     
                </div>
                    </div>

                   <!--Seleccion de estado-->

                    <div class="row form-group ">
                <div class="col col-md-3 "><label for="select" class=" form-control-label">Estado</label></div>
                <div class="col-12 col-md-9 ">&nbsp; 
                    <asp:DropDownList ID="Mestadopapiloma" runat="server" ToolTip="estado" CssClass="form-control">
                    <asp:ListItem Value="0">SELECCIONE</asp:ListItem>
                    <asp:ListItem Value="1">Activo</asp:ListItem>
                    <asp:ListItem Value="2">En espera</asp:ListItem>
                    </asp:DropDownList>
                </div>
                </div>
                 <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                <asp:HiddenField runat="server" ID="HiddenField3" />
                <asp:Button id="insertarordenpapiloma" runat="server" Text="enviar" CssClass="btn btn-primary" OnClick="insertarordenpapiloma_Click"/>
            </div>
                <asp:Button class="btn btn-outline-success btn-lg btn-block" ID="btnpaternidad" runat="server" Text="Paternidad" OnClick="btnpaternidad_Click"/>

                </asp:View>


        </asp:MultiView>
    </form>
        </div>
        </div>

    
</asp:Content>
