using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
                    //string hash = EncodePassword(string.Concat(usuario, password));
                    comando.Parameters.AddWithValue("@password", password);//QUITE EL HASH

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
                    //string hash = EncodePassword(string.Concat(usuario, password));
                    comando.Parameters.AddWithValue("@password", password); //QUITE EL HASH


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

        public static string EncodePassword(string originalPassword)
        {
            //Clave para encriptar la contraseña
            string clave = "7f9facc418f74439c5e9709832;0ab8a5:OCOdNSW1,q8SLIQz8i|8agmu¬s13Q7ZXyno/";
            //Se instancia el objeto para luego calcular la matriz de BYTES
            SHA512 sha512 = new SHA512CryptoServiceProvider();

            //Se cre un arreglo donde la password, el usuario y la clave se vuelven en BYTES
            byte[] inputBytes = (new UnicodeEncoding()).GetBytes(originalPassword + clave);
            //Se calcula la matriz de bytes y se encripta 
            byte[] hash = sha512.ComputeHash(inputBytes);
            //Lo convertimos en cadena y se devuelve
            return Convert.ToBase64String(hash);
        }
    }
}