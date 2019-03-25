using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;

namespace CentroBiologiaMolecularUCA.Views.ViewUsuario
{
    public partial class VerUsuario : System.Web.UI.Page
    {
        private DTUsuario dtusuario;
        private DTrol dtrol;
        public Usuario us;
        private SqlDataReader registro;
        private SqlDataReader rol;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.dtusuario = new DTUsuario();
            us = new Usuario();
            this.dtrol = new DTrol();
            String valor = Request.QueryString["id"];
            int id = int.Parse(valor);
            us.Id_usuario = id;

            Mrol1.DataSource = dtrol.listarRol();
            Mrol1.DataTextField = "Rol";
            Mrol1.DataValueField = "Id_rol";
            Mrol1.DataBind();

            this.registro = dtusuario.getUsuarioporid(id);
            Id_usuario.Value = valor;


            if (registro.Read())
            {
                us.Nombre = this.registro["Nombre_Usuario"].ToString();

                us.Id_rol = Convert.ToInt32(this.registro["Id_rol"]);
            }

        }
    }
}