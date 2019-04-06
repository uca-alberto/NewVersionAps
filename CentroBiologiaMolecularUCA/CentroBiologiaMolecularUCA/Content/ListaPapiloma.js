function edit(codigo, padre, hijo, fecha, tipocaso, observaciones, boucher) {
    document.getElementById('MainContent_Mcodigopapiloma').value = codigo;
    document.getElementById('MainContent_Mdoctorpapiloma').value = padre;
    document.getElementById('MainContent_Mpacientepapiloma').value = hijo;
    document.getElementById('MainContent_Mfechapapiloma').value = fecha;
    document.getElementById('MainContent_Mtipocasopapiloma').value = tipocaso;

    document.getElementById('MainContent_Mobservacionespapiloma').value = observaciones;
    document.getElementById('MainContent_Mboucherpapiloma').value = boucher;
    
}

function eliminar(url) {
    if (window.confirm('estas seguro?')) {

        window.location = url;

    }
}