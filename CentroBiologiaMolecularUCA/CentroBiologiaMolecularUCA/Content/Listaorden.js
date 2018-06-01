function edit(tipo_caso, tipo_orden, observaciones, baucher, numero, estado, fecha) {


    document.getElementById('MainContent_Mtipocaso').value = tipo_caso;
    document.getElementById('MainContent_Mtipoorden').value = tipo_orden;
    document.getElementById('MainContent_Mobservaciones').value = observaciones;
    document.getElementById('MainContent_Mbaucher').value = baucher;
    document.getElementById('MainContent_Mnoorden').value = numero;
    document.getElementById('MainContent_Mestado').value = estado;
    document.getElementById('MainContent_Mfecha').value = fecha;
}

function Eliminar(url) {
    if (window.confirm('estas seguro?')) {

        window.toLocaleString = url;

    }
}