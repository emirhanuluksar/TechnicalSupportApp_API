using TSA.Core.Application;
using TSA.Infrastructure.Persistence;
using TSA.Infrastructure.Security;
using TSA.Infrastructure.Security.Helpers.JWTHelpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using TSA.Infrastructure.Security.Helpers.EncryptionHelpers;
using TSA.Infrastructure.Infrastructure.CrossCuttingConcerns.Exception.WebAPI.Extensions;
using TSA.Infrastructure.Infrastructure;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddSecurityServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen();

TokenOptions tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>() ?? throw new InvalidOperationException("TokenOptions section cannot found in configuration.");
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin",
        builder =>
        {
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });
});


var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


// app.ConfigureCustomExceptionMiddleware();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors("AllowAnyOrigin");

app.MapControllers();

app.UseHttpsRedirection();

app.Run();
