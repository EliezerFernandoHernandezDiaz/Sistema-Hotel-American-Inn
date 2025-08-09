using System.Linq;

namespace Clave5_Grupo6
{
    /*Clase definida para el hotel que se ubica en la playa*/

    class HotelPlaya : Hotel
    {

        //Constructor de la clase con el nombre del hotel , la ubicación que es, en la playa
        public HotelPlaya(string nombreHotel, string ubicacion) : base()
        {
            //Asignacion de los valores que se han heradado de la clase base, es decir la clase principal o superclase. 
            NombreHotel = nombreHotel;
            Ubicacion = ubicacion;

            //Asignacion de los tipos de habitacion con los diferentes precios que posee el hotel que se encuentra en la playa 
            Habitaciones.Add(new Habitacion { TipoHabitacion = "Sencilla", Precio = 65.00M });
            Habitaciones.Add(new Habitacion { TipoHabitacion = "Doble", Precio = 75.00M });
            Habitaciones.Add(new Habitacion { TipoHabitacion = "Deluxe", Precio = 90.00M });
            Habitaciones.Add(new Habitacion { TipoHabitacion = "Suite", Precio = 100.00M });
        }
        public Habitacion ObtenerHabitacion(string tipoHabitacion)
        {
            return Habitaciones.FirstOrDefault(h => h.TipoHabitacion == tipoHabitacion);
        }
    }
}
