using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TripInc_Wallet.Domain.Entities;
using TripInc_Wallet.Persistence;
using static TripInc_Wallet.Persistence.IAppContext;

namespace TripInc_Wallet.Application.CQRS.VoucherQueries
{
    public class GetVoucherByIdQuery : IRequest<Voucher>
    {
        public int Id { get; set; }
        public class GetVoucherByIdQueryHandler : IRequestHandler<GetVoucherByIdQuery, Voucher>
        {
            private readonly IAppDbContext context;
            public GetVoucherByIdQueryHandler(IAppDbContext context)
            {
                this.context = context;
            }
            public async Task<Voucher> Handle(GetVoucherByIdQuery query, CancellationToken cancellationToken)
            {
                var voucher = await context.Vouchers.Where(a => a.id == query.Id).FirstOrDefaultAsync();
                if (voucher == null) return null;
                return voucher;
            }
        }
    }
}