using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TripInc_Wallet.Domain.Entities;
using TripInc_Wallet.Persistence;
using static TripInc_Wallet.Persistence.IAppContext;

namespace TripInc_Wallet.Application.CQRS.VoucherCommands
{
    public class DeleteVoucherByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteVoucherByIdCommandHandler : IRequestHandler<DeleteVoucherByIdCommand, int>
        {
            private readonly IAppDbContext context;
            public DeleteVoucherByIdCommandHandler(IAppDbContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(DeleteVoucherByIdCommand command, CancellationToken cancellationToken)
            {
                var student = await context.Vouchers.Where(a => a.id == command.Id).FirstOrDefaultAsync();
                if (student == null) return default;
                context.Vouchers.Remove(student);
                await context.SaveChangesAsync();
                return student.id;
            }
        }
    }
}