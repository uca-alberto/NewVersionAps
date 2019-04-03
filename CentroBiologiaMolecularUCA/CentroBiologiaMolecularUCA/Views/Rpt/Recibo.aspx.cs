using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CentroBiologiaMolecularUCA.Views.Rpt
{
	public partial class Recibo : System.Web.UI.Page
	{
		ReciboOrden re = new ReciboOrden();
		int id;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				Cargar();
			}
		}
		protected void Cargar()
		{
			String valor = Request.QueryString["id"];
		    id = int.Parse(valor);
			re.SetParameterValue("@id", id);
			CrystalReportViewer1.ReportSource =re;
		}

		protected void Exportar_Click(object sender, EventArgs e)
		{
			String valor = Request.QueryString["id"];
			id = int.Parse(valor);
			re.SetParameterValue("@id", id);
			re.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, true, "NombreArchivo");
		}
	}
}