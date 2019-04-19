using CentroBiologiaMolecularUCA.Ncapas.Datos;
using CentroBiologiaMolecularUCA.Ncapas.Entidades;
using CentroBiologiaMolecularUCA.Ncapas.Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Negocio;

namespace CentroBiologiaMolecularUCA.Views.OpcionesConfigurables.Emp
{
    public partial class SeeEmployee : System.Web.UI.Page
    {
        private SqlDataReader registro;
        public Empleado emp;


        protected void Page_Load(object sender, EventArgs e)
        {

            //Creacion de los objetos
            emp = new Empleado();

            //Obtener id del empleado
            String valor = Request.QueryString["id"];
            int id = int.Parse(valor);
            emp.Id_Empleado = id;

            //Lamamos al metodo buscar empleado por id
            this.registro = NGEmpleado.getInstance().ListarEmpleadoPorId(id);
            Id_Emp.Value = valor;

            //Comenzamos a recorer el sqldatareader
            if (registro.Read())
            {
                this.emp.Cedula = this.registro["cedula"].ToString();
                this.emp.Nombre_Empleado = this.registro["Nombre_empleado"].ToString();
                this.emp.Apellido = this.registro["Apellido"].ToString();
				this.emp.Cargo = this.registro["Cargo"].ToString();
			}

        }
    }
}