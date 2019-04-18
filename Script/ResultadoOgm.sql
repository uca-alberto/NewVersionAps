CREATE PROCEDURE ResultadosOgm
@Id int
AS
SELECT ord.Id_codigo, res.Hora,res.Fecha_procesamiento,CONCAT(emp.Nombre_empleado,' ',emp.Apellido)AS Nombre_Empleado ,CONCAT(cli.Nombre,' ',Cli.Apellido) AS Nombre_Cliente ,mue.muestra,res.Observaciones,ana.analisis,op.Resultado 
FROM T_Resultados res INNER JOIN T_Orden ord ON res.Id_orden=ord.Id_orden INNER JOIN T_Usuario usu ON usu.Id_usuario=ord.Id_usuario 
INNER JOIN T_Empleados emp ON emp.Id_empleado=usu.Id_empleado INNER JOIN T_Clientes cli ON ord.Id_cliente=
cli.Id_cliente INNER JOIN T_Tipo_muestra mue ON mue.Id_tipo_muestra=ord.Id_tipo_muestra INNER JOIN T_Resultado_Detalle detalle ON detalle.Id_resultado=res.Id_resultado
 INNER JOIN T_Tipo_Analisis ana ON detalle.Id_analisis=ana.Id_analisis INNER JOIN T_Opcion_resultado op ON detalle.Resultado=op.Id_opcion
WHERE res.Id_resultado=@Id

