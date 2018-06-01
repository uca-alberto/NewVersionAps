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
    public partial class EditarUsuario : System.Web.UI.Page
    {
        private DTUsuario dtusuario;
        private DTrol dtrol;
        private SqlDataReader registro;
        public Usuario us;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.dtusuario = new DTUsuario();
            us = new Usuario();
            this.dtrol = new DTrol();
            String valor = Request.QueryString["id"];
            int id = int.Parse(valor);
            us.Id_usuario = id;

            Mrol.DataSource = dtrol.listarRol();
            Mrol.DataTextField = "Rol";
            Mrol.DataValueField = "Id_rol";
            Mrol.DataBind();

            this.registro = dtusuario.getUsuarioporid(id);
            Id_usuario.Value = valor;


            if (registro.Read())
            {
                us.Nombre = this.registro["Nombre_Usuario"].ToString();
                us.Contrasena = this.registro["Contrasena"].ToString();
                us.Id_rol = Convert.ToInt32(this.registro["Id_rol"]);
            }


        }

        public Usuario modificar()
        {
            Usuario usuario = new Usuario();
            String valor = Request.QueryString["id"];
            int id = int.Parse(valor);

            if (Mnombre.ToString() != null)
            {
                usuario.Nombre = Mnombre.Text;
            }

            if (Mcontrasena.ToString() != null)
            {
                usuario.Contrasena = Mcontrasena.Text;
            }

            if (Mrol.ToString() != null)
            {
                string Rol = Mrol.SelectedValue;
                us.Id_rol = Convert.ToInt32(Rol);
            }

            return usuario;
        }

        protected void EditarFormulario(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            bool resp = NGUsuario.getInstance().ModificarUsuario(usuario);
            if (resp == true)
            {
                Response.Redirect("AgregarUsuario.aspx");
            }
            else
            {
                Response.Redirect("EditarUsuario.aspx" + Id_usuario.Value);
            }
        }
    }
}