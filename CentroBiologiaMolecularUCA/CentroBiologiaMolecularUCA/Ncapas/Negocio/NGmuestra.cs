using CentroBiologiaMolecularUCA.Ncapas.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;

namespace CentroBiologiaMolecularUCA.Ncapas.Negocio
{

    public class NGmuestra
    {
        //PATRÓN SINGLETON
        #region "SINGLETON"
        private static NGmuestra emp = null;
        private NGmuestra()
        {

        }

        public static NGmuestra getInstance()
        {
            if (emp == null)
            {
                emp = new NGmuestra();
            }
            return emp;
        }
        #endregion

        public bool guardarMuestra(Muestra muestra)
        {
            return DTmuestra.getInstance().crear(muestra);
        }
        public bool ModificarMuestra(Muestra muestra)
        {
            return DTmuestra.getInstance().modificar(muestra);
        }
        public SqlDataReader ListarMuestra()
        {
            return DTmuestra.getInstance().listarmuestras();
        }
    }

}