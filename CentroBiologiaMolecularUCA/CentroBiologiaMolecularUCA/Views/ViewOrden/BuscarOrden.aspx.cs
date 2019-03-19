using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;

namespace CentroBiologiaMolecularUCA.Views.ViewOrden
{
    public partial class BuscarOrden : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static List<OrdenAdn> GetData()
        {
            TOrden dtp = new TOrden();

            return dtp.GetData();
        }

        [WebMethod]
        public static bool EliminarOrd(String id)
        {
            bool resp = false;

            OrdenAdn ord = new OrdenAdn
            {
                Id_orden = Convert.ToInt32(id)
            };
            Console.Write(ord);

            resp = TOrden.getInstance().eliminar(ord);
            return resp;
        }
    }
}