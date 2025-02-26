

using Microsoft.EntityFrameworkCore;
using Tennos_Prueba.core.Domain.Entidades;
using Tennos_Prueba.Infraestructura.persistence.Context;

namespace Tennos_Prueba.Infraestructura.persistence.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly TennosContext appContext;

        public ProductoRepository(TennosContext appContext)
        {
            this.appContext = appContext;
        }
        public virtual async Task<Productos> AddAsync(Productos t)
        {
            await appContext.Set<Productos>().AddAsync(t);
            await appContext.SaveChangesAsync();
            return t;
        }

        public virtual async Task UpdateAsync(Productos t, int id)
        {
            var entity = await appContext.Set<Productos>().FindAsync(id);
            appContext.Entry(entity).CurrentValues.SetValues(t!);
            await appContext.SaveChangesAsync();

        }

        public virtual async Task DeleteAsync(int id)
        {
            var result = await appContext.Set<Productos>().FindAsync(id);
            appContext.Set<Productos>().Remove(result!);
            await appContext.SaveChangesAsync();
        }

        public virtual async Task<List<Productos>> GetAllAsync()
        {
            return await appContext.Set<Productos>().ToListAsync();
        }

        public virtual async Task<Productos> GetByIdAsync(int id)
        {
            return await appContext.Set<Productos>().FindAsync(id);
        }


    }

}
