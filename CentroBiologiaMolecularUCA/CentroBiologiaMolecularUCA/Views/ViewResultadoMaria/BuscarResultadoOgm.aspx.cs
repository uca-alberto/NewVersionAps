using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data.SqlClient;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;
using Microsoft.AspNet.SignalR;


namespace CentroBiologiaMolecularUCA.Views.ViewResultadoMaria
{
    public partial class BuscarResultadoOgm : System.Web.UI.Page
    {

       // private DTresultado tresultado;
      //  private SqlDataReader registro;

        protected void Page_Load(object sender, EventArgs e)
        {
          //  this.tresultado = new DTresultado();
          //  this.registro = this.tresultado.listarTodo();

        }
        [WebMethod]
        public static List<Resultado> GetData()
        {
            DTresultado dtp = new DTresultado();
            return dtp.GetData();
        }

        [WebMethod]
        public static bool EliminarResultado(String id)
        {
            bool resp = false;
            Resultado ep = new Resultado()

            {
                Id_resultado = Convert.ToInt32(id)
            
            };
            Console.Write(ep);
            resp = DTresultado.getInstance().eliminar(ep);
           
            return resp;

        }
        //  public SqlDataReader getregistros()
        //  {
        //aqui se enlista la resultado ogm
        //  return this.registro;
        //  }
    }
}