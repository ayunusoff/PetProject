using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using PetProject.Interfaces;
using PetProject.Entities;
using VueCliMiddleware;
using PetProject.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DB");

builder.Services.AddDbContext<PetProjectContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddControllers();

builder.Services.AddSpaStaticFiles(configuration => configuration.RootPath = "clientapp/dist");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<DbContext, PetProjectContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

var app = builder.Build();
app.UseCors(builder => builder.AllowAnyOrigin());
app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints => 
    {
        endpoints.MapControllers();
    });

app.UseSpaStaticFiles();

app.UseSpa(spa => 
    {
        spa.Options.SourcePath = "clientapp";
        if (app.Environment.IsDevelopment()) 
        {
            spa.UseVueCli(npmScript: "serve");
        }
    });

app.Run();
