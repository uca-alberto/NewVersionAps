using System.Data.SqlClient;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;

namespace WebSistemaCentroBiologiaMolecularUCA.Ncapas.Negocio
{
    public class NGresultado
    {

        //PATRÓN SINGLETON
        #region "SINGLETON"
        private static NGresultado emp = null;

        private NGresultado()
        {
        }

        public static NGresultado getInstance()
        {
            if (emp == null)
            {
                emp = new NGresultado();
            }
            return emp;
        }
        #endregion

        public bool guardarresultado(Resultado resultado)
        {
            return DTresultado.getInstance().crear(resultado);
        }

        public bool Eliminarresultado(Resultado resultado)
        {
            return DTresultado.getInstance().eliminar(resultado);
        }

        public bool Modificarresultado(Resultado resultado)
        {
            return DTresultado.getInstance().modificar(resultado);
        }

        //Datos resultado
        public SqlDataReader ListardatosResultados(int id)
        {
            return DTresultado.getInstance().cargardatosporid(id);
        }
        //Datos Tabla
        public SqlDataReader Resultadostabla(int id)
        {
            return DTresultado.getInstance().getAnalisisporId(id);
        }
        //Datos usuario actual
        public SqlDataReader datosusuario(int id)
        {
            return DTresultado.getInstance().datousuario(id);
        }

        public SqlDataReader resultados(int id)
        {
            return DTresultado.getInstance().getresultadoporid(id);
        }
        public SqlDataReader visualizartabla(int id)
        {
            return DTresultado.getInstance().visualizartabla(id);
        }
    }
}