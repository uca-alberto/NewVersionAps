var table;
$(document).ready(function () {
    var table = $('#table').DataTable({
        "bDestroy": true,
        "paging": false,
        "ordering": false,
        "info": false,
        "searching": false,

        columnDefs: [
                {
                    targets: [1],//fila

                    render: function (data, type, full, meta) {
                        if (type === 'display') {
                //aqui cargo los checkbox
                            var datos =
                                '<input type="checkbox" id="radio" name="Positivo" value="1">Positivo<br>'

                                + '<input type="checkbox" id="radio" name="Negativo" value="0">Negativo<br>';
                            return datos;

                        }
                        return data;
                    },
                },
        ],

    });

    $('#table tbody').on('click', '#radio', function () { //cuando presione el check
        var dataRow = table.rows($(this).parents('tr')).data()[0]; //obtener fila
        var union;
        var valor1;
        var valor2;
        $('input[name="Positivo"]:checked').each(function () { //recorrer check para positivos

            var i = 0;
            var radio = $('input[name="Positivo"]:checked').val();
            ++i;
            valor1 = dataRow[0] + " " + radio;

        });
        console.log(valor1)
        //$('input[name="Negativo"]:checked').each(function () {

        //    var i = 0;
        //    var radio = $('input[name="Negativo"]:checked').val();
        //    ++i;

        //    valor2 = dataRow[0] + " " + radio;
        //});
    });
});