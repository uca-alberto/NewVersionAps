function edit(codigo, padre, hijo, fecha, tipocaso, observaciones, boucher, estado) {
    document.getElementById('MainContent_Mcodigomadre').value = codigo;
    document.getElementById('MainContent_Mnombremadre').value = padre;
    document.getElementById('MainContent_Mnombrehijomadre').value = hijo;
    document.getElementById('MainContent_Mfechamaternidad').value = fecha;
    document.getElementById('MainContent_Mtipocasomadre').value = tipocaso;

    document.getElementById('MainContent_Mobservacionesmadre').value = observaciones;
    document.getElementById('MainContent_baouchermaternidad').value = boucher;
    document.getElementById('MainContent_Mestadomaternidad').value = estado;
}

function eliminar(url) {
    if (window.confirm('estas seguro?')) {

        window.location = url;

    }
}