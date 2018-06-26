using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;

namespace CentroBiologiaMolecularUCA.Views.ViewCliente
{
    public partial class BuscarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ViewCliente.SetActiveView(ClientesActivos);
        }
        [WebMethod]
        public static List<Cliente> GetData()
        {
            DTcliente dtp = new DTcliente();

            return dtp.GetData();
        }
        protected void TablaClientesDesactivos(object sender, EventArgs e)
        {
            ViewCliente.SetActiveView(ClientesDesactivos);

        }

        [WebMethod]
        public static IEnumerable<Cliente> GetDataDesactivados()
        {
            DTcliente dtp = new DTcliente();

            return dtp.GetDataDesactivados();
        }

        protected void TablaClienteActivos(object sender, EventArgs e)
        {
            ViewCliente.SetActiveView(ClientesActivos);

        }
        [WebMethod]
        public static bool EliminarEmp(String id)
        {
            bool resp = false;

            Cliente ep = new Cliente()
            {
                Id_Cliente = Convert.ToInt32(id)
            };
            Console.Write(ep);

            resp = DTcliente.getInstance().eliminar(ep);
            return resp;
        }

    }
}