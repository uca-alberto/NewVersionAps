using CentroBiologiaMolecularUCA.Ncapas.Entidades;
using CentroBiologiaMolecularUCA.Ncapas.Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;

namespace CentroBiologiaMolecularUCA.Views.Opc
{
    public partial class Searchmue : System.Web.UI.Page
    {
        private SqlDataReader registros;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                Danalisis.DataSource = NGmuestra.getInstance().Listaranalisis();
                Danalisis.DataBind();
                

            }


        }
        [WebMethod]
        public static List<Muestra> GetData()
        {
            return NGmuestra.getInstance().ListarMuestra();   
        }
        public Muestra GetEntity()
        {
            Muestra muestra = new Muestra();

            if (Mmuestra.ToString() == null)//todo esto se hace para todos los campos del formulario
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator2);
            }
            else
            {
                muestra.muestra = Mmuestra.Text;
            }
            if (Danalisis.ToString() == null)//todo esto se hace para todos los campos del formulario
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator2);
            }
            else
            {
                muestra.Id_tipo_analisis = int.Parse(Danalisis.SelectedValue);
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
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript: Insertarmuestra(); ", true);
            

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
        [WebMethod]
        public static bool Eliminarmue(String id)
        {
            bool resp = false;
            string data ="";
            Muestra ep = new Muestra()
            {
                Id_muestra = Convert.ToInt32(id),
                
            };

            data = ep.Id_muestra.ToString();
            Console.Write(data);

            resp = DTmuestra.getInstance().eliminar(ep);
            return resp;

        }



    }
}