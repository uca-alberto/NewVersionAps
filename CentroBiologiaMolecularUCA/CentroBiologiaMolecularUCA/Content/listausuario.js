function edit(nombre, rol) {

    document.getElementById('MainContent_Mnombre').value = nombre;
    document.getElementById('MainContent_Mrol1').value = rol;
   

}

function Eliminar(url) {
    if (window.confirm('estas seguro?')) {

        window.toLocaleString = url;

    }
}