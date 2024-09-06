using System;

namespace PruebaWaltherOlivoEventos.Models
{
    public class Prestamo
    {
        public int PrestamoId { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public string Estado { get; set; }
        public int TipoPrestamoId { get; set; }

        // Relación con TipoPrestamo
        public TipoPrestamo TipoPrestamo { get; set; }
    }
}
