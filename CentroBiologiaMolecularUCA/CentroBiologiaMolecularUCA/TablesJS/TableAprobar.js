var data, tabla;
function addRowDT(data) {
    tabla = $("#bootstrap-data-table").DataTable();
    for (var i = 0; i < data.length; i++) {
        tabla.row.add([
            data[i].Id_resultado,
            data[i].Id_codigo,
            data[i].Examen,
            data[i].Estado,
            '<a title="visualizar" id="ver"><i class="fa ti-eye"></i>&nbsp;' +
            '<a value="Eliminarre" title="Aprobar" id="Aprobar"><i class="ti-check-box"></i>' +
            '<a value="Anular" title="Anular" id="anular"><i class="ti-close"></i>'
        ]).draw(false);
    }
}

function sendDataAjax() {
    $.ajax({
        type: "POST",
        url: "Aprreall.aspx/GetData",
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

function AprobarDataAjax(data) {
    swal({
        title: "Esta Seguro?",
        text: "Aprobar el Resultado",
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
                    url: "Aprreall.aspx/AprobarRe",
                    data: obj,
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    error: function (xhr, ajaxOptions, thrownError) {
                        console.log(xhr.status + "\n" + xhr.responseText, thrownError);
                    },

                });
                swal("Se Aprobó Correctamente", {
                    icon: "success",
                });
                location.href = "Aprreall.aspx"
            }
        });
}

//EVENTO PARA BOTON ELIMINAR
$(document).on('click', '#Aprobar', function (e) {
    e.preventDefault();
    var dataRow = tabla.rows($(this).parents('tr')).data()[0];
    console.log(dataRow[0])
    //Enviar código al servidor
    //ENVIAR EL ID POR MEDIO DE AJAX
    AprobarDataAjax(dataRow[0]);
    //RENDERIZAR EL DATATABLE

    sendDataAjax();
    tabla.clear().draw();
});

function deleteDataAjax(data) {
    swal({
        title: "Esta Seguro?",
        text: "Anular Resultado",
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
                    url: "Aprreall.aspx/AnularRe",
                    data: obj,
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    error: function (xhr, ajaxOptions, thrownError) {
                        console.log(xhr.status + "\n" + xhr.responseText, thrownError);
                    },

                });
                swal("Se Anuló Correctamente", {
                    icon: "success",
                });
                location.href = "Aprreall.aspx"
            }
        });
}

//EVENTO PARA BOTON ELIMINAR
$(document).on('click', '#Anular', function (e) {
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
