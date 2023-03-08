namespace Estacionamiento_WebApi.Entidades
{
    public class Estacionamiento
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public DateOnly Fundacion { get; set; }
        public int TicketID { get; set; }
        public Ticket ticket {get; set; }
    }
}