using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TripInc_Wallet.Domain.Entities;
using TripInc_Wallet.Persistence;
using static TripInc_Wallet.Persistence.IAppContext;

namespace TripInc_Wallet.Application.CQRS.PurchaseQueries
{
    public class GetAllPurchaseQuery : IRequest<IEnumerable<Purchase>>
    {

        public class GetAllPurchaseQueryHandler : IRequestHandler<GetAllPurchaseQuery, IEnumerable<Purchase>>
        {
            private readonly IAppDbContext context;
            public GetAllPurchaseQueryHandler(IAppDbContext context)
            {
                this.context = context;
            }
            public async Task<IEnumerable<Purchase>> Handle(GetAllPurchaseQuery query, CancellationToken cancellationToken)
            {
                var PurchaseList = await context.Purchases.ToListAsync();
                if (PurchaseList == null)
                {
                    return null;
                }
                return PurchaseList.AsReadOnly();
            }
        }
    }
}