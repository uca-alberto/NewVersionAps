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

namespace CentroBiologiaMolecularUCA.Views.Vogm
{
    public partial class Seeogm : System.Web.UI.Page
    {

        //Cliente
        private DTcliente dtcliente;
        private SqlDataReader cliente;

        //Orden y analisis
        private SqlDataReader registro;
        private SqlDataReader analisis;

        public OrdenAdn ord;
        private String[] array = new String[10];
        private int index = 0;

        //Guardar el id cliente
        private int idcliente;

        protected void Page_Load(object sender, EventArgs e)
        {

            dtcliente = new DTcliente();
            ord = new OrdenAdn();
            String valor = Request.QueryString["id"];
            int id = int.Parse(valor);
            ord.Id_orden = id;

            //Cargar los tipos de Analisis

            Manalisis.DataSource = NGorden.getInstance().ListarAnalisis();
            Manalisis.DataTextField = "analisis";
            Manalisis.DataValueField = "Id_analisis";
            Manalisis.DataBind();

            //Cargar Tipos de Muestras
            Mmuestra.DataSource = NGorden.getInstance().ListarMuestras();
            Mmuestra.DataTextField = "muestra";
            Mmuestra.DataValueField = "Id_tipo_muestra";
            Mmuestra.DataBind();

            this.registro = NGorden.getInstance().Ordenporid(id);
            Id_orden.Value = valor;

            //Llenar CheckBoxList
            this.analisis = NGorden.getInstance().Listarexamen(id);

            while (analisis.Read())
            {
                //Guardo en Arreglo los tipos de analisis segun la orden seleccionada
                array[index] = this.analisis["Id_analisis"].ToString();
                index++;
            }
            analisis.Close();
            //Recorro la cantidad de Items y comparo los id del areglo con los del checkbox si son iguales me checkea
            for (int i = 0; i < Manalisis.Items.Count; i++)
            {
                int idcheck = i + 0;
                for (int x = 0; x < array.Length; x++)
                {
                    if (array[x] == Manalisis.Items[idcheck].Value)
                    {
                        Manalisis.Items[i].Selected = true;
                    }
                }
            }

            if (registro.Read())
            {

                ord.Id_codigo = this.registro["Id_codigo"].ToString();
                ord.Fecha = Convert.ToDateTime(this.registro["Fecha"].ToString());
                ord.Tipo_muestra = Convert.ToInt32(this.registro["Id_tipo_muestra"].ToString());
                ord.Observaciones = this.registro["Observaciones"].ToString();
                ord.Baucher = this.registro["Baucher"].ToString();

                //Datos Cliente
                idcliente = Convert.ToInt32(registro["Id_cliente"].ToString());
            }

            //Mostrar datos en el textbox
            this.cliente = dtcliente.getClienteporid(idcliente);
            if (cliente.Read())
            {
                Mcliente.Text = cliente["Nombre"].ToString() + " " + cliente["Apellido"].ToString();
                Mcedula.Text = cliente["Cedula"].ToString();
            }

        }
    }
}