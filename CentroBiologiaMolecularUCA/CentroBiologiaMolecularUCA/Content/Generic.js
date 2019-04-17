function editAbueldidad(codigo, padre, hijo, fecha, tipocaso, observaciones, boucher) {
    document.getElementById('MainContent_Mcodigoabuela').value = codigo;
    document.getElementById('MainContent_Mnombredelaabuela').value = padre;
    document.getElementById('MainContent_Mnombrenieto').value = hijo;
    document.getElementById('MainContent_Mfechaabuelidad').value = fecha;
    document.getElementById('MainContent_Mtipocasoabuelidad').value = tipocaso;
    document.getElementById('MainContent_Mobservacionesabuelidad').value = observaciones;
    document.getElementById('MainContent_Mboucherabuelidad').value = boucher;
}

function editAlzheimer(codigo, padre, hijo, fecha, tipocaso, observaciones, boucher) {
    document.getElementById('MainContent_Mcodigoalzheimer').value = codigo;
    document.getElementById('MainContent_Mnombredeldoctor').value = padre;
    document.getElementById('MainContent_Mnombredelpaciente').value = hijo;
    document.getElementById('MainContent_Mfechaalzheimer').value = fecha;
    document.getElementById('MainContent_Mtipocasoalzheimer').value = tipocaso;
    document.getElementById('MainContent_Mobservacionesalzheimer').value = observaciones;
    document.getElementById('MainContent_Mboucheralzheimer').value = boucher;
}

function editCliente(cedula, nombre, apellido, departamento, municipio, sexo, telefono, correo, direccion) {
    document.getElementById('MainContent_Mcedula').value = cedula;
    document.getElementById('MainContent_Mnombre').value = nombre;
    document.getElementById('MainContent_Mapellido').value = apellido;
    document.getElementById('MainContent_Mdepartamento').value = departamento;
    document.getElementById('MainContent_Mmunicipio').value = municipio;
    document.getElementById('MainContent_Mdireccion').value = direccion;
    document.getElementById('MainContent_Msexo').value = sexo;
    document.getElementById('MainContent_Mtelefono').value = telefono;
    document.getElementById('MainContent_Mcorreo').value = correo;
}

function editEmpleados(Cargo, Cedula, Nombre_empleado, Apellido) {
    document.getElementById('ContentPlaceHolder1_Mcargo').value = Cargo;
    document.getElementById('ContentPlaceHolder1_Mcedula').value = Cedula;
    document.getElementById('ContentPlaceHolder1_Mnombre').value = Nombre_empleado;
    document.getElementById('ContentPlaceHolder1_Mapellido').value = Apellido;
}

function editMaternidad(codigo, padre, hijo, fecha, tipocaso, observaciones, boucher) {
    document.getElementById('MainContent_Mcodigomadre').value = codigo;
    document.getElementById('MainContent_Mnombremadre').value = padre;
    document.getElementById('MainContent_Mnombrehijomadre').value = hijo;
    document.getElementById('MainContent_Mfechamaternidad').value = fecha;
    document.getElementById('MainContent_Mtipocasomadre').value = tipocaso;
    document.getElementById('MainContent_Mobservacionesmadre').value = observaciones;
    document.getElementById('MainContent_baouchermaternidad').value = boucher;
}

function editMuestra(nombre, analisis) {
	document.getElementById('ContentPlaceHolder1_Mmuestra').value = nombre;
	document.getElementById('ContentPlaceHolder1_Danalisis').value = analisis;
}

function editOrdenAdn(codigo, padre, hijo, fecha, tipocaso, observaciones, boucher) {
    document.getElementById('MainContent_Mcodigo').value = codigo;
    document.getElementById('MainContent_Mnombrepareja').value = padre;
    document.getElementById('MainContent_Mnombrehijo').value = hijo;
    document.getElementById('MainContent_Mfecha').value = fecha;
    document.getElementById('MainContent_Mtipocaso').value = tipocaso;

    document.getElementById('MainContent_Mobservaciones').value = observaciones;
    document.getElementById('MainContent_Mbaucher').value = boucher;

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
        $("input[id$='Mcliente']").val(nombre),
            $("input[id$='Id_cliente']").val(id);
        $("input[id$='Mcedula']").val(cedula);
        swal({
            title: "Cliente Agregado a la Orden",
            text: "Usted a seleccionado al cliente: \n" + nombre,
            icon: "info",
            buttons: false,
            timer: 2000,
        });
    })
});

function editOrdenOgm(codigo, fecha, analisis, muestra, observaciones, boucher) {
    document.getElementById('MainContent_Mcodigo').value = codigo;
    document.getElementById('MainContent_Mfecha').value = fecha;
    document.getElementById('MainContent_Manalisis').value = analisis;
    document.getElementById('MainContent_Mmuestra').value = muestra;
    document.getElementById('MainContent_Mobservaciones').value = observaciones;
    document.getElementById('MainContent_Mbaucher').value = boucher;
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
        $("input[id$='Mcliente']").val(nombre),
            $("input[id$='Id_cliente']").val(id);
        $("input[id$='Mcedula']").val(cedula);
        swal({
            title: "Cliente Agregado a la Orden",
            text: "Usted a seleccionado al cliente: \n" + nombre,
            icon: "info",
            buttons: false,
            timer: 2600,
        });
    })
});

function editPapiloma(codigo, padre, hijo, fecha, tipocaso, observaciones, boucher) {
    document.getElementById('MainContent_Mcodigopapiloma').value = codigo;
    document.getElementById('MainContent_Mdoctorpapiloma').value = padre;
    document.getElementById('MainContent_Mpacientepapiloma').value = hijo;
    document.getElementById('MainContent_Mfechapapiloma').value = fecha;
    document.getElementById('MainContent_Mtipocasopapiloma').value = tipocaso;
    document.getElementById('MainContent_Mobservacionespapiloma').value = observaciones;
    document.getElementById('MainContent_Mboucherpapiloma').value = boucher;
}

function editResultado(fecha, observaciones) {
    document.getElementById('MainContent_Mfecha').value = fecha;
    document.getElementById('MainContent_Mobservaciones').value = observaciones;
}


function editUsuario(nombre, rol) {
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

function editExamen(nombre, precio_examen) {
    document.getElementById('ContentPlaceHolder1_Mnombre').value = nombre;
    document.getElementById('ContentPlaceHolder1_Mprecio').value = precio_examen;

}