using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos
{
    interface Igeneric<clase>
    {
        bool crear(clase obj);
        bool modificar(clase obj);
        bool eliminar(clase obj);
        //clase Listar(clase obj);
        List<clase> listarTodo();
    }
}