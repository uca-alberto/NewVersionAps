using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;

namespace CentroBiologiaMolecularUCA.Views.OpcionesConfigurables
{
    public partial class VerExamen : System.Web.UI.Page
    {
        public DTexamenes dtExamen;
        public Examen exam;
        public SqlDataReader registro;

        protected void Page_Load(object sender, EventArgs e)
        {
            //CRECION DE LOS OBJETOS
            this.dtExamen = new DTexamenes();
            exam = new Examen();

            //OBTENCION DEL ID DE EXAMEN
            string valor = Request.QueryString["id"];
            int id = int.Parse(valor);
            exam.Id_examenes = id;

            //INVOCAMOS EL METODO BUSCAR EXAMEN POR ID
            this.registro = dtExamen.getExamenporid(id);
            Id_Examen.Value = valor;

            if (registro.Read())
            {
                //seteamos los datos de los campos de ese examen
                exam.Nombre = registro["Nombre"].ToString();

                exam.Precio_examen = int.Parse(this.registro["Precio_examen"].ToString());
            }
        }

    }
}
