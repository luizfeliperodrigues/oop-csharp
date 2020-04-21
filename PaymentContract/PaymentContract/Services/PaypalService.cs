
namespace PaymentContract.Services
{
    class PaypalService : IOnlinePaymentService
    {
        private const double FeePercentage = 0.02;
        private const double MonthlyInterest = 0.01;

        public double Interest(double installmentValue, int installmentNumber)
        {
            return (installmentValue * MonthlyInterest * installmentNumber);
        }

        public double PaymentFee(double interestValue)
        {
            return (interestValue * FeePercentage);
        }
    }
}
