function edit(nombre, rol) {

    document.getElementById('MainContent_Mnombre').value = nombre;
    document.getElementById('MainContent_Mrol1').value = rol;


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
        $("input[id$='Musuario']").val(nombre),
        $("input[id$='Idempleado']").val(id);
        $("input[id$='Mcedula']").val(cedula);
        swal({
            title: "Empleado Agregado",
            text: "Usted a seleccionado al empleado: \n" + nombre,
            icon: "info",
            buttons: false,
            timer: 2600,
        });
    })
});