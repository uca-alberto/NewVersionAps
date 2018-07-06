using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;

namespace WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos
{
    public class DTresultado : Igeneric<Resultado>
    {
        private SqlDataReader registros;
        //private Conexion c;
        //private SqlCommand comando;

        //PATRÓN SINGLETON

        #region "SINGLETON"
        public static DTresultado dte = null;
        public DTresultado()
        {

        }
        public static DTresultado getInstance()
        {
            if (dte == null)
            {
                dte = new DTresultado();
            }
            return dte;
        }

        #endregion
        //CONSTANTES DE CONEXIÓN Y COMANDO SQL
        SqlConnection c = new SqlConnection();
        SqlCommand comando = null;

        public bool crear(Resultado e)
        {
            bool guardado = false;
            try
            {
                //CONSULTA SQL
                c = Conexion.getInstance().ConexionDB();
                // string sql = "insert into T_Orden (Id_orden,Fecha,Entregado,Tipo_orden,Observaciones,Baucher,No_orden,Estado,Actividad) VALUES(2,@Mfecha,@Mentregado,@Mtipoorden,@Mobservaciones,@Mbaucher,@Mnoorden,@Mestado,1)";

                string sql = "insert into T_Resultados (Validacion,Fecha_procesamiento,Usuario_valida,Usuario_procesa,Estado,Analisis,Resultado,Actividad) VALUES(@Mvalidacion,@Mfecha,@Musuariovalida,@Musuarioprocesa,@Mestado,@Manalisis,@Mresultado,1)";
                //PASANDO PARÁMETROS A CONSULTA SQL
                using (comando = new SqlCommand(sql, c))
                {
                    comando.Parameters.AddWithValue("@Mvalidacion", e.Validacion);
                    comando.Parameters.AddWithValue("@Mfecha", e.Fecha_procesamiento);
                    comando.Parameters.AddWithValue("@Musuariovalida", e.Usuario_valida);
                    comando.Parameters.AddWithValue("@Musuarioprocesa", e.Usuario_procesa);
                    comando.Parameters.AddWithValue("@Mestado", e.Estado);
                    comando.Parameters.AddWithValue("@Manalisis", e.Analisis);
                    comando.Parameters.AddWithValue("@Mresultado", e.Parametros);
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
                c.Close();
                c = null;
                throw;
            }
            finally
            {
                //LUEGO DE REALIZAR LA SENTENCIA SQL
                //CERRAMOS LA CONEXIÓN A LA BASE DE DATOS
                comando.Connection.Close();
                c.Close();
                c = null;
            }

            return guardado;

        }

        public bool modificar(Resultado e)
        {
            bool guardado = false;
            try
            {
                //CONSULTA SQL
                c = Conexion.getInstance().ConexionDB();
                string sql = "update T_Resultados set Validacion=(@Mvalidacion),Fecha_procesamiento=(@Mfecha),Usuario_valida=(@Musuariovalida),Usuario_procesa=(@Musuarioprocesa),Estado=(@Mestado),Analisis=(@Manalisis),Resultado=(@Mresultado) where Id_resultado=(@mid)";

                //PASANDO PARÁMETROS A CONSULTA SQL
                using (comando = new SqlCommand(sql, c))
                {
                    comando.Parameters.AddWithValue("@mid", e.Id_resultado);
                    comando.Parameters.AddWithValue("@Mvalidacion", e.Validacion);
                    comando.Parameters.AddWithValue("@Mfecha", e.Fecha_procesamiento);
                    comando.Parameters.AddWithValue("@Musuariovalida", e.Usuario_valida);
                    comando.Parameters.AddWithValue("@Musuarioprocesa", e.Usuario_procesa);
                    comando.Parameters.AddWithValue("@Mestado", e.Estado);
                    comando.Parameters.AddWithValue("@Manalisis", e.Analisis);
                    comando.Parameters.AddWithValue("@Mresultado", e.Parametros);
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
                c.Close();
                c = null;
                throw;
            }
            finally
            {
                //LUEGO DE REALIZAR LA SENTENCIA SQL
                //CERRAMOS LA CONEXIÓN A LA BASE DE DATOS
                comando.Connection.Close();
                c.Close();
                c = null;
            }

            return guardado;
        }

        public bool eliminar(Resultado re)
        {
            bool guardado = false;
            try
            {
                //CONSULTA SQL
                c = Conexion.getInstance().ConexionDB();
                string sql = "update T_Resultados set Actividad=0 where Id_resultado=(@mid)";

                //PASANDO PARÁMETROS A CONSULTA SQL
                using (comando = new SqlCommand(sql, c))
                {

                    comando.Parameters.AddWithValue("@mid", re.Id_resultado);
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
                            Console.WriteLine("ERROR AL ELIMINAR DATOS");
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
                c.Close();
                c = null;
                throw;
            }
            finally
            {
                //LUEGO DE REALIZAR LA SENTENCIA SQL
                //CERRAMOS LA CONEXIÓN A LA BASE DE DATOS
                comando.Connection.Close();
                c.Close();
                c = null;
            }

            return guardado;
        }

        public SqlDataReader listarTodo()
        {
            c = Conexion.getInstance().ConexionDB();
            String sql = "select * from T_Resultados where Actividad = 1;";

            SqlCommand comando = new SqlCommand(sql, this.c);
            this.registros = comando.ExecuteReader();
            return this.registros;
            c.Close();
        }

        public SqlDataReader getresultadoporid(int id)
        {
            c = Conexion.getInstance().ConexionDB();
            String sql = "select  Validacion, Fecha_procesamiento, Usuario_valida, Usuario_procesa, Estado, Analisis, Resultado from T_Resultados where Id_resultado='" + id + "';";

            SqlCommand comando = new SqlCommand(sql, this.c);
            this.registros = comando.ExecuteReader();
            return this.registros;
            c.Close();
        }

        List<Resultado> Igeneric<Resultado>.listarTodo()
        {
            throw new NotImplementedException();
        }
    }
}