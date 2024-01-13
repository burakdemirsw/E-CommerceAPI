using GoogleAPI.Domain.Entities.User;
using GooleAPI.Application.IRepositories.UserAndCommunication;
using Microsoft.IdentityModel.Tokens;
using Serilog.Context;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class LogUserNameMiddleware
{
    private readonly RequestDelegate next;
    readonly IConfiguration _configuration;

    public LogUserNameMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        this.next = next;
        _configuration = configuration;
    }

    public async Task Invoke(HttpContext context, IUserReadRepository userReadRepository)
    {
        try
        {
            if (context.Request.Headers.ContainsKey("Authorization"))
            {
                var authorizationHeader = context.Request.Headers["Authorization"].ToString();

                // E�er Authorization ba�l��� "Bearer " ile ba�l�yorsa, JWT token� var demektir
                if (authorizationHeader.StartsWith("Bearer "))
                {
                    var jwtToken = authorizationHeader.Substring("Bearer ".Length);

                    // JWT token�n� ��z�mle
                    var claims = GetClaimsFromJwtToken(jwtToken);
                    if (claims == null)
                    {
                        await next(context);
                        return;
                    }
                    // Elde edilen claim bilgilerini loglamak i�in kullanabilirsiniz
                    if (claims.Count > 0)
                    {
                        var email = claims.FirstOrDefault(c => c.Type.Contains("claims/name"))?.Value;
                        User? user = userReadRepository.Table.FirstOrDefault(u => u.Email == email);
                        //Console.WriteLine(user.RefreshToken);
                        LogContext.PushProperty("UserName", user.Email);
                        await next(context);
                        return;
                    }
                    else
                    {
                        LogContext.PushProperty("UserName", Guid.NewGuid().ToString());
                        await next(context);
                        return;
                    }



                }
            }
            else
            {
                LogContext.PushProperty("UserName", Guid.NewGuid().ToString());
                await next(context);
            }
        }
        catch (Exception)
        {


            await next(context);
        }
        // JWT token� "Authorization" ba�l��� alt�nda gelebilir, bu y�zden kontrol edelim




    }

    public List<Claim> GetClaimsFromJwtToken(string jwtToken)
    {
        try
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
            var tokenHandler = new JwtSecurityTokenHandler();

            // Token� do�rula ve ��z�mle
            var principal = tokenHandler.ValidateToken(jwtToken, new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = _configuration["Token:Issuer"],
                ValidateAudience = true,
                ValidAudience = _configuration["Token:Audience"],
                IssuerSigningKey = securityKey,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero // Token�n hala ge�erli oldu�unu kontrol etmek i�in
            }, out SecurityToken validatedToken);

            if (validatedToken is not JwtSecurityToken jwtSecurityToken)
            {
                throw new SecurityTokenException("Invalid JWT token.");
            }

            // JWT token�ndan "claims" alan�n� al�n
            var claims = principal.Claims.ToList();

            return claims;
        }
        catch (Exception)
        {
            return null;

        }

    }
}
