using bettingsoccerscoresapi.Domains.UserService.UserPage;
using Microsoft.EntityFrameworkCore;
using betting.soccer.scores.api.Domains.UserService.AuthorizationEntity;
using betting.soccer.scores.api.Domains.UserService.UserPage;
using betting.soccer.scores.api.Infraestructure;
using betting.soccer.scores.api.Mediators.UserService.UserPage;
using betting.soccer.scores.api.Domains.SoccerTeamService.SoccerTeamPage;
using betting.soccer.scores.api.Utilities;
using betting.soccer.scores.api.Domains.SoccerGameService.SoccerGamePage;
using betting.soccer.scores.api.Mediators.SoccerGameService.SoccerGamePage;

var builder = WebApplication.CreateBuilder(args);

DataContext _context;
// Add services to the container.
{
    var services = builder.Services;
    var env = builder.Environment;

    // Update ASPNETCORE_ENVIRONMENT={Development} 
    if (env.IsProduction() || env.IsDevelopment())
    {
        services.AddDbContext<DataContext, SqlServerDataContext>(ServiceLifetime.Transient);
    }

    services.AddCors();
    services.AddControllers();

    // configure automapper with all automapper profiles from this assembly
    services.AddAutoMapper(typeof(Program));

    // configure strongly typed settings object
    services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
    // configure DI for application services
    services.AddScoped<IJwtUtils, JwtUtils>();

    services.AddScoped<SoccerTeamProcessor>();
    services.AddScoped<ISoccerGame, SoccerGameMediator>();
    services.AddScoped<IRegisterSoccerGame, SoccerGameMediator>();

    services.AddScoped<SoccerGameProcessor>();
    services.AddScoped<IRegisterSoccerTeam, SoccerTeamMediator>();
    services.AddTransient<ISoccerTeam, SoccerTeamMediator>();
    services.AddScoped<IGetSoccerTeam, SoccerTeamMediator>();
}

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// migrate any database changes on startup (includes initial db creation)
using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    dataContext.Database.Migrate();
    DbInitializer.Initialize(dataContext, builder.Environment);
}

// Configure the HTTP request pipeline.
{
    // global cors policy
    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    // global error handler
    app.UseMiddleware<ErrorHandlerMiddleware>();

    // custom jwt auth middleware
    app.UseMiddleware<JwtMiddleware>();

    app.MapControllers();
}
app.Run();