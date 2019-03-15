using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;

namespace WebSistemaCentroBiologiaMolecularUCA.Ncapas.Negocio
{
    public class NGorden
    {
        //PATRÓN SINGLETON
        #region "SINGLETON"
        private static NGorden ord = null;
        private NGorden()
        {

        }

        public static NGorden getInstance()
        {
            if (ord == null)
            {
                ord = new NGorden();
            }
            return ord;
        }
        #endregion

        //Orden Detalle
        public bool guardardetalle(OrdenAdn ord)
        {
            return TOrden.getInstance().creardetalle(ord);
        }
        //Modificar Detalle
        public bool modificardetalle(OrdenAdn ord)
        {
            return TOrden.getInstance().modificardetalle(ord);
        }
        //Eliminar Detalle
        public bool eliminardetalle(OrdenAdn ord)
        {
            return TOrden.getInstance().eliminardetalle(ord);
        }

        //Agregar Orden
        public bool guardarord(OrdenAdn ord)
        {
            return TOrden.getInstance().crear(ord);
        }

        public bool eliminarord(OrdenAdn ord)
        {
            return TOrden.getInstance().eliminar(ord);
        }

        public bool modificarord(OrdenAdn ord)
        {
            return TOrden.getInstance().modificar(ord);
        }
    }
}