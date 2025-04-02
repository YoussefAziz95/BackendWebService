namespace Domain.Enums
{
    public enum ActionEnum
    {
        // Initial Actions
        Request = 1,
        Assign = 2,
        Forward = 3,

        // Processing Actions
        Start = 4,
        Open = 5,
        Resume = 6,
        Reopen = 7,

        // Temporary Pauses
        Pause = 8,
        Hold = 9,
        Unhold = 10,
        Suspend = 11,

        // Task Completion or Decision Making
        Review = 12,
        Score = 13,
        Approve = 14,
        Reject = 15,
        Complete = 16,

        // Payment & Financial Actions
        Payment = 17,

        // Task Cancellation or Closure
        Withdraw = 18,
        Cancel = 19,
        Return = 20,
        Close = 21,
        Stop = 22
    }
}
