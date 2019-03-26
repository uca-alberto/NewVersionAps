using System;
using System.Collections.Generic;
using System.Data;
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
    public partial class AgregarOrdenOgm : System.Web.UI.Page
    {
        private TOrden tOrden;
        private DTanalisis dtanalisis;
        private DTmuestra dtmuestra;
        private SqlDataReader registro;
        private Conexion conexion;
        private int Id;

        //Para cargar la Tabla
        private DTcliente tcliente;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.tOrden = new TOrden();
            this.tcliente = new DTcliente();
            this.dtanalisis = new DTanalisis();
            this.dtmuestra = new DTmuestra();
            this.conexion = new Conexion();
            this.registro = this.tcliente.listarCliente();

            //Generar el codigo
            Mcodigo.Text = tOrden.generarCodigo();
            //Obtengo el Id
            Id = tOrden.ultimoid();

            if (!IsPostBack)
            {
                //en esta parte se carga el dropdownlist de Examen

                Manalisis.DataSource = NGorden.getInstance().ListarAnalisis();//aqui le paso mi consulta que esta en la clase dtexamenes
                Manalisis.DataTextField = "analisis";//le paso el texto del items
                Manalisis.DataValueField = "Id_analisis";//le paso el id de cada items
                Manalisis.DataBind();

                //en esta parte se carga el dropdownlist de Muestra
                Mmuestra.DataSource = NGorden.getInstance().ListarMuestras();
                Mmuestra.DataTextField = "muestra";
                Mmuestra.DataValueField = "Id_tipo_muestra";
                Mmuestra.DataBind();
                ListItem li = new ListItem("SELECCIONE", "0");//creamos una lista, para agregar el seleccione
                Mmuestra.Items.Insert(0, li);

            }
        }

        public SqlDataReader getregistros()
        {
            return this.registro;

        }

        public OrdenAdn GetEntity()
        {
            OrdenAdn ord = new OrdenAdn();

            if (Manalisis.ToString()==null )
            {
            }
            else
            {
                ord.Tipo_examen = Manalisis.SelectedValue;
            }
            if (Mmuestra.SelectedValue.ToString() == "0")
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
            if (Mcodigo.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Id_codigo = Mcodigo.Text;
            }
            if (Mestado.SelectedValue.ToString() == "0")
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
           // int id1 =Convert.ToInt32( Id_cliente.ToString());
            String userid = (string)Session["Id_usuario"];
            ord.id_cliente = int.Parse(Id_cliente.Value.ToString());
            ord.Id_usuario = userid;
            ord.Id_orden = Id;
           // System.Diagnostics.Debug.WriteLine(ord.Id_cliente);
            return ord;
        }

        protected void InsertarOrden(object sender, EventArgs e)
        {

            if (IsValid)//valido que si mi formulario esta correcto
            {
                OrdenAdn ord = GetEntity();
                //LLAMANDO A CAPA DE NEGOCIO
                bool resp = NGorden.getInstance().guardarord(ord);

                if (resp == true)
                {
                    //Recorro el CheckboxList y mando a guardar los que esten Checkeados(seleccionados)
                    //A la tabla Orden Detalle

                    for (int i = 0; i < Manalisis.Items.Count; i++)
                    {
                        if (Manalisis.Items[i].Selected)
                        {
                            ord.Id_analisis = Manalisis.Items[i].Value; ;
                            bool respu = NGorden.getInstance().guardardetalle(ord);
                        }
                    }
                    //Mostrar Notificacion
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript: InsertarOrden(); ", true);
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
        //COMBO BOX EXAMEN
        protected void Manalisis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Manalisis.SelectedIndex == 0)
            {

            }
            else
            {
            }
        }
        //COMBO BOX MUESTRA
        protected void Mmuestra_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Mmuestra.SelectedIndex == 0)
            {

            }
            else
            {
            }
        }

    }
}