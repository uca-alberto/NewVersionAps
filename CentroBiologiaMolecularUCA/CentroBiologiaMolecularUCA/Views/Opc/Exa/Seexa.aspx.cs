using System;
using System.Data.SqlClient;

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
            exam.id_examenes = id;

            //INVOCAMOS EL METODO BUSCAR EXAMEN POR ID
            this.registro = dtExamen.getExamenporid(id);
            Id_Examen.Value = valor;

            if (registro.Read())
            {
                //seteamos los datos de los campos de ese examen
                exam.precio_examen = Convert.ToDecimal(registro["Precio_examen"].ToString()); ;
                exam.nombre = registro["Nombre"].ToString();
              
            }
        }

    }
}
