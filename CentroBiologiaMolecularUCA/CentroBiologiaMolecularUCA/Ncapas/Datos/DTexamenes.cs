using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos
{
    public class DTexamenes
    {
        private SqlDataReader registros;
        //PATRÓN SINGLETON
        #region "SINGLETON"
        private static DTexamenes dte = null;
        public DTexamenes()
        {

        }

        public static DTexamenes getInstance()
        {
            if (dte == null)
            {
                dte = new DTexamenes();
            }
            return dte;
        }
        #endregion

        //CONSTANTES DE CONEXIÓN Y COMANDO SQL
        SqlConnection conexion = new SqlConnection();
        SqlCommand comando = null;

        public bool crear(Entidades.Examen e)
        {
            bool guardado = false;
            try
            {
                //CONSULTA SQL
                conexion = Conexion.getInstance().ConexionDB();
                // string sql = "insert into T_Orden (Id_orden,Fecha,Entregado,Tipo_orden,Observaciones,Baucher,No_orden,Estado,Actividad) VALUES(2,@Mfecha,@Mentregado,@Mtipoorden,@Mobservaciones,@Mbaucher,@Mnoorden,@Mestado,1)";

                string sql = "insert into T_Examenes (Nombre, Precio_examen,Estado) VALUES(@Mnombre, @Mprecio,1)";
                //PASANDO PARÁMETROS A CONSULTA SQL
                using (comando = new SqlCommand(sql, conexion))
                {

                    comando.Parameters.AddWithValue("@Mnombre", e.nombre);
                    comando.Parameters.AddWithValue("@Mprecio", e.precio_examen);

                    //VALIDANDO SI LA CONEXIÓN ESTÁ ACTIVA O CERRADA
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
                            guardado = false;
                            Console.WriteLine("ERROR AL INSERTAR DATOS");
                        }
                        else
                        {
                            guardado = true;
                        }
                    }
                    else
                    {
                        comando.Connection.Open();

                    }
                }
            }
            catch (Exception)
            {
                comando.Connection.Close();
                conexion.Close();
                conexion = null;
                throw;
            }
            finally
            {
                //LUEGO DE REALIZAR LA SENTENCIA SQL
                //CERRAMOS LA CONEXIÓN A LA BASE DE DATOS
                comando.Connection.Close();
                conexion.Close();
                conexion = null;
            }

            return guardado;

        }

        public bool modificar(Entidades.Examen e)
        {
            bool guardado = false;
            try
            {
                //CONSULTA SQL
                conexion = Conexion.getInstance().ConexionDB();
                string sql = "update T_Examenes set Nombre=(@Mnombre), Precio_examen=(@Mprecio_examenes) where Id_examenes = (@mid_examenes)";

                //PASANDO PARÁMETROS A CONSULTA SQL
                using (comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@Mid_examenes", e.id_examenes);
                    comando.Parameters.AddWithValue("@Mnombre", e.nombre);
                    comando.Parameters.AddWithValue("@Mprecio_examenes", e.precio_examen);

                    //VALIDANDO SI LA CONEXIÓN ESTÁ ACTIVA O CERRADA
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
                            guardado = false;
                            Console.WriteLine("ERROR AL INSERTAR DATOS");
                        }
                        else
                        {
                            guardado = true;
                        }
                    }
                    else
                    {
                        comando.Connection.Open();

                    }
                }
            }
            catch (Exception)
            {
                comando.Connection.Close();
                conexion.Close();
                conexion = null;
                throw;
            }
            finally
            {
                //LUEGO DE REALIZAR LA SENTENCIA SQL
                //CERRAMOS LA CONEXIÓN A LA BASE DE DATOS
                comando.Connection.Close();
                conexion.Close();
                conexion = null;
            }

            return guardado;
        }

        public SqlDataReader listarexamenes()
        {
            conexion = Conexion.getInstance().ConexionDB();
            String sql = "select Id_examenes , Nombre, Precio_examen from T_Examenes where Estado=1;";

            SqlCommand comando = new SqlCommand(sql, this.conexion);
            registros = comando.ExecuteReader();
            return registros;
            conexion.Close();
        }

        public SqlDataReader getExamenporid(int id)
        {
            conexion = Conexion.getInstance().ConexionDB();
            String sql = "select Id_examenes, Nombre, Precio_examen from T_Examenes where Id_examenes='" + id + "';";

            SqlCommand comando = new SqlCommand(sql, this.conexion);
            this.registros = comando.ExecuteReader();
            return this.registros;
            conexion.Close();
        }
    }
}