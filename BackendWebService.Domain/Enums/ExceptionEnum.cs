namespace Domain.Enums
{
    public enum ExceptionEnum
    {
        // Common Exceptions
        NullReferenceException = 1001,
        SqlException = 1002,
        ArgumentException = 1003,
        TimeoutException = 1004,
        InvalidOperationException = 1005,
        FileNotFoundException = 1006,
        KeyNotFoundException = 1007,
        IndexOutOfRangeException = 1008,
        FormatException = 1009,
        OverflowException = 1010,
        DivideByZeroException = 1011,
        InvalidCastException = 1012,
        UnauthorizedAccessException = 1013,
        NotImplementedException = 1014,
        NotSupportedException = 1015,
        ArgumentOutOfRangeException = 1016,
        ArgumentNullException = 1017,

        // IO Exceptions
        IOException = 1100,
        DirectoryNotFoundException = 1101,
        PathTooLongException = 1102,
        EndOfStreamException = 1103,
        FileLoadException = 1104,

        // Network Exceptions
        SocketException = 1200,
        WebException = 1201,
        HttpRequestException = 1202,

        // Serialization Exceptions
        SerializationException = 1300,
        InvalidDataContractException = 1301,
        JsonSerializationException = 1302,

        // Security Exceptions
        SecurityException = 1400,
        CryptographicException = 1401,

        // Threading Exceptions
        ThreadAbortException = 1500,
        ThreadInterruptedException = 1501,
        SynchronizationLockException = 1502,

        // Reflection Exceptions
        AmbiguousMatchException = 1600,
        TargetInvocationException = 1601,

        // Custom Application-Level Exceptions (user-defined)
        CustomApplicationException = 1700,

        // Default for unknown exception types
        UnknownException = 9999
    }


}
