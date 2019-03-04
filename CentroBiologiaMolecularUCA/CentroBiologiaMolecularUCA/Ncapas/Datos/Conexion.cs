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
            // conexion.ConnectionString = "Data Source=DESKTOP-PF2CIA5\\SA;Initial Catalog=Biologias;Integrated Security=True";
            // conexion.ConnectionString = "Data Source=localhost;Initial Catalog=centro; MultipleActiveResultSets=True ;Max Pool Size = 50; Min Pool Size = 1; Pooling = True;User ID = sa; Password = 123;";
            conexion.ConnectionString = "Data Source=localhost;Initial Catalog=biologia; MultipleActiveResultSets=True ;Max Pool Size = 50; Min Pool Size = 1; Pooling = True;User ID = sa; Password = 1234;";
            // conexion.ConnectionString = "Data Source=localhost;Initial Catalog=CBM; MultipleActiveResultSets=True ;Max Pool Size = 50; Min Pool Size = 1; Pooling = True;User ID = sa; Password = 123;";

            // conexion.ConnectionString = "Data Source=165.98.12.158;Initial Catalog=cbm;User ID=aps;Password=$qlS3rv3rAPS*";
            conexion.Open();
            return conexion;
        }

    }
}