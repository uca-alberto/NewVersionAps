using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;

namespace WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos
{
    public class DTparametros
    {
        private SqlDataReader registros;
        //PATRÓN SINGLETON
        #region "SINGLETON"
        private static DTparametros dte = null;
        public DTparametros()
        {

        }

        public static DTparametros getInstance()
        {
            if (dte == null)
            {
                dte = new DTparametros();
            }
            return dte;
        }
        #endregion

        //CONSTANTES DE CONEXIÓN Y COMANDO SQL
        SqlConnection c = new SqlConnection();
        SqlCommand comando = null;

        public SqlDataReader listarparametros()
        {
            c = Conexion.getInstance().ConexionDB();
            String sql = "SELECT Id_parametros,Nombre FROM T_Parametros where Id_examenes=5;";

            SqlCommand comando = new SqlCommand(sql, this.c);
            this.registros = comando.ExecuteReader();
            return this.registros;
            c.Close();
        }
    }
}