using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TripInc_Wallet.Domain.Entities;
using static TripInc_Wallet.Persistence.IAppContext;

namespace TripInc_Wallet.Application.CQRS.PurchaseCommands
{
    public class UpdatePurchaseCommand : IRequest<int>
    {
        public int Id { get; set; }
        public decimal AmountDue { get; set; }
        public string? VoucherCode { get; set; }
        public decimal AmountPaid { get; set; }
        // Purpose of Payment
        public string? PaymentParticulars { get; set; }
        public string? ModeOfPayment { get; set; }
        public class UpdatePurchaseCommandHandler : IRequestHandler<UpdatePurchaseCommand, int>
        {
            private readonly IAppDbContext context;
            public UpdatePurchaseCommandHandler(IAppDbContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(UpdatePurchaseCommand command, CancellationToken cancellationToken)
            {
                var purchase = context.Purchases.Where(a => a.id == command.Id).FirstOrDefault();

                if (purchase == null)
                    return default;

                purchase.AmountDue = command.AmountDue;
                purchase.VoucherCode = command.VoucherCode;
                purchase.AmountPaid = command.AmountPaid;
                purchase.PaymentParticulars = command.PaymentParticulars;
                purchase.ModeOfPayment = command.ModeOfPayment;
                return purchase.id;
            }
        }
    }
}