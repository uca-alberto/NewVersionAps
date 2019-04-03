﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Negocio;

namespace CentroBiologiaMolecularUCA.Views.Vreogm
{
    public partial class Seereogm : System.Web.UI.Page
    {
        public Resultado res;
        //datos resultados
        private SqlDataReader registro;
        private SqlDataReader datos;
        private SqlDataReader analisis;
        private SqlDataReader tabla;
        private String[] array = new String[10];
        private int index = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.res = new Resultado();

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

            String valor = Request.QueryString["id"];
            int id = int.Parse(valor);
            tabla = NGresultado.getInstance().visualizartabla(id);
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

            //Registros
            datos = NGresultado.getInstance().ListardatosResultados(id);

            if (datos.Read())
            {
                Mcodigo.Text = datos["Id_codigo"].ToString();
                Mimportador.Text = datos["Nombre"].ToString() + " " + datos["Apellido"].ToString();
                Mmuestra.SelectedValue = datos["Id_tipo_muestra"].ToString();
            }

            registro = NGresultado.getInstance().resultados(id);
            if (registro.Read())
            {
                res.Usuario_procesa = registro["Usuario_procesa"].ToString();
                res.Fecha_procesamiento= Convert.ToDateTime(registro["Fecha_procesamiento"].ToString());
                res.Observaciones = registro["Observaciones"].ToString();

                Mhora.Text = registro["Hora"].ToString();
            }
    }
        //cargar datos en la tabla 
        public SqlDataReader getregistros()
        {
            return tabla;
        }


    }
}