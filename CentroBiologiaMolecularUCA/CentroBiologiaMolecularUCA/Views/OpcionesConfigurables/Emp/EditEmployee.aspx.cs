using CentroBiologiaMolecularUCA.Ncapas.Datos;
using CentroBiologiaMolecularUCA.Ncapas.Entidades;
using CentroBiologiaMolecularUCA.Ncapas.Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CentroBiologiaMolecularUCA.Views.OpcionesConfigurables.Emp
{
    public partial class EditEmployee : System.Web.UI.Page
    {
        private DTEmpleados temp;
        private SqlDataReader registro;
        public Empleado emp;

        protected void Page_Load(object sender, EventArgs e)
        {
            //creamos los objetos de la biblioteca de datos;
            this.temp = new DTEmpleados();
            emp = new Empleado();
            String valor = Request.QueryString["id"]; //obtenemos el id que le pasamos a travez de la url
            int id = int.Parse(valor); //parseamos el valorm, para obtenerlo un int;
            emp.Id_Empleado = id; //le asignamos ese id a la propiedad Id_empleado;
            this.registro = temp.getEmpleadoporid(id); //usamos el metodo de la clase dtemp para buscar el cliente por el id
            Id_Emp.Value = valor; //le pasamos el valor del id a este hidden por si de un error, no perder el id y volver a cargar la pagina con esos datos;

            if (registro.Read()) //validamos 
            {

                this.emp.Cargo = this.registro["Cargo"].ToString();
                this.emp.Cedula = this.registro["cedula"].ToString();
                this.emp.Nombre_Empleado = this.registro["Nombre_empleado"].ToString();
                this.emp.Apellido = this.registro["Apellido"].ToString();
                //le seteamos los valores que obtenemos del empleado;

            }


        }

        public Empleado Modificar()
        {
            Empleado emp = new Empleado();
            String valor = Request.QueryString["id"];
            int id = int.Parse(valor);
            emp.Id_Empleado = id;

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


            //  ord.Tipo_caso = Mtipocaso.SelectedValue;
            //ord.Tipo_orden = Mtipoorden.SelectedValue;
            //ord.Observaciones = Mobservaciones.Text;
            // ord.Baucher = Mbaucher.Text;
            // ord.No_orden = int.Parse(Mnoorden.Text);
            // ord.Estado = Mestado.SelectedValue;

            return emp;
        }


        public void EditarFormulario(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Empleado emp = Modificar();
                bool resp = NGEmpleado.getInstance().Modificarempleado(emp);
                if (resp == true)
                {
                    Response.Redirect("SearchEmpleado.aspx");
                }
                else
                {
                    Response.Redirect("EditEmployee.aspx" + Id_Emp.Value);
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