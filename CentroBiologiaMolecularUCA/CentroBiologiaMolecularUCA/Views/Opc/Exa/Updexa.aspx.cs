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
    public partial class EditarExamenes : System.Web.UI.Page
    {
        private DTexamenes dtexamenes;
        private SqlDataReader registro;
        public Examen exam;
        public NGExamen nge;

        protected void Page_Load(object sender, EventArgs e)
        {
            dtexamenes = new DTexamenes();
            exam = new Examen();

            String valor = Request.QueryString["id"];//obtenemos el id que le pasamos a travez de la url
            int id = int.Parse(valor);//parseamos el valorm, para obtenerlo un int;
            this.registro = dtexamenes.getExamenporid(id);//usamos el metodo de la clase dtcliente para buscar el cliente por el id


            if (registro.Read())//validamos 
            {
                exam.Id_examenes = int.Parse(this.registro["Id_Examenes"].ToString());
                this.exam.Nombre = this.registro["Nombre"].ToString();
                exam.Precio_examen = int.Parse(this.registro["Precio_Examen"].ToString());
                //le seteamos los valores que obtenemos del cliente;

            }


        }

        public Examen Modificar()
        {


            if (Mnombre.ToString() == null)
            {
                BorderStyle.Solid.ToString();
            }
            else
            {
                exam.Nombre = Mnombre.Text;
            }
            if (Mprecio.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator3);
            }
            else
            {
                exam.Precio_examen = int.Parse(Mprecio.Text);

            }

            return exam;
        }
        public void EditarFormulario(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Examen exa = Modificar();
                bool resp = NGExamen.getInstance().Modificarexamen(exa);
                if (resp == true)
                {
                    Response.Redirect("Searchexa.aspx");
                }
                else
                {
                    Response.Redirect("Updexa.aspx" + Id_cliente.Value);
                }
            }
            else
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator3);
            }
        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuscarExamenes.aspx");
        }


    }


}