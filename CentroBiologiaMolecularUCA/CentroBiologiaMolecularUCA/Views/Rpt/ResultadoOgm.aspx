<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResultadoOgm.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.Rpt.ResultadoOgm" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
        <asp:Label Text="Exportar Documento" runat="server"></asp:Label>&nbsp;
        
        <asp:DropDownList runat="server" ID="Export" CssClass="form-control">
			<asp:ListItem Value="0">Seleccione Archivo</asp:ListItem>
			<asp:ListItem Value="1">Word</asp:ListItem>
			<asp:ListItem Value="2">PDF</asp:ListItem>
			<asp:ListItem Value="3">Excel</asp:ListItem>
		</asp:DropDownList>
                 
        <asp:Button ID="btnexportar" text="Guardar Archivo" runat="server" CssClass="btn btn-info" OnClick="btnexportar_Click"/>     
  
           <CR:CrystalReportViewer ID="CrystalReportViewer" runat="server" AutoDataBind="True" ToolPanelWidth="0px" HasPrintButton="False" HasExportButton="False" />
   </form>
</asp:Content>
