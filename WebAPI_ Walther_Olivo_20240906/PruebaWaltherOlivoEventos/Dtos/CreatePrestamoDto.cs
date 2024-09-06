namespace PruebaWaltherOlivoEventos.Dtos
{
    public class CreatePrestamoDto
    {
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public string Estado { get; set; }
        public int TipoPrestamoId { get; set; }
    }

}
