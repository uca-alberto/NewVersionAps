using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;

namespace CentroBiologiaMolecularUCA.Views.ViewCliente
{
    public partial class VerCliente : System.Web.UI.Page
    {
        private DTcliente dtcliente;
        private DTdepartamento dtdepartamento;
        private SqlDataReader registro;
        public Cliente cli;
        private DTmunicipio dtmunicipio;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Creacion de los objetos
            this.dtcliente = new DTcliente();
            dtdepartamento = new DTdepartamento();
            cli = new Cliente();
            this.dtmunicipio = new DTmunicipio();

            //Obtener id del cliente
            String valor = Request.QueryString["id"];
            int id = int.Parse(valor);
            cli.Id_Cliente = id;

			//Cargar el Combobox de departamento
			Mdepartamento.DataSource = dtdepartamento.listardepartamento();//aqui le paso mi consulta que esta en la clase dtdepartamento
            Mdepartamento.DataBind();

            //Cargar el Combobox de municipio
            Mmunicipio.DataSource = dtmunicipio.listarmunicipio();
            Mmunicipio.DataBind();

            //Lamamos al metodo buscar cliente por id
            this.registro = dtcliente.getClienteporid(id);
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
				Image1.ImageUrl = "../../"+registro["Imagen"].ToString();

			}

        }
    }
}