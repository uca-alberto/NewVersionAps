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
        private DTUsuario dtusuario;
        private SqlDataReader registro;
        private Conexion conexion;
        private String Rol;
        private DTrol dtrol;


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

             if (rolid == "1")
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



             if(permiso == false)
             {
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript: Acceso(); ", true);
            }
            

            this.dtusuario = new DTUsuario();
            this.registro = this.dtusuario.listarTodo();
            this.conexion = new Conexion();
            this.dtrol = new DTrol();

            if (!IsPostBack)
            {
                //en esta parte se carga el dropdownlist
                Mrol.DataSource = dtrol.listarRol();//aqui le paso mi consulta que esta en la clase dtdepartamento
                Mrol.DataTextField = "Rol";//le paso el texto del items
                Mrol.DataValueField = "Id_rol";//le paso el id de cada items
                Mrol.DataBind();
            }

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