Select * From Reserva

Exec MostrarOrdenFKPorSucursal 1


Select * From Orden

go
Create Procedure MostrarReservasFKporSucursal @ReservaID int
as
Select R.MesaID , R.ClienteID 
from Reserva as R 
where ReservaID = @ReservaID

Exec MostrarReservasFKporSucursal 2
Exec MostrarOrdenFKPorSucursal 1


go

Select * From Reserva
Select * From Cliente
go

alter procedure ActualizarReserva @ReservaID int,@MesaID int, @ClienteID int , @CantidadA int , @fechaR datetime , @fechaL datetime, @AtencionE int
as
Update Reserva 
set MesaID = @MesaID , ClienteID = @ClienteID , CantidadAsistente = @CantidadA, FechaReserva = @fechaR , FechaLlegada = @fechaL , AtencionEspecial = @AtencionE
where ReservaID = @ReservaID


 


Select * from Cliente


Exec LoadTableAvailableForSucursal 3

Select * From Reserva


Select * From Sucursal

Select * FROM Mesa where SucursalID = 3

Exec [Validar acceso] 'Rodian', 'matey'

