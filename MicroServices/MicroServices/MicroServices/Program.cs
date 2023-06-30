
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MicroServices.Model;
using Microsoft.Extensions.Configuration;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();
        var ConnectionString = builder.Configuration.GetConnectionString("AppDb");
        builder.Services.AddTransient<DataSeeder>();
        builder.Services.AddDbContext<EmployeeDbContext>(x => x.UseSqlServer(ConnectionString));

        if (args.Length == 1 && args[ToLower() == "seeddata"])
        {
            SeedData(app);
        }

        void SeedData(IHost app)
        {
            var scopedFactory = app.Services.GetServices<IServiceScopeFactory>();

            using (var scope = scopedFactory.CreateScoup())
            {
                var service = scope.ServiceProvider.GetService<DataSeeder>();
                service.Seed();
            }
        }



        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }


        app.MapGet("/", () => "Verilere ulaþmak için \n http://localhost:5231/employee ve http://localhost:5231/employees adreslerine bakýnýz. ");

        app.MapGet("/employee", () =>
        {

            return new Employee()
            {
                EmployeeId = "1",
                Name = "Onur",
                Surname = "Cakili",
                Country = "Turkey"

            };
        });

        app.MapGet("/employees", () =>
        {
            return new EmployeeCollection().GetEmployees();
        }
        );


        app.MapGet("/employee/{id}", async (http) =>
        {
            if (!http.Request.RouteValues.TryGetValue("id", out var id))
            {
                http.Response.StatusCode = 400;
                return;
            }
            else
            {
                await http.Response.WriteAsJsonAsync(new EmployeeCollection()
                    .GetEmployees()
                    .FirstOrDefault(x => x.EmployeeId == (string)id));
            }
        });






        app.Run();

        static string GetConnectionString(WebApplicationBuilder builder)
        {
            return builder.Configuration.GetConnectionString();
        }

        static int ToLower()
        {
            return 0.ToLower();
        }
    }
}