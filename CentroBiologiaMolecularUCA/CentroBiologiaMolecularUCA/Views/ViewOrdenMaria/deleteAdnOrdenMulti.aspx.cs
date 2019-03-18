using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;

namespace CentroBiologiaMolecularUCA.Views.ViewOrdenMaria
{
    public partial class deleteAdnOrdenMulti : System.Web.UI.Page
    {
        private DTAdnPaternidad dtadnpaternidad;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.dtadnpaternidad = new DTAdnPaternidad();
            OrdenAdn ord = new OrdenAdn();
            String valor = Request.QueryString["id"];

            int id = int.Parse(valor);
            ord.Id_orden = id;

            this.dtadnpaternidad.eliminar(ord);
            Response.Redirect("BuscarMultiAdnOrden.aspx");
        }
    }
}