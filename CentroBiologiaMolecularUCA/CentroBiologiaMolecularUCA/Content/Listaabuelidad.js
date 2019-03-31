function edit(codigo, padre, hijo, fecha, tipocaso, observaciones, boucher, estado) {
    document.getElementById('MainContent_Mcodigoabuela').value = codigo;
    document.getElementById('MainContent_Mnombredelaabuela').value = padre;
    document.getElementById('MainContent_Mnombrenieto').value = hijo;
    document.getElementById('MainContent_Mfechaabuelidad').value = fecha;
    document.getElementById('MainContent_Mtipocasoabuelidad').value = tipocaso;

    document.getElementById('MainContent_Mobservacionesabuelidad').value = observaciones;
    document.getElementById('MainContent_Mboucherabuelidad').value = boucher;
    document.getElementById('MainContent_Mestadoabuelidad').value = estado;
}

function eliminar(url) {
    if (window.confirm('estas seguro?')) {

        window.location = url;

    }
}