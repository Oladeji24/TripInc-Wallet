using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TripInc_Wallet.Domain.Entities;
using TripInc_Wallet.Persistence;
using static TripInc_Wallet.Persistence.IAppContext;

namespace TripInc_Wallet.Application.CQRS.TopUpCommands
{
    public class CreateTopUpCommand : IRequest<int>
    {
        public decimal TopUpAmount { get; set; }
        public string? ModeofTopUp { get; set; }
        public DateTime TopUpDate { get; set; }
        public decimal AmountDue { get; set; }
        public class CreateTopUpCommandHandler : IRequestHandler<CreateTopUpCommand, int>
        {
            private readonly IAppDbContext context;
            public CreateTopUpCommandHandler(IAppDbContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(CreateTopUpCommand command, CancellationToken cancellationToken)
            {
                var topUp = new TopUp();
                topUp.TopUpAmount = command.TopUpAmount;
                topUp.ModeofTopUp = command.ModeofTopUp;
                topUp.TopUpDate = command.TopUpDate;
                topUp.AmountDue = command.AmountDue;

                context.TopUps.Add(topUp);
                await context.SaveChangesAsync();
                return topUp.id;
            }
        }
    }
}