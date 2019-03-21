<%@ Page Title="" Language="C#" MasterPageFile="~/configuration.Master" AutoEventWireup="true" CodeBehind="AgregarUsuario.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.ViewUsuario.AgregarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">      

 
      <script src="../../assets/sweetalert.min.js"></script>
          
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
        function InsertarUsuario(data) {
            swal({
                title: "Usuario Agregado",
                text: "Correctamente",
                icon: "success",
            })
          .then((willDelete) => {
              if (willDelete) {
                  location.href = "../../Views/ViewUsuario/BuscarUsuario.aspx";
              } 
          });
        }
    </script>
<!-------- Alerta de permisos ------>
     <script>
        function Acceso(data) {
            swal({
                title: "Usted no tiene acceso",
                text: "restricted access",
                icon: "error",
                
            })
          .then((willDelete) => {
              if (willDelete) {
                  location.href = "../../Views/ViewLogin/Index.aspx";
              } 
          });
        }
    </script>
                   
 <!--script de alerta-->
                    <div class="card-header">
                        <i class="mr-2 fa fa-align-justify"></i>
                        <strong class="card-title" v-if="headerText">Crear</strong>
                    </div>
                    
               
  
                            
                                <!--Aqui Comienza el formulario dentro del modal-->                                
                     <div class="card">
                      <div class="card-body card-block">
                        <form action="" method="post" enctype="multipart/form-data" class="form-horizontal" runat="server">

                            
                            <!--Comienzo de los formulario-->
                              <!--nombre-->
                          <div class="row form-group">
                            <div class="col col-md-3"><label for="text-input" class=" form-control-label">Nombre de Usuario</label></div>
                            <div class="col-12 col-md-9">
                                 <asp:TextBox ID="Mnombre" runat="server" Text="" ToolTip="Nombre de usuario" CssClass="form-control" ValidateRequestMode="Enabled"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Mnombre" Display="Dynamic" ErrorMessage="Este Campo es requerido" BorderColor="#FF5050" BorderStyle="None" CssClass="form_hint" ForeColor="Red"></asp:RequiredFieldValidator>
                               </div>
                          </div>
                           
                            <!--Contraseña-->
                          <div class="row form-group">
                            <div class="col col-md-3"><label for="email-input" class=" form-control-label">Contraseña</label></div>
                            <div class="col-12 col-md-9">
                                 <asp:TextBox ID="Mcontrasena" runat="server" TextMode="Password" ToolTip="Contraseña" CssClass="form-control" ValidateRequestMode="Enabled"></asp:TextBox>                                              
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ControlToValidate="Mcontrasena" Display="Dynamic" ErrorMessage="Contraseña Incorrecta" BorderColor="#FF5050" BorderStyle="None" CssClass="form_hint" ForeColor="Red"></asp:RequiredFieldValidator>
                                
                            </div>
                          </div>
                         
                           
                            <!--Seleccion de Rol-->
                          <div class="row form-group">
                            <div class="col col-md-3"><label for="select" class=" form-control-label">Rol</label></div>
                            <div class="col-12 col-md-9">
                              <asp:DropDownList ID="Mrol" runat="server" ToolTip="Rol del usuario" CssClass="form-control">
                               
                              </asp:DropDownList>
                            </div>
                          </div>
                         <div class="modal-footer">
                          <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                              <asp:HiddenField runat="server" ID="id_usuario" />
                              <asp:Button id="Aceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary" OnClick="InsertarUsuario"/>
                          </div>
                            
                        </form>
                      </div>
                    </div>
                            <!--Botones del Modal-->                               
              
                            
                        
    <script type="text/javascript" src="../../Content/listausuario.js"></script>
</asp:Content>

