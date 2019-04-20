<%@  Page Title="" Language="C#" MasterPageFile="~/configuration.Master" AutoEventWireup="true" CodeBehind="Peruser.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.Opc.Use.Peruser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
     <form id="myfrom" method="post" enctype="multipart/form-data" class="form-horizontal" runat="server">
             
    <!--Seleccion de Permisos-->
                  
                    <div class="card-header">
                        <strong class="card-title">Permisos Agregables</strong>
                            </div>&nbsp; 
                <div class="row form-group ">
                <div class="col col-md-3 "><label for="select" class=" form-control-label">Añadir permisos</label></div>
                <div class="checkbox">&nbsp; 
                        <asp:CheckBoxList ID="Magregar" runat="server" ToolTip="Seleccione los permisos"  OnSelectedIndexChanged="Mpermiso_SelectedIndexChanged" AutoPostBack="false">
                         </asp:CheckBoxList>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="validarcheckbox" ErrorMessage="Debe Seleccionar al menos un examen" ForeColor="Red" Font-Italic="true"></asp:CustomValidator>
                </div>
                      </div>

          <!--Seleccion de Permisos-->
                  
                    <div class="card-header">
                        <strong class="card-title">Permisos Eliminables</strong>
                            </div>&nbsp; 
                <div class="row form-group ">
                <div class="col col-md-3 "><label for="select" class=" form-control-label">Añadir permisos</label></div>
                <div class="checkbox">&nbsp; 
                        <asp:CheckBoxList ID="Meliminar" runat="server" ToolTip="Seleccione los permisos"  OnSelectedIndexChanged="Mpermiso_SelectedIndexChanged" AutoPostBack="false">
                         </asp:CheckBoxList>
                </div>
                      </div>

        <div class="modal-footer">
                <button type="button" class="btn btn-secondary" onclick="location.href='../Index.aspx'" data-dismiss="modal">Cancelar</button>
                <asp:HiddenField runat="server" ID="id_rol" />
                <asp:Button id="enviar" runat="server" Text="Guardar Cambios" CssClass="btn btn-primary" OnClick="Permisos"/>
            </div>             
       </form> 
</asp:Content>