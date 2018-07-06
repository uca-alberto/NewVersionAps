<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pruebaalertas.aspx.cs" Inherits="CentroBiologiaMolecularUCA.pruebaalertas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    
    <link href="assets/sweetalert.css" rel="sweetalert"/>
    <title> prueba</title>
</head>
<body>
 <button onclick="ver()">ver</button>
    <script src="assets/sweetalert.min.js"></script>
    <script>
    function ver(){
        swal("Cliente agregado!", "Clik Para Continuar!", "success");
    }
    </script>
</body>
</html>
