using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TripInc_Wallet.Domain.Entities;
using static TripInc_Wallet.Persistence.IAppContext;

namespace TripInc_Wallet.Application.CQRS.WalletBalanceCommands
{
    public class DeleteWalletBalanceByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteWalletBalanceByIdCommandHandler : IRequestHandler<DeleteWalletBalanceByIdCommand, int>
        {
            private readonly IAppDbContext context;
            public DeleteWalletBalanceByIdCommandHandler(IAppDbContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(DeleteWalletBalanceByIdCommand command, CancellationToken cancellationToken)
            {
                var walletBalance = await context.WalletBalances.Where(a => a.id == command.Id).FirstOrDefaultAsync();
                if (walletBalance == null) return default;
                context.WalletBalances.Remove(walletBalance);
                await context.SaveChangesAsync();
                return walletBalance.id;
            }
        }
    }
}
