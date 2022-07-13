using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TripInc_Wallet.Domain.Entities;
using TripInc_Wallet.Persistence;
using static TripInc_Wallet.Persistence.IAppContext;

namespace TripInc_Wallet.Application.CQRS.TopUpCommands
{
    public class DeleteTopUpByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteTopUpByIdCommandHandler : IRequestHandler<DeleteTopUpByIdCommand, int>
        {
            private readonly IAppDbContext context;
            public DeleteTopUpByIdCommandHandler(IAppDbContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(DeleteTopUpByIdCommand command, CancellationToken cancellationToken)
            {
                var topUp = await context.TopUps.Where(a => a.id == command.Id).FirstOrDefaultAsync();
                if (topUp == null) return default;
                context.TopUps.Remove(topUp);
                await context.SaveChangesAsync();
                return topUp.id;
            }
        }
    }
}