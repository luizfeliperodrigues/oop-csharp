
namespace PaymentContract.Services
{
    interface IOnlinePaymentService
    {
        public double Interest(double installmentValue, int installmentNumber);

        public double PaymentFee(double interestValue);
    }
}
