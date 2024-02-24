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

//loglama iþlemleri
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


// CORS (Cross-Origin Resource Sharing) ayarlarý yapýlýyor.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        // Ýzin verilen kökenleri (origins) burada belirtiyoruz.
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
                "http://212.156.46.206:4203", "*") // Yýldýz (*) kullanarak herhangi bir kaynaða izin verebilirsiniz.
             .AllowAnyHeader().AllowAnyMethod().AllowCredentials();
    });
});

builder.Services.AddControllers(options =>
{
    options.Filters.Add<RolePermissionFilter>();
}); // Controller'larý ekliyoruz.

// Swagger/OpenAPI belgelerini yapýlandýrma.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationInsightsTelemetry(); // Application Insights için yapýlandýrma ekleniyor.

var app = builder.Build();

// HTTP istek iþleme hattýný yapýlandýrma.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.ConfigureExceptionHandler<Program>();
app.UseCors(); // CORS özelliðini etkinleþtiriyoruz.


app.UseHttpsRedirection(); // HTTPS'e yönlendirme yapýlýyor.
app.UseAuthentication();
app.UseAuthorization(); // Yetkilendirme iþlemleri için kullanýlýyor.
//app.UseSerilogRequestLogging();
//app.UseHttpLogging();
//app.UseMiddleware<LogUserNameMiddleware>();

app.MapControllers(); // Controller'lara yönlendirme yapýlýyor.

app.Run();
