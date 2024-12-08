using AsmrsBackend.Data;
using AsmrsBackend.Repositories;
using AsmrsBackend.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

var jwtval = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtval["Key"]);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDBSettings"));

builder.Services.AddSingleton<AppDbContext>();

builder.Services.AddSingleton<IMongoDatabase>(sp =>
{
    var settings = sp.GetRequiredService<IConfiguration>().GetSection("MongoDBSettings").Get<MongoDBSettings>();
    var client = new MongoClient(settings.ConnectionString);
    return client.GetDatabase(settings.DatabaseName);
});

//Entity framework
//builder.Services.AddDbContext<AppDbContext>(i => i.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//Authentication
builder.Services.AddAuthentication(i =>
{
    i.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    i.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(i =>
{
    i.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtval["Issuer"],
        ValidAudience = jwtval["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});


//Authorization

builder.Services.AddAuthorization(i =>
{
    i.AddPolicy("AdminOnly", j => j.RequireRole("Admin"));
    i.AddPolicy("All", j => j.RequireRole("Admin", "Visitor", "Tourguide", "Researcher", "Conservator"));
    i.AddPolicy("TourguideOnly", j => j.RequireRole("Tourguide", "Admin"));
    
});

builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddScoped<IArtifactRepository, ArtifactRepository>();
builder.Services.AddScoped<IArtifactService, ArtifactService>();
builder.Services.AddScoped<ISiteRepository, SiteRepository>();
builder.Services.AddScoped<ISiteService, SiteService>();
builder.Services.AddScoped<IPublicationRepository, PublicationRepository>();
builder.Services.AddScoped<IPublicationService, PublicationService>();
builder.Services.AddScoped<IConservationProjectRepository, ConservationProjectRepository>();
builder.Services.AddScoped<IConservationProjectService, ConservationProjectService>(); 
builder.Services.AddScoped<IExcavationService, ExcavationService>();
builder.Services.AddScoped<IExcavationRepository, ExcavationRepository>();
builder.Services.AddScoped<IVisitorTourRepository, VisitorTourRepository>();
builder.Services.AddScoped<IVisitorTourService, VisitorTourService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
public class MongoDBSettings
{
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
}