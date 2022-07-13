using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TripInc_Wallet.Domain.Entities;
using static TripInc_Wallet.Persistence.IAppContext;

namespace TripInc_Wallet.Application.CQRS.WalletUserInfoCommands
{
    public class UpdateWalletUserInfoCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Rank { get; set; }
        public class UpdateWalletUserInfoCommandHandler : IRequestHandler<UpdateWalletUserInfoCommand, int>
        {
            private readonly IAppDbContext context;
            public UpdateWalletUserInfoCommandHandler(IAppDbContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(UpdateWalletUserInfoCommand command, CancellationToken cancellationToken)
            {
                var walletuserinfo = context.WalletInfos.Where(a => a.id == command.Id).FirstOrDefault();

                if (walletuserinfo == null)
                    return default;

                walletuserinfo.FirstName = command.FirstName;
                walletuserinfo.LastName = command.LastName;
                await context.SaveChangesAsync();
                return walletuserinfo.id;
            }
        }
    }
}