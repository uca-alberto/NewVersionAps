using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Negocio;

namespace CentroBiologiaMolecularUCA.Views.Vreogm
{
    public partial class Searchreogm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<Resultado> GetData()
        {
            return NGresultado.getInstance().getData();
        }

        [WebMethod]
        public static bool EliminarOrd(String id)
        {
            bool resp = false;

            Resultado res = new Resultado
            {
                Id_resultado = Convert.ToInt32(id)
            };
			NGresultado.getInstance().Updateorden(res);
            resp = NGresultado.getInstance().Eliminar(res);
            return resp;
        }


    }
}