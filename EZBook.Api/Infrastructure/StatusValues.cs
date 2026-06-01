namespace EZBook.Api.Infrastructure
{
    public static class BookingStatusValues
    {
        public const string PendingApproval = "New";
        public const string Approved = "Approve";
        public const string Cancelled = "Cancelled";
    }

    public static class CancellationStatusValues
    {
        public const string PendingApproval = "New";
        public const string Approved = "Approved";
        public const string Disapproved = "Disapproved";
    }
}
