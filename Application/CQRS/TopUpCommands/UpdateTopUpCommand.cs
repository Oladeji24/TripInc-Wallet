using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TripInc_Wallet.Persistence;
using TripInc_Wallet.Domain.Entities;
using static TripInc_Wallet.Persistence.IAppContext;

namespace TripInc_Wallet.Application.CQRS.TopUpCommands
{
    public class UpdateTopUpCommand : IRequest<int>
    {
        public int Id { get; set; }
        public decimal TopUpAmount { get; set; }
        public string? ModeofTopUp { get; set; }
        public DateTime TopUpDate { get; set; }
        public decimal AmountDue { get; set; }
        public class UpdateTopUpCommandHandler : IRequestHandler<UpdateTopUpCommand, int>
        {
            private readonly IAppDbContext context;
            public UpdateTopUpCommandHandler(IAppDbContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(UpdateTopUpCommand command, CancellationToken cancellationToken)
            {
                var topUp = context.TopUps.Where(a => a.id == command.Id).FirstOrDefault();

                if (topUp == null)
                    return default;

                topUp.TopUpAmount = command.TopUpAmount;
                topUp.ModeofTopUp = command.ModeofTopUp;
                topUp.TopUpDate = command.TopUpDate;
                topUp.AmountDue = command.AmountDue;
                await context.SaveChangesAsync();
                return topUp.id;
            }
        }
    }
}