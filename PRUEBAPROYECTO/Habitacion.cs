namespace Clave5_Grupo6
{
    class Habitacion         /*Clase creada habitacion con sus atributos principales
                              * y al final inicializa en una lista los equipos disponibles*/
    {
        public string TipoHabitacion { get; set; }
        public decimal Precio { get; set; }
        public string Hotel { get; set; }


        public string ObtenerPrecio()
        {
            return $"{Precio:C2}";
        }



    }
}
