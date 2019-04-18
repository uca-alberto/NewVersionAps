using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CentroBiologiaMolecularUCA.Views.Rpt
{
    public partial class ResultadoOgm : System.Web.UI.Page
    {
        ReporteOrdenOGM re = new ReporteOrdenOGM();
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
		
			if(!IsPostBack)
			{
				String valor = Request.QueryString["id"];
				id = int.Parse(valor);
				re.SetParameterValue("@Id", id);
				CrystalReportViewer.ReportSource = re;

			}
            

        }

        protected void btnexportar_Click(object sender, EventArgs e)
        {
            String valor = Request.QueryString["id"];
            id = int.Parse(valor);
            re.SetParameterValue("@Id", id);

            switch (Export.SelectedValue)
            {
                case "1":
                    re.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, true, "ResultadoOGMN°:" + id);
                    break;
                case "2":
                    re.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "ResultadoOGMN°:" + id);
                    break;
                case "3":
                    re.ExportToHttpResponse(ExportFormatType.Excel, Response, true, "ResultadoOGMN°:" + id);
                    break;
                default:
                    break;
            }
        }
    }
}