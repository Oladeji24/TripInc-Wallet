using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripInc_Wallet.Domain.Entities
{
    public class Purchase : BaseEntry
    {
        public decimal AmountDue { get; set; }
        public string? VoucherCode { get; set; }
        public decimal AmountPaid { get; set; }
        // Purpose of Payment
        public string? PaymentParticulars { get; set; }
        public string? ModeOfPayment { get; set; }
    }
    public enum ModeOfPayment
    {
        DebitCard, CreditCard, Transfer
    }
}
