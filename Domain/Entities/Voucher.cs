using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace TripInc_Wallet.Domain.Entities
{
    public class Voucher : BaseEntry
    {
        public string? VoucherName { get; set; }
        public string? VoucherCode { get; set; }
        public decimal VoucherAmount { get; set; }
        public DateTime VoucherCreatedDate { get; set; }
        public DateTime VoucherExpiryDate { get; set; }
        public bool IsValid { get; set; }
        public string? VoucherUserEmail { get; set; }
        public string? VoucherType { get; set; }
    }
    public enum VoucherType
    {
        OnceInLifeTimeVoucher, UserContinousVoucher, CostReductionVoucher
    }
}
