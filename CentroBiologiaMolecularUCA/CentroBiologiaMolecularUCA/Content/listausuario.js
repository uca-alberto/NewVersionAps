function edit(nombre, contraseña, rol) {

    document.getElementById('MainContent_Mnombre').value = nombre;
    document.getElementById('MainContent_Mcontrasena').value = contraseña;
    document.getElementById('MainContent_Mrol').value = rol;

}

function Eliminar(url) {
    if (window.confirm('estas seguro?')) {

        window.toLocaleString = url;

    }
}