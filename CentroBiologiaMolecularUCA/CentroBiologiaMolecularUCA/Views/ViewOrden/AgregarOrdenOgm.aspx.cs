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
    public partial class AgregarOrdenOgm : System.Web.UI.Page
    {
        private TOrdenAdn tOrden;
        private DTexamenes dtexamenes;
        private DTmuestra dtmuestra;
        private SqlDataReader registro;
        private Conexion conexion;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.tOrden = new TOrdenAdn();
            this.dtexamenes = new DTexamenes();
            this.dtmuestra = new DTmuestra();
            this.conexion = new Conexion();
            this.registro = this.tOrden.listarTodo();

            if (!IsPostBack)
            {
                //en esta parte se carga el dropdownlist de Examen

                Mexamen.DataSource = dtexamenes.listarexamenes();//aqui le paso mi consulta que esta en la clase dtexamenes
                Mexamen.DataTextField = "Nombre";//le paso el texto del items
                Mexamen.DataValueField = "Id_examenes";//le paso el id de cada items
                Mexamen.DataBind();

                ListItem li = new ListItem("SELECCIONE", "0");//creamos una lista, para agregar el seleccione
                Mexamen.Items.Insert(0, li);//agregamos el seleccione en la posicion uno

                //en esta parte se carga el dropdownlist de Muestra
                Mmuestr.DataSource= dtmuestra.listarmuestras();
                Mmuestr.DataTextField = "muestra";
                Mmuestr.DataValueField = "Id_tipo_muestra";
                Mmuestr.DataBind();
            }
        }
     
        public SqlDataReader getregistros()
        {
            return this.registro;
            
        }

        public OrdenAdn GetEntity()
        {
            OrdenAdn ord = new OrdenAdn();

            if (Mexamen.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Tipo_caso = Mexamen.SelectedValue;
            }
            if (Mmuestr.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Tipo_orden = Mmuestr.SelectedValue;
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
                ord.Fecha = Convert.ToDateTime(Mfecha.Text);
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
                    Response.Redirect("/Views/ViewOrdenMaria/BuscarOrdenAdn.aspx");
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
        //COMBO BOX EXAMEN
        protected void Mexamen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Mexamen.SelectedIndex == 0)
            {

            }
            else
            {
            }
        }
        //COMBO BOX MUESTRA
        protected void Mmuestra_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Mmuestr.SelectedIndex == 0)
            {

            }
            else
            {
            }
        }
        
    }
}