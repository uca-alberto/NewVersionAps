create trigger tr_orden
on T_Orden 
after insert 
as
begin
	declare @id_orden int select MAX(Id_orden) from T_Orden
	declare  @id int select  Id_usuario from T_Orden
	insert into T_Audit_Orden (Id_orden, Id_usuario, Accion, Fecha_accion)
	values ( @id_orden, @id, 'insertar', GETDATE())
end