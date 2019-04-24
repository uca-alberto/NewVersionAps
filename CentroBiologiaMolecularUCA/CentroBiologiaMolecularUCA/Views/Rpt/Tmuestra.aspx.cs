using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CentroBiologiaMolecularUCA.Views.Rpt
{
	public partial class Tmuestra : System.Web.UI.Page
	{
		ConMue con = new ConMue();
		int id;
		protected void Page_Load(object sender, EventArgs e)
		{
			String valor = Request.QueryString["id"];

		}

		protected void ConstanciaMuestra_Click(object sender, EventArgs e)
		{
		
				String valor = Request.QueryString["id"];
				id = int.Parse(valor);
				con.SetParameterValue("@id_orden", id);
				con.SetParameterValue("@Personauno", Persona1.Text);
				con.SetParameterValue("@personados", Persona2.Text);
				con.SetParameterValue("@cedulauno", Cedula1.Text);
				con.SetParameterValue("@cedulados", Cedula2.Text);

			CrystalReportViewer1.ReportSource = con;

		}
	}
}