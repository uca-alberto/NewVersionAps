using CentroBiologiaMolecularUCA.Ncapas.Entidades;
using CentroBiologiaMolecularUCA.Ncapas.Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CentroBiologiaMolecularUCA.Views.Opc
{
    public partial class Searchmue : System.Web.UI.Page
    {
        private SqlDataReader registros;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            registros= NGmuestra.getInstance().ListarMuestra();

        }
        public SqlDataReader getregistros()
        {
            //aqui se enlistan los examenes
            return registros;
        }
        public Muestra GetEntity()
        {
            Muestra muestra = new Muestra();

            if (Mmuestra.ToString() == null)//todo esto se hace para todos los campos del formulario
            {
               
            }
            else
            {
                muestra.muestra = Mmuestra.Text;
            }

            return muestra;
        }

        protected void Aceptar_Click(object sender, EventArgs e)
        {
            if (IsValid)//valido que si mi formulario esta correcto
            {
                //Registro del examen
                Muestra mue = GetEntity();
                //LLAMANDO A CAPA DE NEGOCIO
                bool resp = NGmuestra.getInstance().guardarMuestra(mue);

                if (resp == true)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript: InsertarExamen(); ", true);
                    Response.Redirect("Searchmue.aspx");

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