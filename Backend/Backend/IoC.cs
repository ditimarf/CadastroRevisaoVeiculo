using Backend.Repository;
using Backend.Services;

namespace Backend
{
    public static class IoC
	{
		public static void AdicionarInjecaoDeDependencia(this WebApplicationBuilder builder)
		{
            builder.Services.AddScoped<CarroRepository>();
            builder.Services.AddScoped<CaminhaoRepository>();
            builder.Services.AddScoped<RevisaoRepository>();
            builder.Services.AddScoped<VeiculoRepository>();

            builder.Services.AddScoped<RevisaoService>();
            builder.Services.AddScoped<VeiculoService>();
        }
	}
}

