using CentroBiologiaMolecularUCA.Ncapas.Datos;
using CentroBiologiaMolecularUCA.Ncapas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CentroBiologiaMolecularUCA.Views.OpcionesConfigurables.Emp
{
    public partial class Searchemp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<Empleado> GetData()
        {
            DTEmpleados dtp = new DTEmpleados();

            return dtp.GetData();
        }

        [WebMethod]
        public static bool EliminarEmp(String id)
        {
            bool resp = false;

            Empleado ep = new Empleado()
            {
                Id_Empleado = Convert.ToInt32(id)
            };
            Console.Write(ep);

            resp = DTEmpleados.getInstance().eliminar(ep);
            return resp;

        }
    }
}