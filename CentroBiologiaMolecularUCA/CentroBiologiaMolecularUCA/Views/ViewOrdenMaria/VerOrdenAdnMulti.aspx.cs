using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;
using System.Data.SqlClient;

namespace CentroBiologiaMolecularUCA.Views.ViewOrdenMaria
{
    public partial class VerOrdenAdnMulti : System.Web.UI.Page
    {
        private DTAdnPaternidad dtadnpaternidad;
   
        private SqlDataReader registro;
        public OrdenAdn ord;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.dtadnpaternidad = new DTAdnPaternidad();
           
            ord = new OrdenAdn();

            //Obtener id del cliente
            String valor = Request.QueryString["id"];
            int id = int.Parse(valor);
            ord.Id_orden = id;
            //Cargar el Combobox de tipo orden examen
           

            this.registro = dtadnpaternidad.getOrdenporid(id);
            Id_orden.Value = valor;

            //Comenzamos a recorer el sqldatareader
            if (registro.Read())
            {
                //seteamos los datos de los campos de ese cliente
                this.ord.Id_codigo = this.registro["Id_codigo"].ToString();
                ord.Nombre_pareja = this.registro["Nombre_pareja"].ToString();
                ord.Nombre_menor = this.registro["Nombre_menor"].ToString();
                ord.Fecha = Convert.ToDateTime(this.registro["Fecha"].ToString());
                ord.Tipo_Caso = this.registro["Tipo_caso"].ToString();
               

                ord.Observaciones = this.registro["Observaciones"].ToString();
                ord.Baucher = this.registro["Baucher"].ToString();
                
            }
        }
    }
}