//$(function () {

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
           data[i].Id_orden,
           data[i].Id_codigo,
           data[i].Baucher,
           data[i].Examen,
           '<a title="visualizar" id="ver"><i class="fa ti-eye"></i>&nbsp;' +
           '<a title="Eliminar" value="Eliminarre" id="Eliminar"><i class="fa fa-trash-o"></i>&nbsp;' +
           '<a title="Generar Resultado" id="generar"><i class="fa fa-file-text-o"></i>&nbsp;' +
           '<a title="Generar Recibo"  href="../../Views/Rpt/Recibo?id=' + data[i].Id_orden + '"><i class="ti-clipboard"></i>&nbsp;'+
           '<a title="Generar Recibo"  href="../../Views/Rpt/Tmuestra?id=' + data[i].Id_orden + '"><i class="ti-clipboard"></i>&nbsp;'



        ]).draw(false);
    }
}

function sendDataAjax() {
    $.ajax({
        type: "POST",
        url: "Searchogm.aspx/GetData",
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
        text: "Eliminar Orden",
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
              url: "Searchogm.aspx/EliminarOrd",
              data: obj,
              dataType: "json",
              contentType: "application/json; charset=utf-8",
              error: function (xhr, ajaxOptions, thrownError) {
                  console.log(xhr.status + "\n" + xhr.responseText, thrownError);
              },

          });
          swal("Orden Eliminada Correctamente", {
              icon: "success",
          });
          location.href = "Searchogm.aspx"
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

//Resultado
$('#bootstrap-data-table tbody').on('click', '#generar', function () {
    var table = $('#bootstrap-data-table').DataTable();
    var data = table.row($(this).parents("tr")).data();
    var id = data[0];
   
    var redict = data[3];
    //Granos
    if (redict == "OGM") {
        location.href = '../../Views/Vreogm/Addreogm?id=' + id + ''
    }
    if (redict == "Patogeno") {
        location.href = '../../Views/Vrepat/Addrepat?id=' + id + ''
    }
    //ADN
    if (redict == "Paternidad" || redict == "Maternidad" || redict == "Abuelidad" || redict == "Hermandad") {
        location.href = '../../Views/Vreadn/addreadn?id=' + id + ''
    }
    //Alzhaimer
    if (redict == "Alzhaimer") {
        location.href = '../../Views/Vrealz/Addrealz?id=' + id + ''
    }
    //VPH
    if (redict == "Papiloma Humano") {
        location.href = '../../Views/Vrevph/Addrevph?id=' + id + ''
    }
  
  
});

//Probando el Visualizar
$('#bootstrap-data-table tbody').on('click', '#ver', function () {
    var table = $('#bootstrap-data-table').DataTable();
    var data = table.row($(this).parents("tr")).data();
    var id = data[0];

    var redict = data[3];
    //Granos
    if (redict == "OGM") {
        location.href = 'Seeogm.aspx?id=' + id + ''
    }
    //Granos
    if (redict == "Patogeno") {
        location.href = '../Vpat/Seepat.aspx?id=' + id + ''
    }
    //ADN
    if (redict == "Paternidad") {
        location.href = '../ViewOrdenMaria/VerOrdenAdnMulti.aspx?id=' + id + ''
    }
    if (redict == "Maternidad") {
        location.href = '../ViewOrdenMaria/VerMaternidadMulti.aspx?id=' + id + ''
    }
    if (redict == "Abuelidad") {
        location.href = '../ViewOrdenMaria/VerAbuelidadMulti.aspx?id=' + id + ''
    }
    //HUMANO
    if (redict == "Alzhaimer") {
        location.href = '../ViewOrdenMaria/VerAlzheimerMulti.aspx?id=' + id + ''
    }
    if (redict == "Papiloma Humano") {
        location.href = '../ViewOrdenMaria/VerPapilomaMulti.aspx?id=' + id + ''
    }
});