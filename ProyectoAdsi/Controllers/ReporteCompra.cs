using System;

namespace ProyectoAdsi.Controllers
{
    internal class ReporteCompra
    {
        public string nombreCliente { get; set; }
        public string documentoCliente { get; set; }
        public string emailCliente { get; set; }
        public DateTime fechaCompra { get; set; }
        public int totalCompra { get; set; }
    }
}