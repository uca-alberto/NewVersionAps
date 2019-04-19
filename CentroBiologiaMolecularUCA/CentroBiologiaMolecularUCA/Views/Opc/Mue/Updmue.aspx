<%@ Page Title="" Language="C#" MasterPageFile="~/configuration.Master" AutoEventWireup="true" CodeBehind="Updmue.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.Opc.Mue.Updmue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
            function ADD() {
            swal({
                title: "Error",
                text: "Revisar Formulario",
                icon: "warning",
                button: "OK",
            });
    }
    </script>
   
     <script>
         function Modificarmuestra(data) {
            swal({
                title: "Muestra Modificada",
                text: "Correctamente",
                icon: "success",
               // buttons: true,
                //dangerMode: true,
            })
          .then((willDelete) => {
              if (willDelete) {
              	location.href="Searchmue.aspx";
              } 
          });
        }
    </script>
          <div class="card-header">
            <strong class="card-title" v-if="headerText">Modificar Muestra</strong>
        </div>
                  <div class="card">
                      <div class="card-body card-block">
                        <form method="post" enctype="multipart/form-data" class="form-horizontal" runat="server">
                              <!--nombre-->
                          <div class="row form-group">
                            <div class="col col-md-3"><label for="text-input" class=" form-control-label">Muestra</label></div>
                            <div class="col-12 col-md-9">
                                 <asp:TextBox ID="Mmuestra" runat="server" Text="" ToolTip="Muestra" CssClass="form-control" required="required"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Mmuestra" Display="Dynamic" ErrorMessage="Este Campo es requerido" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="Mmuestra" ErrorMessage="Datos Incorrectos" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]*$" ForeColor="#FF3300"></asp:RegularExpressionValidator>              
                            </div>
                          </div>
                         <div class="modal-footer">
                              <asp:Button id="Cancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="Cancelar_Click"/>
                              <asp:HiddenField runat="server" ID="Id_muestra" />
                              <asp:Button id="Aceptar" runat="server" Text="Moficicar" CssClass="btn btn-primary" OnClick="EditarFormulario"/>
                          </div>
                            
                        </form>
                      </div>
                    </div>
	<script src="../../../Content/Generic.js"></script>
    <script  type="text/javascript">
        window.onload = function () {
        	editMuestra('<%=mue.muestra%>')
        };
    </script>
</asp:Content>
