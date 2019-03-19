﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerOrdenAdnMulti.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.ViewOrdenMaria.VerOrdenAdnMulti" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <div class="card-header">
        <strong class="card-title">ADN</strong>
         </div>  
            <div class="card">
            <div class="card-body card-block">
                <form id="Form1" method="post" enctype="multipart/form-data" class="form-horizontal" runat="server">
                    <!--Comienzo de los formulario-->    
                      <!--Codigo-->  
                     <div class="row form-group ">
                <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Codigo orden</label></div>
                <div class="col-12 col-md-9">&nbsp; 
                        <asp:TextBox ID="Mcodigo" runat="server" ReadOnly="true" ToolTip="Codigo Orden" CssClass="form-control"></asp:TextBox>&nbsp; 
                </div>
                    </div>

                     <!--nombre del padre-->  
                        <div class="row form-group ">
                <div class="col col-md-3 "><label for="password-input" class=" form-control-label">Nombre del padre</label></div>
                <div class="col-12 col-md-9">&nbsp;
                <asp:TextBox ID="Mnombrepareja" runat="server" Text="" ToolTip="nombrepareja" CssClass="form-control" placeholder="Ingrese el nombre del padre"></asp:TextBox>
                           
                    </div>
                </div>
                       <!--nombre del hijo-->    
                       <div class="row form-group ">
                <div class="col col-md-3 "><label for="password-input" class=" form-control-label">Nombre del hijo</label></div>
                <div class="col-12 col-md-9">&nbsp;
                <asp:TextBox ID="Mnombrehijo" runat="server" Text="" ToolTip="nombrehijo" CssClass="form-control" placeholder="Ingrese el nombre del hijo"></asp:TextBox>
                         
                    </div>
                </div>  
                    
                      <!--fecha-->
´                   <div class="row form-group ">
                   <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Fecha</label></div>
                <div class="col-12 col-md-9">&nbsp; 
                      <asp:Textbox ID="Mfecha" runat="server" ToolTip="fecha" CssClass="form-control" ReadOnly="true" placeholder="dd/mm/yyyy"></asp:Textbox>
                     </div>
                   </div> 

                    <!--Seleccion de Tipo caso-->
                           <div class="row form-group">
                             <div class="col col-md-3"><label for="select" class=" form-control-label">caso</label></div>
                              <div class="col-12 col-md-9">&nbsp; 
                               <asp:DropDownList ID="Mtipocaso"  runat="server" ToolTip="tipocaso" CssClass="form-control"  required="">
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

                   

                     <div class="card-header">
                        <strong class="card-title">Datos secundarios de orden adn </strong>
                            </div>  &nbsp;

                    <!--observaciones -->
                <div class="row form-group ">
                <div class="col col-md-3 "><label for="password-input" class=" form-control-label">observaciones</label></div>
                <div class="col-12 col-md-9">&nbsp;
                <asp:TextBox ID="Mobservaciones" runat="server" Text="" ToolTip="observaciones" CssClass="form-control" placeholder="Ingrese las observaciones"></asp:TextBox>
                         
                    </div>
                </div>  

                      <!--boucher -->
                
                 <div class="row form-group ">
                <div class="col col-md-3 "><label for="password-input" class=" form-control-label">Baucher</label></div>
                <div class="col-12 col-md-9">&nbsp;
                <asp:TextBox ID="Mbaucher" runat="server" Text="" ToolTip="baucher" CssClass="form-control" placeholder="Ingrese el baucher"></asp:TextBox>
                           
                    </div>
                </div>

                    
                  <!--Seleccion de estado-->
                    <div class="row form-group ">
                <div class="col col-md-3 "><label for="select" class=" form-control-label">Estado</label></div>
                <div class="col-12 col-md-9 ">&nbsp; 
                    <asp:DropDownList ID="Mestado"  runat="server" ToolTip="estado" CssClass="form-control" required="">
                    <asp:ListItem Value="0">SELECCIONE</asp:ListItem>
                    <asp:ListItem Value="1">Activo</asp:ListItem>
                    <asp:ListItem Value="2">En espera</asp:ListItem>
                    </asp:DropDownList>
                </div>
                </div>

                     <div class="modal-footer">
                       <asp:HiddenField runat="server" ID="Id_orden" />
                      <a class="btn btn-outline-success btn-lg btn-block" href="../../Views/ViewOrdenMaria/BuscarMultiAdnOrden.aspx">Regresar</a>  
                </div> 

                        </form>
            </div>
         </div>  

    <script type="text/javascript" src="../../Content/ListaOrdenAdn.js"></script>
    <script  type="text/javascript">
 window.onload = function () {
    edit( '<%=ord.Id_codigo%>', '<%=ord.Nombre_pareja%>','<%=ord.Nombre_menor%>','<%=ord.Fecha%>','<%=ord.Tipo_Caso%>','<%=ord.Observaciones%>','<%=ord.Baucher%>','<%=ord.Estado%>'
           )
};
</script> 


</asp:Content>