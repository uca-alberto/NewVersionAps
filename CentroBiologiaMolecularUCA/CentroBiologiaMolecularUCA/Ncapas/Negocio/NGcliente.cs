using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;

namespace WebSistemaCentroBiologiaMolecularUCA.Ncapas.Negocio
{
    public class NGcliente
    {
        //PATRÓN SINGLETON
        #region "SINGLETON"
        private static NGcliente emp = null;
        private NGcliente()
        {

        }

        public static NGcliente getInstance()
        {
            if (emp == null)
            {
                emp = new NGcliente();
            }
            return emp;
        }
        #endregion

        public bool guardarcliente(Cliente cliente)
        {
            return DTcliente.getInstance().crear(cliente);
        }
        public bool Eliminarcliente(Cliente cliente)
        {
            return DTcliente.getInstance().eliminar(cliente);
        }
        public bool Modificarcliente(Cliente cliente)
        {
            return DTcliente.getInstance().modificar(cliente);
        }
    }
}