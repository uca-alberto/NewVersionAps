using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Negocio;
using CentroBiologiaMolecularUCA.Ncapas.Negocio;

namespace CentroBiologiaMolecularUCA.Views.ViewOrdenMaria
{
    public partial class AgregarOrdenAdnMulti : System.Web.UI.Page
    {
        private DTAdnPaternidad tpaternidad;
        private String valor = "";
        private TOrdenAdn tOrden;
        private SqlDataReader registro;

        //Para cargar la Tabla
        private DTcliente tcliente;
        private Conexion conexion;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.tpaternidad = new DTAdnPaternidad();
            this.tcliente = new DTcliente();
            this.conexion = new Conexion();
            this.registro = this.tcliente.listarCliente();
            //Generar el codigo
            Mcodigo.Text = tpaternidad.generarCodigo();
            Mcodigomadre.Text = tpaternidad.generarCodigo();
            Mcodigoabuela.Text = tpaternidad.generarCodigo();
            Mcodigoalzheimer.Text = tpaternidad.generarCodigo();
            Mcodigopapiloma.Text = tpaternidad.generarCodigo();

          
        }

        public SqlDataReader getregistros()
        {
            return this.registro;
        }

        public OrdenAdn GetPapiloma()
        {
            OrdenAdn ord = new OrdenAdn();
            if (Mtipocasopapiloma.ToString() == "0")
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }

