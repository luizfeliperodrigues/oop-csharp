using System;
using PaymentContract.Entities;
using PaymentContract.Services;

namespace PaymentContract.Services
{
    class ContractService
    {
        private IOnlinePaymentService _onlinePaymentService;

        public ContractService(IOnlinePaymentService onlinePaymentService)
        {
            _onlinePaymentService = onlinePaymentService;
        }

        public void ProcessContract(Contract contract, int months)
        {
            double basicQuota = contract.TotalValue / months;

            for(int i=1; i <= months; i++)
            {
                DateTime installmentDate = contract.Date.AddMonths(i);
                double interestValue = _onlinePaymentService.Interest(basicQuota, i);
                double feeValue = _onlinePaymentService.PaymentFee(basicQuota);
                double installmentValue = basicQuota + interestValue + feeValue;

                contract.AddInstallment(new Installment(installmentDate, installmentValue));
            }
        }
    }
}
