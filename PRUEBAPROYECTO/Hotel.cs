using System.Collections.Generic;

namespace Clave5_Grupo6
{
    class Hotel  /*Clase creada hotel, esta clase representa al 
                   * tipo de hotel y sus atributos 
                   * como el tipo de hotel, tipo de habitaciones, etc. */
    {
        public string NombreHotel { get; set; }
        public string Ubicacion { get; set; }
        public List<Habitacion> Habitaciones { get; set; }

        public Hotel()
        {
            Habitaciones = new List<Habitacion>(); // Inicializa la lista en el constructor
        }


        public virtual Habitacion ObtenerHabitacion(string tipoHabitacion)
        {
            // Asigna el nombre del hotel a cada habitación al agregarla
            Habitacion habitacion = new Habitacion { TipoHabitacion = tipoHabitacion, Hotel = NombreHotel };
            Habitaciones.Add(habitacion);
            return habitacion;
        }
    }
}
