using static Entities.Extention.ServiceExtentionEntities;
using static Infrastructure.Extention.ServiceExtentionInfrastructure;
using static Domain.Extention.ServiceExtentionApplication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Helpers.Utility;
using Domain.Services.TokenService;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddSharedEntities();
builder.Services.AddSharedInfrastructure();
builder.Services.AddSharedApplication();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                        .AddJwtBearer(option =>
                        {
                            option.TokenValidationParameters = new TokenValidationParameters
                            {
                                ValidateIssuer = false,
                                ValidateAudience = false,
                                ValidateLifetime = true,
                                ValidateIssuerSigningKey = true,

                                ValidIssuer = "ClientList.Security.Bearer",
                                ValidAudience = "ClientList.Security.Bearer",
                                IssuerSigningKey = JwtSecurityKey.Create(Util.SecurityKey)
                            };

                            option.Events = new JwtBearerEvents
                            {
                                OnAuthenticationFailed = context =>
                                {
                                    Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                                    return Task.CompletedTask;
                                },

                                OnTokenValidated = context =>
                                {
                                    Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                                    return Task.CompletedTask;
                                }
                            };
                        });

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
