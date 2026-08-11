using ChubbInsuranceClaim.src.Domain.Common;

namespace ChubbInsuranceClaim.src.Domain.Entity
{
    public class RefreshToken : AuditableEntity
    {
        public Guid UserId { get; set; }

        public BusinessUser User { get; set; } = null!;

        public string Token { get; set; } = string.Empty;

        public DateTime ExpiryDate { get; set; }

        public bool IsRevoked { get; set; }
    }
}
