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
            this.registro = this.dtusuario.listarTodo();
            this.conexion = new Conexion();
            this.dtrol = new DTrol();
            //en esta parte se carga el dropdownlist
            Mrol.DataSource = dtrol.listarRol();//aqui le paso mi consulta que esta en la clase dtdepartamento
            Mrol.DataTextField = "Rol";//le paso el texto del items
            Mrol.DataValueField = "Id_rol";//le paso el id de cada items
            Mrol.DataBind();


        }

        public SqlDataReader getregistros()
        {
            return this.registro;
        }

        //Extraer los datos de la vista
        public Usuario GetEntity()
        {
            Usuario us = new Usuario();
            if (Mnombre.ToString() != null)
            {
                us.Nombre = Mnombre.Text;
            }
            else
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            if (Mcontrasena.ToString() != null)
            {
                us.Contrasena = Mcontrasena.Text;
            }
            else
            {
                RegularExpressionValidator.GetValidationProperty(RegularExpressionValidator1);
            }
            if (Mrol.ToString() != null)
            {

                Rol = Mrol.SelectedValue;
                us.Id_rol = Convert.ToInt32(Rol);
            }
            else
            {
                RegularExpressionValidator.GetValidationProperty(RegularExpressionValidator1);
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
                    Response.Redirect("AgregarUsuario.aspx");
                }
                else
                {
                    Response.Write("<script>alert('REGISTRO INCORRECTO.')</script)");
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "none", "confirm('Error, Formulario llenado de forma incorrecta');", true);
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);//sino esta validado me mostrara los campos a corregir y no mandara datos.
            }

        }
    }
}