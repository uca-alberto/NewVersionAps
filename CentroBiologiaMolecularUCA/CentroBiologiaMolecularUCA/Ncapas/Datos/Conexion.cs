using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos
{
    public class Conexion
    {
        #region "SINGLETON"
        private static Conexion conexion = null;
        public Conexion()
        {

        }

        public static Conexion getInstance()
        {
            if (conexion == null)
            {
                conexion = new Conexion();
            }
            return conexion;
        }
        #endregion

        public SqlConnection ConexionDB()
        {
            SqlConnection conexion = new SqlConnection();

             conexion.ConnectionString = "Data Source=localhost;Initial Catalog=CBM; MultipleActiveResultSets=True ;Max Pool Size = 50; Min Pool Size = 1; Pooling = True;User ID = sa; Password = 1234;";
            conexion.Open();
            return conexion;
        }

    }
}