using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static TripInc_Wallet.Persistence.IAppContext;
using TripInc_Wallet.Domain.Entities;

namespace TripInc_Wallet.Application.CQRS.WalletUserInfoCommands
{
    public class DeleteWalletUserInfoByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteWalletUserInfoByIdCommandHandler : IRequestHandler<DeleteWalletUserInfoByIdCommand, int>
        {
            private readonly IAppDbContext context;
            public DeleteWalletUserInfoByIdCommandHandler(IAppDbContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(DeleteWalletUserInfoByIdCommand command, CancellationToken cancellationToken)
            {
                var walletuserInfo = await context.WalletInfos.Where(a => a.id == command.Id).FirstOrDefaultAsync();
                if (walletuserInfo == null) return default;
                context.WalletInfos.Remove(walletuserInfo);
                await context.SaveChangesAsync();
                return walletuserInfo.id;
            }
        }
    }
}