--Presedimiento para la creacion de recibos
USE [CBM]
GO
/****** Object:  StoredProcedure [dbo].[ReciboOrden]    Script Date: 2/4/2019 13:13:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE ReciboOrden
@id int
AS
BEGIN

SELECT 
orden.Id_codigo,CONCAT(clientes.Nombre ,' ', clientes.Apellido) as nombres,
CONCAT(examenes.Nombre,'.') AS Name_examen, dbo.CantidadConLetra(examenes.Precio_examen)as montoletras,
examenes.Precio_examen,orden.Baucher
FROM 
T_Orden orden
INNER JOIN T_Clientes clientes on orden.Id_cliente=clientes.Id_cliente
INNER JOIN T_Examenes examenes on orden.Id_examenes=examenes.Id_examenes
WHERE orden.Id_orden=@id
END
