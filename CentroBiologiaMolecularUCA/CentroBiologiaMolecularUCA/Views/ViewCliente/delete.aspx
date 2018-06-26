<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="delete.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.ViewCliente.delete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <script src="../../assets/sweetalert.min.js"></script>
     <script>
         function Delete() {
            swal({
                title: "Esta Seguro?",
                text: "Eliminar Cliente",
                icon: "warning",
                buttons: true,
                dangerMode: true,
            })
          .then((willDelete) => {
           if (willDelete) {
            swal("Se Elimino Correctamente", {
                icon: "success",
                
            }); 
        } else {
        swal("Your imaginary file is safe!");
         }
         });
        }
    </script>
</asp:Content>
