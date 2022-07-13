using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TripInc_Wallet.Domain.Entities;
using TripInc_Wallet.Persistence;
using static TripInc_Wallet.Persistence.IAppContext;

namespace TripInc_Wallet.Application.CQRS.TopUpQueries
{
    public class GetTopUpByIdQuery : IRequest<TopUp>
    {
        public int Id { get; set; }
        public class GetTopUpByIdQueryHandler : IRequestHandler<GetTopUpByIdQuery, TopUp>
        {
            private readonly IAppDbContext context;
            public GetTopUpByIdQueryHandler(IAppDbContext context)
            {
                this.context = context;
            }
            public async Task<TopUp> Handle(GetTopUpByIdQuery query, CancellationToken cancellationToken)
            {
                var topUp = await context.TopUps.Where(a => a.id == query.Id).FirstOrDefaultAsync();
                if (topUp == null) return null;
                return topUp;
            }
        }
    }
}