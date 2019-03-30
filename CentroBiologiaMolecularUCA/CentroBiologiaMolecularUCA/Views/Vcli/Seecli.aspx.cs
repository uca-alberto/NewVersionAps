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

namespace CentroBiologiaMolecularUCA.Views.ViewCliente
{
    public partial class VerCliente : System.Web.UI.Page
    {
        private SqlDataReader registro;
        public Cliente cli;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Creacion de los objetos
            cli = new Cliente();
			NGcliente ng = new NGcliente();

            //Obtener id del cliente
            String valor = Request.QueryString["id"];
            int id = int.Parse(valor);
            cli.Id_Cliente = id;

			//Cargar el Combobox de departamento
			Mdepartamento.DataSource = ng.ListarDepartamento();//aqui le paso mi consulta que esta en la clase dtdepartamento
            Mdepartamento.DataBind();

            //Cargar el Combobox de municipio
            Mmunicipio.DataSource = ng.ListarMunicipio();
            Mmunicipio.DataBind();

            //Lamamos al metodo buscar cliente por id
            registro = ng.ListarClientePorId(id);
            Id_cliente.Value = valor;

            //Comenzamos a recorer el sqldatareader
            if (registro.Read())
            {
                //seteamos los datos de los campos de ese cliente
                this.cli.Nombres = this.registro["Nombre"].ToString();
                cli.Apellidos = this.registro["Apellido"].ToString();
                cli.Cedula = this.registro["Cedula"].ToString();
                cli.Departamento = this.registro["Id_Departamento"].ToString();
                cli.Dirreccion = this.registro["Direccion"].ToString();
                cli.Municipio = this.registro["Id_Municipio"].ToString();
                cli.Sexo = this.registro["Sexo"].ToString();
                cli.Telefono = int.Parse(this.registro["Num_Telefono"].ToString());
                cli.Correo = this.registro["Email"].ToString();
				if (registro["Imagen"].ToString()=="")
				{
					Image1.ImageUrl = "../../ImagesClientes/User-placeholder.jpg";
				}
				else
				{
					Image1.ImageUrl = "../../" + registro["Imagen"].ToString();
				}

			}

        }
    }
}