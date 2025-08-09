namespace Clave5_Grupo6
{
    class HotelMontaña : Hotel
    {
        public HotelMontaña(string nombreHotel, string ubicacion) : base()
        {
            NombreHotel = nombreHotel;
            Ubicacion = ubicacion;
            Habitaciones.Add(new Habitacion { TipoHabitacion = "Sencilla", Precio = 60.00M });
            Habitaciones.Add(new Habitacion { TipoHabitacion = "Doble", Precio = 70.00M });
            Habitaciones.Add(new Habitacion { TipoHabitacion = "Deluxe", Precio = 80.00M });
            Habitaciones.Add(new Habitacion { TipoHabitacion = "Suite", Precio = 90.00M });
        }

        public override Habitacion ObtenerHabitacion(string tipoHabitacion)
        {
            return base.ObtenerHabitacion(tipoHabitacion);
        }
    }
}
