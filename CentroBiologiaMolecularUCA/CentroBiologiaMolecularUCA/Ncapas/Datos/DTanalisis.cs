using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos
{
    public class DTanalisis
    {
        private SqlDataReader registros;
        //PATRÓN SINGLETON
        #region "SINGLETON"
        private static DTanalisis dte = null;
        public DTanalisis()
        {

        }

        public static DTanalisis getInstance()
        {
            if (dte == null)
            {
                dte = new DTanalisis();
            }
            return dte;
        }
        #endregion

        //CONSTANTES DE CONEXIÓN Y COMANDO SQL
        SqlConnection c = new SqlConnection();
        SqlCommand comando = null;

        public SqlDataReader listaranalisis()
        {
            c = Conexion.getInstance().ConexionDB();
            String sql = "select Id_analisis , analisis  from T_Tipo_Analisis;";

            SqlCommand comando = new SqlCommand(sql, this.c);
            this.registros = comando.ExecuteReader();
            return this.registros;
            c.Close();
        }
    }


}