namespace ChubbInsuranceClaim.src.Domain.Common
{
    public interface IAuditable
    {
        DateTime CreatedDate { get; set; }

        DateTime? UpdatedDate { get; set; }
    }
}
