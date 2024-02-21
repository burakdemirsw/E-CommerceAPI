using GoogleAPI.Domain.Models.Cargo.Mng.Request;
using GoogleAPI.Domain.Models.Cargo.Mng.Response;
using GoogleAPI.Domain.Models.Order.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooleAPI.Application.Abstractions.IServices.ICargo.IMng
{
    public interface IMNGCargoService
    {
        Task<CreateTokenResponse_MNG> CreateToken( );
        Task<CreatePackage_MNG_Response> CreateCargo(GetOrderDetail_ResponseModel Order ); //CreateOrder
        Task<bool> DeleteCargo( );
        //void UpdateCargo( );
        //void GetCargoById( );
        //void GetCargoList( );
    }
}
