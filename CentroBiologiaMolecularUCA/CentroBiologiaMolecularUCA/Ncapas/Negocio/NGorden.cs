using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        //CARGAR COMBO BOX Y CHECKBOX
        public SqlDataReader ListarMuestras()
        {
            return DTmuestra.getInstance().listarmuestras();
        }
        public SqlDataReader ListarAnalisis()
        {
            return DTanalisis.getInstance().listaranalisis();
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
        //Llenar Checkbox
        public SqlDataReader Listarexamen(int id)
        {
            return TOrden.getInstance().getAnalisisporId(id);
        }
        public string GenerarCodigo()
        {
            return TOrden.getInstance().generarCodigo();
        }
        public int UltimoId()
        {
            return TOrden.getInstance().ultimoid();
        }

        public SqlDataReader Ordenporid(int id)
        {
            return TOrden.getInstance().getOrdenporid(id);
        }
        public List<OrdenAdn> getData()
        {
            return TOrden.getInstance().GetData();
        }

    }
}