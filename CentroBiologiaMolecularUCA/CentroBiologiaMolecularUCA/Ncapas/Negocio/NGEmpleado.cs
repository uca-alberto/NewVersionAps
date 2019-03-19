﻿using CentroBiologiaMolecularUCA.Ncapas.Datos;
using CentroBiologiaMolecularUCA.Ncapas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;

namespace CentroBiologiaMolecularUCA.Ncapas.Negocio
{
    public class NGEmpleado
    {
        //PATRÓN SINGLETON
        #region "SINGLETON"
        private static NGEmpleado emp = null;
        private NGEmpleado()
        {

        }

        public static NGEmpleado getInstance()
        {
            if (emp == null)
            {
                emp = new NGEmpleado();
            }
            return emp;
        }
        #endregion

        public bool guardarempleado(Empleado empleado)
        {
            return DTEmpleados.getInstance().crear(empleado);
        }
        public bool Eliminarempleado(Empleado empleado)
        {
            return DTEmpleados.getInstance().eliminar(empleado);
        }
        public bool Modificarempleado(Empleado empleado)
        {
            return DTEmpleados.getInstance().modificar(empleado);
        }
    }
}