function edit(codigo, padre, hijo, fecha, tipocaso, observaciones, boucher, estado) {
    document.getElementById('head_Mcodigomadre').value = codigo;
    document.getElementById('head_Mnombremadre').value = padre;
    document.getElementById('head_Mnombrehijomadre').value = hijo;
    document.getElementById('head_Mfechamaternidad').value = fecha;
    document.getElementById('head_Mtipocasomadre').value = tipocaso;
   
    document.getElementById('head_Mobservacionesmadre').value = observaciones;
    document.getElementById('head_baouchermaternidad').value = boucher;
    document.getElementById('head_Mestadomaternidad').value = estado;
}

function eliminar(url) {
    if (window.confirm('estas seguro?')) {

        window.location = url;

    }
}