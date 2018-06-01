using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos
{
    public class DTmunicipio
    {
        private SqlDataReader registros;
        //PATRÓN SINGLETON
        #region "SINGLETON"
        private static DTmunicipio dte = null;
        public DTmunicipio()
        {

        }

        public static DTmunicipio getInstance()
        {
            if (dte == null)
            {
                dte = new DTmunicipio();
            }
            return dte;
        }
        #endregion

        //CONSTANTES DE CONEXIÓN Y COMANDO SQL
        SqlConnection c = new SqlConnection();
        SqlCommand comando = null;

        public SqlDataReader getmunicipioporid(int id)
        {
            c = Conexion.getInstance().ConexionDB();
            String sql = "select Id_municipio, Municipio from T_Municipio where Id_departamento ='" + id + "';";

            SqlCommand comando = new SqlCommand(sql, this.c);
            this.registros = comando.ExecuteReader();
            return this.registros;
            c.Close();
        }
        public SqlDataReader listarmunicipio()
        {
            c = Conexion.getInstance().ConexionDB();
            String sql = "select Id_municipio, Municipio from T_Municipio;";

            SqlCommand comando = new SqlCommand(sql, this.c);
            this.registros = comando.ExecuteReader();
            return this.registros;
            c.Close();
        }
    }
}