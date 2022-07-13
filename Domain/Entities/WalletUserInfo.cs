using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TripInc_Wallet.Domain.Entities
{
    public class WalletUserInfo : BaseEntry
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
