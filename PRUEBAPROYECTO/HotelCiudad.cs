namespace Clave5_Grupo6
{
    /*Se han creado diferentes clases segun la ubicacion del hotel
     * esta clase representa especificamente el hotel que está en la ciudad
     * y hereda de la clase Hotel*/

    class HotelCiudad : Hotel
    {
        //Constructor de la clase
        public HotelCiudad(string nombreHotel, string ubicacion) : base()

        {
            //Propiedades que se heredaron de la clase base, o superclase

            NombreHotel = nombreHotel;
            Ubicacion = ubicacion;

            /*Se agregan los diferentes tipos de habitaciones que el hotel american inn posee
             * asi como tambien los diferentes precios que cada una tiene*/

            Habitaciones.Add(new Habitacion { TipoHabitacion = "Sencilla", Precio = 55.00M });
            Habitaciones.Add(new Habitacion { TipoHabitacion = "Doble", Precio = 65.00M });
            Habitaciones.Add(new Habitacion { TipoHabitacion = "Deluxe", Precio = 75.00M });
            Habitaciones.Add(new Habitacion { TipoHabitacion = "Suite", Precio = 85.00M });
        }

        public override Habitacion ObtenerHabitacion(string tipoHabitacion)
        {
            return base.ObtenerHabitacion(tipoHabitacion);
        }

    }
}

