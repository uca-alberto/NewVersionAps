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

namespace CentroBiologiaMolecularUCA.Views.ViewResultadoMaria
{
    public partial class AgregarResultadoOgm : System.Web.UI.Page
    {
        private DTresultado dtresultado;
        private SqlDataReader registro;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            this.dtresultado = new DTresultado();
            this.registro = this.dtresultado.listarTodo();

        }

        public SqlDataReader getregistros()
        {
            return this.registro;
        }

        public Resultado GetEntity()
        {
            Resultado re = new Resultado();
            if (Mfecha.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
              //  re.Fecha_procesamiento = Convert.ToDateTime(Mfecha.Text);
            }
            if (Mvalidacion.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                re.Validacion = Mvalidacion.SelectedValue;
            }
            if (Mresultado.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
              
            }
            if (Mestado.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                re.Estado = Mestado.SelectedValue;
            }
            if (Musuarioprocesa.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                re.Usuario_procesa = Musuarioprocesa.Text;
            }
            if (Musuariovalida.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                re.Usuario_valida = Musuariovalida.Text;
            }
            if (Manalisis.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
               
            }

            return re;
        }

        protected void InsertarOrden(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Resultado re = GetEntity();
                bool resp = NGresultado.getInstance().guardarresultado(re);
                if (resp == true)
                {
                    Response.Redirect("AgregarResultadoOgm.aspx");
                }
                else
                {
                    Response.Write("<script>alert('REGISTRO INCORRECTO.')</script)");
                }
            }
            else
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);//sino esta validado me mostrara los campos a corregir y no mandara datos.

            }
        }
    }
}