function edit(codigo, fecha, analisis, muestra, observaciones, boucher, estado) {
    document.getElementById('MainContent_Mcodigo').value = codigo;
    document.getElementById('MainContent_Mfecha').value = fecha;
    document.getElementById('MainContent_Manalisis').value = analisis;
    document.getElementById('MainContent_Mmuestra').value = muestra;
    document.getElementById('MainContent_Mobservaciones').value = observaciones;
    document.getElementById('MainContent_Mbaucher').value = boucher;
    document.getElementById('MainContent_Mestado').value = estado;
}
var table;
$(document).ready(function () {
    var table = $('#bootstrap-data-table').DataTable({
        "bDestroy": true,
        "paging": false,
        "ordering": false,
        "info": false
    });


    $('#bootstrap-data-table tbody').on('click', '#btn', function () {
        var data = table.row($(this).parents("tr")).data();

        //Mandar datos al textbox
        var id = data[0],
            nombre = data[1] + " " + data[2],
            cedula = data[3];
        $("input[id$='Mcliente']").val(nombre),
        $("input[id$='Id_cliente']").val(id);
        $("input[id$='Mcedula']").val(cedula);
        swal({
            title: "Cliente Agregado a la Orden",
            text: "Usted a seleccionado al cliente: \n" + nombre,
            icon: "info",
            buttons: false,
            timer: 2600,
        });
    })
});
