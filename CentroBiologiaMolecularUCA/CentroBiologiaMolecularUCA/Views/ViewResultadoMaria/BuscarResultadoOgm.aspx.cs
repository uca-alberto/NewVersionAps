using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;

namespace CentroBiologiaMolecularUCA.Views.ViewResultadoMaria
{
    public partial class BuscarResultadoOgm : System.Web.UI.Page
    {

        private DTresultado tresultado;
        private SqlDataReader registro;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.tresultado = new DTresultado();
            this.registro = this.tresultado.listarTodo();

        }

        public SqlDataReader getregistros()
        {
            //aqui se enlista la resultado ogm
            return this.registro;
        }
    }
}