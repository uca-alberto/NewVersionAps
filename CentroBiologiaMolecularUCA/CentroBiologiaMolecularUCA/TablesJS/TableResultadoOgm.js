var data, tabla;
function addRowDT(data) {
    tabla = $("#bootstrap-data-table").DataTable();
    for (var i = 0; i < data.length; i++) {
        tabla.row.add([
           data[i].Id_resultado,
           data[i].Estado,
           data[i].Tipo,
          '<a title="ver" id="see"><i class="fa ti-eye"></i>&nbsp;'+
           '<a title="Reporte Resultado"  id="report"><i class="ti-clipboard"></i>&nbsp;'+
		   '<a title="Eliminar" value="Eliminarre" id="Eliminar"><i class="fa fa-trash-o"></i>&nbsp;' 

        ]).draw(false);
    }
}

function sendDataAjax() {
    $.ajax({
        type: "POST",
        url: "Searchreogm.aspx/GetData",
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
        text: "Eliminar Resultado",
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
              url: "Searchreogm.aspx/EliminarOrd",
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
          location.href = "Searchreogm.aspx"
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
//Reporte
$('#bootstrap-data-table tbody').on('click', '#report', function () {
    var table = $('#bootstrap-data-table').DataTable();
    var data = table.row($(this).parents("tr")).data();
    var id = data[0];

    var redict = data[2];
    //Granos
    if (redict == "OGM" || redict == "Patogeno") {
        location.href ='../../Views/Rpt/ResultadoOgm?id=' + id + ''
    }
    else {
        swal({
            title: "Lo sentimos",
            text: "El reporte seleccionado esta en mantenimiento: \n",
            icon: "warning",
            buttons: false,
            timer: 2000,
        });

    }
});
//Visualizar
$('#bootstrap-data-table tbody').on('click', '#see', function () {
    var table = $('#bootstrap-data-table').DataTable();
    var data = table.row($(this).parents("tr")).data();
    var id = data[0];

    var redict = data[2];
    //Granos
    if (redict == "OGM") {
        location.href = '../../Views/Vreogm/seereogm?id=' + id + ''
    }
    //Patogeno
    if (redict == "Patogeno") {
        location.href = '../../Views/Vrepat/Seerepat?id=' + id + ''
    }
    //Alzhaimer
    if (redict == "Alzhaimer") {
        location.href = '../../Views/Vrealz/Seerealz?id=' + id + ''
    }
    //VPH
    if (redict == "Papiloma Humano") {
        location.href = '../../Views/Vrevph/Seerevph?id=' + id + ''
    }
});