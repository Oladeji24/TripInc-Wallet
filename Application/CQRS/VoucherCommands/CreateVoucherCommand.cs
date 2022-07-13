using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TripInc_Wallet.Domain.Entities;
using static TripInc_Wallet.Persistence.IAppContext;

namespace TripInc_Wallet.Application.CQRS.VoucherCommands
{
    public class CreateVoucherCommand : IRequest<int>
    {
        public string? VoucherName { get; set; }
        public string? VoucherCode { get; set; }
        public decimal VoucherAmount { get; set; }
        public DateTime VoucherCreatedDate { get; set; }
        public DateTime VoucherExpiryDate { get; set; }
        public bool IsValid { get; set; }
        public string? VoucherUserEmail { get; set; }
        public string? VoucherType { get; set; }
        public class CreateVoucherCommandHandler : IRequestHandler<CreateVoucherCommand, int>
        {
            private readonly IAppDbContext context;
            public CreateVoucherCommandHandler(IAppDbContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(CreateVoucherCommand command, CancellationToken cancellationToken)
            {
                var voucher = new Voucher();
                voucher.VoucherName = command.VoucherName;
                voucher.VoucherCode = command.VoucherCode;
                voucher.VoucherAmount = command.VoucherAmount;
                voucher.VoucherCreatedDate = command.VoucherCreatedDate;
                voucher.VoucherExpiryDate = command.VoucherExpiryDate;
                voucher.IsValid = command.IsValid;
                voucher.VoucherUserEmail = command.VoucherUserEmail;
                voucher.VoucherType = command.VoucherType;


                context.Vouchers.Add(voucher);
                await context.SaveChangesAsync();
                return voucher.id;
            }
        }
    }
}