            else
            {
                ord.Tipo_Caso = Mtipocasopapiloma.SelectedValue;
            }
            if (Mdoctorpapiloma.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Nombre_pareja = Mdoctorpapiloma.Text;
            }
            if (Mpacientepapiloma.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Nombre_menor = Mpacientepapiloma.Text;
            }
            if (Mobservacionespapiloma.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Observaciones = Mobservacionespapiloma.Text;
            }
            if (Mboucherpapiloma.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Baucher = Mboucherpapiloma.Text;
            }
            if (Mcodigopapiloma.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Id_codigo = Mcodigopapiloma.Text;
            }
            if (Mestadopapiloma.ToString() == "0")
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Estado = Mestadopapiloma.SelectedValue;
            }
            if (Mfechapapiloma.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Fecha = Convert.ToDateTime(Mfechapapiloma.Text);
            }


            String userid = (string)Session["Id_usuario"];
            ord.Id_cliente = int.Parse(Id_cliente.Value.ToString());
            ord.Id_usuario = Convert.ToInt32(userid);
            
            return ord;
        }
        public OrdenAdn GetAlzheimer()
        {
            OrdenAdn ord = new OrdenAdn();
            if (Mtipocasoalzheimer.ToString() == "0")
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }

            else
            {
                ord.Tipo_Caso = Mtipocasoalzheimer.SelectedValue;
            }
            if (Mnombredeldoctor.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Nombre_pareja = Mnombredeldoctor.Text;
            }
            if (Mnombredelpaciente.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Nombre_menor = Mnombredelpaciente.Text;
            }
            if (Mobservacionesalzheimer.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Observaciones = Mobservacionesalzheimer.Text;
            }
            if (Mboucheralzheimer.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Baucher = Mboucheralzheimer.Text;
            }
            if (Mcodigoalzheimer.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Id_codigo = Mcodigoalzheimer.Text;
            }
            if (Mestadoalzheimer.ToString() == "0")
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Estado = Mestadoalzheimer.SelectedValue;
            }
            if (Mfechaalzheimer.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Fecha = Convert.ToDateTime(Mfechaalzheimer.Text);
            }

            String userid = (string)Session["Id_usuario"];
            ord.Id_cliente = int.Parse(Id_cliente.Value.ToString());
            ord.Id_usuario = Convert.ToInt32(userid);

            return ord;
        }

        public OrdenAdn GetAbuelidad()
        {
            OrdenAdn ord = new OrdenAdn();
            //abuelidad
            if (Mtipocasoabuelidad.ToString() == "0")
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }

            else
            {
                ord.Tipo_Caso = Mtipocasoabuelidad.SelectedValue;
            }
            if (Mnombredelaabuela.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Nombre_pareja = Mnombredelaabuela.Text;
            }
            if (Mnombrenieto.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Nombre_menor = Mnombrenieto.Text;
            }
            if (Mobservacionesabuelidad.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Observaciones = Mobservacionesabuelidad.Text;
            }
            if (Mboucherabuelidad.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Baucher = Mboucherabuelidad.Text;
            }
            if (Mcodigoabuela.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Id_codigo = Mcodigoabuela.Text;
            }
            if (Mestadoabuelidad.ToString() == "0")
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Estado = Mestadoabuelidad.SelectedValue;
            }
            if (Mfechaabuelidad.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Fecha = Convert.ToDateTime(Mfechaabuelidad.Text);
            }

            String userid = (string)Session["Id_usuario"];
            ord.Id_cliente = int.Parse(Id_cliente.Value.ToString());
            // ord.id_cliente = int.Parse(Id_cliente.Value.ToString());
            ord.Id_usuario = Convert.ToInt32(userid);

            return ord;
        }

        public OrdenAdn Get()
        {
            OrdenAdn ord = new OrdenAdn();

            //maternidad
            if (Mtipocasomadre.ToString() == "0")
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }

            else
            {
                ord.Tipo_Caso = Mtipocasomadre.SelectedValue;
            }
         
            if (Mnombremadre.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Nombre_pareja = Mnombremadre.Text;
            }
            if (Mnombrehijomadre.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Nombre_menor = Mnombrehijomadre.Text;
            }
            if (Mobservacionesmadre.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Observaciones = Mobservacionesmadre.Text;
            }
            if (baouchermaternidad.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Baucher = baouchermaternidad.Text;
            }
            if (Mcodigomadre.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Id_codigo = Mcodigomadre.Text;
            }
            if (Mestadomaternidad.ToString() == "0")
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
                
            }
            else
            {
                ord.Estado = Mestadomaternidad.SelectedValue;
            }
            if (Mfechamaternidad.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Fecha = Convert.ToDateTime(Mfechamaternidad.Text);
            }

            String userid = (string)Session["Id_usuario"];
           ord.Id_cliente = int.Parse(Id_cliente.Value.ToString());
            ord.Id_usuario = Convert.ToInt32(userid);

            return ord;

        }

        public OrdenAdn GetEntity()
        {


            OrdenAdn ord = new OrdenAdn();
            if (Mtipocaso.ToString() == "0")
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Tipo_Caso = Mtipocaso.SelectedValue;
            }
         
            if (Mnombrepareja.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Nombre_pareja = Mnombrepareja.Text;
            }
            if (Mnombrehijo.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Nombre_menor = Mnombrehijo.Text;
            }
            if (Mobservaciones.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Observaciones = Mobservaciones.Text;
            }
            if (Mbaucher.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Baucher = Mbaucher.Text;
            }
            if (Mcodigo.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Id_codigo = Mcodigo.Text;
            }
            if (Mestado.ToString() == "0")
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Estado = Mestado.SelectedValue;
            }
            if (Mfecha.ToString() == null)
            {
                RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);
            }
            else
            {
                ord.Fecha = Convert.ToDateTime(Mfecha.Text);
            }
            String userid = (string)Session["Id_usuario"];
            ord.Id_cliente = int.Parse(Id_cliente.Value.ToString());
            ord.Id_usuario = Convert.ToInt32(userid);


            return ord;
        }



        //maternidad
        protected void Button1_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }
        //paternidad
        protected void Button2_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 4;
        }

        //nada
        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        protected void Btnbackpaternidad_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }


        protected void InsertarOrden(object sender, EventArgs e)
        {
            if (IsValid)//valido que si mi formulario esta correcto
            {
                OrdenAdn ord = GetEntity();
                //LLAMANDO A CAPA DE NEGOCIO
                bool resp = NGAdnPaternidad.getInstance().guardarord(ord);


                if (resp == true)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript: InsertarOrden(); ", true);
                    //Response.Redirect("/Views/ViewOrdenMaria/BuscarOrdenAdn.aspx");
                }
                else
                {
                    Response.Write("<script>alert('REGISTRO INCORRECTO.')</script)");
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript: ADD(); ", true);
                // RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);//sino esta validado me mostrara los campos a corregir y no mandara datos.
            }
        }

    

        protected void Btnabuelidad_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
        }

        protected void Btnbackabuelidad_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void Btnalzheimer_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 3;
        }

        protected void insertarordenmaternidad_Click(object sender, EventArgs e)
        {
            if (IsValid)//valido que si mi formulario esta correcto
            {
                OrdenAdn ord = Get();
                //LLAMANDO A CAPA DE NEGOCIO
                bool resp = NGAdnPaternidad.getInstance().guardarord(ord);


                if (resp == true)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript: InsertarOrden(); ", true);
                    //Response.Redirect("/Views/ViewOrdenMaria/BuscarOrdenAdn.aspx");
                }
                else
                {
                    Response.Write("<script>alert('REGISTRO INCORRECTO.')</script)");
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript: ADD(); ", true);
                // RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);//sino esta validado me mostrara los campos a corregir y no mandara datos.
            }
        }

        protected void Btnpapiloma_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 4;
        }

        protected void Btnbackmaternidad_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void Btnbackalzheimer_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btnpaternidad_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void insertarordenabuelidad_Click(object sender, EventArgs e)
        {
            if (IsValid)//valido que si mi formulario esta correcto
            {
                OrdenAdn ord = GetAbuelidad();
                //LLAMANDO A CAPA DE NEGOCIO
                bool resp = NGAdnPaternidad.getInstance().guardarord(ord);


                if (resp == true)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript: InsertarOrden(); ", true);
                    //Response.Redirect("/Views/ViewOrdenMaria/BuscarOrdenAdn.aspx");
                }
                else
                {
                    Response.Write("<script>alert('REGISTRO INCORRECTO.')</script)");
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript: ADD(); ", true);
                // RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);//sino esta validado me mostrara los campos a corregir y no mandara datos.
            }
        }

        protected void insertarordenalzheimer_Click(object sender, EventArgs e)
        {
            if (IsValid)//valido que si mi formulario esta correcto
            {
                OrdenAdn ord = GetAlzheimer();
                //LLAMANDO A CAPA DE NEGOCIO
                bool resp = NGAdnPaternidad.getInstance().guardarord(ord);


                if (resp == true)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript: InsertarOrden(); ", true);
                    //Response.Redirect("/Views/ViewOrdenMaria/BuscarOrdenAdn.aspx");
                }
                else
                {
                    Response.Write("<script>alert('REGISTRO INCORRECTO.')</script)");
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript: ADD(); ", true);
                // RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);//sino esta validado me mostrara los campos a corregir y no mandara datos.
            }
        }

        protected void insertarordenpapiloma_Click(object sender, EventArgs e)
        {
            if (IsValid)//valido que si mi formulario esta correcto
            {
                OrdenAdn ord = GetPapiloma();
                //LLAMANDO A CAPA DE NEGOCIO
                bool resp = NGAdnPaternidad.getInstance().guardarord(ord);


                if (resp == true)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript: InsertarOrden(); ", true);
                    //Response.Redirect("/Views/ViewOrdenMaria/BuscarOrdenAdn.aspx");
                }
                else
                {
                    Response.Write("<script>alert('REGISTRO INCORRECTO.')</script)");
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript: ADD(); ", true);
                // RegularExpressionValidator.GetValidationProperty(RequiredFieldValidator1);//sino esta validado me mostrara los campos a corregir y no mandara datos.
            }
        }

        protected void Btnpaternidadn_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 5;
        }

        protected void btnvolverpaternidadnuevo_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }
    }



}
