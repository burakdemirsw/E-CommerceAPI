using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooleAPI.Application.Abstractions.IServices.ICargo.IAras
{
    public interface IArasCargoService
    {
        void CreateCargo( );
        void DeleteCargo( );
        void UpdateCargo( );
        void GetCargoById( );
        void GetCargoList( );
    }
}
