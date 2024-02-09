using GoogleAPI.Domain.Models.Order.CommandModel;
using GoogleAPI.Domain.Models.Payment.CommandModel;
using GoogleAPI.Domain.Models.User.ViewModel;

namespace GoogleAPI.Domain.Models.Payment
{
    public class Payment_CommandModel
    {
        public string BasketId { get; set; }
        public string BasketPrice { get; set; }
        public UserList_VM User { get; set; }
        public List<GetBasketProductsFilter_ResponseModel> BasketItems { get; set; }
        public UserShippingAddress_VM Address { get; set; }
        public CredidCartModel? CredidCard { get; set; }

        //billing address de eklencek
    }
}
