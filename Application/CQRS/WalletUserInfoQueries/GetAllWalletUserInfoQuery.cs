using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TripInc_Wallet.Domain.Entities;
using TripInc_Wallet.Persistence;
using static TripInc_Wallet.Persistence.IAppContext;

namespace TripInc_Wallet.Application.CQRS.WalletUserInfoQueries
{
    public class GetAllWalletUserInfoQuery : IRequest<IEnumerable<WalletUserInfo>>
    {

        public class GetAllWalletUserInfoQueryHandler : IRequestHandler<GetAllWalletUserInfoQuery, IEnumerable<WalletUserInfo>>
        {
            private readonly IAppDbContext context;
            public GetAllWalletUserInfoQueryHandler(IAppDbContext context)
            {
                this.context = context;
            }
            public async Task<IEnumerable<WalletUserInfo>> Handle(GetAllWalletUserInfoQuery query, CancellationToken cancellationToken)
            {
                var walletuserInfo = await context.WalletInfos.ToListAsync();
                if (walletuserInfo == null)
                {
                    return null;
                }
                return walletuserInfo.AsReadOnly();
            }
        }
    }
}