using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TripInc_Wallet.Persistence;
using TripInc_Wallet.Domain.Entities;
using static TripInc_Wallet.Persistence.IAppContext;

namespace TripInc_Wallet.Application.CQRS.VoucherCommands
{
    public class UpdateVoucherCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string? VoucherName { get; set; }
        public string? VoucherCode { get; set; }
        public decimal VoucherAmount { get; set; }
        public DateTime VoucherCreatedDate { get; set; }
        public DateTime VoucherExpiryDate { get; set; }
        public bool IsValid { get; set; }
        public string? VoucherUserEmail { get; set; }
        public string? VoucherType { get; set; }
        public class UpdateVoucherCommandHandler : IRequestHandler<UpdateVoucherCommand, int>
        {
            private readonly IAppDbContext context;
            public UpdateVoucherCommandHandler(IAppDbContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(UpdateVoucherCommand command, CancellationToken cancellationToken)
            {
                var voucher = context.Vouchers.Where(a => a.id == command.Id).FirstOrDefault();

                if (voucher == null)
                    return default;

                voucher.VoucherName = command.VoucherName;
                voucher.VoucherCode = command.VoucherCode;
                voucher.VoucherAmount = command.VoucherAmount;
                voucher.VoucherCreatedDate = command.VoucherCreatedDate;
                voucher.VoucherExpiryDate = command.VoucherExpiryDate;
                voucher.IsValid = command.IsValid;
                voucher.VoucherUserEmail = command.VoucherUserEmail;
                voucher.VoucherType = command.VoucherType;
                await context.SaveChangesAsync();
                return voucher.id;
            }
        }
    }
}