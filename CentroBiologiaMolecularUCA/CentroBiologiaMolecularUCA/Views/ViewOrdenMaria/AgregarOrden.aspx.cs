using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Negocio;

namespace CentroBiologiaMolecularUCA.Views.ViewOrdenMaria
{
    public partial class AgregarOrden : System.Web.UI.Page
    {
        private TOrdenAdn tOrden;
        private DTexamenes dtexamenes;
        private SqlDataReader registro;
        private Conexion conexion;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.tOrden = new TOrdenAdn();
            this.dtexamenes = new DTexamenes();
            this.conexion = new Conexion();
            this.registro = this.tOrden.listarTodo();


            if (!IsPostBack)
            {
                //en esta parte se carga el dropdownlist
                Mtipoorden.DataSource = dtexamenes.listarexamenes();//aqui le paso mi consulta que esta en la clase dtdepartamento
                Mtipoorden.DataTextField = "Nombre";//le paso el texto del items
                Mtipoorden.DataValueField = "Id_examenes";//le paso el id de cada items
                Mtipoorden.DataBind();

                ListItem li = new ListItem("SELECCIONE", "0");//creamos una lista, para agregar el seleccione
                Mtipoorden.Items.Insert(0, li);//agregamis el seleccione en la posicion uno

            }
        }

        public SqlDataReader getregistros()
        {
            return this.registro;
        }

        public OrdenAdn GetEntity()
        {
            OrdenAdn ord = new OrdenAdn();

            if (Mtipocaso.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Tipo_caso = Mtipocaso.SelectedValue;
            }
            if (Mtipoorden.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Tipo_orden = Mtipoorden.SelectedValue;
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
            if (Mnoorden.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.No_orden = int.Parse(Mnoorden.Text);
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
                ord.Fecha = Mfecha.Text;
            }


            return ord;

        }

        protected void InsertarOrden(object sender, EventArgs e)
        {
            if (IsValid)//valido que si mi formulario esta correcto
            {
                OrdenAdn ord = GetEntity();
                //LLAMANDO A CAPA DE NEGOCIO
                bool resp = NOrdenAdn.getInstance().guardarord(ord);
                if (resp == true)
                {
                    Response.Redirect("BuscarOrdenAdn.aspx");
                }
                else
                {
                    Response.Write("<script>alert('REGISTRO INCORRECTO.')</script)");
                }
            }
            else
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);//sino esta validado me mostrara los campos a corregir y no mandara datos.
            }
        }

        protected void Mtipoorden_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Mtipoorden.SelectedIndex == 0)
            {

            }
            else
            {
            }
        }
    }
}