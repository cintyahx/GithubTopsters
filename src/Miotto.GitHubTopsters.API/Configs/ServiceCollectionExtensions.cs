using Microsoft.AspNetCore.Http.Json;
using Miotto.GitHubTopsters.Domain.Interfaces;
using Miotto.GitHubTopsters.Gateway;
using Miotto.GitHubTopsters.Infra.Repositories;
using Miotto.GitHubTopsters.Service;
using System.Diagnostics.CodeAnalysis;

namespace Miotto.GitHubTopsters.API.Configs
{
    [ExcludeFromCodeCoverage]
    public static partial class ServiceCollectionExtensions
    {
        public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
        {
            var devCorsPolicy = "GithubTopstersCORS";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(devCorsPolicy, builder =>
                {
                    builder.WithOrigins("*");
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });

            builder.Services.AddScoped<IGithubService, GithubService>();
            builder.Services.AddTransient<IGithubGateway, GithubGateway>();
            builder.Services.AddScoped<IGithubRepoRepository, GithubRepoRepository>();

            builder.Services.Configure<JsonOptions>(o => { o.SerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull; });

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return builder;
        }
    }
}
