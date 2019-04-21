using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Negocio;
using System.Data.SqlClient;

namespace CentroBiologiaMolecularUCA.Views.ViewOrdenMaria
{
    public partial class VerOrdenAdnMulti : System.Web.UI.Page
    {
        private SqlDataReader cliente;
        private DTAdnPaternidad dtadnpaternidad;
   
        private SqlDataReader registro;
        public OrdenAdn ord;
        //Guardar el id cliente
        private int idcliente;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.dtadnpaternidad = new DTAdnPaternidad();
           
            ord = new OrdenAdn();

            //Obtener id del cliente
            String valor = Request.QueryString["id"];
            int id = int.Parse(valor);
            ord.Id_orden = id;
            //Cargar el Combobox de tipo orden examen
           

            this.registro = dtadnpaternidad.getOrdenporid(id);
            Id_orden.Value = valor;

            //Comenzamos a recorer el sqldatareader
            if (registro.Read())
            {
                //seteamos los datos de los campos de ese cliente
                this.ord.Id_codigo = this.registro["Id_codigo"].ToString();
                ord.Nombre_pareja = this.registro["Nombre_pareja"].ToString();
                ord.Nombre_menor = this.registro["Nombre_menor"].ToString();
                ord.Fecha = Convert.ToDateTime(this.registro["Fecha"].ToString());
                ord.Tipo_Caso = this.registro["Tipo_caso"].ToString();
               

                ord.Observaciones = this.registro["Observaciones"].ToString();
                ord.Baucher = this.registro["Baucher"].ToString();
                //Datos Cliente
                idcliente = Convert.ToInt32(registro["Id_cliente"].ToString());

            }
            //Mostrar datos en el textbox
            this.cliente = NGcliente.getInstance().ListarClientePorId(idcliente);
            if (cliente.Read())
            {
                Mcliente.Text = cliente["Nombre"].ToString() + " " + cliente["Apellido"].ToString();
                Mcedula.Text = cliente["Cedula"].ToString();
            }
        }
    }
}