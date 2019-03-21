using CentroBiologiaMolecularUCA.Ncapas.Entidades;
using CentroBiologiaMolecularUCA.Ncapas.Negocio;
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

namespace CentroBiologiaMolecularUCA.Views.Opc.Mue
{
    public partial class Updmue : System.Web.UI.Page
    {

        private DTmuestra dtmuestra;
        private SqlDataReader registro;
        public Muestra exam;
        public NGmuestra nge;
        protected void Page_Load(object sender, EventArgs e)
        {
            dtmuestra = new DTmuestra();
            exam = new Muestra();

            String valor = Request.QueryString["id"];//obtenemos el id que le pasamos a travez de la url
            int id = int.Parse(valor);//parseamos el valorm, para obtenerlo un int;
            this.registro = dtmuestra.getmuestraporid(id);//usamos el metodo de la clase dtcliente para buscar el cliente por el id


            if (registro.Read())//validamos 
            {
                exam.Id_muestra = int.Parse(this.registro["Id_tipo_muestra"].ToString());
                exam.muestra = this.registro["muestra"].ToString();

            }
            Id_cliente.Value = valor;

        }
        public Muestra Modificar()
        {

            if (Mnombre.ToString() == null)
            {
                BorderStyle.Solid.ToString();
            }
            else
            {
                exam.muestra = Mnombre.Text;
            }

            return exam;
        }
        public void EditarFormulario(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Muestra mues = Modificar();
                bool resp = NGmuestra.getInstance().ModificarMuestra(mues);
                if (resp == true)
                {
                    Response.Redirect("Searchmue.aspx");
                }
                else
                {
                    Response.Redirect("Updexa.aspx" + Id_cliente.Value);
                }
            }
            else
            {
               // RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator3);
            }
        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuscarExamenes.aspx");
        }
    }
}