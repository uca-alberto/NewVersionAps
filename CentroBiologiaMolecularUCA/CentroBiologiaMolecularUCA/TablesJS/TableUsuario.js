﻿//$(function () {

//    // Proxy created on the fly
//    var job = $.connection.myHub;

//    //     Declare a function on the job hub so the server can invoke it
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
           //data[i].Id_usuario,
           data[i].Nombre,
           data[i].nombre_rol,
           '<a title="ver" href="Seeuse.aspx?id=' + data[i].Id_usuario + '"><i class="fa ti-eye"></i>&nbsp;' +
           '<a title="Editar" href="Upduse.aspx?id=' + data[i].Id_usuario + '"><i class="fa fa-edit"></i>&nbsp;' +
           '<a value="Eliminarre" id="Eliminar"><i class="fa fa-trash-o"></i>'

        ]).draw(false);
    }
}

function sendDataAjax() {
    $.ajax({
        type: "POST",
        url: "Searchuse.aspx/GetData",
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
        title: "¿Estas Seguro?",
        text: "Eliminar Usuario",
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
              url: "Searchuse.aspx/EliminarUs",
              data: obj,
              dataType: "json",
              contentType: "application/json; charset=utf-8",
              error: function (xhr, ajaxOptions, thrownError) {
                  console.log(xhr.status + "\n" + xhr.responseText, thrownError);
              },

          });
          swal("Usuario Eliminado Correctamente", {
              icon: "success",
          });
          location.href = "Searchuse.aspx"
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


//LLAMANDO A LA FUNCION AJAX AL CARGAR DOCUMENTO
sendDataAjax();