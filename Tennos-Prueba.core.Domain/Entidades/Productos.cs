

namespace Tennos_Prueba.core.Domain.Entidades
{
    public class Productos
    {
        public int ProductoID { get; set; }
        public string Nombre { get; set; }

        public decimal Precio { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}
