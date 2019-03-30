using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Negocio;

namespace CentroBiologiaMolecularUCA.Views.OpcionesConfigurables
{
        public partial class BuscarExamenes : System.Web.UI.Page
        {
            private SqlDataReader registros;
            protected void Page_Load(object sender, EventArgs e)
            {
			NGExamen ng = new NGExamen();
             registros = ng.ListarExamenes();

            }
            public SqlDataReader getregistros()
            {
                //aqui se enlistan los examenes
                return this.registros;
            }

        }
    }