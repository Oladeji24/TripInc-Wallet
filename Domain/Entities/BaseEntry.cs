using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripInc_Wallet.Domain.Entities
{
    public class BaseEntry
    {
        public int id { get; set; }
        public string? UserEmail { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
        public DateTime SearchDate { get; set; }
    }
}
