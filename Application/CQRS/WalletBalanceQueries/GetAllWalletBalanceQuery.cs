using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TripInc_Wallet.Domain.Entities;
using TripInc_Wallet.Persistence;
using static TripInc_Wallet.Persistence.IAppContext;

namespace TripInc_Wallet.Application.CQRS.WalletBalanceQueries
{
    public class GetAllWalletBalanceQuery : IRequest<IEnumerable<WalletBalance>>
    {

        public class GetAllWalletBalanceQueryHandler : IRequestHandler<GetAllWalletBalanceQuery, IEnumerable<WalletBalance>>
        {
            private readonly IAppDbContext context;
            public GetAllWalletBalanceQueryHandler(IAppDbContext context)
            {
                this.context = context;
            }
            public async Task<IEnumerable<WalletBalance>> Handle(GetAllWalletBalanceQuery query, CancellationToken cancellationToken)
            {
                var walletBalanceList = await context.WalletBalances.ToListAsync();
                if (walletBalanceList == null)
                {
                    return null;
                }
                return walletBalanceList.AsReadOnly();
            }
        }
    }
}