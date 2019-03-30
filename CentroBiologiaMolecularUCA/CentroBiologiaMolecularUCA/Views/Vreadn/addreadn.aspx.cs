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
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Negocio;

namespace CentroBiologiaMolecularUCA.Views.Vreadn
{
    public partial class addreadn : System.Web.UI.Page
    {
        private DTEmpleados dte;
        private DTUsuario dtusuario;
        private DTresultado result;
        private TOrdenAdn toa;
        private SqlDataReader registro;//Data resultado
        // Datos del empleado
        private SqlDataReader empleados;
        private SqlDataReader usuario;
        private int id_empleado;
        //
        private int id;
        private int usuario_procesa;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.dtusuario = new DTUsuario();
            this.dte = new DTEmpleados();
            String userid = (string)Session["Id_usuario"];
            usuario_procesa = Convert.ToInt32(userid);
            this.result = new DTresultado();
            this.toa = new TOrdenAdn();
          
            //Obtener el Id Orden
            String valor = Request.QueryString["id"];
            id = int.Parse(valor);

            //Registros
            registro = result.cargardatosadnporid(id);
            if (registro.Read())
            {
                Mcodigo.Text = registro["Id_codigo"].ToString();
              
                Mcliente.Text = registro["Nombre"].ToString() + " " + registro["Apellido"].ToString();
                Mpareja.Text = registro["Nombre_pareja"].ToString();
                Mmenor.Text = registro["Nombre_menor"].ToString();
            }
            //Mostrar datos en el textbox
            usuario = result.datousuario(usuario_procesa);
            if (usuario.Read())
            {
                Minvestigador.Text = empleados["Nombre_empleado"].ToString() + " " + empleados["Apellido"].ToString();
            }
            /* usuario = dtusuario.getUsuarioporid(usuario_procesa);
             if (usuario.Read())
             {

                 id_empleado = Convert.ToInt32(this.registro["Id_empleado"]);
             }
             //Mostrar datos en el textbox
             this.empleados = dte.getEmpleadoporid(id_empleado);
             if (empleados.Read())
             {
                 Minvestigador.Text = empleados["Nombre_empleado"].ToString() + " " + empleados["Apellido"].ToString();
             }
             */


            //Cargar Fecha y hora 
            Mfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            Mhora.Text = DateTime.Now.ToString("hh:mm");
        }

        public Resultado GetEntity()
        {
            Resultado res = new Resultado();

            if (Mobservaciones == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator2);
            }
            else
            {
                res.Observaciones = Mobservaciones.Text;
            }
            if (Mresultado.SelectedValue.ToString() == "0")
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator2);
            }
            else
            {
                res.Validacion = Mresultado.SelectedValue;
            }
            res.Id_orden = id;
            res.Fecha_procesamiento = Convert.ToDateTime(Mfecha.Text);
            res.Hora = Convert.ToDateTime(Mhora.Text);
            res.Usuario_procesa = usuario_procesa.ToString();
            //Obtener el usuario actual
            String userprocesa = (string)Session["Id_usuario"];
            res.Usuario_procesa = userprocesa;
            //estado para mientras
            res.Estado = "Procesada";
            return res;
        }

        public void InsertarResultado(object sender, EventArgs e)
        {
            if (IsValid)//valido que si mi formulario esta correcto
            {
                Resultado res = GetEntity();
                //LLAMANDO A CAPA DE NEGOCIO
                bool resp = NGresultado.getInstance().guardarresultado(res);

                if (resp == true)
                {
                    //Mostrar Notificacion
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript: InsertarResultado(); ", true);
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