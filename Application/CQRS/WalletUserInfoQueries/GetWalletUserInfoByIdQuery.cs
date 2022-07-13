using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TripInc_Wallet.Domain.Entities;
using TripInc_Wallet.Persistence;
using static TripInc_Wallet.Persistence.IAppContext;

namespace TripInc_Wallet.Application.CQRS.WalletUserInfoQueries
{
    public class GetWalletUserInfoByIdQuery : IRequest<WalletUserInfo>
    {
        public int Id { get; set; }
        public class GetWalletUserInfoByIdQueryHandler : IRequestHandler<GetWalletUserInfoByIdQuery, WalletUserInfo>
        {
            private readonly IAppDbContext context;
            public GetWalletUserInfoByIdQueryHandler(IAppDbContext context)
            {
                this.context = context;
            }
            public async Task<WalletUserInfo> Handle(GetWalletUserInfoByIdQuery query, CancellationToken cancellationToken)
            {
                var walletuserInnfo = await context.WalletInfos.Where(a => a.id == query.Id).FirstOrDefaultAsync();
                if (walletuserInnfo == null) return null;
                return walletuserInnfo;
            }
        }
    }
}