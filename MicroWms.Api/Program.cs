using Microsoft.EntityFrameworkCore;
using MicroWms.Api.Data;

public partial class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<WmsDbContext>(options =>
                                                                options.UseNpgsql(
        builder.Configuration.GetConnectionString("WmsDatabase")));

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("Angular", policy =>
            {
                policy
                    .WithOrigins("http://192.168.1.186:4200", "http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<WmsDbContext>();

            var canConnect = dbContext.Database.CanConnect();

            Console.WriteLine($"PostgreSQL connection: {canConnect}");
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseCors("Angular");
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}