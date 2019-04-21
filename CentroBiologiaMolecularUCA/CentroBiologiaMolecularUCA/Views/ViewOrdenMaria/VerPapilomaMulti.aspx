<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerPapilomaMulti.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.ViewOrdenMaria.VerPapilomaMulti" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card-header">
                        <strong class="card-title">Datos de las personas de orden ADN papiloma</strong>
                            </div>  
      <div class="card">
            <div class="card-body card-block">
                <form id="Form1" method="post" enctype="multipart/form-data" class="form-horizontal" runat="server">
                      <!------------------------------------------------------------------------------------>
                     <div class="card-header">
                        <strong class="card-title">Orden del Cliente</strong>
                            </div>&nbsp;
                     <!--Obtener el nombre del cliente que selecciono-->
            <div class="row form-group ">
                <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Nombre Cliente</label></div>
                <div class="col-12 col-md-9">
                     <asp:TextBox ID="Mcliente" ReadOnly="true" runat="server" ToolTip="Nombre Cliente" CssClass="form-control"></asp:TextBox>   
                </div>
             </div>
                    <!--Obtener la cedula del cliente que selecciono-->
           <div class="row form-group ">
                <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Cedula</label></div>
                <div class="col-12 col-md-9">
                     <asp:TextBox ID="Mcedula" ReadOnly="true" runat="server" ToolTip="Cedula Cliente" CssClass="form-control"></asp:TextBox>      
                     </div>
             </div>
                     <!------------------------------------------------------------------------------------>
                  <!--codigo de papiloma-->  
                        <div class="row form-group ">
                <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Código orden</label></div>
                <div class="col-12 col-md-9">&nbsp;
                <asp:TextBox ID="Mcodigopapiloma" runat="server" ReadOnly="true"  Text="" ToolTip="codigodelamadre" CssClass="form-control"></asp:TextBox>
                      
                    </div>
                </div>

                      <!--nombre  de la doctor papiloma-->    
                       <div class="row form-group ">
                <div class="col col-md-3 "><label for="password-input" class=" form-control-label">Nombre del doctor</label></div>
                <div class="col-12 col-md-9">&nbsp;
                <asp:TextBox ID="Mdoctorpapiloma" runat="server" Text="" ToolTip="nombremadre" CssClass="form-control" placeholder="Ingrese el nombre del hijo"></asp:TextBox>
                       
                    </div>
                </div> 
                    <!--nombre del paciente-->    
                       <div class="row form-group ">
                <div class="col col-md-3 "><label for="password-input" class=" form-control-label">Nombre del paciente</label></div>
                <div class="col-12 col-md-9">&nbsp;
                <asp:TextBox ID="Mpacientepapiloma" runat="server" Text="" ToolTip="nombrehijomadre" CssClass="form-control" placeholder="Ingrese el nombre del hijo"></asp:TextBox>
                       
                    </div>
                </div> 
                    
                       





                   <!--fecha-->
                           <div class="row form-group ">
                          <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Fecha</label></div>
                <div class="col-12 col-md-9">&nbsp; 
                    
                      <asp:Textbox ID="Mfechapapiloma" runat="server" ToolTip="fecha" placeholder="dd/mm/yyyy"></asp:Textbox>
                    
                       
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
                            
                </div>
                    </div>

             

               

                     <div class="modal-footer">
                       <asp:HiddenField runat="server" ID="Id_orden" />
                      <a class="btn btn-outline-success btn-lg btn-block" href="../../Views/Vogm/Searchogm.aspx">Regresar</a>  
                </div> 


                      </form>
            </div>
         </div>  
       <script type="text/javascript" src="../../Content/Generic.js"></script>
    <script  type="text/javascript">
 window.onload = function () {
     editPapiloma('<%=ord.Id_codigo%>', '<%=ord.Nombre_pareja%>', '<%=ord.Nombre_menor%>', '<%=ord.Fecha%>', '<%=ord.Tipo_Caso%>', '<%=ord.Observaciones%>', '<%=ord.Baucher%>'
           )
};
</script> 
</asp:Content>
