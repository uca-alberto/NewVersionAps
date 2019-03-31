using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Negocio;

namespace CentroBiologiaMolecularUCA.Views.Vreogm
{
    public partial class Addreogm : System.Web.UI.Page
    {
        private DTresultado result;
        private TOrden tOrden;
        private DTanalisis dtanalisis;
        private DTmuestra dtmuestra;
        private SqlDataReader tablaresultado;
        private SqlDataReader analisis;//Cargar tipo examen
        private SqlDataReader registro;//Data resultado

        private String[] array = new String[10];
        private int index = 0;
        private int id;

        private string usuario_valida;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.result = new DTresultado();
            this.tOrden = new TOrden();
            this.dtanalisis = new DTanalisis();
            this.dtmuestra = new DTmuestra();

            //Obtener el Id Orden
            String valor = Request.QueryString["id"];
            id = int.Parse(valor);

            //Cargar los tipos de Analisis

            Manalisis.DataSource = NGorden.getInstance().ListarAnalisis();
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
            this.analisis = NGorden.getInstance().Listarexamenes(id);
            llenarcheckbox();

            //data para la tabla de resultados
            tablaresultado = NGresultado.getInstance().Resultadostabla(id);

            //Registros
            registro = NGresultado.getInstance().ListardatosResultados(id);

            if (registro.Read())
            {
                Mcodigo.Text = registro["Id_codigo"].ToString();
                Minvestigador.Text = registro["Nombre_empleado"].ToString() + " (" + registro["Cargo"] + ")";
                Mimportador.Text = registro["Nombre"].ToString() + " " + registro["Apellido"].ToString();
                Mmuestra.SelectedValue = registro["Id_tipo_muestra"].ToString();

                //Usuario que valida
                usuario_valida = registro["Id_usuario"].ToString();
            }
            //Cargar Fecha y hora 
            Mfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            Mhora.Text = DateTime.Now.ToString("hh:mm");

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
        //cargar datos en la tabla 
        public SqlDataReader getregistros()
        {
            return tablaresultado;
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
            res.Usuario_valida = usuario_valida;
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
                //LLAMANDO A CAPA DE NEGOCIO
                bool resp = NGresultado.getInstance().guardarresultado(res);

                if (resp == true)
                {
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