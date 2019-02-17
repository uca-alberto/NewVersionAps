﻿using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;
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
    }
}