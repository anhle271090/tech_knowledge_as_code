
// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.

// builder.Services.AddControllers();
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();

// app.UseAuthorization();

// app.MapControllers();

// app.Run();

using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        // First step of Net Application lifecyle.
        // (step 1) Application initilization
        // Creating Host Instance and run it
        var builder = WebApplication.CreateBuilder();

        #region using built-in DI framework of Microsoft.
        // with this EmailSender instance will be created every time even if it is the same request
        builder.Services.AddTransient<IEmailSender, EmailSender>();

        // if we register multiple lifetimes for the same service, IoC container will resolve dependency based on the last configuration.
        // So in this case EmailSender instance will be created and reused within the request
        builder.Services.AddScoped<IEmailSender, EmailSender>();

        // Only one service instance is created and shared for all requests
        // This is useful for services that are statefull or need to be accessed globally.
        builder.Services.AddSingleton<IEmailConfiguration, EmailConfiguration>();

        builder.Services.AddScoped<MyDIService>();
        builder.Services.AddScoped<AsychronousProgramming>();

        builder.Services.AddScoped<IPolicyRepository,PolicyRepository>();
        builder.Services.AddScoped<IPolicyService, PolicyService>();
        #endregion

        #region using built-in DI framework for DbContext
        RegisterDbContext(builder);
        #endregion

        // Registrying dependencies for application
        builder.Services.AddControllers();
        builder.Services.AddControllersWithViews();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();
        // Configure middlewares for HTTP Request Pipeline
        app.UseMiddleware<ErrorHandlingMiddleware>();
        // app.UseMiddleware<MyCustomMiddleware>();
        // app.UseMiddleware<MySecondCustomMiddleware>();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseAuthorization();
        app.MapControllers();

        app.Lifetime.ApplicationStarted.Register(OnApplicationStarted);

        app.Run();

        // (step 2) Request Handling
        // (step 3) Application Handling: application handle requests by its logic.
        // (step 4) Response Handling: generating response and send it back to the client by middleware pipeline
        // (step 5) When the application is shuting down. The runtime will performs some cleanup tasks such as closing connections and releasing resources.
        // app.StopAsync();




    }

    private static void RegisterDbContext(WebApplicationBuilder builder)
    {
        string connectionString = "Host=103.174.212.59;Port=5403;Database=stag_myapp;Username=policyexecutoruser;Password=asdfaJewTS2fDX4Zdauhf3K6oR6i4NnqbJLQu2342Viwpb5ioaa";
        builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));
    }

    public static void OnApplicationStarted()
    {
        RootService rootService = new RootService();
        rootService.MainFunction();
    }
}