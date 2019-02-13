using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;

namespace CentroBiologiaMolecularUCA.Views.ViewResultadoMaria
{
    public partial class EliminarresultadoOgm : System.Web.UI.Page
    {
        private DTresultado dtresultado;
        protected void Page_Load(object sender, EventArgs e)
        {

            this.dtresultado = new DTresultado(); //creo mi objeto dtcliente
            Resultado re = new Resultado();
             //creo  objeto Resultado para poderle asignar el id que quiero eliminar

            String valor = Request.QueryString["id"];//obtengo el id atravez de la url

            int id = int.Parse(valor);//parseo para luego pasarselo al metodo eliminar de dtcliente
            
            re.Id_resultado = id;

            this.dtresultado.eliminar(re);
            
            //le paso el id que obtengo y se hace el eliminado logico
            Response.Redirect("BuscarResultadoOgm.aspx");//redirecciono

        }
    }
}