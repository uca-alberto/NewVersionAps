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

namespace CentroBiologiaMolecularUCA.Views.ViewUsuario
{
    public partial class BuscarUsuario : System.Web.UI.Page
    {

        private SqlDataReader registro;
        protected void Page_Load(object sender, EventArgs e)
        {
            String rolid = (string)Session["Id_rol"];
            string ubicacion = HttpContext.Current.Request.Url.AbsolutePath;

            int rol = Convert.ToInt32(rolid);

            this.registro = NGUsuario.getInstance().acceso(rol);
            bool permiso = false;
            String[] array = new String[10];
            int index = 0;

            if (rolid == "1")
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



            if (permiso == false)
            {
                Response.Redirect("../../Views/Opc/Index.aspx");
            }

        }
        [WebMethod]
        public static List<Usuario> GetData()
        {
            DTUsuario dtu = new DTUsuario();

            return dtu.GetData();
        }

        [WebMethod]
        public static bool EliminarUs(String id)
        {
            bool resp = false;

            Usuario us = new Usuario
            {
                Id_usuario = Convert.ToInt32(id)
            };
            Console.Write(us);

            resp = DTUsuario.getInstance().eliminar(us);
            return resp;
        }
    }
}
