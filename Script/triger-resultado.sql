create trigger tr_resultado
on T_Resultados
after insert 
as
begin
	declare  @id_resultado int select MAX(Id_resultado)from T_Resultados
	declare @id int select Usuario_procesa from T_Resultados 
	insert into T_Audit_Orden ( Id_orden, Id_usuario, Accion, Fecha_accion)
	values ( @id_resultado, @id , 'insertar', GETDATE())
end
