using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Negocio;

namespace CentroBiologiaMolecularUCA.Views.Vrealz
{

    public partial class Addrealz : System.Web.UI.Page
    {
        private SqlDataReader registro;
        private SqlDataReader investigador;
        private int id;
        String userprocesa;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Obtener el Id Orden
            String valor = Request.QueryString["id"];
            id = Convert.ToInt16(valor);

            if (!IsPostBack)
            {
                Mparametro.DataSource = NGresultado.getInstance().listarParametros();
                Mparametro.DataTextField = "Id_parametros";
                Mparametro.DataTextField = "Nombre";
                Mparametro.DataBind();
                ListItem li = new ListItem("SELECCIONE", "0");//creamos una lista, para agregar el seleccione
                Mparametro.Items.Insert(0, li);
            }

            registro = NGresultado.getInstance().datosResultadosAlz(id);

            if(registro.Read()){
                Mcodigo.Text = registro["Id_codigo"].ToString();
                Mfecha.Text = registro["Fecha"].ToString();
                Mcliente.Text = registro["Cliente"].ToString();
            }
            //Obtener el usuario actual
            userprocesa = (string)Session["Id_usuario"];
            investigador = NGresultado.getInstance().datosusuario(Convert.ToInt32(userprocesa));
            if (investigador.Read())
            {
                Minvestigador.Text = investigador["Nombre_empleado"].ToString() + " " + investigador["Apellido"].ToString();
            }

        }

        public Resultado GetEntity()
        {
            Resultado res = new Resultado();
            String fecha = DateTime.Now.ToString("dd/MM/yyyy");
            String hora= DateTime.Now.ToString("hh:mm");

            res.Id_orden=id;
            res.Validacion= Mparametro.SelectedValue;
            res.Fecha_procesamiento = Convert.ToDateTime(fecha);
            res.Hora = Convert.ToDateTime(hora);
            res.Usuario_procesa = userprocesa;
            res.Observaciones = Mobservaciones.Text.Replace("\r\n", " "); ;
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