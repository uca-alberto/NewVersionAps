<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Recibo.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.Rpt.Recibo" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

	<form id="form1" runat="server">
		<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True" ToolPanelWidth="0px" HasPrintButton="False" HasExportButton="False" />

		<asp:Button runat="server" CssClass="border-success" ID="Exportar" Text="Expordar Documento" OnClick="Exportar_Click"  />

	</form>

</asp:Content>
