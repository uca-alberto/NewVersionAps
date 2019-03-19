﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;

namespace WebSistemaCentroBiologiaMolecularUCA.Ncapas.Negocio
{
    public class NGExamen
    {
        //PATRÓN SINGLETON
        #region "SINGLETON"
        private static NGExamen emp = null;
        private NGExamen()
        {

        }

        public static NGExamen getInstance()
        {
            if (emp == null)
            {
                emp = new NGExamen();
            }
            return emp;
        }
        #endregion

        public bool guardarexamen(Examen examen)
        {
            return DTexamenes.getInstance().crear(examen);
        }
        public bool Modificarexamen(Examen examen)
        {
            return DTexamenes.getInstance().modificar(examen);
        }
    }
}