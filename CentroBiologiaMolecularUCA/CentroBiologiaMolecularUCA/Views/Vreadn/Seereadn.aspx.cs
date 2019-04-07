using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Negocio;

namespace CentroBiologiaMolecularUCA.Views.Vreadn
{
    public partial class Seereadn : System.Web.UI.Page
    {
        public Resultado res;
        //datos resultados
        private SqlDataReader usuario;
        private SqlDataReader registro;
        private SqlDataReader datos;
        private int Usuario_procesa;
        private string url = "";
        private int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.res = new Resultado();
            //Obtener el Id Orden
            String valor = Request.QueryString["id"];
            id = int.Parse(valor);

            //Registros
            registro = NGresultado.getInstance().verResultadosadn(id);
            if (registro.Read())
            {
                Mcodigo.Text = registro["Id_codigo"].ToString();

                Mcliente.Text = registro["Nombre"].ToString() + " " + registro["Apellido"].ToString();
                Mpareja.Text = registro["Nombre_pareja"].ToString();
                Mmenor.Text = registro["Nombre_menor"].ToString();
                Mtipocaso.SelectedValue = registro["Tipo_caso"].ToString();

            }

            datos = NGresultado.getInstance().resultados(id);
            if (datos.Read())
            {
                Usuario_procesa = Convert.ToInt32(datos["Usuario_procesa"].ToString());
                res.Fecha_procesamiento = Convert.ToDateTime(datos["Fecha_procesamiento"].ToString());
                res.Observaciones = datos["Observaciones"].ToString();
                if (datos["imagen"].ToString() == "")
                {
                    Image1.ImageUrl = "../../ImagesAdn/User-placeholder.jpg";
                }
                else
                {
                    Image1.ImageUrl = "../../" + datos["Imagen"].ToString();
                }
                Mhora.Text = datos["Hora"].ToString();
                Mresultado.SelectedValue = datos["Validacion"].ToString();
            }

            //Mostrar datos en el textbox
            usuario = NGresultado.getInstance().datosusuario(Usuario_procesa);
            if (usuario.Read())
            {
                Minvestigador.Text = usuario["Nombre_empleado"].ToString() + " " + usuario["Apellido"].ToString();
            }
        }
    }
}