using System;

namespace Clave5_Grupo6
{

    //Clase reserva que se ha creado con el fin de que esta guarde las propiedades de las reservas con sus atributos.

    class Reserva
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dui { get; set; }
        public string TipoHotel { get; set; }
        public string TipoHabitacion { get; set; }
        public decimal PrecioHabitacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int CantidadHuespedes { get; set; }                    /*esta clase establece los diferentes atributos que
                                                                       * se definen para este clase como nombre, apellido del cliente, tipohabitacion, precio
                                                                       * fechas check inn, out, etc . */
        public string FormaPago { get; set; }
        public int IdHabitacion { get; set; }
        public int IdReserva { get; set; }
        public bool CostoExtra { get; set; }
    }
}
