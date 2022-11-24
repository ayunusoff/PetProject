using Microsoft.AspNetCore.SpaServices;
using VueCliMiddleware;
using Microsoft.Extensions.DependencyInjection;
using PetProject.DBContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("PetDB");
builder.Services.AddDbContext<PetProjectContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddControllers();
builder.Services.AddSpaStaticFiles(configuration => configuration.RootPath = "clientapp/dist");
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

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
