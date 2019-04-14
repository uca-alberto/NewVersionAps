using CentroBiologiaMolecularUCA.Ncapas.Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;

namespace CentroBiologiaMolecularUCA.Views.Valz
{
	public partial class Addalz : System.Web.UI.Page
	{
		private DTAdnPaternidad tpaternidad;
		private SqlDataReader registro;
		private DTcliente tcliente;

		protected void Page_Load(object sender, EventArgs e)
		{
			this.tpaternidad = new DTAdnPaternidad();
			this.tcliente = new DTcliente();
			this.registro = this.tcliente.listarCliente();
			Mcodigoalzheimer.Text = tpaternidad.generarCodigoAlzheimer();


		}
		public SqlDataReader getregistros()
		{
			return this.registro;
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
			ord.Tipo_examen = 5;

			return ord;
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
	}
}