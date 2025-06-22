using System.ComponentModel.DataAnnotations;

namespace Domain.Enums;

public enum ExceptionEnum
{
    // 🔁 Common Exceptions
    [Display(Name = "NullReferenceException", Description = "حدثت مشكلة بسبب محاولة استخدام بيانات غير موجودة.")]
    NullReferenceException = 1001,

    [Display(Name = "SqlException", Description = "تعذر الاتصال بقاعدة البيانات أو تنفيذ الاستعلام.")]
    SqlException = 1002,

    [Display(Name = "ArgumentException", Description = "تم إرسال بيانات غير صحيحة إلى العملية المطلوبة.")]
    ArgumentException = 1003,

    [Display(Name = "TimeoutException", Description = "استغرقت العملية وقتًا أطول من المتوقع.")]
    TimeoutException = 1004,

    [Display(Name = "InvalidOperationException", Description = "تم تنفيذ إجراء في حالة غير مناسبة.")]
    InvalidOperationException = 1005,

    [Display(Name = "FileNotFoundException", Description = "لم يتم العثور على الملف المطلوب.")]
    FileNotFoundException = 1006,

    [Display(Name = "KeyNotFoundException", Description = "تعذر العثور على عنصر في البيانات.")]
    KeyNotFoundException = 1007,

    [Display(Name = "IndexOutOfRangeException", Description = "تم تجاوز حدود القائمة أو المصفوفة.")]
    IndexOutOfRangeException = 1008,

    [Display(Name = "FormatException", Description = "تم إدخال بيانات بتنسيق غير صحيح.")]
    FormatException = 1009,

    [Display(Name = "OverflowException", Description = "تم تجاوز الحد الأقصى لقيمة مدخلة.")]
    OverflowException = 1010,

    [Display(Name = "DivideByZeroException", Description = "لا يمكن القسمة على صفر.")]
    DivideByZeroException = 1011,

    [Display(Name = "InvalidCastException", Description = "حدث خطأ أثناء تحويل نوع البيانات.")]
    InvalidCastException = 1012,

    [Display(Name = "UnauthorizedAccessException", Description = "ليس لديك صلاحية للوصول إلى هذا المورد.")]
    UnauthorizedAccessException = 1013,

    [Display(Name = "NotImplementedException", Description = "هذه الميزة غير متوفرة حاليًا.")]
    NotImplementedException = 1014,

    [Display(Name = "NotSupportedException", Description = "العملية المطلوبة غير مدعومة.")]
    NotSupportedException = 1015,

    [Display(Name = "ArgumentOutOfRangeException", Description = "تم إدخال قيمة خارج النطاق المسموح به.")]
    ArgumentOutOfRangeException = 1016,

    [Display(Name = "ArgumentNullException", Description = "تم إرسال قيمة فارغة غير مسموح بها.")]
    ArgumentNullException = 1017,

    // 💾 IO Exceptions
    [Display(Name = "IOException", Description = "حدث خطأ في التعامل مع الملفات أو البيانات.")]
    IOException = 1100,

    [Display(Name = "DirectoryNotFoundException", Description = "لم يتم العثور على المجلد المطلوب.")]
    DirectoryNotFoundException = 1101,

    [Display(Name = "PathTooLongException", Description = "المسار إلى الملف أو المجلد طويل جدًا.")]
    PathTooLongException = 1102,

    [Display(Name = "EndOfStreamException", Description = "تم الوصول إلى نهاية البيانات بشكل غير متوقع.")]
    EndOfStreamException = 1103,

    [Display(Name = "FileLoadException", Description = "حدث خطأ أثناء تحميل الملف.")]
    FileLoadException = 1104,

    // 🌐 Network Exceptions
    [Display(Name = "SocketException", Description = "تعذر الاتصال بالشبكة.")]
    SocketException = 1200,

    [Display(Name = "WebException", Description = "فشل الاتصال بالإنترنت أو بالخدمة.")]
    WebException = 1201,

    [Display(Name = "HttpRequestException", Description = "فشل إرسال أو استقبال الطلب عبر الإنترنت.")]
    HttpRequestException = 1202,

    // 🧩 Serialization Exceptions
    [Display(Name = "SerializationException", Description = "حدث خطأ أثناء تحويل البيانات.")]
    SerializationException = 1300,

    [Display(Name = "InvalidDataContractException", Description = "هيكل البيانات غير متوافق مع المعايير.")]
    InvalidDataContractException = 1301,

    [Display(Name = "JsonSerializationException", Description = "فشل في قراءة أو كتابة بيانات JSON.")]
    JsonSerializationException = 1302,

    // 🔐 Security Exceptions
    [Display(Name = "SecurityException", Description = "تم حظر العملية لأسباب أمنية.")]
    SecurityException = 1400,

    [Display(Name = "CryptographicException", Description = "فشل في تشفير أو فك تشفير البيانات.")]
    CryptographicException = 1401,

    // 🧵 Threading Exceptions
    [Display(Name = "ThreadAbortException", Description = "تم إيقاف العملية قسريًا.")]
    ThreadAbortException = 1500,

    [Display(Name = "ThreadInterruptedException", Description = "تم مقاطعة تنفيذ العملية.")]
    ThreadInterruptedException = 1501,

    [Display(Name = "SynchronizationLockException", Description = "فشل في مزامنة العمليات.")]
    SynchronizationLockException = 1502,

    // 🔍 Reflection Exceptions
    [Display(Name = "AmbiguousMatchException", Description = "تم العثور على أكثر من تطابق غير واضح.")]
    AmbiguousMatchException = 1600,

    [Display(Name = "TargetInvocationException", Description = "حدث خطأ عند استدعاء وظيفة.")]
    TargetInvocationException = 1601,

    // 🧰 Custom Application-Level Exceptions
    [Display(Name = "CustomApplicationException", Description = "حدث خطأ مخصص داخل التطبيق.")]
    CustomApplicationException = 1700,

    // ❓ Fallback for unknown types
    [Display(Name = "UnknownException", Description = "حدث خطأ غير متوقع، يُرجى المحاولة لاحقًا.")]
    UnknownException = 9999
}
