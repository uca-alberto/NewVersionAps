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
//Método para Eliminar Datos
//function deleteDataAjax(data) {
//    var obj = JSON.stringify({
//        id: JSON.stringify(data)
//    });
//    $.ajax({
//        type: "POST",
//        url: "BuscarCliente.aspx/EliminarCli",
//        data: obj,
//        dataType: "json",
//        contentType: "application/json; charset=utf-8",
//        error: function (xhr, ajaxOptions, thrownError) {
//            console.log(xhr.status + "\n" + xhr.responseText, thrownError);
//        },
//        success: function (response) {
//            if (response.d) {
//                alert('Registro eliminado de Manera Correcta');
//            }
//            else {
//                alert('No se pudo eliminarr el registro');
//            }

//        }
//    });
//}
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
          } else {
              swal("Your imaginary file is safe!");
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
   
    sendDataAjax();
    tabla.clear().draw();
});


//LLAMANDO A LA FUNCION AJAX AL CARGAR DOCUMENTO
sendDataAjax();