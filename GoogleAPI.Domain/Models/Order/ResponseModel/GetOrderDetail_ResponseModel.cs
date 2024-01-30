using GoogleAPI.Domain.Models.Order.ViewModel;
using GoogleAPI.Domain.Models.User.ViewModel;

namespace GoogleAPI.Domain.Models.Order.ResponseModel
{
    public class GetOrderDetail_ResponseModel
    {

        //public List<BasketItemList_VM>? Items { get; set; }
        public UserShippingAddress_VM Address { get; set; }
        public OrderUser_VM User { get; set; }
        public OrderList_VM OrderDetail {  get; set; }

    }


}
