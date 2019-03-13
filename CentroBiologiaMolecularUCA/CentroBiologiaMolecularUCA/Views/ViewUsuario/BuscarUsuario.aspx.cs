using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;

namespace CentroBiologiaMolecularUCA.Views.ViewUsuario
{
    public partial class BuscarUsuario : System.Web.UI.Page
    {

        private DTUsuario dtusuario;
        private SqlDataReader registro;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.dtusuario = new DTUsuario();
            this.registro = this.dtusuario.listarTodo();
            String rolid = (string)Session["Id_rol"];
            string ubicacion = "../../Views/ViewUsuario/AgregarUsuario.aspx";

            int rol = Convert.ToInt32(rolid);

            this.registro = dtusuario.acceso(rol);
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
                Response.Redirect("../../Views/OpcionesConfigurables/Index.aspx");
            }

        }
        public SqlDataReader getregistros()
        {
            return this.registro;
        }
    }
}