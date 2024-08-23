using MongoDB.Bson;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;
//using TechsysLogProj.API.Configuration;
using TechsysLogProj.Application.Interfaces;
using TechsysLogProj.Application.Services;
using TechsysLogProj.Domain.Interfaces.Repositoy;
using TechsysLogProj.Infra.Data.Repository;
using TechsysLogProj.Application.Mappers;
using TechsysLogProj.API.Configuration;

namespace TechsysLogProj.API
{
    public static class Startup
    {

        public static IServiceCollection ConfigureServices(this  IServiceCollection services, IConfiguration Configuration)
        {
          
            services.AddApplicationMappers();


            var mongoSettings = Configuration.GetSection("MongoSettings").Get<MongoSettings>();
            var client = new MongoClient(mongoSettings.ConnectionString);
            var database = client.GetDatabase(mongoSettings.Database);

            services.AddSingleton(database);

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IPedidoService, PedidoService>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioRepository,UsuarioRepository>();

          //  services.ConfigureCors();

            services.AddMvc();

            return services;
        }

        public static IServiceCollection AddApplicationMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(PedidoMapper));
            return services;
        }

        //private static IServiceCollection ConfigureCors(this IServiceCollection services)
        //{
        //    services.AddCors(options =>
        //        options.AddPolicy("DefaultCorsPolicy",
        //            builder => builder.AllowAnyOrigin()
        //            .AllowAnyMethod()
        //            .AllowAnyHeader()
        //        )
        //    );

        //    return services;
        //}
    }
}
