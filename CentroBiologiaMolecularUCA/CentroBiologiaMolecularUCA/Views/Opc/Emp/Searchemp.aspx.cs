using CentroBiologiaMolecularUCA.Ncapas.Datos;
using CentroBiologiaMolecularUCA.Ncapas.Entidades;
using CentroBiologiaMolecularUCA.Ncapas.Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Negocio;

namespace CentroBiologiaMolecularUCA.Views.OpcionesConfigurables.Emp
{
    public partial class Searchemp : System.Web.UI.Page
    {
        private DTUsuario dtusuario;
        private SqlDataReader registro;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Metodo de Permisos
            String rolid = (string)Session["Id_rol"];
            string ubicacion = HttpContext.Current.Request.Url.AbsolutePath;

            int rol = Convert.ToInt32(rolid);

            bool permiso = false;

            if (rol == 1)
            {
                permiso = true;
            }
            else
            {
                permiso = NGUsuario.getInstance().acceso(rol, ubicacion);

            }

            //Se redirecciona si no tiene permiso
            if (permiso == false)
            {

                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript: Acceso(); ", true);
            }

            //Fin del metodo
        }

        [WebMethod]
        public static List<Empleado> GetData()
        {
            NGEmpleado dtp = new NGEmpleado();

            return dtp.Data();
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

            resp = NGEmpleado.getInstance().Eliminarempleado(ep);
            return resp;

        }
    }
}