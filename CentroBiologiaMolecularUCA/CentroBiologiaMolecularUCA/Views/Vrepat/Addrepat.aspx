<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Addrepat.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.Vrepat.Addrepat" %>
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
            <strong class="card-title" >REGISTRO DE ANALISIS DE DETECCION DE PATOGENO</strong>
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


               <!--Nombre del importador-->
                 <div class="row form-group ">
                   <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Nombre del importador</label></div>
                <div class="col-12 col-md-9">&nbsp;                     
                      <asp:Textbox ID="Mimportador" ReadOnly="true" BackColor="White" runat="server" ToolTip="Nombre del importador" CssClass="formcursor"></asp:Textbox>
                     </div>
                   </div>

            <!--Seleccion de Tipo de Analisis-->
                   
                <div class="row form-group ">
                <div class="col col-md-3 "><label for="select" class=" form-control-label">Tipo de Analisis</label></div>
                <div class="checkbox">&nbsp; 
                        <asp:CheckBoxList ID="Manalisis" Enabled="false" BackColor="White" runat="server" ToolTip="Seleccione los Tipo de Analisis" AutoPostBack="false">
                         </asp:CheckBoxList>
                </div>
                      </div>

              <!--Seleccion de Tipo Muestra-->
                           <div class="row form-group">
                             <div class="col col-md-3"><label for="select" class=" form-control-label">Tipo Muestra</label></div>
                              <div class="col-12 col-md-9">&nbsp; 
                               <asp:DropDownList ID="Mmuestra" Enabled="false" BackColor="White" runat="server" CssClass="form-control">
                                 </asp:DropDownList>
                            </div>
                          </div>

           <div class="card-header">
            <strong class="card-title" >Resultado Examen</strong>
        </div>&nbsp;

          <!--TABLA PARA RESULTADO DETALLE-->
		   <div class="row form-group">
			   <div class="col-sm-6">
                    <div class="card-body">
                        <table id="table"class="table table-striped table-bordered" >
                            <thead>
                                <tr>
                                    <th>Tipo de Analisis</th> 
                                </tr>
                            </thead>
                            <tbody>  

                                    <%
                                    while(getregistros().Read())
                                    {
                                        %>
                                            <tr><td><%=getregistros()["analisis"] %></td>
                                        <%
											}
                                %>
                            </tr>
								
                            </tbody>
                        </table>
                    </div>
				   </div> 
			   <div class="radioEspecial">
					   <asp:RadioButtonList runat="server" ID="radio1" Visible="false" RepeatDirection="Horizontal">
						   <asp:ListItem Value="1" Text="Positivo "></asp:ListItem>
						   <asp:ListItem Value="0" Text="Negativo"></asp:ListItem>
					   </asp:RadioButtonList>
				   
					<asp:RadioButtonList runat="server" ID="radio2" Visible="false" RepeatDirection="Horizontal">
					   <asp:ListItem Value="1" Text="Positivo "></asp:ListItem>
					   <asp:ListItem Value="0" Text="Negativo"></asp:ListItem>
				   </asp:RadioButtonList>
				   </div>
			   </div>
             <!--observaciones-->                            
                    <div class="row form-group ">
                <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Observaciones</label></div>
                <div class="col-12 col-md-9">&nbsp;
                <asp:Textbox ID="Mobservaciones" runat="server" TextMode="multiline" Columns="50" Rows="5" ToolTip="observaciones" CssClass="form-control" placeholder="Ingrese las observaciones"></asp:Textbox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Mobservaciones" Display="Dynamic" ErrorMessage="Este Campo es requerido" ForeColor="Red" Font-Italic="true"></asp:RequiredFieldValidator>     
                    </div>
                </div> 


                                     
             <div class="modal-footer">
                <button type="button" class="btn btn-secondary" onclick="location.href='../Vogm/Searchogm.aspx'">Cancelar</button>
                <asp:HiddenField runat="server" ID="id_orden" />
                <asp:Button id="enviar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="InsertarResultado" />
            </div>   

            </form>
            </div>
        </div>

</asp:Content>
