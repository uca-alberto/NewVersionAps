using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;

namespace CentroBiologiaMolecularUCA.Views.ViewOrdenMaria
{
    public partial class VerOrdenAdn : System.Web.UI.Page
    {
        private TOrdenAdn tOrden;
        private DTexamenes dtexamenes;
        private SqlDataReader registro;
        public OrdenAdn ord;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.tOrden = new TOrdenAdn();
            ord = new OrdenAdn();
            this.dtexamenes = new DTexamenes();
            String valor = Request.QueryString["id"];
            int id = int.Parse(valor);
            ord.Id_orden = id;
            Mtipoorden.DataSource = dtexamenes.listarexamenes();//aqui le paso mi consulta que esta en la clase dtdepartamento
            Mtipoorden.DataTextField = "Nombre";//le paso el texto del items
            Mtipoorden.DataValueField = "Id_examenes";//le paso el id de cada items
            Mtipoorden.DataBind();
            this.registro = tOrden.getOrdenporid(id);

            Id_orden.Value = valor;
            if (registro.Read())
            {


               // this.ord.Tipo_caso = this.registro["Tipo_caso"].ToString();
                //ord.Tipo_orden = this.registro["Id_examenes"].ToString();
                ord.Observaciones = this.registro["Observaciones"].ToString();
                ord.Baucher = this.registro["Baucher"].ToString();
                //ord.No_orden = int.Parse(this.registro["No_orden"].ToString());
                ord.Estado = this.registro["Estado"].ToString();
                this.ord.Fecha = Convert.ToDateTime(this.registro["Fecha"].ToString());


            }

        }
    }
}