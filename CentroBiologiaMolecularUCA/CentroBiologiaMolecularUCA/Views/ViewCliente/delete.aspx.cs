using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;

namespace CentroBiologiaMolecularUCA.Views.ViewCliente
{
    public partial class delete : System.Web.UI.Page
    {
        private DTcliente dtcliente;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.dtcliente = new DTcliente();//creo mi objeto dtcliente
            
            Cliente cli = new Cliente(); //creo mi objeto cliente para poderle asignar el id que quiero eliminar

            String valor = Request.QueryString["id"];//obtengo el id atravez de la url

            int id = int.Parse(valor);//parseo para luego pasarselo al metodo eliminar de dtcliente
            cli.Id_Cliente = id;
           
                
                this.dtcliente.eliminar(cli);//le paso el id que obtengo y se hace el eliminado logico
                Response.Redirect("BuscarCliente.aspx");//redirecciono
            
            
        }
    }
}