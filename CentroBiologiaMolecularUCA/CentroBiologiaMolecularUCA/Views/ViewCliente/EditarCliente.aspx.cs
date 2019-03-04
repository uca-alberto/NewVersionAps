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

namespace CentroBiologiaMolecularUCA.Views.ViewCliente
{
    public partial class EditarCliente : System.Web.UI.Page
    {
        private DTcliente dtcliente;
        private DTdepartamento dtdepartamento;
        private DTmunicipio dtmunicipio;
        private SqlDataReader registro;
        public Cliente cli;

        protected void Page_Load(object sender, EventArgs e)
        {
            //creamos los objetos de la biblioteca de datos;
            this.dtcliente = new DTcliente();
            dtdepartamento = new DTdepartamento();
            this.dtmunicipio = new DTmunicipio();
            cli = new Cliente();

            String valor = Request.QueryString["id"];//obtenemos el id que le pasamos a travez de la url
            int id = int.Parse(valor);//parseamos el valorm, para obtenerlo un int;
            cli.Id_Cliente = id;//le asignamos ese id a la propiedad id_cliente;
            this.registro = dtcliente.getClienteporid(id);//usamos el metodo de la clase dtcliente para buscar el cliente por el id

            if (!IsPostBack)
            {
                //en esta parte se carga el dropdownlist
                Mdepartamento.DataSource = dtdepartamento.listardepartamento();//aqui le paso mi consulta que esta en la clase dtdepartamento                                                                   
                Mdepartamento.DataBind();

                Mmunicipio.DataSource = dtmunicipio.listarmunicipio();
                Mmunicipio.DataBind();

                ListItem li = new ListItem("SELECCIONE", "0");//creamos una lista, para agregar el seleccione
                Mdepartamento.Items.Insert(0, li);//agregamis el seleccione en la posicion uno
                Mmunicipio.Items.Insert(0, li);
                Mmunicipio.Enabled = false;
            }

            Id_cliente.Value = valor;//le pasamos el valor del id a este hidden por si de un error, no perder el id y volver a cargar la pagina con esos datos;
            if (registro.Read())//validamos 
            {
                this.cli.Nombres = this.registro["Nombre"].ToString();
                cli.Apellidos = this.registro["Apellido"].ToString();
                cli.Cedula = this.registro["Cedula"].ToString();
                cli.Departamento = this.registro["Id_Departamento"].ToString();
                cli.Municipio = this.registro["Id_Municipio"].ToString();
                cli.Dirreccion = this.registro["Direccion"].ToString();
                cli.Sexo = this.registro["sexo"].ToString();
                cli.Telefono = int.Parse(this.registro["Num_Telefono"].ToString());
                this.cli.Correo = this.registro["Email"].ToString();
                //le seteamos los valores que obtenemos del cliente;

            }

        }

        public Cliente Modificar()
        {
          
            if (Mnombre.ToString() == null)
            {
                BorderStyle.Solid.ToString();
            }
            else
            {
                cli.Nombres = Mnombre.Text;
            }
            if (Mapellido.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                cli.Apellidos = Mapellido.Text;
            }
            if (Mcedula.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                cli.Cedula = Mcedula.Text;
            }
            if (Mdepartamento.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                cli.Departamento = Mdepartamento.SelectedValue;
            }
            if (Mmunicipio.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                cli.Municipio = Mmunicipio.SelectedValue;
            }
            if (Msexo.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                cli.Sexo = Msexo.SelectedValue;
            }
            if (Mtelefono.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                cli.Telefono = int.Parse(Mtelefono.Text);
            }
            if (Mcorreo.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                cli.Correo = Mcorreo.Text;
            }
            if (Mdireccion.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                cli.Dirreccion = Mdireccion.Text;
            }

            return cli;
        }

        protected void EditarFormulario(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Cliente cli = Modificar();
                bool resp = NGcliente.getInstance().Modificarcliente(cli);
                if (resp == true)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript: ModificarCliente(); ", true);
                }
                else
                {
                    Response.Redirect("EditarCliente.aspx?id=" + Id_cliente.Value);
                }

            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript: ADD(); ", true);
            }
        }

        protected void Mdepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Mdepartamento.SelectedIndex == 0)
            {

            }
            else
            {
                Mmunicipio.Enabled = true;
                Mmunicipio.DataSource = dtmunicipio.getmunicipioporid(int.Parse(Mdepartamento.SelectedValue));
                // Mmunicipio.DataTextField = "Municipio";
                // Mmunicipio.DataValueField = "Id_Municipio";
                Mmunicipio.DataBind();
                //tienes que resolver, el problema que recarga la pagina y se sale del formulario, resolverlo
                //tratar de hacerlo con jqury https://www.youtube.com/watch?v=P_-zxQYPy5w Ese es eñ video
            }
        }

        protected void cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../ViewLogin/Index.aspx");
        }
    }
}