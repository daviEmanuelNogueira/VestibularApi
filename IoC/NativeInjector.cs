using Core.Interface;
using Core.Interface.Services;
using Core.Services;
using Infraestrutura.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace IoC
{
    public class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Services

            services.AddScoped<IAlunoService, AlunoService>();
            services.AddScoped<IProvaService, ProvaService>();
            services.AddScoped<IRespostaService, RespostaService>();
            services.AddScoped<IQuestaoService, QuestaoService>();
            #endregion

            #region Repositories

            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IQuestaoRepository, QuestaoRepository>();
            services.AddScoped<IRespostaRepository, RespostaRepository>();
            services.AddScoped<IProvaRepository, ProvaRepository>();

            #endregion
        }
    }
}
