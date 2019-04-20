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

namespace CentroBiologiaMolecularUCA.Views.ViewUsuario
{
    public partial class AgregarUsuario : System.Web.UI.Page
    {
        private SqlDataReader registro;
        private SqlDataReader empleado;
       
        private Conexion conexion;
        private String Rol;



        protected void Page_Load(object sender, EventArgs e)
        {
            String rolid = (string)Session["Id_rol"];
            string ubicacion = HttpContext.Current.Request.Url.AbsolutePath;

            int rol = Convert.ToInt32(rolid);

            bool permiso = false;

            if (rol == 1)
            {
                permiso = true;
            }
            else
            {
                permiso = NGUsuario.getInstance().acceso(rol, ubicacion);

            }

            //Se redirecciona si no tiene permiso
            if (permiso == false)
            {

                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript: Acceso(); ", true);
            }
            /*if(dtusuario.Sicrear() >= dtusuario.SicrearE())
                       {
                           ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript: Emleado(); ", true);

                       }*/


            this.empleado = NGUsuario.getInstance().ListarEmpleados();
            ;
            this.conexion = new Conexion();
            
            if (!IsPostBack)
            {
                //en esta parte se carga el dropdownlist
                Mrol.DataSource = NGUsuario.getInstance().listarRol();//aqui le paso mi consulta que esta en la clase dtdepartamento
                Mrol.DataTextField = "Rol";//le paso el texto del items
                Mrol.DataValueField = "Id_rol";//le paso el id de cada items
                Mrol.DataBind();

                ListItem li = new ListItem("SELECCIONE", "0");//creamos una lista, para agregar el seleccione
                Mrol.Items.Insert(0, li);
            }

        }

        public SqlDataReader getregistros()
        {
            return this.empleado;

        }



        //Extraer los datos de la vista
        public Usuario GetEntity()
        {
            Usuario us = new Usuario();
            if (Mnombre.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);

            }
            else
            {
                us.Nombre = Mnombre.Text;
            }

            if (Mcontrasena.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);

            }
            else
            {
                us.Contrasena = Mcontrasena.Text;
            }
            if (Mrol.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);

            }
            else
            {
                Rol = Mrol.SelectedValue;
                us.Id_rol = Convert.ToInt32(Rol);
            }
            us.Id_empleado = int.Parse(Idempleado.Value.ToString());
            us.Activo = 1;

            return us;
        }

        protected void InsertarUsuario(object sender, EventArgs e)
        {
            if (IsValid)
            {
                //Registro al usuario
                Usuario us = GetEntity();
                bool resp = NGUsuario.getInstance().guardarUsuario(us);
                if (resp == false)
                {
                    Response.Redirect("Searchuse.aspx");
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
    }
}