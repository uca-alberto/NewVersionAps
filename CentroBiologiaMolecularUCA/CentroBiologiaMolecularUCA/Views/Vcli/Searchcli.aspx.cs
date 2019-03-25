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

namespace CentroBiologiaMolecularUCA.Views.ViewCliente
{
    public partial class BuscarCliente : System.Web.UI.Page
    {
        private SqlDataReader registro;
        private DTUsuario dtusuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.dtusuario = new DTUsuario();
            String rolid = (string)Session["Id_rol"];
            string ubicacion = HttpContext.Current.Request.Url.AbsolutePath;

            int rol = Convert.ToInt32(rolid);

            this.registro = dtusuario.acceso(rol);
            bool permiso = false;
            String[] array = new String[10];
            int index = 0;

            //Si es admin tiene acceso
            if (rol == 1)
            {
                permiso = true;
            }
            else
            {
                //guardar los datos que se extraen de la BD
                while (registro.Read())
                {
                    array[index] = registro["opciones"].ToString();
                    index++;

                }

                for (int i = 0; i < array.Length; i++)
                {

                    if (array[i] == ubicacion)
                    {
                        permiso = true;
                        break;
                    }


                }
            }


            //Se redirecciona si no tiene permiso
            if (permiso == false)
            {
                Response.Redirect("../../Views/ViewLogin/Index.aspx");
            }
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