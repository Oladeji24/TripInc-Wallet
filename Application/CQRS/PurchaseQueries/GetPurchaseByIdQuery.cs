using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TripInc_Wallet.Domain.Entities; 
using TripInc_Wallet.Persistence;
using static TripInc_Wallet.Persistence.IAppContext;

namespace TripInc_Wallet.Application.CQRS.PurchaseQueries
{
    public class GetPurchaseByIdQuery : IRequest<Purchase>
    {
        public int Id { get; set; }
        public class GetPurchaseByIdQueryHandler : IRequestHandler<GetPurchaseByIdQuery, Purchase>
        {
            private readonly IAppDbContext context;
            public GetPurchaseByIdQueryHandler(IAppDbContext context)
            {
                this.context = context;
            }
            public async Task<Purchase> Handle(GetPurchaseByIdQuery query, CancellationToken cancellationToken)
            {
                var purchase = await context.Purchases.Where(a => a.id == query.Id).FirstOrDefaultAsync();
                if (purchase == null) return null;
                return purchase;
            }
        }
    }
}