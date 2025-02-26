using Tennos_Prueba.core.Domain.Entidades;

namespace Tennos_Prueba.Infraestructura.persistence.Repository
{
    public interface IProductoRepository
    {
        Task<Productos> AddAsync(Productos t);
        Task DeleteAsync(int id);
        Task<List<Productos>> GetAllAsync();
        Task<Productos> GetByIdAsync(int id);
        Task UpdateAsync(Productos t, int id);
    }
}