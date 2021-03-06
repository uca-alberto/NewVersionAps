﻿using CentroBiologiaMolecularUCA.Ncapas.Datos;
using CentroBiologiaMolecularUCA.Ncapas.Entidades;
using CentroBiologiaMolecularUCA.Ncapas.Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Negocio;

namespace CentroBiologiaMolecularUCA.Views.OpcionesConfigurables.Emp
{
    public partial class AgregarEmpleado : System.Web.UI.Page
    {
        private DTUsuario dtusuario;
        private SqlDataReader registro;

        protected void Page_Load(object sender, EventArgs e)
        {

            String rolid = (string)Session["Id_rol"];
            string ubicacion = HttpContext.Current.Request.Url.AbsolutePath;

            int rol = Convert.ToInt32(rolid);

            bool permiso = false;

            if (rol == 1)
            {
                permiso = true;
            }
            else
            {
                permiso = NGUsuario.getInstance().acceso(rol, ubicacion);

            }

            //Se redirecciona si no tiene permiso
            if (permiso == false)
            {

                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript: Acceso(); ", true);
            }

        }



        public Empleado GetEntity()
        {
            Empleado emp = new Empleado();

            if (Mnombre.ToString() == null)//valido los campos que no sean nulos
            {
                Mnombre.BorderColor = System.Drawing.Color.Red;//si son nulos, me tirara un error de validacion
            }
            else
            {
                emp.Nombre_Empleado = Mnombre.Text;//si son validos, me dejara enviar los datos a la base de datoa
            }
            if (Mapellido.ToString() == null)//todo esto se hace para todos los campos del formulario
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                emp.Apellido = Mapellido.Text;
            }
            if (Mcedula.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                emp.Cedula = Mcedula.Text;
            }
            if (Mcargo.SelectedValue == null)//todo esto se hace para todos los campos del formulario
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                emp.Cargo = Mcargo.SelectedValue;
            }



            return emp;
        }

        protected void InsertarEmpleado(object sender, EventArgs e)
        {

            if (IsValid)//valido que si mi formulario esta correcto
            {
                //Registro del Empleado
                Empleado emp = GetEntity();
                //LLAMANDO A CAPA DE NEGOCIO
                bool resp = NGEmpleado.getInstance().guardarempleado(emp);

                if (resp == true)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript: InsertarEmpleado(); ", true);
                    //Response.Redirect("BuscarCliente.aspx");

                }
                else
                {
                    Response.Write("<script>alert('REGISTRO INCORRECTO.')</script)");
                }

            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript: ADD(); ", true);
            }

        }

        
    }
}