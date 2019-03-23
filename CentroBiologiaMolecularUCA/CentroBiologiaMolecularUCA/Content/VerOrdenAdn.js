function edit(codigo, padre, hijo, fecha, tipocaso, observaciones, boucher, estado) {
    document.getElementById('head_Mcodigo').value = codigo;
    document.getElementById('head_Mnombrepareja').value = padre;
    document.getElementById('head_Mnombrehijo').value = hijo;
    document.getElementById('head_Mfecha').value = fecha;
    document.getElementById('head_Mtipocaso').value = tipocaso;
   
    document.getElementById('head_Mobservaciones').value = observaciones;
    document.getElementById('head_Mbaucher').value = boucher;
    document.getElementById('head_Mestado').value = estado;
}
 
function eliminar(url) {

    if (window.confirm()) {
        window.Location = url;
    }

}