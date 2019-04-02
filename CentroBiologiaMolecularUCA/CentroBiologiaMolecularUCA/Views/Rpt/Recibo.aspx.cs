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
			int id = int.Parse(valor);
			ReciboOrden re = new ReciboOrden();
			re.SetParameterValue("@id", id);
			CrystalReportViewer1.ReportSource =re;

		}
	}
}