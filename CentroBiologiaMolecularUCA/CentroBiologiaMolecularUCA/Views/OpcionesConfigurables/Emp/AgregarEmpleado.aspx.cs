using CentroBiologiaMolecularUCA.Ncapas.Datos;
using CentroBiologiaMolecularUCA.Ncapas.Entidades;
using CentroBiologiaMolecularUCA.Ncapas.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CentroBiologiaMolecularUCA.Views.OpcionesConfigurables.Emp
{
    public partial class AgregarEmpleado : System.Web.UI.Page
    {
        private DTEmpleados dtempleado;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.dtempleado = new DTEmpleados();
            Mcedula.MaxLength = 16;

        }



        public Empleado GetEntity()
        {
            Empleado emp = new Empleado();

            if (Mnombre.ToString() == null)//valido los campos que no sean nulos
            {
                Mnombre.BorderColor = System.Drawing.Color.Red;//si son nulos, me tirara un error de validacion
            }
            else
            {
                emp.Nombre_Empleado = Mnombre.Text;//si son validos, me dejara enviar los datos a la base de datoa
            }
            if (Mapellido.ToString() == null)//todo esto se hace para todos los campos del formulario
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                emp.Apellido = Mapellido.Text;
            }
            if (Mcedula.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                emp.Cedula = Mcedula.Text;
            }
            if (Mcargo.ToString() == null)//todo esto se hace para todos los campos del formulario
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                emp.Cargo = Mcargo.Text;
            }



            return emp;
        }

        protected void InsertarEmpleado(object sender, EventArgs e)
        {

            if (IsValid)//valido que si mi formulario esta correcto
            {
                //Registro del Empleado
                Empleado emp = GetEntity();
                //LLAMANDO A CAPA DE NEGOCIO
                bool resp = NGEmpleado.getInstance().guardarempleado(emp);

                if (resp == true)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript: InsertarEmpleado(); ", true);
                    //Response.Redirect("BuscarCliente.aspx");

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

        protected void cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../ViewLogin/Index.aspx");
        }
    }
}