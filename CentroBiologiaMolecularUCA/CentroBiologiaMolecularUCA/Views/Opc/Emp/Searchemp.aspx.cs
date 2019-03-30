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

namespace CentroBiologiaMolecularUCA.Views.OpcionesConfigurables.Emp
{
    public partial class Searchemp : System.Web.UI.Page
    {
        private DTUsuario dtusuario;
        private SqlDataReader registro;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Metodo de Permisos
            this.dtusuario = new DTUsuario();
            String rolid = (string)Session["Id_rol"];
            string ubicacion = HttpContext.Current.Request.Url.AbsolutePath;

            int rol = Convert.ToInt32(rolid);

            this.registro = dtusuario.acceso(rol);
            bool permiso = false;
            String[] array = new String[10];
            int index = 0;

            //Si es admin Tiene acceso directo
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


            //Valida si lo tiene
            if (permiso == false)
            {
                Response.Redirect("../../Views/OpcionesConfigurables/Index.aspx");
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