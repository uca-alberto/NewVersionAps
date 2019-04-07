using CentroBiologiaMolecularUCA.Ncapas.Datos;
using CentroBiologiaMolecularUCA.Ncapas.Negocio;
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

namespace CentroBiologiaMolecularUCA.Views.Opc.Use
{
    public partial class Upduse : System.Web.UI.Page
    {
      private SqlDataReader empleado;
        private SqlDataReader registro;
        public Usuario us;
        private SqlDataReader empleados;
        private int id_empleado;
        private String Rol;

        protected void Page_Load(object sender, EventArgs e)
        {

            this.empleado = NGEmpleado.getInstance().listarempleado();
            us = new Usuario();
            String valor = Request.QueryString["id"];
            int id = int.Parse(valor);
            us.Id_usuario = id;

            if(!IsPostBack)
            {

                Mrol.DataSource = NGUsuario.getInstance().listarRol();
                Mrol.DataTextField = "Rol";
                Mrol.DataValueField = "Id_rol";
                Mrol.DataBind();
            }

            this.registro = NGUsuario.getInstance().getUsuarioporid(id);
            Id_usuario.Value = valor;


            if (registro.Read())
            {
                us.Nombre = this.registro["Nombre_Usuario"].ToString();
                us.Id_rol = Convert.ToInt32(this.registro["Id_rol"]);
               // id_empleado = Convert.ToInt32(this.registro["Id_empleado"]);
            }
            
           /* if(!IsPostBack)
            {
                //Mostrar datos en el textbox
                this.empleados = dte.getEmpleadoporid(id_empleado);
                if (empleados.Read())
                {
                    Musuario.Text = empleados["Nombre_empleado"].ToString() + " " + empleados["Apellido"].ToString();
                    Mcedula.Text = empleados["Cedula"].ToString();
                }
            }*/

        }

        public SqlDataReader getregistros()
        {
            return this.empleado;

        }

        public Usuario modificar()
        {
            Usuario usuario = new Usuario();
            String valor = Request.QueryString["id"];
            int id = int.Parse(valor);
            usuario.Id_usuario = id;

            if (Mnombre.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);

            }
            else
            {
                usuario.Nombre = Mnombre.Text;
            }

            if (Mcontrasena.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);

            }
            else
            {
                usuario.Contrasena = Mcontrasena.Text;
            }
            if (Mrol.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);

            }
            else
            {
                Rol = Mrol.SelectedValue;
                usuario.Id_rol = Convert.ToInt32(Rol);
            }
            usuario.Id_empleado = int.Parse(Idempleado.Value.ToString());
            usuario.Activo = 1;

            return usuario;
        }

        protected void EditarFormulario(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Usuario usuario = modificar();
                bool resp = NGUsuario.getInstance().ModificarUsuario(usuario);
                if (resp == true)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript: ModificarUsuario(); ", true);
                }
                else
                {
                    Response.Redirect("Upduse.aspx" + Id_usuario.Value);
                }
            }
              else
            {
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript: ADD(); ", true);
            }
        }
    }
}