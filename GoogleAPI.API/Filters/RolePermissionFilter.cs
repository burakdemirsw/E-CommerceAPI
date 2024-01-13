using GoogleAPI.Domain.Entities.User;
using GooleAPI.Application.Abstractions.IServices.IUser;
using GooleAPI.Application.CustomAttributes;
using GooleAPI.Application.IRepositories.UserAndCommunication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace GoogleAPI.API.Filters;
public class RolePermissionFilter : IAsyncActionFilter
{
    readonly IUserService _userService;
    readonly IUserReadRepository _ur;
    readonly IConfiguration _configuration;
    public RolePermissionFilter(IUserService userService, IUserReadRepository ur, IConfiguration configuration)
    {
        _userService = userService;
        _ur = ur;
        _configuration = configuration;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        string? email = null;
        if (context.HttpContext.Request.Headers.ContainsKey("Authorization"))
        {
            var authorizationHeader = context.HttpContext.Request.Headers["Authorization"].ToString();

            // Eðer Authorization baþlýðý "Bearer " ile baþlýyorsa, JWT tokený var demektir
            if (authorizationHeader.StartsWith("Bearer "))
            {
                var jwtToken = authorizationHeader.Substring("Bearer ".Length);

                // JWT tokenýný çözümle
                var claims = GetClaimsFromJwtToken(jwtToken);
                if (claims != null)

                {
                    if (claims.Count > 0)
                    {
                        email = claims.FirstOrDefault(c => c.Type.Contains("claims/name"))?.Value;

                    }
                }

                // Elde edilen claim bilgilerini loglamak için kullanabilirsiniz





            }
        }


        if (!string.IsNullOrEmpty(email) && email != "demir.burock96@gmail.com")
        {
            try
            {
                User? user = _ur.Table.FirstOrDefault(u => u.Email == email);
                var descriptor = context.ActionDescriptor as ControllerActionDescriptor;
                var attribute = descriptor.MethodInfo.GetCustomAttribute(typeof(AuthorizeDefinitionAttribute)) as AuthorizeDefinitionAttribute;
                if (attribute == null) //eðer AuthorizeDefinition yoksa zaten direkt actiona ulaþ
                {
                    await next();
                }
                else
                {


                    var httpAttribute = descriptor.MethodInfo.GetCustomAttribute(typeof(HttpMethodAttribute)) as HttpMethodAttribute;

                    var code = $"{(httpAttribute != null ? httpAttribute.HttpMethods.First() : HttpMethods.Get)}.{attribute.ActionType}.{attribute.Definition.Replace(" ", "")}";

                    var hasRole = await _userService.HasRolePermissionToEndpointAsync(user.Id, code);

                    if (!hasRole)
                        context.Result = new UnauthorizedResult();
                    else
                        await next();
                }

            }
            catch (Exception)
            {
                context.Result = new UnauthorizedResult();

            }

        }
        else
            await next();
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
