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
        private SqlDataReader analisis;
        public OrdenAdn ord;
        private String[] array = new String[10];
        private int index = 0;


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

            //Llenar CheckBoxList
            this.analisis = tOrden.getAnalisisporId(id);

            while (analisis.Read())
            {
                //Guardo en Arreglo los tipos de analisis segun la orden seleccionada
                array[index] = this.analisis["Id_analisis"].ToString();
                index++;
            }
            analisis.Close();
            //Recorro la cantidad de Items y comparo los id del areglo con los del checkbox si son iguales me checkea
            for (int i = 0; i < Manalisis.Items.Count; i++)
            {
                int idcheck = i + 0;
                for (int x = 0; x < array.Length; x++)
                {
                    if (array[x] == Manalisis.Items[idcheck].Value)
                    {
                        Manalisis.Items[i].Selected = true;
                    }
                }
            }

            if (registro.Read())
            {

                ord.Id_codigo = this.registro["Id_codigo"].ToString();
                ord.Fecha = Convert.ToDateTime(this.registro["Fecha"].ToString());
                ord.Tipo_muestra = this.registro["Id_tipo_muestra"].ToString();
                ord.Observaciones = this.registro["Observaciones"].ToString();
                ord.Baucher = this.registro["Baucher"].ToString();
                ord.Estado = this.registro["Estado"].ToString();
            }
        }
    }
}