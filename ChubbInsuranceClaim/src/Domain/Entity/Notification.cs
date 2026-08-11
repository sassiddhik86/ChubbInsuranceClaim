using ChubbInsuranceClaim.src.Domain.Common;
using ChubbInsuranceClaim.src.Domain.Enums;

namespace ChubbInsuranceClaim.src.Domain.Entity
{
    public class Notification : AuditableEntity
    {
        public Guid UserId { get; set; }

        public BusinessUser User { get; set; } = null!;

        public string Title { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public NotificationType NotificationType { get; set; }

        public bool IsRead { get; set; }
    }
}
