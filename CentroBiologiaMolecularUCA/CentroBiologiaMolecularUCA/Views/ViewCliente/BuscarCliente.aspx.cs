using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;
using Microsoft.AspNet.SignalR;

namespace CentroBiologiaMolecularUCA.Views.ViewCliente
{
    public partial class BuscarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        [WebMethod]
        public static List<Cliente> GetData()
        {
            DTcliente dtp = new DTcliente();

            return dtp.GetData();
        }

        [WebMethod]
        public static bool EliminarCli(String id)
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