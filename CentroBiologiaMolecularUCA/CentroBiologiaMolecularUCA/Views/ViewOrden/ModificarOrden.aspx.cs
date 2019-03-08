using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Negocio;

namespace CentroBiologiaMolecularUCA.Views.ViewOrden
{
    public partial class ModificarOrden : System.Web.UI.Page
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

        public OrdenAdn Modificar()
        {
            OrdenAdn ord = new OrdenAdn();
            String valor = Request.QueryString["id"];
            int id = int.Parse(valor);
            ord.Id_orden = id;

            if (Manalisis.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Tipo_examen = Manalisis.SelectedValue;
            }
            if (Mmuestra.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Tipo_muestra = Mmuestra.SelectedValue;
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

            return ord;
        }

        protected void EditarFormulario(object sender, EventArgs e)
        {

            if (IsValid)
            {
                OrdenAdn ord = Modificar();
                //LLAMANDO A CAPA DE NEGOCIO
                bool resp = NGorden.getInstance().modificarord(ord);

                if (resp == true)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript: ModificarOrden(); ", true);

                }
                else
                {
                    Response.Write("<script>alert('REGISTRO INCORRECTO.')</script)");
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript: ADD(); ", true);
            }
        }



    }
}

