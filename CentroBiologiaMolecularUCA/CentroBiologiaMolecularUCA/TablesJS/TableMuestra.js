//$(function () {

//    // Proxy created on the fly
//    var job = $.connection.myHub;

////     Declare a function on the job hub so the server can invoke it
//    job.client.displayStatus = function () {
//        addRowDT(data)
//    };

//    // Start the connection
//    $.connection.hub.start();
//    addRowDT(data)
//});

var data, tabla;
function addRowDT(data) {
    tabla = $("#bootstrap-data-table").DataTable();
    for (var i = 0; i < data.length; i++) {
        tabla.row.add([
           data[i].Id_muestra,
           data[i].muestra,
           '<a title="Editar" id="Editar" data-target="#mediumModal" data-toggle="modal"><i class="fa fa-edit"></i>&nbsp;' +
           '<a value="Eliminarre" id="Eliminar"><i class="fa fa-trash-o"></i>'

        ]).draw(false);
    }
}

function sendDataAjax() {
    $.ajax({
        type: "POST",
        url: "Searchmue.aspx/GetData",
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
    swal({
        title: "Esta Seguro?",
        text: "Eliminar Cliente",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
  .then((willDelete) => {
      if (willDelete) {
          var obj = JSON.stringify({
              id: JSON.stringify(data)
          });
          $.ajax({
              type: "POST",
              url: "BuscarCliente.aspx/EliminarCli",
              data: obj,
              dataType: "json",
              contentType: "application/json; charset=utf-8",
              error: function (xhr, ajaxOptions, thrownError) {
                  console.log(xhr.status + "\n" + xhr.responseText, thrownError);
              },

          });
          swal("Se Elimino Correctamente", {
              icon: "success",
          });
          location.href = "BuscarCliente.aspx"
      }
  });
}

//EVENTO PARA BOTON ELIMINAR
$(document).on('click', '#Eliminar', function (e) {
    e.preventDefault();
    var dataRow = tabla.rows($(this).parents('tr')).data()[0];
    console.log(dataRow[0])
    //Enviar código al servidor
    //ENVIAR EL ID POR MEDIO DE AJAX
    deleteDataAjax(dataRow[0]);
    //RENDERIZAR EL DATATABLE

    sendDataAjax();
    tabla.clear().draw();
});

function updateDataAjax() {
    var obj = JSON.stringify({
        id: JSON.stringify(data[0]), muestra: $("#Mmuestra").val()
    });
    $.ajax({
        type: "POST",
        url: "Searchmue.aspx/Actualizarmue",
        data: obj,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + "\n" + xhr.responseText, thrownError);
        },
        success: function (response) {
            if (response.d) {
                alert('Registro actualizado de Manera Correcta');
                $('#mediumModal .close').click();
                $('body').removeClass('modal-open');
                $('.modal-backdrop').remove();
                tabla.clear().draw();
                sendDataAjax();
            }
            else {
                alert('No se pudo actualizar el registro');
            }

        }
    });
}

$(document).on('click', '#Editar', function (e) {
    e.preventDefault();
    data = tabla.rows($(this).parents('tr')).data()[0];
    fillModalData();
});

//cargar datos en el modal
function fillModalData() {
    $("#ContentPlaceHolder1_Mmuestra").val(data[1]);
}
// ENVIAR AL SERVIDOR
$('#ContentPlaceHolder1_Aceptar').click(function (e) {
    e.preventDefault();
    updateDataAjax();

});

//LLAMANDO A LA FUNCION AJAX AL CARGAR DOCUMENTO
sendDataAjax();