using GoogleAPI.API.Extentions;
using GoogleAPI.API.Filters;
using GooleAPI.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using System.Data;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Servisler ekleniyor.

builder.Services.AddPersistanceServices();
builder.Services.AddHttpContextAccessor();
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(
        "Admin",
        options =>
        {
            options.TokenValidationParameters = new()
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidAudience = builder.Configuration["Token:Audience"],
                ValidIssuer = builder.Configuration["Token:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])
                ),
                LifetimeValidator = (notBefore, expires, securityToken, validationParameters) =>
                    expires != null ? expires > DateTime.UtcNow : false,
                NameClaimType = ClaimTypes.Name
            };
        }
    );

//loglama i�lemleri
var columnOptions = new ColumnOptions
{
    AdditionalColumns = new Collection<SqlColumn>
    {
        new SqlColumn
        {

            ColumnName = "UserName",
            PropertyName = "UserName",
            DataType = SqlDbType.NVarChar,
            DataLength = 64
        },
    }
};
Logger logger = new LoggerConfiguration()
          .WriteTo.MSSqlServer(
              connectionString: builder.Configuration.GetConnectionString("SqlServer"),
              sinkOptions: new MSSqlServerSinkOptions
              {
                  TableName = "Logs",
                  AutoCreateSqlTable = true,


              }, columnOptions: columnOptions)
          .Enrich.FromLogContext()
          .MinimumLevel.Information()
          .CreateLogger();

builder.Host.UseSerilog(logger);

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("sec-ch-ua");
    logging.ResponseHeaders.Add("MyResponseHeader");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 9999;
    logging.ResponseBodyLogLimit = 9999;
});


// CORS (Cross-Origin Resource Sharing) ayarlar� yap�l�yor.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        // �zin verilen k�kenleri (origins) burada belirtiyoruz.
        policy
            .WithOrigins(
                 "http://localhost:7180",
                "http://localhost:4200",
                "http://localhost:4203",
                 "http://localhost:4202",
                "http://192.168.2.36:7180",
                "http://192.168.2.36:4203",
                "http://192.168.2.36:4200",
                 "http://192.168.2.36:4202",
                "http://212.156.46.206:4200",
                 "http://212.156.46.206:4202",
                "http://212.156.46.206:7180",
                "http://212.156.46.206:4203", "*") // Y�ld�z (*) kullanarak herhangi bir kayna�a izin verebilirsiniz.
             .AllowAnyHeader().AllowAnyMethod().AllowCredentials();
    });
});

builder.Services.AddControllers(options =>
{
    options.Filters.Add<RolePermissionFilter>();
}); // Controller'lar� ekliyoruz.

// Swagger/OpenAPI belgelerini yap�land�rma.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationInsightsTelemetry(); // Application Insights i�in yap�land�rma ekleniyor.

var app = builder.Build();

// HTTP istek i�leme hatt�n� yap�land�rma.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.ConfigureExceptionHandler<Program>();
app.UseCors(); // CORS �zelli�ini etkinle�tiriyoruz.


app.UseHttpsRedirection(); // HTTPS'e y�nlendirme yap�l�yor.
app.UseAuthentication();
app.UseAuthorization(); // Yetkilendirme i�lemleri i�in kullan�l�yor.
//app.UseSerilogRequestLogging();
//app.UseHttpLogging();
//app.UseMiddleware<LogUserNameMiddleware>();

app.MapControllers(); // Controller'lara y�nlendirme yap�l�yor.

app.Run();
