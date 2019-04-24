<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tmuestra.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.Rpt.Tmuestra" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="card">
		<div class="card-header">
			<strong>CONSTANCIA DE TOMA DE MUESTRA</strong>
			<form runat="server">
				<div class="">
					<label>SR.</label>
					<asp:TextBox runat="server" ToolTip="Señor" ID="Persona1" CssClass="form-control"></asp:TextBox>
				</div>

				<div class="">
					<label>CEDULA.</label>
					<asp:TextBox runat="server" ToolTip="Señor" ID="Cedula1" CssClass="form-control"></asp:TextBox>
				</div>

				<div class="">
					<label>SRA.</label>
					<asp:TextBox runat="server" ToolTip="Señor" ID="Persona2" CssClass="form-control"></asp:TextBox>
				</div>

				<div class="">
					<label>CEDULA.</label>
					<asp:TextBox runat="server" ToolTip="Señor" ID="Cedula2" CssClass="form-control"></asp:TextBox>
				</div>
				<div>
					<br />
					<asp:Button runat="server" ID="ConstanciaMuestra" OnClick="ConstanciaMuestra_Click" Text="Generar Reporte" CssClass="btn btn-outline-success btn-lg btn-block" data-toggle="modal" data-target="#mediumModal" />
				</div>
				<br />
				<br />
				
			<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True" ToolPanelWidth="0px" HasPrintButton="False" HasExportButton="False" />
				</form>
		</div>
	</div>

	    

</asp:Content>
