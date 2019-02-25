<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EliminarresultadoOgm.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.ViewResultadoMaria.EliminarresultadoOgm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <script src="../../assets/sweetalert.min.js"></script>
     <script>
         function Delete() {
            swal({
                title: "Esta Seguro?",
                text: "Eliminar resultado OGM",
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
