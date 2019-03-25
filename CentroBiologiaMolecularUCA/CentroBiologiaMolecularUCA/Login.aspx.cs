using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;

namespace CentroBiologiaMolecularUCA.Views.ViewLogin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Session.Abandon();
            }

        }
        protected void Iniciar_Sesion(object sender, EventArgs e)
        {
            string usuario = "a", contrasena = "b";
            //se declara una variable string para que reemplace los -- y ; y así evitar SQlInyection
            if (Mnombre.ToString() != null)
            {
                usuario = this.Mnombre.Text.Replace(";", "").Replace("--", "");
            }
            else
            {
                Response.Redirect("~/");
                //RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript: Required(); ", true);

            }
            if (Mcontrasena.ToString() != null)
            {
                contrasena = this.Mcontrasena.Text.Replace(";", "").Replace("--", "");
            }
            else
            {
                Response.Redirect("~/");
                //RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript: Required(); ", true);

            }

            //Se manda a llamar el metodo de autenticacion
            if (DTlogin.getInstance().Autenticar(usuario, contrasena) == true)
            {
                //Se verifica en la BD el Id_usuario
                DataTable tblUsuario = DTlogin.getInstance().prConsultaUsuario(usuario, contrasena);
                Session["Id_usuario"] = tblUsuario.Rows[0]["Id_usuario"].ToString();
                Session["Id_rol"] = tblUsuario.Rows[0]["Id_rol"].ToString();
                Session["Activo"] = tblUsuario.Rows[0]["Activo"].ToString();
                Response.Redirect("~/Views/Index");
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript: ADD(); ", true);
            }

        }
    }
}