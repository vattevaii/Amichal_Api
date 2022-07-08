using Amichal.Api.Filter;
using Amichal.Api.Middleware;
using Amichal.Application;
using Amichal.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
{
   builder.Services
       .AddApplication()
       .AddInfrastructure(builder.Configuration);

    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                builder.Configuration.GetSection("JWtSettings:Secret").Value
                )),
            ValidateAudience = false,
            ValidateIssuer = false
        };
    });

    builder.Services.AddAuthorization(o =>
    {
        o.AddPolicy("User", p => p.RequireRole("User", "Admin"));
        o.AddPolicy("Admin", p => p.RequireRole("Admin"));
    });


    builder.Services.AddControllers(
       // Exception handling with filter
       //options => options.Filters.Add<ErrorHandlingFilterAttribute>()
       );
}

var app = builder.Build();
{
    // Exception handling with middleware
    //app.UseMiddleware<ErrorHandlingMiddleWare>();

    // Exception handling with controllers
    app.UseExceptionHandler("/error");
   app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
   
    app.MapControllers();
   app.Run();
}

