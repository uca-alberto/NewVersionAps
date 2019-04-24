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
            String sql = "SELECT * FROM T_Parametros where Id_examenes=5;";

            SqlCommand comando = new SqlCommand(sql, this.c);
            this.registros = comando.ExecuteReader();
            return this.registros;
            c.Close();
        }


        public SqlDataReader listarvphbajo()
        {
            c = Conexion.getInstance().ConexionDB();
            String sql = "SELECT Id_parametros,Nombre AS VPH_Bajo FROM T_Parametros where Id_examenes=6 AND Id_parametros<=15;";

            SqlCommand comando = new SqlCommand(sql, this.c);
            this.registros = comando.ExecuteReader();
            return this.registros;
            c.Close();
        }
        public SqlDataReader listarvphalto()
        {
            c = Conexion.getInstance().ConexionDB();
            String sql = "SELECT Id_parametros,Nombre AS VPH_Alto FROM T_Parametros where Id_examenes=6 AND Id_parametros>15;";

            SqlCommand comando = new SqlCommand(sql, this.c);
            this.registros = comando.ExecuteReader();
            return this.registros;
            c.Close();
        }
    }
}