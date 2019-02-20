using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;

namespace WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos
{
    public class DTmuestra
    {
        private SqlDataReader registros;
        //PATRÓN SINGLETON
        #region "SINGLETON"
        private static DTmuestra dte = null;
        public DTmuestra()
        {

        }

        public static DTmuestra getInstance()
        {
            if (dte == null)
            {
                dte = new DTmuestra();
            }
            return dte;
        }
        #endregion

        //CONSTANTES DE CONEXIÓN Y COMANDO SQL
        SqlConnection c = new SqlConnection();
        SqlCommand comando = null;

        public SqlDataReader listarmuestras()
        {
            c = Conexion.getInstance().ConexionDB();
            String sql = "select Id_tipo_muestra , muestra  from T_Tipo_muestra;";

            SqlCommand comando = new SqlCommand(sql, this.c);
            this.registros = comando.ExecuteReader();
            return this.registros;
            c.Close();
        }
    }
}