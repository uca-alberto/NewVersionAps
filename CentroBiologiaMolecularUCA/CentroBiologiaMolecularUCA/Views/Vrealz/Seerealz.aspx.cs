using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Negocio;

namespace CentroBiologiaMolecularUCA.Views.Vrealz
{
    public partial class Seerealz : System.Web.UI.Page
    {
        private SqlDataReader registros;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Obtener el Id Orden
            String valor = Request.QueryString["id"];
            int id = Convert.ToInt16(valor);

            registros = NGresultado.getInstance().veralzhaimer(id);
            if (registros.Read())
            {
                Mcodigo.Text = registros["Id_codigo"].ToString();
                Minvestigador.Text = registros["Investigador"].ToString();
                Mfecha.Text= registros["fecha_muestra"].ToString();
                Mhora.Text= registros["Hora"].ToString();
                Mfechare.Text= registros["Fecha_procesamiento"].ToString();
                Mcliente.Text = registros["Nombre_Cliente"].ToString();
                Mobservaciones.Text= registros["Observaciones"].ToString();
                Mparametros.Text = registros["Nombre"].ToString();
            }

        }
    }
}