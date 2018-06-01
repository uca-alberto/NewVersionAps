using System;
using System.Data.SqlClient;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;

namespace CentroBiologiaMolecularUCA.Views.ViewOrdenMaria
{
    public partial class BuscarOrdenAdn : System.Web.UI.Page
    {
        private TOrdenAdn tOrden;
        private SqlDataReader registro;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.tOrden = new TOrdenAdn();
            this.registro = this.tOrden.listarTodo();

        }

        public SqlDataReader getregistros()
        {
            //aqui se enlista la orden de ADN
            return this.registro;
        }
    }
}