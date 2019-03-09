function edit(nombre, precio_examen) {
    document.getElementById('ContentPlaceHolder1_Mnombre').value = nombre;
    document.getElementById('ContentPlaceHolder1_Mprecio').value = precio_examen;

}

function eliminar(url) {

    if (window.confirm()) {
        window.Location = url;
    }

}