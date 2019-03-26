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

namespace CentroBiologiaMolecularUCA.Views.Vreogm
{
    public partial class Addreogm : System.Web.UI.Page
    {
        private DTresultado result;
        private TOrden tOrden;
        private DTanalisis dtanalisis;
        private DTmuestra dtmuestra;
        private SqlDataReader analisis;//Cargar tipo examen
        private SqlDataReader registro;//Data resultado

        private String[] array = new String[10];
        private int index = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.result = new DTresultado();
            this.tOrden = new TOrden();
            this.dtanalisis = new DTanalisis();
            this.dtmuestra = new DTmuestra();

            //Obtener el Id Orden
            String valor = Request.QueryString["id"];
            int id = int.Parse(valor);

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
            this.analisis = tOrden.getAnalisisporId(id);
            llenarcheckbox();

            //Registros
            registro = result.cargardatosporid(id);

            if (registro.Read())
            {
                Mcodigo.Text = registro["Id_codigo"].ToString();
                Minvestigador.Text = registro["Nombre_empleado"].ToString() + " (" + registro["Cargo"] + ")";
                Mimportador.Text = registro["Nombre"].ToString() + " " + registro["Apellido"].ToString();
                Mmuestra.SelectedValue = registro["Id_tipo_muestra"].ToString();
            }
            //Cargar Fecha y hora 
            Mfecha.Text = DateTime.Now.ToString("MM/dd/yyyy");
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


        public Resultado GetEntity()
        {
            Resultado res = new Resultado();

            if (Mobservaciones == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator2);
            }
            else
            {

            }
            if (Mresultado.SelectedValue.ToString() == "0")
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator2);
            }
            else
            {
                res.Validacion = Mresultado.SelectedValue;
            }

            return res;
        }

        public void InsertarResultado(object sender, EventArgs e)
        {

        }



    }
}