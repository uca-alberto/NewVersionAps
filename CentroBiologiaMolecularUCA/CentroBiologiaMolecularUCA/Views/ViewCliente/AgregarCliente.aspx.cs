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
    public partial class AgregarCliente : System.Web.UI.Page
    {

        private SqlDataReader registro;
        private DTUsuario dtusuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.dtusuario = new DTUsuario();
            String rolid = (string)Session["Id_rol"];
            string ubicacion = HttpContext.Current.Request.Url.AbsolutePath;

            int rol = Convert.ToInt32(rolid);

            this.registro = dtusuario.acceso(rol);
            bool permiso = false;
            String[] array = new String[10];
            int index = 0;

            //Si es admin tiene acceso
            if (rol == 1)
            {
                permiso = true;
            }
            else
            {
                //guardar los datos que se extraen de la BD
                while (registro.Read())
                {
                    array[index] = registro["opciones"].ToString();
                    index++;

                }

                for (int i = 0; i < array.Length; i++)
                {

                    if (array[i] == ubicacion)
                    {
                        permiso = true;
                        break;
                    }


                }
            }


            //Se redirecciona si no tiene permiso
            if (permiso == false)
            {
                Response.Redirect("../../Views/ViewLogin/Index.aspx");
            }

            Mcedula.MaxLength = 16;
            if (!IsPostBack)
            {
                //en esta parte se carga el dropdownlist
                Mdepartamento.DataSource = NGcliente.getInstance().ListarDepartamento();//aqui le paso mi consulta que esta en la clase dtdepartamento
                Mdepartamento.DataBind();

                ListItem li = new ListItem("SELECCIONE", "0");//creamos una lista, para agregar el seleccione
                Mdepartamento.Items.Insert(0,li);
                Mmunicipio.Items.Insert(0, li);
                Mmunicipio.Enabled = false;
            }
        }

        public Cliente GetEntity()
        {
            Cliente cli = new Cliente();
            // cli.Id_Cliente = int.Parse(id_cliente.ToString());
            if (Mnombre.ToString() == null)//valido los campos que no sean nulos
            {
                Mnombre.BorderColor = System.Drawing.Color.Red;//si son nulos, me tirara un error de validacion
            }
            else
            {
                cli.Nombres = Mnombre.Text;//si son validos, me dejara enviar los datos a la base de datoa
            }
            if (Mapellido.ToString() == null)//todo esto se hace para todos los campos del formulario
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
            if (int.Parse(Msexo.SelectedValue) == 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript: ADD(); ", true);
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

        protected void InsertarCliente(object sender, EventArgs e)
        {

            if (IsValid)//valido que si mi formulario esta correcto
            {
                //Registro del Empleado
                Cliente cli = GetEntity();
                //LLAMANDO A CAPA DE NEGOCIO
                bool resp = NGcliente.getInstance().guardarcliente(cli);
               
                if (resp == true)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript: InsertarCliente(); ", true);
                    //Response.Redirect("BuscarCliente.aspx");

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

        protected void Mdepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Mdepartamento.SelectedIndex == 0)
            {

            }
            else
            {
                Mmunicipio.Enabled = true;
                Mmunicipio.DataSource = NGcliente.getInstance().ListarMunicipioPorId(int.Parse(Mdepartamento.SelectedValue));
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