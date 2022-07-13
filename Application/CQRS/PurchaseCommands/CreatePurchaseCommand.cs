using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TripInc_Wallet.Domain.Entities;
using static TripInc_Wallet.Persistence.IAppContext;

namespace TripInc_Wallet.Application.CQRS.PurchaseCommands
{
    public class CreatePurchaseCommand : IRequest<int>
    {
        public decimal AmountDue { get; set; }
        public string? VoucherCode { get; set; }
        public decimal AmountPaid { get; set; }
        // Purpose of Payment
        public string? PaymentParticulars { get; set; }
        public string? ModeOfPayment { get; set; }
        public class CreatePurchaseCommandHandler : IRequestHandler<CreatePurchaseCommand, int>
        {
            private readonly IAppDbContext context;
            public CreatePurchaseCommandHandler(IAppDbContext context)
            {
                this.context = context;
            }

            public async Task<int> Handle(CreatePurchaseCommand command, CancellationToken cancellationToken)
            {
                var purchase = new Purchase();
                purchase.AmountDue = command.AmountDue;
                purchase.VoucherCode = command.VoucherCode;
                purchase.AmountPaid = command.AmountPaid;
                purchase.PaymentParticulars = command.PaymentParticulars;
                purchase.ModeOfPayment = command.ModeOfPayment;

                context.Purchases.Add(purchase);
                await context.SaveChangesAsync();
                return purchase.id;
            }
        }
    }
}
