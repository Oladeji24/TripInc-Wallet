using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TripInc_Wallet.Domain.Entities;
using TripInc_Wallet.Persistence;
using static TripInc_Wallet.Persistence.IAppContext;

namespace TripInc_Wallet.Application.CQRS.WalletBalanceQueries
{
    public class GetWalletBalanceByIdQuery : IRequest<WalletBalance>
    {
        public int Id { get; set; }
        public class GetWalletBalanceByIdQueryHandler : IRequestHandler<GetWalletBalanceByIdQuery, WalletBalance>
        {
            private readonly IAppDbContext context;
            public GetWalletBalanceByIdQueryHandler(IAppDbContext context)
            {
                this.context = context;
            }
            public async Task<WalletBalance> Handle(GetWalletBalanceByIdQuery query, CancellationToken cancellationToken)
            {
                var walletBalance = await context.WalletBalances.Where(a => a.id == query.Id).FirstOrDefaultAsync();
                if (walletBalance == null) return null;
                return walletBalance;
            }
        }
    }
}