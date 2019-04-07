using CentroBiologiaMolecularUCA.Ncapas.Datos;
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

namespace CentroBiologiaMolecularUCA.Views.Vreadn
{
    public partial class addreadn : System.Web.UI.Page
    {
 
        private SqlDataReader registro;//Data resultado
        // Datos del empleado
        private SqlDataReader usuario;
        private String url = "";
        //
        private int id;
        private int usuario_procesa;

        protected void Page_Load(object sender, EventArgs e)
        {
            String userid = (string)Session["Id_usuario"];
            usuario_procesa = Convert.ToInt32(userid);
          
            //Obtener el Id Orden
            String valor = Request.QueryString["id"];
            id = int.Parse(valor);


            //Registros
            registro = NGresultado.getInstance().ListardatosResultadosadn(id);
            if (registro.Read())
            {
                Mcodigo.Text = registro["Id_codigo"].ToString();

                Mcliente.Text = registro["Nombre"].ToString() + " " + registro["Apellido"].ToString();
                Mpareja.Text = registro["Nombre_pareja"].ToString();
                Mmenor.Text = registro["Nombre_menor"].ToString();
                Mtipocaso.SelectedValue = registro["Tipo_caso"].ToString();

            }


            //Mostrar datos en el textbox
            usuario = NGresultado.getInstance().datosusuario(usuario_procesa);
            if (usuario.Read())
            {
                Minvestigador.Text = usuario["Nombre_empleado"].ToString() + " " + usuario["Apellido"].ToString();
            }



            //Cargar Fecha y hora 
            Mfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            Mhora.Text = DateTime.Now.ToString("hh:mm");

        }

        public Resultado GetEntity()
        {
            Resultado res = new Resultado();

            if (Mobservaciones == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator2);
            }
            else
            {
                res.Observaciones = Mobservaciones.Text;
            }
            if (Mresultado.SelectedValue.ToString() == "0")
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator2);
            }
            else
            {
                res.Validacion = Mresultado.SelectedValue;
            }
            res.Id_orden = id;
            res.Fecha_procesamiento = Convert.ToDateTime(Mfecha.Text);
            res.Hora = Convert.ToDateTime(Mhora.Text);
            //Obtener el usuario actual
            String userprocesa = (string)Session["Id_usuario"];
            res.Usuario_procesa = userprocesa;
            //estado para mientras
            res.Estado = "Procesada";
            return res;
        }

        public void InsertarResultado(object sender, EventArgs e)
        {
            if (IsValid)//valido que si mi formulario esta correcto
            {
                Resultado res = GetEntity();
                bool resp;
                if (FileUpload1.HasFile)
                {

                    string extension = System.IO.Path.GetExtension(FileUpload1.FileName);

                    if (extension == ".jpg" || extension == ".png")
                    {
                        if (FileUpload1.PostedFile.ContentLength > 30000000)
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript: Advertenciaimg(); ", true);


                        }
                        else
                        {
                            string path = Server.MapPath("../../ImagesAdn\\");
                            Urlimagen.Text = path;
                            FileUpload1.SaveAs(path + res.Id_orden + extension);
                            //guardar en bd 
                            url = "ImagesAdn\\" + res.Id_orden + extension;
                            res.Imagen = url;
                            resp = NGresultado.getInstance().guardaradnresultado(res);

                            if (resp == true)
                            {
                                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript: InsertarCliente(); ", true);
                            }
                        }

                    }
                    else
                        Urlimagen.Text = "Imagen no corresponde a un formato correcto";
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript: ADD(); ", true);

                }
                else
                {
                    url = "ImagesAdn/User-placeholder.jpg";
                    res.Imagen = url;

                    bool resp1 = NGresultado.getInstance().guardaradnresultado(res);

                    if (resp1 == true)
                    {
                        ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript: InsertarCliente(); ", true);
                    }
                }



            }
        }
    }
}