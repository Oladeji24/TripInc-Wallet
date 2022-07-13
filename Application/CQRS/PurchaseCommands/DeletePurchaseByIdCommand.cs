using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static TripInc_Wallet.Persistence.IAppContext;
using TripInc_Wallet.Domain.Entities;

namespace TripInc_Wallet.Application.CQRS.PurchaseCommands
{
    public class DeletePurchaseByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeletePurchaseByIdCommandHandler : IRequestHandler<DeletePurchaseByIdCommand, int>
        {
            private readonly IAppDbContext context;
            public DeletePurchaseByIdCommandHandler(IAppDbContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(DeletePurchaseByIdCommand command, CancellationToken cancellationToken)
            {
                var purchase = await context.Purchases.Where(a => a.id == command.Id).FirstOrDefaultAsync();
                if (purchase == null) return default;
                context.Purchases.Remove(purchase);
                await context.SaveChangesAsync();
                return purchase.id;
            }
        }
    }
}