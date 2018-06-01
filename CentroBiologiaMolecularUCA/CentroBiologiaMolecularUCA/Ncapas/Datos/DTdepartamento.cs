using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos
{
    public class DTdepartamento
    {
        private SqlDataReader registros;
        //PATRÓN SINGLETON
        #region "SINGLETON"
        private static DTdepartamento dte = null;
        public DTdepartamento()
        {

        }

        public static DTdepartamento getInstance()
        {
            if (dte == null)
            {
                dte = new DTdepartamento();
            }
            return dte;
        }
        #endregion

        //CONSTANTES DE CONEXIÓN Y COMANDO SQL
        SqlConnection c = new SqlConnection();
        SqlCommand comando = null;

        public SqlDataReader listardepartamento()
        {
            c = Conexion.getInstance().ConexionDB();
            String sql = "select Id_departamento , Departamento  from T_Departamento;";

            SqlCommand comando = new SqlCommand(sql, this.c);
            this.registros = comando.ExecuteReader();
            return this.registros;
            c.Close();
        }
    }
}