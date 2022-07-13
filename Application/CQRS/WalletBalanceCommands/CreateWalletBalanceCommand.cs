using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TripInc_Wallet.Domain.Entities;
using TripInc_Wallet.Persistence;
using static TripInc_Wallet.Persistence.IAppContext;

namespace TripInc_Wallet.Application.CQRS.WalletBalanceCommands
{
    public class CreateWalletBalanceCommand : IRequest<int>
    {
        public int id { get; set; }
        public decimal Balance { get; set; }
        public DateTime BalanceDate { get; set; }
        public string? UserEmail { get; set; }
        public class CreateWalletBalanceCommandHandler : IRequestHandler<CreateWalletBalanceCommand, int>
        {
            private readonly IAppDbContext context;
            public CreateWalletBalanceCommandHandler(IAppDbContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(CreateWalletBalanceCommand command, CancellationToken cancellationToken)
            {
                var walletbalance = new WalletBalance();
                walletbalance.Balance = command.Balance;
                walletbalance.BalanceDate = command.BalanceDate;
                walletbalance.UserEmail = command.UserEmail;

                context.WalletBalances.Add(walletbalance);
                await context.SaveChangesAsync();
                return walletbalance.id;
            }
        }
    }
}