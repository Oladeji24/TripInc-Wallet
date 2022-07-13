using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TripInc_Wallet.Domain.Entities;
using TripInc_Wallet.Persistence;
using static TripInc_Wallet.Persistence.IAppContext;

namespace TripInc_Wallet.Application.CQRS.VoucherQueries
{
    public class GetAllVoucherQuery : IRequest<IEnumerable<Voucher>>
    {

        public class GetAllVoucherQueryHandler : IRequestHandler<GetAllVoucherQuery, IEnumerable<Voucher>>
        {
            private readonly IAppDbContext context;
            public GetAllVoucherQueryHandler(IAppDbContext context)
            {
                this.context = context;
            }
            public async Task<IEnumerable<Voucher>> Handle(GetAllVoucherQuery query, CancellationToken cancellationToken)
            {
                var studentList = await context.Vouchers.ToListAsync();
                if (studentList == null)
                {
                    return null;
                }
                return studentList.AsReadOnly();
            }
        }
    }
}