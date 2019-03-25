﻿<%@ Page Title="" Language="C#" MasterPageFile="~/configuration.Master" AutoEventWireup="true" CodeBehind="Addexa.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.OpcionesConfigurables.AgregarExamenes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

         <script>
        function Insertarexa(data) {
            swal({
                title: "Exámen Agregado",
                text: "Correctamente",
                icon: "success",
               // buttons: true,
                //dangerMode: true,
            })
          .then((willDelete) => {
              if (willDelete) {
                  location.href = "Searchexa.aspx";
              } 
          });
        }
    </script>
       
         <div class="card-header">
            <strong class="card-title" v-if="headerText">Agregar Examen</strong>
        </div>

                                 <!--Aqui Comienza el formulario dentro del modal-->                                
                     <div class="card">
                      <div class="card-body card-block">
                        <form method="post" enctype="multipart/form-data" class="form-horizontal" runat="server">
                              <!--nombre-->
                      
                          <div class="row form-group">
                            <div class="col col-md-3"><label for="text-input" class=" form-control-label">Nombre Examen</label></div>
                            <div class="col-12 col-md-9">
                                 <asp:TextBox ID="Mnombre" runat="server" Text="" ToolTip="Nombres" CssClass="form-control" required="required" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Mnombre" Display="Dynamic" ErrorMessage="Este Campo es requerido" BorderColor="#FF5050" BorderStyle="None" CssClass="form_hint" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Mnombre" Display="Dynamic" ErrorMessage="Este Campo es requerido" BorderColor="#FF5050" BorderStyle="None" CssClass="form_hint" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Mnombre" ErrorMessage="Datos Incorrectos" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]*$" BackColor="White" BorderColor="#FF5050" BorderStyle="None" Font-Bold="False" Font-Italic="False" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>
                          </div>
                            <!--Precio-->
                            <div class="row form-group">
                            <div class="col col-md-3"><label for="text-input" class=" form-control-label">Precio Examen</label></div>
                                 <div class="col-12 col-md-9">
                            <asp:TextBox ID="Mprecio" runat="server" Text="" ToolTip="Precio" CssClass="form-control" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Mprecio" Display="Dynamic" ErrorMessage="Este Campo es requerido" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="Mprecio" ErrorMessage="Datos Incorrectos" ValidationExpression="^[0-9]*$" MaxLength="8" ForeColor="#FF3300"></asp:RegularExpressionValidator>                                                   
                                 </div>
                                 </div>
                         <div class="modal-footer">
                          <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                              <asp:HiddenField runat="server" ID="id_usuario" />
                              <asp:Button id="Aceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary" OnClick="InsertarExamen"/>
                          </div>
                            
                        </form>
                      </div>
                    </div>
   
</asp:Content>
