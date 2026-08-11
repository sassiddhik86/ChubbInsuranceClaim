namespace ChubbInsuranceClaim.src.Domain.Enums
{
    public enum ClaimStatus
    {
        Draft = 1,

        Submitted = 2,

        Assigned = 3,

        UnderReview = 4,

        WaitingForInformation = 5,

        Investigation = 6,

        Approved = 7,

        Rejected = 8,

        Settled = 9,

        Closed = 10,

        NeedMoreInformation = 11,

        InformationReceived = 12
    }
}
