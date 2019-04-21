using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Negocio;

namespace CentroBiologiaMolecularUCA.Views.Vrevph
{
    public partial class Seerevph : System.Web.UI.Page
    {
        private SqlDataReader registros;
        private SqlDataReader tabla;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Obtener el Id Orden
            String valor = Request.QueryString["id"];
            int id = Convert.ToInt16(valor);

            registros = NGresultado.getInstance().verrevph(id);
            tabla = NGresultado.getInstance().Tablavph(id);
            if (registros.Read())
            {
                Mcodigo.Text = registros["Id_codigo"].ToString();
                Minvestigador.Text = registros["Investigador"].ToString();
                Mfecham.Text = registros["fecha_muestra"].ToString();
                Mhora.Text = registros["Hora"].ToString();
                Mfecha.Text = registros["Fecha_procesamiento"].ToString();
                Mcliente.Text = registros["Nombre_Cliente"].ToString();
                Mcedula.Text= registros["Cedula"].ToString();
                Mobservaciones.Text = registros["Observaciones"].ToString();
            }
        }
        //cargar datos en la tabla 
        public SqlDataReader getregistros()
        {
            return tabla;
        }
    }
}