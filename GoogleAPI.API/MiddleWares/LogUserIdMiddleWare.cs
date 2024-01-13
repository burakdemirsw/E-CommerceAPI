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

                // Eðer Authorization baþlýðý "Bearer " ile baþlýyorsa, JWT tokený var demektir
                if (authorizationHeader.StartsWith("Bearer "))
                {
                    var jwtToken = authorizationHeader.Substring("Bearer ".Length);

                    // JWT tokenýný çözümle
                    var claims = GetClaimsFromJwtToken(jwtToken);
                    if (claims == null)
                    {
                        await next(context);
                        return;
                    }
                    // Elde edilen claim bilgilerini loglamak için kullanabilirsiniz
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
        // JWT tokený "Authorization" baþlýðý altýnda gelebilir, bu yüzden kontrol edelim




    }

    public List<Claim> GetClaimsFromJwtToken(string jwtToken)
    {
        try
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
            var tokenHandler = new JwtSecurityTokenHandler();

            // Tokený doðrula ve çözümle
            var principal = tokenHandler.ValidateToken(jwtToken, new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = _configuration["Token:Issuer"],
                ValidateAudience = true,
                ValidAudience = _configuration["Token:Audience"],
                IssuerSigningKey = securityKey,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero // Tokenýn hala geçerli olduðunu kontrol etmek için
            }, out SecurityToken validatedToken);

            if (validatedToken is not JwtSecurityToken jwtSecurityToken)
            {
                throw new SecurityTokenException("Invalid JWT token.");
            }

            // JWT tokenýndan "claims" alanýný alýn
            var claims = principal.Claims.ToList();

            return claims;
        }
        catch (Exception)
        {
            return null;

        }

    }
}
