using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TripInc_Wallet.Domain.Entities;
using TripInc_Wallet.Persistence;
using static TripInc_Wallet.Persistence.IAppContext;
namespace TripInc_Wallet.Application.CQRS.WalletBalanceCommands
{
    public class UpdateWalletBalanceCommand : IRequest<int>
    {
        public int id { get; set; }
        public decimal Balance { get; set; }
        public DateTime BalanceDate { get; set; }
        public string? UserEmail { get; set; }
        public class UpdateWalletBalanceCommandHandler : IRequestHandler<UpdateWalletBalanceCommand, int>
        {
            private readonly IAppDbContext context;
            public UpdateWalletBalanceCommandHandler(IAppDbContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(UpdateWalletBalanceCommand command, CancellationToken cancellationToken)
            {
                var walletbalance = context.WalletBalances.Where(a => a.id == command.id).FirstOrDefault();

                if (walletbalance == null)
                    return default;

                walletbalance.Balance = command.Balance;
                walletbalance.BalanceDate = command.BalanceDate;
                walletbalance.UserEmail = command.UserEmail;
                await context.SaveChangesAsync();
                return walletbalance.id;
            }
        }
    }
}