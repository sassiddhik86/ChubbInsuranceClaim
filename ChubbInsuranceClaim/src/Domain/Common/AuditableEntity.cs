namespace ChubbInsuranceClaim.src.Domain.Common
{
    public abstract class AuditableEntity : BaseEntity
    {
        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string CreatedBy { get; set; } = string.Empty;

        public string? UpdatedBy { get; set; }
    }
}
