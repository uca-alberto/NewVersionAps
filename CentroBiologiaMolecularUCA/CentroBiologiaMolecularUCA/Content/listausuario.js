function edit(nombre, rol) {

    document.getElementById('ContentPlaceHolder1_Mnombre').value = nombre;
    document.getElementById('ContentPlaceHolder1_Mrol').value = rol;
   

}

function Eliminar(url) {
    if (window.confirm('estas seguro?')) {

        window.toLocaleString = url;

    }
}