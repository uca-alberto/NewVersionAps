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
using System.Data.SqlClient;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Negocio;

namespace CentroBiologiaMolecularUCA.Views.ViewCliente
{
    public partial class BuscarCliente : System.Web.UI.Page
    {
        private SqlDataReader registro;
        private DTUsuario dtusuario;
        protected void Page_Load(object sender, EventArgs e)
        {
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

        }
        [WebMethod]
        public static List<Cliente> GetData()
        {
			NGcliente ng = new NGcliente();

            return ng.Data();
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

            resp = NGcliente.getInstance().Eliminarcliente(ep);  
            return resp;
         
        }
    }
}