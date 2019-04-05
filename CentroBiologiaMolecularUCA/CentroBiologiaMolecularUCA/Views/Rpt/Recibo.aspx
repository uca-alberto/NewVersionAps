<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Recibo.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.Rpt.Recibo" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

	<form id="form1" runat="server">

		<asp:DropDownList runat="server" ID="Export" CssClass="form-control">
			<asp:ListItem Value="0">Seleccione Archivo</asp:ListItem>
			<asp:ListItem Value="1">Word</asp:ListItem>
			<asp:ListItem Value="2">PDF</asp:ListItem>
			<asp:ListItem Value="3">Excel</asp:ListItem>
		</asp:DropDownList>
		<asp:Button runat="server" CssClass="btn btn-outline-success btn-lg btn-block" ID="Exportar" Text="Exportar Documento" OnClick="Exportar_Click"  />

		<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True" ToolPanelWidth="0px" HasPrintButton="False" HasExportButton="False" />


	</form>

</asp:Content>
