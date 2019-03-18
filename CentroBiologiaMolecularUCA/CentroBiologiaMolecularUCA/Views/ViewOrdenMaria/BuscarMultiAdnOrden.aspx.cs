using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;
using System.Web.Services;
using Microsoft.AspNet.SignalR;

namespace CentroBiologiaMolecularUCA.Views.ViewOrdenMaria
{
    public partial class BuscarMultiAdnOrden : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static List<OrdenAdn> GetData()
        {
            DTAdnPaternidad dtp = new DTAdnPaternidad();

            return dtp.GetData();
        }

        [WebMethod]
        public static bool Eliminarord(String id)
        {
            bool resp = false;

            OrdenAdn ep = new OrdenAdn()
            {
                Id_orden = Convert.ToInt32(id)
            };
            Console.Write(ep);

            resp = DTAdnPaternidad.getInstance().eliminar(ep);
            return resp;

        }
    }
}