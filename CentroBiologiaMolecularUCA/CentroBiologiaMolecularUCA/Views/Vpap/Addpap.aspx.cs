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

namespace CentroBiologiaMolecularUCA.Views.Vpap
{
	public partial class Addpap : System.Web.UI.Page
	{
		private SqlDataReader registro;
		private DTcliente tcliente;
		private DTAdnPaternidad tpaternidad;


		protected void Page_Load(object sender, EventArgs e)
		{
			this.tpaternidad = new DTAdnPaternidad();
			this.tcliente = new DTcliente();
			this.registro = this.tcliente.listarCliente();
			Mcodigopapiloma.Text = tpaternidad.generarCodigoPapiloma();
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
			ord.Tipo_examen = 6;

			return ord;
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

	}
}