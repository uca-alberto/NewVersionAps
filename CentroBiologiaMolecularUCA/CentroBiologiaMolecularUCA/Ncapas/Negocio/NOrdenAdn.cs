using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;

namespace WebSistemaCentroBiologiaMolecularUCA.Ncapas.Negocio
{
    public class NOrdenAdn
    {
        //PATRÓN SINGLETON
        #region "SINGLETON"
        private static NOrdenAdn ord = null;
        private NOrdenAdn()
        {

        }

        public static NOrdenAdn getInstance()
        {
            if (ord == null)
            {
                ord = new NOrdenAdn();
            }
            return ord;
        }
        #endregion
        public bool guardarord(OrdenAdn ord)
        {
            return TOrdenAdn.getInstance().crear(ord);
        }

        public bool eliminarord(OrdenAdn ord)
        {
            return TOrdenAdn.getInstance().eliminar(ord);
        }

        public bool modificarord(OrdenAdn ord)
        {
            return TOrdenAdn.getInstance().modificar(ord);
        }
    }
}