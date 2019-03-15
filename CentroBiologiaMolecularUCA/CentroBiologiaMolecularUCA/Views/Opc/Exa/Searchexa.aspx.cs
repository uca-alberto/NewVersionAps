using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;

namespace CentroBiologiaMolecularUCA.Views.OpcionesConfigurables
{
        public partial class BuscarExamenes : System.Web.UI.Page
        {
            private SqlDataReader registros;
            private DTexamenes dtexamenes;
            protected void Page_Load(object sender, EventArgs e)
            {
                this.dtexamenes = new DTexamenes();
                this.registros = this.dtexamenes.listarexamenes();

            }
            public SqlDataReader getregistros()
            {
                //aqui se enlistan los examenes
                return this.registros;
            }

        }
    }