using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;

namespace CentroBiologiaMolecularUCA.Ncapas.Negocio
{
    public class NGAdnPaternidad
    {
        //PATRÓN SINGLETON
        #region "SINGLETON"
        private static NGAdnPaternidad emp = null;
        private NGAdnPaternidad()
        {

        }

        public static NGAdnPaternidad getInstance()
        {
            if (emp == null)
            {
                emp = new NGAdnPaternidad();
            }
            return emp;
        }
        #endregion   
    }
}