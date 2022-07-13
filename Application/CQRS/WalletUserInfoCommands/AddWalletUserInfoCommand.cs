using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TripInc_Wallet.Domain.Entities;
using TripInc_Wallet.Persistence;
using static TripInc_Wallet.Persistence.IAppContext;

namespace TripInc_Wallet.Application.CQRS.WalletUserInfoCommands
{
    public class AddWalletUserInfoCommand : IRequest<int>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public class AddWalletUserInfoCommandHandler : IRequestHandler<AddWalletUserInfoCommand, int>
        {
            private readonly IAppDbContext context;
            public AddWalletUserInfoCommandHandler(IAppDbContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(AddWalletUserInfoCommand command, CancellationToken cancellationToken)
            {
                var walletUserInfo = new WalletUserInfo();
                walletUserInfo.FirstName = command.FirstName;
                walletUserInfo.LastName = command.LastName;

                context.WalletInfos.Add(walletUserInfo);
                await context.SaveChangesAsync();
                return walletUserInfo.id;
            }
        }
    }
}