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

namespace CentroBiologiaMolecularUCA.Views.Opc.Use
{
    public partial class Seeuse : System.Web.UI.Page
    {
        private DTUsuario dtusuario;
 
        private DTEmpleados dte;
        private DTrol dtrol;
        public Usuario us;
        private SqlDataReader empleados;
        private SqlDataReader rol;
        private int id_empleado;
        private SqlDataReader registro;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.dte = new DTEmpleados();
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

                us.Id_rol = Convert.ToInt32(this.registro["Id_rol"]);
                id_empleado = Convert.ToInt32(this.registro["Id_empleado"]);
            }
            //Mostrar datos en el textbox
            this.empleados = dte.getEmpleadoporid(id_empleado);
            if (empleados.Read())
            {
                Mempleado.Text = empleados["Nombre_empleado"].ToString() + " " + empleados["Apellido"].ToString();
            }

        }

    }
}