<%@ Page Title="" Language="C#" MasterPageFile="~/configuration.Master" AutoEventWireup="true" CodeBehind="AgregarExamenes.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.OpcionesConfigurables.AgregarExamenes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="card-header">
            <strong class="card-title" v-if="headerText">Agregar examen</strong>
        </div>
            <div class="card">
                                             
            <div class="card-body card-block">
                <form id="myfrom" method="post" enctype="multipart/form-data" class="form-horizontal" runat="server">
                    <!--Comienzo de los formularios--> 
                    
                    
                                                
                    <!--nombre-->
                <div class="form-group">
                    <div class="col col-md-1"><label for="text-input" class=" form-control-label">Nombre examen:</label></div>
                    <div class="col-12 col-md-3">&nbsp;
                        <asp:TextBox ID="Mnombre" runat="server" Text="" ToolTip="Nombres" CssClass="form-control" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Mnombre" Display="Dynamic" ErrorMessage="Este Campo es requerido" BorderColor="#FF5050" BorderStyle="None" CssClass="form_hint" ForeColor="Red"></asp:RequiredFieldValidator>
                    
                    </div>
                </div>

                    <!--precio-->
                <div class="form-group">
                    <div class="col col-md-1"><label for="password-input" class=" form-control-label">Precio examen:</label></div>
                    <div class="col-12 col-md-3">&nbsp;
                        <asp:TextBox ID="Mprecio" runat="server" Text="" ToolTip="Precio" CssClass="form-control" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Mprecio" Display="Dynamic" ErrorMessage="Este Campo es requerido" BorderColor="#FF5050" BorderStyle="None" CssClass="form_hint" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                    <div class="modal-footer">
                                       <asp:Button id="cancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" />
                                       <asp:HiddenField runat="server" ID="Id_examen" />
                                       <asp:Button id="enviar" runat="server" Text="Agregar" CssClass="btn btn-primary" OnClick="InsertarExamen" />
                                  </div>
                    </form>
                </div>
                    </div>
</asp:Content>
