using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos
{
    public class DTlogin
    {
        //PATRÓN SINGLETON
        #region "SINGLETON"
        private static DTlogin dtl = null;
        public DTlogin()
        {

        }

        public static DTlogin getInstance()
        {
            if (dtl == null)
            {
                dtl = new DTlogin();
            }
            return dtl;
        }
        #endregion
        SqlConnection c = new SqlConnection();
        SqlCommand comando = null;

        public bool Autenticar(string usuario, string password)
        {
            bool autentico = false;
            //Declaramos la sentencia SQL 
            string sql = @"SELECT COUNT(*)
                         FROM T_Usuario
                         WHERE Nombre_Usuario = @usuario AND Contrasena = @password";
            c = Conexion.getInstance().ConexionDB();

            //Se utiliza Using para indicarle al compilador que este bloque se llame al metodo dispose

            try
            {

                using (comando = new SqlCommand(sql, c))
                {

                    comando.Parameters.AddWithValue("@usuario", usuario);
                    comando.Parameters.AddWithValue("@password", password);

                    int count = Convert.ToInt32(comando.ExecuteScalar());


                    if (count != 0)
                    {
                        autentico = true;
                    }


                    if (comando.Connection.State != System.Data.ConnectionState.Closed)
                    {
                        //EJECUTANDO SENTENCIA SQL CON EXECUTENONQUERY
                        int result = comando.ExecuteNonQuery();

                        /* 
                         * EL BLOQUE IF SIRVE PARA HACER UNA VALIDACIÓN DEL EXECUTENONQUERY
                         * DICHO MÉTODO DEVUELVE UN ENTERO, DONDE 0 ES QUE NO AFECTO NINGUNA FILA
                         * SI ES MAYOR A 0 (POSITIVO)
                         * QUIERE DECIR QUE SE GUARDARON DATOS EN LA BASE DE DATOS
                         */


                        if (result < 0)
                        {

                            Console.WriteLine("ERROR AL INSERTAR DATOS");
                        }
                        else
                        {
                            comando.Connection.Open();
                        }
                    }

                }



            }
            catch
            {
                comando.Connection.Close();
                c.Close();
                c = null;
                throw;
            }
            finally
            {
                comando.Connection.Close();
                c.Close();
                c = null;
            }


            return autentico;
        }

        public DataTable prConsultaUsuario(string usuario, string password)
        {
            string sql = @"SELECT Id_usuario FROM T_Usuario WHERE Nombre_Usuario = @usuario AND Contrasena = @password";
            DataTable dtDatos = null;
            c = Conexion.getInstance().ConexionDB();
            try
            {
                using (comando = new SqlCommand(sql, c))
                {
                    comando.Parameters.AddWithValue("@usuario", usuario);
                    comando.Parameters.AddWithValue("@password", password);


                    SqlDataAdapter dtAdaptador = new SqlDataAdapter(comando);
                    dtDatos = new DataTable();
                    dtAdaptador.Fill(dtDatos);
                    return dtDatos;
                }
            }
            catch
            {
                comando.Connection.Close();
                c.Close();
                c = null;
                throw;
            }
            finally
            {
                comando.Connection.Close();
                c.Close();
                c = null;

            }

            return dtDatos;
        }
    }
}