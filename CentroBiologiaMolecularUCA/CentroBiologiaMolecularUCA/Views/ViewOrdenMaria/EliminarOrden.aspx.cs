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
    public partial class EliminarOrden : System.Web.UI.Page
    {
        private TOrdenAdn dtorden;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            this.dtorden = new TOrdenAdn();//creo mi objeto dtcliente

            OrdenAdn orde = new OrdenAdn(); //creo mi objeto cliente para poderle asignar el id que quiero eliminar

            String valor = Request.QueryString["id"];//obtengo el id atravez de la url

            int id = int.Parse(valor);//parseo para luego pasarselo al metodo eliminar de dtcliente
            orde.Id_orden = id;


            this.dtorden.eliminar(orde);
            //le paso el id que obtengo y se hace el eliminado logico
            Response.Redirect("BuscarOrdenAdn.aspx");//redirecciono

        }
    }
}