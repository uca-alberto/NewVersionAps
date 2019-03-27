function edit(codigo, padre, hijo, fecha, tipocaso, observaciones, boucher, estado) {
    document.getElementById('MainContent_Mcodigo').value = codigo;
    document.getElementById('MainContent_Mnombrepareja').value = padre;
    document.getElementById('MainContent_Mnombrehijo').value = hijo;
    document.getElementById('MainContent_Mfecha').value = fecha;
    document.getElementById('MainContent_Mtipocaso').value = tipocaso;
   
    document.getElementById('MainContent_Mobservaciones').value = observaciones;
    document.getElementById('MainContent_Mbaucher').value = boucher;
    document.getElementById('MainContent_Mestado').value = estado;
}
 
function eliminar(url) {

    if (window.confirm()) {
        window.Location = url;
    }

}