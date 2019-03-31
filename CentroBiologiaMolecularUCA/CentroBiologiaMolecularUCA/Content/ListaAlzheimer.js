function edit(codigo, padre, hijo, fecha, tipocaso, observaciones, boucher, estado) {
    document.getElementById('MainContent_Mcodigoalzheimer').value = codigo;
    document.getElementById('MainContent_Mnombredeldoctor').value = padre;
    document.getElementById('MainContent_Mnombredelpaciente').value = hijo;
    document.getElementById('MainContent_Mfechaalzheimer').value = fecha;
    document.getElementById('MainContent_Mtipocasoalzheimer').value = tipocaso;

    document.getElementById('MainContent_Mobservacionesalzheimer').value = observaciones;
    document.getElementById('MainContent_Mboucheralzheimer').value = boucher;
    document.getElementById('MainContent_Mestadoalzheimer').value = estado;
}

function eliminar(url) {
    if (window.confirm('estas seguro?')) {

        window.location = url;

    }
}