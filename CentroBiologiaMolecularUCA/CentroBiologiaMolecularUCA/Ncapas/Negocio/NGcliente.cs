using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        public NGcliente()
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
        public SqlDataReader ListarDepartamento()
        {
            return DTdepartamento.getInstance().listardepartamento();
        }
        public SqlDataReader ListarMunicipio()
        {
            return DTmunicipio.getInstance().listarmunicipio();
        }
        public SqlDataReader ListarMunicipioPorId(int id)
        {
            return DTmunicipio.getInstance().getmunicipioporid(id);
        }
		public List<Cliente> Data()
		{
			return DTcliente.getInstance().GetData();
		}
		public SqlDataReader ListarClientePorId(int id)
		{
			return DTcliente.getInstance().getClienteporid(id);
		}
	}
}