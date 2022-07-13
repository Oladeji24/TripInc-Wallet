using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripInc_Wallet.Domain.Entities
{
    public class WalletBalance : BaseEntry
    {
        public int id { get; set; }
        public decimal Balance { get; set; }
        public DateTime BalanceDate { get; set; }
        public string? UserEmail { get; set; }
    }
}
