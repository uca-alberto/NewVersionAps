using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Negocio;

namespace CentroBiologiaMolecularUCA.Views.Vrevph
{
    public partial class Addrevph : System.Web.UI.Page
    {
        private SqlDataReader registros;
        private SqlDataReader investigador;
        private int id;
        private int idresultado;
        private string userprocesa;

        protected void Page_Load(object sender, EventArgs e)
        {

            //Obtener el Id Orden
            String valor = Request.QueryString["id"];
            id = Convert.ToInt16(valor);
            if (!IsPostBack) { 
                Mparametros.DataSource = NGresultado.getInstance().listarvphbajo();
                Mparametros.DataTextField = "VPH_Bajo";
                Mparametros.DataValueField = "Id_parametros";
                Mparametros.DataBind();

                //Cargar Tipos de Muestras
                Mparametros1.DataSource = NGresultado.getInstance().listarvphalto();
                Mparametros1.DataTextField = "VPH_Alto";
                Mparametros1.DataValueField = "Id_parametros";
                Mparametros1.DataBind();
            }
            registros = NGresultado.getInstance().datarevph(id);

            if (registros.Read())
            {
                Mcodigo.Text = registros["Id_codigo"].ToString();
                Mfecham.Text = registros["Fecha"].ToString();
                Mcliente.Text= registros["Cliente"].ToString();
                Mcedula.Text = registros["Cedula"].ToString();
            }
            //Obtener el usuario actual
            userprocesa = (string)Session["Id_usuario"];
            investigador = NGresultado.getInstance().datosusuario(Convert.ToInt32(userprocesa));
            if (investigador.Read())
            {
                Minvestigador.Text = investigador["Nombre_empleado"].ToString() + " " + investigador["Apellido"].ToString();
            }

            //Cargar Fecha y hora 
            Mfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            Mhora.Text = DateTime.Now.ToString("hh:mm");
        }

     
            public Resultado GetEntity()
        {
            Resultado res = new Resultado();
            String fecha = DateTime.Now.ToString("dd/MM/yyyy");
            String hora = DateTime.Now.ToString("hh:mm");

            res.Id_orden = id;
            res.Validacion = "0";
            res.Fecha_procesamiento = Convert.ToDateTime(fecha);
            res.Hora = Convert.ToDateTime(hora);
            res.Usuario_procesa = userprocesa;
            res.Observaciones = Mobservaciones.Text;
            res.Estado = "Procesada";
            return res;
        }
        public void guardardetalle()
        {
            Resultado res = new Resultado();

            res.Id_resultado = idresultado;
            res.Resultados = 1;
            //VPH Bajo Riesgo
            for (int i = 0; i < Mparametros.Items.Count; i++)
            {
                if (Mparametros.Items[i].Selected)
                {
                   res.Id_analisis = Convert.ToInt32(Mparametros.Items[i].Value);
                    NGresultado.getInstance().creardetalle(res);
                }
            }
            //VPH Alto riesgo
         
            for (int i = 0; i < Mparametros1.Items.Count; i++)
            {
                if (Mparametros1.Items[i].Selected)
                {
                    res.Id_analisis = Convert.ToInt32(Mparametros1.Items[i].Value);
                    NGresultado.getInstance().creardetalle(res);
                }
            }
        }

        public void InsertarResultado(object sender, EventArgs e)
        {
            if (IsValid)//valido que si mi formulario esta correcto
            {
                Resultado res = GetEntity();
                //LLAMANDO A CAPA DE NEGOCIO

                bool resp = NGresultado.getInstance().guardarresultado(res);
                idresultado = NGresultado.getInstance().idresultado();
                if (resp == true)
                {
                    guardardetalle();
                    NGresultado.getInstance().procesarorden(res);
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