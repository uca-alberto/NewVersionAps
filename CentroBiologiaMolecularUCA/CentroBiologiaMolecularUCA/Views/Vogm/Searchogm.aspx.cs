using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Negocio;

namespace CentroBiologiaMolecularUCA.Views.Vogm
{
    public partial class Searchogm : System.Web.UI.Page
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
                Response.Redirect("../../Views/Index.aspx");
            }
        }
        [WebMethod]
        public static List<OrdenAdn> GetData()
        {
            return NGorden.getInstance().getData(); 
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

            resp = NGorden.getInstance().eliminarord(ord);
            return resp;
        }
    }
}