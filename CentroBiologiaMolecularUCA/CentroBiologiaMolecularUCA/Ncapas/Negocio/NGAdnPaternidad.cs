using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;

namespace CentroBiologiaMolecularUCA.Ncapas.Negocio
{
    public class NGAdnPaternidad
    {
        public bool guardarord(OrdenAdn ord)
        {

            return DTAdnPaternidad.getInstance().crear(ord);
        }

        public bool eliminarord(OrdenAdn ord)
        {
            return DTAdnPaternidad.getInstance().eliminar(ord);
        }

        public bool modificarord(OrdenAdn ord)
        {
            return DTAdnPaternidad.getInstance().modificar(ord);
        }
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