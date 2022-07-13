using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TripInc_Wallet.Domain.Entities;

namespace TripInc_Wallet.Persistence
{
    public interface IAppContext
    {
        public interface IAppDbContext
        {
            public DbSet<Purchase> Purchases { get; set; }
            public DbSet<TopUp> TopUps { get; set; }
            public DbSet<Voucher> Vouchers { get; set; }
            public DbSet<WalletUserInfo> WalletInfos { get; set; }
            public DbSet<WalletBalance> WalletBalances { get; set; }
            Task<int> SaveChangesAsync();
        }
    }
}