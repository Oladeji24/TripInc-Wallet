using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripInc_Wallet.Domain.Entities
{
    public class TopUp : BaseEntry
    {
        public decimal TopUpAmount { get; set; }
        public string? ModeofTopUp { get; set; }
        public DateTime TopUpDate { get; set; }
        public decimal AmountDue { get; set; }
    }
    public enum ModeofTopUp
    {
        DebitCard, CreditCard, Transfer
    }
}

