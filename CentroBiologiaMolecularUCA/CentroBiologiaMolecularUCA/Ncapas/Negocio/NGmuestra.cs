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
        public List<Muestra> ListarMuestra()
        {
            return DTmuestra.getInstance().GetData();
        }
        public SqlDataReader Listaranalisis()
        {
            return DTanalisis.getInstance().listaranalisis();
        }
        public SqlDataReader Listarmuestraporid(int id)
        {
            return DTmuestra.getInstance().getmuestraporid(id);
        }
    }

}