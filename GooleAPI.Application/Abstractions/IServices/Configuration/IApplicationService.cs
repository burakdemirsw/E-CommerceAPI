using GooleAPI.Application.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooleAPI.Application.Abstractions.IServices.Configuration
{
    public interface IApplicationService

    {
        Task<List<Menu>> GetAuthorizeDefinitionEndpoints(Type type);
    }
}
