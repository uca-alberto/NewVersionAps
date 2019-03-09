function edit(codigo, fecha, analisis, muestra, observaciones, boucher, estado) {
    document.getElementById('MainContent_Mcodigo').value = codigo;
    document.getElementById('MainContent_Mfecha').value = fecha;
    document.getElementById('MainContent_Manalisis').value = analisis;
    document.getElementById('MainContent_Mmuestra').value = muestra;
    document.getElementById('MainContent_Mobservaciones').value = observaciones;
    document.getElementById('MainContent_Mbaucher').value = boucher;
    document.getElementById('MainContent_Mestado').value = estado;
}
function Eliminar(id) {
    swal({
        title: "¿Estas Seguro?",
        text: "Eliminar Orden",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
    .then((willDelete) => {
        if (willDelete) {
            swal("La Orden ha sido Eliminada", {
                icon: "success",
            });
        } else {
            swal("Eliminacion Cancelada");
        }
    });
}

