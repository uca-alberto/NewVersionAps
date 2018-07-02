using System;
using System.Data.SqlClient;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;

namespace CentroBiologiaMolecularUCA.Views.ViewResultadoMaria
{
    public partial class VerResultadoOgm : System.Web.UI.Page
    {
        private DTresultado dtresultado;
        private SqlDataReader registro;
        public Resultado re;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.dtresultado = new DTresultado();
            re = new Resultado();
            String valor = Request.QueryString["id"];
            int id = int.Parse(valor);
            re.Id_resultado = id;
            this.registro = dtresultado.getresultadoporid(id);

            //Id_orden.Value = valor; que onda con eso? revisa maria esa parte

            if (registro.Read())
            {

                this.re.Fecha_procesamiento = Convert.ToDateTime(this.registro["Fecha"].ToString());
                re.Validacion = this.registro["Validacion"].ToString();
                re.Parametros = this.registro["Resultado"].ToString();
                re.Estado = this.registro["Estado"].ToString();
                re.Usuario_procesa = this.registro["Usuario_procesa"].ToString();
                re.Usuario_valida = this.registro["Usuario_valida"].ToString();

                this.re.Analisis = this.registro["Analisis"].ToString();

            }

        }
    }
}