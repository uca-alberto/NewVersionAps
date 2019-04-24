USE [CBM]
GO
/****** Object:  StoredProcedure [dbo].[Constancia_Muestra]    Script Date: 23/04/2019 2:03:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Constancia_Muestra]
 @id_orden  int,
 @Personauno varchar(50),
@personados varchar(50),
@cedulauno varchar(20),
@cedulados varchar(20)
AS
BEGIN 
SELECT examenes.Nombre,orden.Id_codigo,orden.Nombre_menor,@Personauno,@personados FROM T_Orden orden
INNER JOIN T_Examenes examenes ON orden.Id_examenes=examenes.Id_examenes
WHERE orden.Id_orden=@id_orden
END
