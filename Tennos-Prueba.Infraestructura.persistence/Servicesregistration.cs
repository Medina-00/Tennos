

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tennos_Prueba.Infraestructura.persistence.Context;
using Tennos_Prueba.Infraestructura.persistence.Repository;

namespace Tennos_Prueba.Infraestructura.persistence
{
    public static class Servicesregistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Contexts

            services.AddDbContext<TennosContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            m => m.MigrationsAssembly(typeof(TennosContext).Assembly.FullName)));

            #endregion

            #region Repositories
            services.AddTransient<IProductoRepository, ProductoRepository>();
            

            #endregion

        }

    }
}
