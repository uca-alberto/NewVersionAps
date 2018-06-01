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

namespace CentroBiologiaMolecularUCA.Views.ViewResultadoMaria
{
    public partial class ModificarResultadoOgm : System.Web.UI.Page
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
            Id_resultado.Value = valor;

            if (registro.Read())
            {
                this.re.Fecha_procesamiento = this.registro["Fecha_procesamiento"].ToString();
                re.Validacion = this.registro["Validacion"].ToString();
                re.Parametros = this.registro["Resultado"].ToString();
                re.Estado = this.registro["Estado"].ToString();
                re.Usuario_procesa = this.registro["Usuario_procesa"].ToString();
                re.Usuario_valida = this.registro["Usuario_valida"].ToString();

                this.re.Analisis = this.registro["Analisis"].ToString();

            }

        }

        public Resultado Modificar()
        {


            Resultado re = new Resultado();
            String valor = Request.QueryString["id"];
            int id = int.Parse(valor);
            re.Id_resultado = id;
            if (Mfecha.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                re.Fecha_procesamiento = Mfecha.Text;
            }
            if (Mvalidacion.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                re.Validacion = Mvalidacion.SelectedValue;
            }
            if (Mresultado.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                re.Parametros = Mresultado.SelectedValue;
            }
            if (Mestado.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                re.Estado = Mestado.SelectedValue;
            }
            if (Musuarioprocesa.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                re.Usuario_procesa = Musuarioprocesa.Text;
            }
            if (Musuariovalida.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                re.Usuario_valida = Musuariovalida.Text;
            }
            if (Manalisis.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                re.Analisis = Manalisis.Text;
            }
            return re;
        }


        protected void EditarFormulario(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Resultado re = Modificar();
                bool resp = NGresultado.getInstance().Modificarresultado(re);
                if (resp == true)
                {
                    Response.Redirect("AgregarResultadoOgm.aspx");
                }
                else
                {
                    Response.Redirect("ModificarResultadoOgm.aspx" + Id_resultado.Value);
                }

            }
            else
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }



        }
    }
}