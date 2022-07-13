using Microsoft.EntityFrameworkCore;
using TripInc_Wallet.Domain.Entities;
using static TripInc_Wallet.Persistence.IAppContext;

namespace TripInc_Wallet.Persistence
{
    public class ApplicationDbContext : DbContext, IAppDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<TopUp> TopUps { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<WalletUserInfo> WalletInfos { get; set; }
        public DbSet<WalletBalance> WalletBalances { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}