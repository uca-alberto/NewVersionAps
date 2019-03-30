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

namespace CentroBiologiaMolecularUCA.Views.OpcionesConfigurables
{
    public partial class AgregarExamenes : System.Web.UI.Page
    {
     

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public Examen GetEntity()
        {
            Examen exam = new Examen();

            if (Mnombre.ToString() == null)//todo esto se hace para todos los campos del formulario
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                exam.nombre = Mnombre.Text;
            }

            if (Mprecio.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                exam.precio_examen = int.Parse(Mprecio.Text);
            }

            return exam;
        }

        protected void InsertarExamen(object sender, EventArgs e)
        {

            if (IsValid)//valido que si mi formulario esta correcto
            {
                //Registro del examen
                Examen exa = GetEntity();
                //LLAMANDO A CAPA DE NEGOCIO
                bool resp = NGExamen.getInstance().guardarexamen(exa);

                if (resp == true)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript: Insertarexa(); ", true);
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