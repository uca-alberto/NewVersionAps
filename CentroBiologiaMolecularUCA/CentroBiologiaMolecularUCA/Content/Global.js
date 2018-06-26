$(function () {

           // Proxy created on the fly
           var job = $.connection.myHub;

           // Declare a function on the job hub so the server can invoke it
           job.client.displayStatus = function () {
               getData();
           };

           // Start the connection
           $.connection.hub.start();
           getData();
       });

function getData() {
    var $tblEncabezado = $('#encabezadoTabla');
    var $tblContenido = $('#contenidoTabla');
    $.ajax({
        url: 'BuscarCliente.aspx/GetData',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        type: "POST",
        success: function (data) {
            debugger;
            if (data.d.length > 0) {
                var newdata = data.d;

                $tblEncabezado.empty();
                $tblEncabezado.append('<tr><th scope="col">Código</th><th scope="col">Nombres</th><th scope="col">Apellidos</th><th scope="col">Correo Electrónico</th><th scope="col">Opciones</th></tr>');
                          
                $tblContenido.empty();
                var rows = [];
                for (var i = 0; i < newdata.length; i++) {
                              
                    rows.push('<tr><th scope="row">' + newdata[i].Id_Cliente + '</th><td>' + newdata[i].Nombres + '</td><td>' + newdata[i].Apellidos + '</td><td>' + newdata[i].Correo + '</td><td><a title="Mostrar" href="VerCliente.aspx?id=' + newdata[i].Id_Cliente + '"><i class="ti-eye"></i></a><a title="Editar" href="EditarCliente.aspx?id=' + newdata[i].Id_Cliente + '"><i class="ti-pencil-alt"></i></a><button value="Eliminar" title="Eliminar" class="btn btn-danger btn-delete"><i class="fa fa-trash-o"></i></button> </td></tr>');
                }
                $tblContenido.append(rows.join(''));
            }
        }
    });
}

function sendDataAjax() {
    $.ajax({
        type: "POST",
        url: "Empleado.aspx/ListarEmp",
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


function deleteDataAjax(data) {
    var obj = JSON.stringify({
        id: JSON.stringify(data)
    });
    $.ajax({
        type: "POST",
        url: "BuscarCliente.aspx/EliminarEmp",
        data: obj,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + "\n" + xhr.responseText, thrownError);
        },
        success: function (response) {
            if (response.d) {
                alert('Registro eliminado de Manera Correcta');
            }
            else {
                alert('No se pudo eliminarr el registro');
            }

        }
    });
}

//EVENTO PARA BOTON ELIMINAR
$(document).on('click', '.btn-delete', function (e) {
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