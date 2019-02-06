$(function () {

    // Proxy created on the fly
    var job = $.connection.myHub;

//     Declare a function on the job hub so the server can invoke it
    job.client.displayStatus = function () {
        sendDataAjax()
    };

    // Start the connection
    $.connection.hub.start();
    sendDataAjax()
});

var data, tabla;
function addRowDT(data) {
    tabla = $("#bootstrap-data-table").DataTable();
    for (var i = 0; i < data.length; i++) {
        tabla.row.add([
           data[i].Id_Cliente,
           data[i].Nombres,
           data[i].Apellidos,
           data[i].Correo,
           '<button value="Actualizar" title="Actualizar" class="btn btn-primary btn-edit" data-target="#imodal" data-toggle="modal"><i class="fa fa-edit"></i></button>&nbsp;' +
           '<button value="Eliminar" title="Eliminar" class="btn btn-danger btn-delete"><i class="fa fa-trash-o"></i></button>'
        ]).draw(false);
    }
}
function sendDataAjax() {
    $.ajax({
        type: "POST",
        url: "BuscarCliente.aspx/GetData",
        data: {},
        contentType: "application/json; charset=utf-8",
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + "\n" + xhr.responseText, thrownError);
        },
        success: function (data) {
            console.log(data.d);
            addRowDT(data.d);

        }
    });
}

//Funcion para obtener los datos 
function sendDataAjax() {
    var $tblEncabezado = $('#Body');
    var $tblContenido = $('#contenidoTabla');
    $.ajax({
        type: "POST",
        url: "BuscarCliente.aspx/GetData",
        data: {},
        contentType: "application/json; charset=utf-8",
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + "\n" + xhr.responseText, thrownError);
        },
        success: function (data) {
            //console.log(data.d);
            // addRowDT(data.d);
            if (data.d.length > 0) {
                var newdata = data.d;

                $tblEncabezado.empty();
                $tblEncabezado.append('<tr><th scope="col">Código</th><th scope="col">Nombres</th><th scope="col">Apellidos</th><th scope="col">Correo Electrónico</th><th scope="col">Opciones</th></tr>');

                $tblContenido.empty();
                var rows = [];
                for (var i = 0; i < newdata.length; i++) {

                    rows.push('<tr><th scope="row">' + newdata[i].Id_Cliente + '</th><td>' + newdata[i].Nombres + '</td><td>' + newdata[i].Apellidos + '</td><td>' + newdata[i].Correo + '</td><td><a title="Mostrar" href="VerCliente.aspx?id=' + newdata[i].Id_Cliente + '"><i class="ti-eye"></i></a><a title="Editar" href="EditarCliente.aspx?id=' + newdata[i].Id_Cliente + '"><i class="ti-pencil-alt"></i></a><a value="Eliminar" id="Eliminar" ><i class="fa fa-trash-o"></i></a> </td></tr>');
                }
                $tblContenido.append(rows.join(''));
            }

        }
    });
}



//EVENTO PARA BOTON ELIMINAR
$(document).on('click', '.Eliminar', function (e) {
    e.preventDefault();
    var dataRow = tabla.rows($(this).parents('tr')).data()[0];
    console.log(dataRow[0])
    //Enviar código al servidor
    //ENVIAR EL ID POR MEDIO DE AJAX
    deleteDataAjax(dataRow[0]);
    //RENDERIZAR EL DATATABLE
    tabla.clear().draw();
    sendDataAjax();
});


//LLAMANDO A LA FUNCION AJAX AL CARGAR DOCUMENTO
sendDataAjax();