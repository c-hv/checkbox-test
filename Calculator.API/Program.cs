
using Calculator.API.Contracts;
using Calculator.API.Services;

namespace Calculator.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(options =>
                options.AddDefaultPolicy(policyBuilder =>
                    policyBuilder
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin()
                    ));

            RegisterCalculationStrategies(builder.Services);
            RegisterCalculationServices(builder.Services);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.UseCors();

            app.Run();
        }

        private static void RegisterCalculationServices(IServiceCollection services)
        {
            services.AddSingleton<ICalculationService, CalculationService>();
            services.AddSingleton<IOperationsService, OperationsService>();
        }

        private static void RegisterCalculationStrategies(IServiceCollection services)
        {
            var strategyType = typeof(ICalculationStrategy);
            var strategies = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => strategyType.IsAssignableFrom(type) && type is { IsInterface: false, IsAbstract: false });

            foreach (var strategy in strategies)
            {
                services.AddSingleton(strategyType, strategy);
            }
        }
    }
}
