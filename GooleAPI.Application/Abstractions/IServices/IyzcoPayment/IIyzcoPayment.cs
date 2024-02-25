using GoogleAPI.Domain.Entities.All_Settings;
using GoogleAPI.Domain.Models;
using GoogleAPI.Domain.Models.Payment;
using GoogleAPI.Domain.Models.Payment.CommandResponse;
using GoogleAPI.Domain.Models.Payment.Filter;
using GoogleAPI.Domain.Models.Payment.ViewModel;
using Iyzipay.Model;
using Iyzipay.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooleAPI.Application.Abstractions.IServices.IyzcoPayment
{
    public interface IIyzcoPayment
    {
        //void PayWithIyzco( );
        //Payment PayWithIyzco2(CreatePaymentRequest request);

        //PayWithIyzicoInitialize PayWithIyzco3(CreatePayWithIyzicoInitializeRequest request);
        Task<CreditCardPayment_CommandResponse> IyzcoPayment(Payment_CommandModel model);

        Task<CreditCardPayment_CommandResponse> PayTRPayment(Payment_CommandModel model);

        Task<CreditCardPayment_CommandResponse> OtherPayments(int basketId, string paymentDescription, Guid token);
        //-------------------------------------------------------------------------
        //ödeme tiplerini çek

        //ödeme listeleme 

        //ödeme durumu güncellme
        Task<bool> UpdatePaymentStatus(int paymentId ,bool status);
        //ödeme ekleme
        Task<bool> AddPayment(Payment_VM request);
        //ödeme silme
        Task<bool> DeletePayment(int request);

        //ödeme entegrasyonları
        Task<List<PaymentMethod_VM>> GetPaymentMethodList( );
        Task<bool> AddPaymentMethod(PaymentMethod_VM request);
        Task<bool> UpdatePaymentMethod(PaymentMethod_VM request);
        Task<bool> DeletePaymentMethod(int paymentMethodId);
    }

}
