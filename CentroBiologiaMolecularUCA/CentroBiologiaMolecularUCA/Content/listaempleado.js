function edit(Cargo,  Cedula, Nombre_empleado, Apellido) {

    document.getElementById('ContentPlaceHolder1_Mcargo').value = Cargo;
    document.getElementById('ContentPlaceHolder1_Mcedula').value = Cedula;
    document.getElementById('ContentPlaceHolder1_Mnombre').value = Nombre_empleado;
    document.getElementById('ContentPlaceHolder1_Mapellido').value = Apellido;
    


}

function Eliminar(url) {
    if (window.confirm('estas seguro?')) {

        window.toLocaleString = url;

    }
}