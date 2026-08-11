using ChubbInsuranceClaim.src.Domain.Common;
using ChubbInsuranceClaim.src.Domain.Enums;

namespace ChubbInsuranceClaim.src.Domain.Entity
{
    public class Payment : AuditableEntity
    {
        public Guid SettlementId { get; set; }

        public string TransactionReference { get; set; } = string.Empty;

        public decimal Amount { get; set; }

        public PaymentStatus Status { get; set; }

        public DateTime? PaidOn { get; set; }
    }
}
