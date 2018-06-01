function edit(fecha, validacion, resultado, estado, usuario_procesa, usuario_valida, analisis) {


    document.getElementById('MainContent_Mfecha').value = fecha;
    document.getElementById('MainContent_Mvalidacion').value = validacion;
    document.getElementById('MainContent_Mresultado').value = resultado;
    document.getElementById('MainContent_Mestado').value = estado;
    document.getElementById('MainContent_Musuarioprocesa').value = usuario_procesa;
    document.getElementById('MainContent_Musuariovalida').value = usuario_valida;

    document.getElementById('MainContent_Manalisis').value = analisis;






}

function Eliminar(url) {
    if (window.confirm('estas seguro?')) {

        window.toLocaleString = url;

    }
}