function edit(codigo, padre, hijo, fecha, tipocaso, observaciones, boucher) {
    document.getElementById('MainContent_Mcodigo').value = codigo;
    document.getElementById('MainContent_Mnombrepareja').value = padre;
    document.getElementById('MainContent_Mnombrehijo').value = hijo;
    document.getElementById('MainContent_Mfecha').value = fecha;
    document.getElementById('MainContent_Mtipocaso').value = tipocaso;
    
    document.getElementById('MainContent_Mobservaciones').value = observaciones;
    document.getElementById('MainContent_Mbaucher').value = boucher;
   
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

function eliminar(url) {
    if (window.confirm('estas seguro?')) {

        window.location = url;

    }
}