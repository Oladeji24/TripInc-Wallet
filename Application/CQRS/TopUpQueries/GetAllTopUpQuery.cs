using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TripInc_Wallet.Domain.Entities;
using TripInc_Wallet.Persistence;
using static TripInc_Wallet.Persistence.IAppContext;

namespace TripInc_Wallet.Application.CQRS.TopUpQueries
{
    public class GetAllTopUpQuery : IRequest<IEnumerable<TopUp>>
    {

        public class GetAllTopUpQueryHandler : IRequestHandler<GetAllTopUpQuery, IEnumerable<TopUp>>
        {
            private readonly IAppDbContext context;
            public GetAllTopUpQueryHandler(IAppDbContext context)
            {
                this.context = context;
            }
            public async Task<IEnumerable<TopUp>> Handle(GetAllTopUpQuery query, CancellationToken cancellationToken)
            {
                var topUpList = await context.TopUps.ToListAsync();
                if (topUpList == null)
                {
                    return null;
                }
                return topUpList.AsReadOnly();
            }
        }
    }
}