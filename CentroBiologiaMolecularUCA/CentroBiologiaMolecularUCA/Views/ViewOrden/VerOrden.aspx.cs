using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;

namespace CentroBiologiaMolecularUCA.Views.ViewOrden
{
    public partial class VerOrden : System.Web.UI.Page
    {
        private TOrden tOrden;
        private DTanalisis dtanalisis;
        private DTmuestra dtmuestra;
        private SqlDataReader registro;
        public OrdenAdn ord;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.tOrden = new TOrden();
            ord = new OrdenAdn();
            this.dtanalisis = new DTanalisis();
            this.dtmuestra = new DTmuestra();

            String valor = Request.QueryString["id"];
            int id = int.Parse(valor);
            ord.Id_orden = id;

            //Cargar los tipos de Analisis

            Manalisis.DataSource = dtanalisis.listaranalisis();
            Manalisis.DataTextField = "analisis";
            Manalisis.DataValueField = "Id_analisis";
            Manalisis.DataBind();


            //Cargar Tipos de Muestras
            Mmuestra.DataSource = dtmuestra.listarmuestras();
            Mmuestra.DataTextField = "muestra";
            Mmuestra.DataValueField = "Id_tipo_muestra";
            Mmuestra.DataBind();

            this.registro = tOrden.getOrdenporid(id);
            Id_orden.Value = valor;

            if (registro.Read())
            {

                ord.Id_codigo = this.registro["Id_codigo"].ToString();
                ord.Fecha = Convert.ToDateTime(this.registro["Fecha"].ToString());
                ord.Tipo_examen = this.registro["Id_examenes"].ToString();
                ord.Tipo_muestra = this.registro["Id_tipo_muestra"].ToString();
                ord.Observaciones = this.registro["Observaciones"].ToString();
                ord.Baucher = this.registro["Baucher"].ToString();
                ord.Estado = this.registro["Estado"].ToString();
            }
        }
    }
}