<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarResultadoOgm.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.ViewResultadoMaria.AgregarResultadoOgm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div class="content mt-3">
            <div class="animated">
                <div class="card">
                    <div class="card-header">
                        <i class="mr-2 fa fa-align-justify"></i>
                        <strong class="card-title" v-if="headerText">Crear</strong>
                    </div>
                    <div class="card-body">
                         <button type="button" class="btn-success" data-toggle="modal" data-target="#mediumModal">
                   <i class="menu-icon fa fa-plus-circle"></i> Nuevo examen OGM </button>
   
                    </div>
                </div>

                <div class="modal fade" id="mediumModal" tabindex="-1" role="dialog" aria-labelledby="mediumModalLabel" aria-hidden="true">
                    <div class="modal-dialog modal-lg" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="mediumModalLabel">Agregar Orden ADN</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                    <div class="card">
                                            <div class="card-body card-block">
                                              <form method="post" enctype="multipart/form-data" class="form-horizontal" runat="server">

                            <!--Comienzo de los formulario-->  
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
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="Mfecha" ErrorMessage="Siga este formato dd/mm/yyyy" ValidationExpression="^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$"></asp:RegularExpressionValidator>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Mfecha" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator> 
                                     
                          </div>
                               </div>
                                    </div>

                            <!--validacion-->
                       <div class="row form-group ">
                            <div class="col col-md-3 "><label for="select" class=" form-control-label">Validacion</label></div>
                            <div class="col-12 col-md-9 ">
                             <asp:DropDownList ID="Mvalidacion" runat="server" ToolTip="caso" CssClass="form-control">
                              <asp:ListItem Value="0">SELECCIONE</asp:ListItem>
                               <asp:ListItem Value="1">Aprobado</asp:ListItem>
                               <asp:ListItem Value="2">No aprobado</asp:ListItem>
                                  <asp:ListItem Value="3">En espera</asp:ListItem>
                               </asp:DropDownList>
                            </div>
                          </div>

                            <!--permiso de importacion-->
                          <div class="row form-group">
                            <div class="col col-md-3"><label for="text-input" class=" form-control-label">permiso importación</label></div>
                                    <div  class="col-12 col-md-9"> <input type="text" id="importacion-input"  name="importacion-input" readonly="readonly" value="per import 27648" placeholder="" class="form-control" /> </div>
                          </div>

                            <!--tipo muestra-->
                          <div class="row form-group">
                            <div class="col col-md-3"><label for="text-input" class=" form-control-label">tipo muestra</label></div>
                                    <div  class="col-12 col-md-9"> <input type="text" id="muestra-input"  name="muestra-numero" readonly="readonly" value="Arroz" placeholder="" class="form-control" /> </div>
                      
                          </div>

                           <!--tipo proteinas-->
                          <div class="row form-group ">
                            <div class="col col-md-3 "><label for="select" class=" form-control-label">eventos</label></div>
                            <div class="col-12 col-md-9 ">
                             <asp:DropDownList ID="Mresultado" runat="server" ToolTip="caso" CssClass="form-control">
                              <asp:ListItem Value="0">SELECCIONE</asp:ListItem>
                               <asp:ListItem Value="1">Cry1Ab</asp:ListItem>
                               <asp:ListItem Value="2">RR</asp:ListItem>
                                  <asp:ListItem Value="3">Cry3Bb</asp:ListItem>
                                 <asp:ListItem Value="4">Cry1F</asp:ListItem>
                                 <asp:ListItem Value="5">LL pat</asp:ListItem>
                                 <asp:ListItem Value="6">Cry34</asp:ListItem>
                                 <asp:ListItem Value="7">mCry3A</asp:ListItem>
                                 <asp:ListItem Value="8">LL bar</asp:ListItem>
                               </asp:DropDownList>
                            </div>
                          </div>

                          <!--ensayo de adn-->
                          <!--div class="row form-group">
                            <div class="col col-md-3"><label for="text-input" class=" form-control-label">Ensayo de ADN por PCR (eventos especifico)</label></div>
                            <div class="col-12 col-md-9"><input type="text" id="ensayo-input" name="ensayo-input" placeholder="" class="form-control"></div>
                          </!--div>

                           <!--ensayo de adn-->
                          <!--div class="row form-group">
                            <div class="col col-md-3"><label for="text-input" class=" form-control-label">Ensayo de ADN por PCR (35s-p)</label></div>
                            <div class="col-12 col-md-9"><input type="text" id="pcr35-input" name="pcr35-input" placeholder="" class="form-control"></div>
                          </!--div>

                               <!--ensayo de adn-->
                          <!--div class="row form-group">
                            <div class="col col-md-3"><label for="text-input" class=" form-control-label">Ensayo de ADN por PCR (T-NOS)</label></div>
                            <div class="col-12 col-md-9"><input type="text" id="tnos-input" name="tnos-input" placeholder="" class="form-control"></div>
                          </!--div>

                                 <!--estado-->
                       <div class="row form-group ">
                            <div class="col col-md-3 "><label for="select" class=" form-control-label">Estado</label></div>
                            <div class="col-12 col-md-9 ">
                             <asp:DropDownList ID="Mestado" runat="server" ToolTip="caso" CssClass="form-control">
                              <asp:ListItem Value="0">SELECCIONE</asp:ListItem>
                               <asp:ListItem Value="1">Activo</asp:ListItem>
                               <asp:ListItem Value="2">en esperaa</asp:ListItem>
                                 
                               </asp:DropDownList>
                            </div>
                          </div>
                               
                               <!--usuario procesa--> 
                         <div class="row form-group ">
                            <div class="col col-md-3 "><label for="password-input" class=" form-control-label">usuario que procesa</label></div>
                            <div class="col-12 col-md-9">
                           <asp:TextBox ID="Musuarioprocesa" runat="server" Text="" ToolTip="Fecha" CssClass="form-control" placeholder="Ingrese el nombre del usuario que realizo el examen"></asp:TextBox>
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Musuarioprocesa" ErrorMessage="Solo letras" ValidationExpression="^[a-z &amp; A-Z]*$"></asp:RegularExpressionValidator>
                                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Musuarioprocesa" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator>     
                               </div>
                          </div>

                          <!--usuario valida--> 
                         <div class="row form-group ">
                            <div class="col col-md-3 "><label for="password-input" class=" form-control-label">usuario que valida</label></div>
                            <div class="col-12 col-md-9">
                           <asp:TextBox ID="Musuariovalida" runat="server" Text="" ToolTip="Fecha" CssClass="form-control" placeholder="digite el usuario que revisa"></asp:TextBox>
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="Musuariovalida" ErrorMessage="Solo letras" ValidationExpression="^[a-z &amp; A-Z]*$"></asp:RegularExpressionValidator>
                                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Musuariovalida" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator>     
                               </div>
                          </div>

                          <!--analisis--> 
                         <div class="row form-group ">
                            <div class="col col-md-3 "><label for="password-input" class=" form-control-label">Analisis</label></div>
                            <div class="col-12 col-md-9">
                           <asp:TextBox ID="Manalisis" runat="server" Text="" ToolTip="Fecha" CssClass="form-control" placeholder="Ingrese el analalisis"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Manalisis" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator>     
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
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>


        <!--Tabla de orden-->                               
                         <div class="content mt-3">
                        <div class="animated fadeIn">
                            <div class="row">
                                <div class="col-md-12 ">
                                    <div class="card">
                                        <div class="card-header">
                                            <strong class="card-title">Orden ADN humano</strong>
                                        </div>
                                        <div class="card-body">
                                            <table id="bootstrap-data-table" class="table table-striped table-bordered">
                                                <thead>
                                                    <tr>
                                                        <th>Codigo</th>
                                                         
                                                        <th>Analisis</th>
                                                        
                                                        <th>Opciones</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                     <%
                                                        while(getregistros().Read())
                                                        {
                                                            %>
                                                              <tr><td><%=getregistros()["Id_resultado"] %></td>
                                                                  
                                                                  <td><%=getregistros()["Analisis"] %></td>
                                                                  
                                                                  <td>
                                                                   <a title="Mostrar" onclick="mostrar" href="VerResultadoOgm.aspx?id=<%=getregistros()["Id_resultado"] %>">
                                                                       <i class="ti-eye"></i>
                                                                     </a>
                                                                     <a title="Editar" onclick="editar" href="ModificarResultadoOgm.aspx?id=<%=getregistros()["Id_resultado"] %>">
                                                                       <i class="ti-pencil-alt"></i>
                                                                    </a> 
                                                                      <a href="Eliminarresultado.aspx?id=<%=getregistros()["Id_resultado"] %>" onclick="Eliminar('Eliminarresultado.aspx?id=<%=getregistros()["Id_resultado"] %>');">
                                                                      <i class="menu-icon fa fa-trash-o"></i>
                                                                      </a> 
                                                                   
                                                                      </td>
                                                             </tr>
                                                            <%
                                                        }
                                                    %>                                                              
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div><!-- .animated -->
                    </div><!-- .content -->
    <script type="text/javascript" src="../../Content/ListaOrdenOgm.js"></script>

    <script src="../../js/plugins/input-mask/jquery.inputmask.js"></script>
                       
                       <script src="../../js/plugins/input-mask/jquery.inputmask.date.extensions.js"></script>
                       
                       <script src="../../js/plugins/timepicker/bootstrap-timepicker.min.js"></script>
                       <script src="../../js/plugins/moment/moment.min.js"></script>

</asp:Content>
