using Microsoft.OpenApi.Models;

namespace Tennos_Prueba.Extenciones
{
    public static class ServicesRegistration
    {
        public static void AddSwaggerExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                List<string> xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", searchOption: SearchOption.TopDirectoryOnly).ToList();
                xmlFiles.ForEach(xmlFile => options.IncludeXmlComments(xmlFile));

                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Prueba API",
                    Description = "Esta API será responsable de la distribución general de datos.",
                    Contact = new OpenApiContact
                    {
                        Name = "Luis Angel Morel",
                        Email = "lmorelmedina@gmail.com"
                    }
                });

                //esto es para que todos los paremetros tengas con el formato de camello.
                options.DescribeAllParametersInCamelCase();

                options.EnableAnnotations();
                
            });


        }

        // Habilitar CORS(Compartición de Recursos entre Orígenes Cruzados) para todas las solicitudes

        public static void CORS(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.WithOrigins("http://127.0.0.1:5500") // Origen de tu cliente
                          .AllowAnyMethod()  // Permitir todos los métodos (GET, POST, PUT, DELETE)
                          .AllowAnyHeader(); // Permitir todos los encabezados
                });
            });
        }




    }

}

