<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Seerevph.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.Vrevph.Seerevph" %>
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
            <strong class="card-title" >DETECCIÓN MOLECULAR Y GENOTIPIFICACION DE VIRUS DE PAPILOMA HUMANO</strong>
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
                   <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Fecha Resultado</label></div>
                <div class="col-12 col-md-9">&nbsp;                     
                      <asp:Textbox ID="Mfecha" runat="server"  BackColor="White" ReadOnly="true" ToolTip="fecha" CssClass="formcursor"></asp:Textbox>
                     </div>
                   </div>
                  <!--Fecha-->
               <div class="row form-group ">
                   <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Fecha Muestra</label></div>
                <div class="col-12 col-md-9">&nbsp;                     
                      <asp:Textbox ID="Mfecham" runat="server"  BackColor="White" ReadOnly="true" ToolTip="fecha" CssClass="formcursor"></asp:Textbox>
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


               <!--Nombre del Cliente-->
                 <div class="row form-group ">
                   <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Nombre del Cliente</label></div>
                <div class="col-12 col-md-9">&nbsp;                     
                      <asp:Textbox ID="Mcliente" ReadOnly="true" BackColor="White" runat="server" ToolTip="Nombre Cliente" CssClass="formcursor"></asp:Textbox>
                     </div>
                   </div>&nbsp;  
                  <div class="row form-group ">
                       <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Cedula</label></div>
                    <div class="col-12 col-md-9">&nbsp;                     
                          <asp:Textbox ID="Mcedula" ReadOnly="true" BackColor="White" runat="server" ToolTip="Cedula" CssClass="formcursor"></asp:Textbox>
                         </div>
                   </div>

        <div class="card-header">
            <strong class="card-title" >Resultado Examen</strong>
        </div>&nbsp;

            <!--TABLA PARA RESULTADO DETALLE-->

                    <div class="card-body">
                        <table id="table" class="table table-striped table-bordered" >
                            <thead>
                                <tr>
                                    <th>Tipo de VPH</th>  
                                    <th>Resultado</th>
                                    
                                </tr>
                            </thead>
                            <tbody> 
<%
                                    while(getregistros().Read())
                                    {
                                        %>
                                            <tr>
                                                <td><%=getregistros()["Nombre"]%></td>
                                                <td><%=getregistros()["Resultado"]%></td>
                                            </tr>
                                        <%
                                    }
                                %>                                                                                                             
                            </tbody>
                        </table>
                    </div>
 
           <!--observaciones-->
        <div class="row form-group ">
                <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Analisis Resultado</label></div>
                <div class="col-12 col-md-9">&nbsp;
                <asp:Textbox ID="Mobservaciones" runat="server" TextMode="multiline" Columns="50" Rows="5" ToolTip="observaciones" CssClass="form-control" placeholder="Ingrese las observaciones"></asp:Textbox>                     
                    </div>
                </div> 
 
                   <div class="modal-footer">
                       <asp:HiddenField runat="server" ID="Id_orden" />
                      <a class="btn btn-outline-success btn-lg btn-block" OnClick="javascript: return history.back()">Regresar</a>  
                </div>     
           
              </form>
            </div>
    </div> 
</asp:Content>
