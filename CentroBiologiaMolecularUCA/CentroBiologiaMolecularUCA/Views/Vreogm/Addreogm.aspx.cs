using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Negocio;

namespace CentroBiologiaMolecularUCA.Views.Vreogm
{
    public partial class Addreogm : System.Web.UI.Page
    {
        private SqlDataReader Tablaresultado;
        private SqlDataReader analisis;//Cargar tipo examen
        private SqlDataReader registro;//Data resultado
        private SqlDataReader usuario;
        private String[] array = new String[10];//check
        private int index = 0;
        private int id;
        private int idresultado;


        protected void Page_Load(object sender, EventArgs e)
        {
            //Obtener el Id Orden
            String valor = Request.QueryString["id"];
            id = Convert.ToInt16(valor);
            idresultado = NGresultado.getInstance().idresultado();

            //Cargar los tipos de Analisis

            Manalisis.DataSource = NGorden.getInstance().ListarAnalisisOgm();
            Manalisis.DataTextField = "analisis";
            Manalisis.DataValueField = "Id_analisis";
            Manalisis.DataBind();

            //Cargar Tipos de Muestras
            Mmuestra.DataSource = NGorden.getInstance().ListarMuestras();
            Mmuestra.DataTextField = "muestra";
            Mmuestra.DataValueField = "Id_tipo_muestra";
            Mmuestra.DataBind();
            ListItem li = new ListItem("SELECCIONE", "0");//creamos una lista, para agregar el seleccione
            Mmuestra.Items.Insert(0, li);

            //Llenar CheckBoxList
            this.analisis = NGorden.getInstance().Listarexamen(id);
            llenarcheckbox();

            //Registros
            Tablaresultado = NGresultado.getInstance().getanalisispororden(id);
            registro = NGresultado.getInstance().ListardatosResultados(id);

            if (registro.Read())
            {
                Mcodigo.Text = registro["Id_codigo"].ToString();
                Mimportador.Text = registro["Nombre"].ToString() + " " + registro["Apellido"].ToString();
                Mmuestra.SelectedValue = registro["Id_tipo_muestra"].ToString();
            }

            //Obtener el usuario actual
            String userprocesa = (string)Session["Id_usuario"];
            usuario = NGresultado.getInstance().datosusuario(Convert.ToInt32(userprocesa));
            if (usuario.Read())
            {
                Minvestigador.Text = usuario["Nombre_empleado"].ToString() + " " + usuario["Apellido"].ToString();
            }


            //Cargar Fecha y hora 
            Mfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            Mhora.Text = DateTime.Now.ToString("hh:mm");

            radiosocultos();
        }

        public void llenarcheckbox()
        {
            while (analisis.Read())
            {
                //Guardo en Arreglo los tipos de analisis segun la orden seleccionada
                array[index] = this.analisis["Id_analisis"].ToString();
                index++;
            }
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
        }
        public SqlDataReader getregistros()
        {
            return Tablaresultado;
        }


        public void radiosocultos()
        {
            if (index == 1)
            {
                radio1.Visible = true;
            }
            if (index == 2)
            {
                radio1.Visible = true;
                radio2.Visible = true;
            }
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

        public void guardardetalle()
        {
            String val1 = radio1.SelectedValue;
            String val2 = radio2.SelectedValue;

            Resultado res = new Resultado();
            if (index > 1)
            {
                res.Id_analisis = Convert.ToInt32(array[0]);
                res.Id_resultado = idresultado;
                res.Resultados = Convert.ToInt32(val1);
                NGresultado.getInstance().creardetalle(res);
            }
            if (index >= 2)
            {
                res.Id_analisis = Convert.ToInt32(array[1]);
                res.Id_resultado = idresultado;
                res.Resultados = Convert.ToInt32(val2);
                NGresultado.getInstance().creardetalle(res);
            }
        }




        public void InsertarResultado(object sender, EventArgs e)
        {
            if (IsValid)//valido que si mi formulario esta correcto
            {
                Resultado res = GetEntity();
                //LLAMANDO A CAPA DE NEGOCIO

                bool resp = NGresultado.getInstance().guardarresultado(res);

                if (resp == true)
                {
                    guardardetalle();
                    NGresultado.getInstance().procesarorden(res);
                    //Mostrar Notificacion
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript: InsertarResultado(); ", true);
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