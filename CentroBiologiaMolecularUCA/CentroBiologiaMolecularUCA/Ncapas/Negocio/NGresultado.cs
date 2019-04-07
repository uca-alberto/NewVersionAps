using System.Collections.Generic;
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

        public bool guardaradnresultado(Resultado resultado)
        {
            return DTresultado.getInstance().crearAdn(resultado);
        }

        public bool Eliminar(Resultado resultado)
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
        //Datos Agregar Resultado
        public SqlDataReader verResultados(int id)
        {
            return DTresultado.getInstance().verdatosresultados(id);
        }

        //Datos Agregar Resultado ADN
        public SqlDataReader verResultadosadn(int id)
        {
            return DTresultado.getInstance().verdatosresultadosadn(id);
        }
        //Datos Tabla ver resultados
        public SqlDataReader Resultadostabla(int id)
        {
            return DTresultado.getInstance().getAnalisisporId(id);
        }
        //Datos tabla Agregar
        public SqlDataReader getanalisispororden(int id)
        {
            return DTresultado.getInstance().getAnalisisporIdorden(id);
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
        public List<Resultado> getData()
        {
            return DTresultado.getInstance().GetData();
        }

        //Detalle
        public bool creardetalle(Resultado resultado)
        {
            return DTresultado.getInstance().creardetalle(resultado);
        }
        public bool procesarorden(Resultado resultado)
        {
            return DTresultado.getInstance().ordenprocesada(resultado);
        }

        public int idresultado()
        {
            return DTresultado.getInstance().ultimoid();
        }
        public SqlDataReader getanalisis(int id)
        {
            return DTresultado.getInstance().getAnalisisporId(id);
        }

        public SqlDataReader ListardatosResultadosadn(int id)
        {
            return DTresultado.getInstance().cargardatosadnporid(id);
        }
    }
}