using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Miotto.GitHubTopsters.API.Configs;
using Miotto.GitHubTopsters.Domain.Dtos;
using Miotto.GitHubTopsters.Domain.Validators;
using Miotto.GitHubTopsters.Infra;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddScoped<IValidator<SearchGithubDto>, SearchGithubValidator>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.AddServices();

builder.Services.AddDbContext<GithubTopstersContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("TopstersContextConnection")));

var app = builder.Build();
app.UseCors("GithubTopstersCORS");

#region Database Migrations

using var provider = app.Services.CreateScope();
var context = provider.ServiceProvider.GetRequiredService<GithubTopstersContext>();
context.Database.Migrate();

#endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
