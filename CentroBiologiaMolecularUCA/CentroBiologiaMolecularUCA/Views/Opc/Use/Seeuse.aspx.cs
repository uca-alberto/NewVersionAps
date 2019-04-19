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
    public partial class Seeuse : System.Web.UI.Page
    {

        public Usuario us;
        private SqlDataReader empleados;
        private SqlDataReader rol;
        private int id_empleado;
        private SqlDataReader registro;

        protected void Page_Load(object sender, EventArgs e)
        {

            us = new Usuario();
            String valor = Request.QueryString["id"];
            int id = int.Parse(valor);
            us.Id_usuario = id;

            Mrol.DataSource = NGUsuario.getInstance().listarRol();
            Mrol.DataTextField = "Rol";
            Mrol.DataValueField = "Id_rol";
            Mrol.DataBind();

            this.registro = NGUsuario.getInstance().getUsuarioporid(id);
            Id_usuario.Value = valor;


            if (registro.Read())
            {
                us.Nombre = this.registro["Nombre_Usuario"].ToString();
                us.Id_rol = Convert.ToInt32(this.registro["Id_rol"]);
                id_empleado = Convert.ToInt32(this.registro["Id_empleado"]);
            }
            //Mostrar datos en el textbox
            this.empleados = NGEmpleado.getInstance().ListarEmpleadoPorId(id_empleado);
            if (empleados.Read())
            {
                Mempleado.Text = empleados["Nombre_empleado"].ToString() + " " + empleados["Apellido"].ToString();
            }

        }

    }
}