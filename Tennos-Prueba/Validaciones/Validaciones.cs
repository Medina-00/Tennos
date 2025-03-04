using Tennos_Prueba.core.Domain.Entidades;

namespace Tennos_Prueba.Validaciones
{
    public static class Validaciones
    {
        public static void ValidarCamposGuardar(Productos productos)
        {
            // Check if the product name is null or empty
            if (string.IsNullOrWhiteSpace(productos.Nombre))
            {
                throw new ArgumentException("EL PRODUCTO DEBE CONTENER UN NOMBRE");
            }

            // Check if the price is greater than 0
            if (productos.Precio <= 0)
            {
                throw new ArgumentException("EL PRODUCTO DEBE CONTENER UN PRECIO VALIDO");
            }

            // Check if the creation date is a valid date
            if (productos.FechaCreacion == default)
            {
                throw new ArgumentException("EL PRODUCTO DEBE CONTENER UNA FECHA DE CREACION VALIDA");
            }
        }

        public static void ValidarCamposUpdate(Productos productos)
        {

            if (productos.ProductoID == 0 )
            {
                throw new ArgumentException("EL PRODUCTO DEBE CONTENER UN ID");
            }

            // Check if the product name is null or empty
            if (string.IsNullOrWhiteSpace(productos.Nombre))
            {
                throw new ArgumentException("EL PRODUCTO DEBE CONTENER UN NOMBRE");
            }

            // Check if the price is greater than 0
            if (productos.Precio <= 0)
            {
                throw new ArgumentException("EL PRODUCTO DEBE CONTENER UN PRECIO VALIDO");
            }

            // Check if the creation date is a valid date
            if (productos.FechaCreacion == default)
            {
                throw new ArgumentException("EL PRODUCTO DEBE CONTENER UNA FECHA DE CREACION VALIDA");
            }
        }
    }
}
