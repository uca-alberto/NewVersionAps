using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Negocio;

namespace CentroBiologiaMolecularUCA.Views.ViewOrdenMaria
{
    public partial class ModificarOrden : System.Web.UI.Page
    {
        private TOrdenAdn tordenadn;
        private DTexamenes dtexamenes;
        private SqlDataReader registro;
        public OrdenAdn ord;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.tordenadn = new TOrdenAdn();
            ord = new OrdenAdn();
            this.dtexamenes = new DTexamenes();
            String valor = Request.QueryString["id"];
            int id = int.Parse(valor);
            ord.Id_orden = id;
            Mtipoorden.DataSource = dtexamenes.listarexamenes();//aqui le paso mi consulta que esta en la clase dtdepartamento
            Mtipoorden.DataTextField = "Nombre";//le paso el texto del items
            Mtipoorden.DataValueField = "Id_examenes";//le paso el id de cada items
            Mtipoorden.DataBind();
            this.registro = tordenadn.getOrdenporid(id);
            Id_orden.Value = valor;
            if (registro.Read())
            {


               // this.ord.Tipo_caso = this.registro["Tipo_caso"].ToString();
               // ord.Tipo_orden = this.registro["Id_examenes"].ToString();
                ord.Observaciones = this.registro["Observaciones"].ToString();
                ord.Baucher = this.registro["Baucher"].ToString();
               // ord.No_orden = int.Parse(this.registro["No_orden"].ToString());
                ord.Estado = this.registro["Estado"].ToString();
                this.ord.Fecha = Convert.ToDateTime(this.registro["Fecha"].ToString());
            }
        }

        public OrdenAdn Modificar()
        {
            OrdenAdn ord = new OrdenAdn();
            String valor = Request.QueryString["id"];
            int id = int.Parse(valor);
            ord.Id_orden = id;

            if (Mtipocaso.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                //ord.Tipo_caso = Mtipocaso.SelectedValue;
            }
            if (Mtipoorden.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                //ord.Tipo_orden = Mtipoorden.SelectedValue;
            }
            if (Mobservaciones.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Observaciones = Mobservaciones.Text;
            }
            if (Mbaucher.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Baucher = Mbaucher.Text;
            }
            if (Mnoorden.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                //ord.No_orden = int.Parse(Mnoorden.Text);
            }
            if (Mestado.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Estado = Mestado.SelectedValue;
            }
            if (Mfecha.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Fecha = Convert.ToDateTime(Mfecha.Text);
            }

            //  ord.Tipo_caso = Mtipocaso.SelectedValue;
            //ord.Tipo_orden = Mtipoorden.SelectedValue;
            //ord.Observaciones = Mobservaciones.Text;
            // ord.Baucher = Mbaucher.Text;
            // ord.No_orden = int.Parse(Mnoorden.Text);
            // ord.Estado = Mestado.SelectedValue;

            return ord;
        }

        public void EditarFormulario(object sender, EventArgs e)
        {
            if (IsValid)
            {
                OrdenAdn ord = Modificar();
                bool resp = NOrdenAdn.getInstance().modificarord(ord);
                if (resp == true)
                {
                    Response.Redirect("AgregarOrden.aspx");
                }
                else
                {
                    Response.Redirect("ModificarOrden.aspx" + Id_orden.Value);
                }
            }
            else
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }


        }
    }
}