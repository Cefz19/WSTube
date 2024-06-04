using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WSTube.Models.Common;
using WSTube.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: "MyCors",
                builder =>
                {
                    builder.WithHeaders("*");
                    builder.WithOrigins("*");
                    builder.WithMethods("*");
                });
        });

        var appSettingsSection = builder.Configuration.GetSection("AppSettings");
        builder.Services.Configure<AppSettings>(appSettingsSection);

        // jwt
        var appSettings = appSettingsSection.Get<AppSettings>();
        var llave = Encoding.ASCII.GetBytes(appSettings.Secreto);
        builder.Services.AddAuthentication(d =>
        {
            d.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            d.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(d =>
            {
                d.RequireHttpsMetadata = false;
                d.SaveToken = true;
                d.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(llave),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

        builder.Services.AddScoped<IUserService, UserService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseCors("MyCors");

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}