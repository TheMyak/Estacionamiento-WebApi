namespace Estacionamiento_WebApi.Entidades
{
    public class Ticket
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public DateOnly Fecha { get; set; }
        public List<Estacionamiento> estacionamiento { get; set; }=new List<Estacionamiento>();
    }
}