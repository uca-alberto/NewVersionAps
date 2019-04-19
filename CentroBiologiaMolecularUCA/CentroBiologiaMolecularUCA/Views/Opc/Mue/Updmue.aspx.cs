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
        private SqlDataReader registro;
        public NGmuestra nge;
        public Muestra mue;
        protected void Page_Load(object sender, EventArgs e)
        {
             mue = new Muestra();

            String valor = Request.QueryString["id"];//obtenemos el id que le pasamos a travez de la url
            int id = int.Parse(valor);//parseamos el valorm, para obtenerlo un int;
            registro = NGmuestra.getInstance().Listarmuestraporid(id);//usamos el metodo de la clase dtcliente para buscar el cliente por el id
            

            if (registro.Read())//validamos 
            {
                mue.Id_muestra = int.Parse(this.registro["Id_tipo_muestra"].ToString());
                mue.muestra = this.registro["muestra"].ToString();
             
            }
            Id_muestra.Value = valor;

        }
        public Muestra Modificar()
        {
         
            if (Mmuestra.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator2);
            }
            else
            {
                mue.muestra = Mmuestra.Text;
            }


            return mue;
        }
        public void EditarFormulario(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Muestra mues = Modificar();
                bool resp = NGmuestra.getInstance().ModificarMuestra(mues);
                if (resp == true)
                {
					ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript: Modificarmuestra(); ", true);
                }
                else
                {
                    Response.Redirect("Updexa.aspx" + Id_muestra.Value);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript: ADD(); ", true);
            }
        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Searchmue.aspx");
        }
    }
}