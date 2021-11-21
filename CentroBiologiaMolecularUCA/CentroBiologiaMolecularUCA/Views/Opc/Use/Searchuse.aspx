<%@ Page Language="C#" MasterPageFile="~/configuration.Master" AutoEventWireup="true" CodeBehind="Searchuse.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.ViewUsuario.BuscarUsuario" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">      
     <form runat="server">
          <asp:ScriptManager runat="server" ID="Update">

    </asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="Update1">
        <ContentTemplate>
              
        </ContentTemplate>

    </asp:UpdatePanel>
    </form>
 
     <script src="../../../TablesJS/TableUsuario.js"></script> 


    
    
</asp:Content>