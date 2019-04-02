<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Recibo.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.Rpt.Recibo" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<form id="form1" runat="server">
	<div class="col col-sm-3">
		<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True" />
	</div>

<%--		<CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
		
		</CR:CrystalReportSource>--%>
	</form>

</asp:Content>
