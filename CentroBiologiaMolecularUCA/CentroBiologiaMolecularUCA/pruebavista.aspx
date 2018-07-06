<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pruebavista.aspx.cs" Inherits="CentroBiologiaMolecularUCA.pruebavista" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/v/bs/dt-1.10.15/datatables.min.css" />
    <link rel="stylesheet" href="public/css/main.css"/>
    <title></title>
</head>
<body>

    <button id="ver">Listar Cliente</button>

 <!--Tabla de orden-->                               
           <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <table id="bootstrap-data-table" class="table table-striped table-bordered">
                    <thead>
                        <tr>
                        <th>Id</th>
                        <th>Usuario</th>
                        <th>Password</th>
                        </tr>
                    </thead>
                </table>
            </div>
        </div>
   
    
    <!-- Latest jQuery minified -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/v/bs/dt-1.10.15/datatables.min.js"></script>
    <!-- Script Personalizado -->
    <script src="Content/global.js"></script>
    <script>
        $(function () {            
            __showUsers();
        });
    </script>
</body>
</html>
