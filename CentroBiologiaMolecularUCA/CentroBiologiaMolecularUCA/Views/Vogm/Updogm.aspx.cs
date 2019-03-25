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
        private SqlDataReader analisis;
        public OrdenAdn ord;
        private String[] array = new String[10];
        private int index = 0;

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

            //Llenar CheckBoxList
            this.analisis = tOrden.getAnalisisporId(id);

            while (analisis.Read())
            {
                array[index] = this.analisis["Id_analisis"].ToString();
                index++;
            }
            analisis.Close();

            //Recorro la cantidad de Items y comparo los id del areglo con los del checkbox si son iguales me checkea
            for (int i = 0; i < Manalisis.Items.Count; i++)
            {
                int idcheck = i + 0;
                for (int x = 0; x < array.Length; x++)
                {
                    if (array[x] == Manalisis.Items[idcheck].Value)
                    {
                        Manalisis.Items[i].Selected = true;
                    }
                }
            }

            if (registro.Read())
            {
                ord.Id_codigo = this.registro["Id_codigo"].ToString();
                ord.Fecha = Convert.ToDateTime(this.registro["Fecha"].ToString());
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
                    /*
                                      //Eliminar Orden detalle que no esten checkeadas
                                      for (int i = 0; i < Manalisis.Items.Count; i++)
                                      {
                                          if (Manalisis.Items[i].Selected == false)
                                          {
                                              ord.Id_analisis = Manalisis.Items[i].Value;
                                              bool res = NGorden.getInstance().eliminardetalle(ord);
                                          }

                                      }

                                      //Modificar Registro
                                      for (int i = 0; i < Manalisis.Items.Count; i++)
                                      {
                                          int idcheck = i + 0;
                                          for (int x = 0; x < array.Length; x++)
                                          {
                                              if (array[x] == Manalisis.Items[idcheck].Value)
                                              {
                                                  ord.Id_analisis = Manalisis.Items[idcheck].Value;
                                                  bool respu = NGorden.getInstance().modificardetalle(ord);
                                              }
                                          }
                                      }*/
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

