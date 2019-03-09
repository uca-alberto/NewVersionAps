using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;

namespace CentroBiologiaMolecularUCA.Views.ViewOrden
{
    public partial class EliminarOrden : System.Web.UI.Page
    {
        private TOrden dtorden;
        protected void Page_Load(object sender, EventArgs e)
        {

            this.dtorden = new TOrden();//creo mi objeto dtOrden

            OrdenAdn orden = new OrdenAdn(); 

            String valor = Request.QueryString["id"];

            int id = int.Parse(valor);
            orden.Id_orden = id;


            this.dtorden.eliminar(orden);
            //le paso el id que obtengo y se hace el eliminado logico
            Response.Redirect("../../Views/ViewOrdenMaria/BuscarOrdenAdn.aspx");//redirecciono

        }
    }
}