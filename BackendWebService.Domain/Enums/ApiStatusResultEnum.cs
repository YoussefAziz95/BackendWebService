using System.ComponentModel.DataAnnotations;

namespace Domain.Enums;

public enum ApiResultStatusCode
{
    [Display(Name = "Ok", Description = "نجاح")]
    Ok = 200,

    [Display(Name = "Success", Description = "تم بنجاح")]
    Success = 201,

    [Display(Name = "Created", Description = "تم الإنشاء")]
    Created = 202,

    [Display(Name = "InternalServerError", Description = "خطأ في الخادم الداخلي")]
    InternalServerError = 203,

    [Display(Name = "UnprocessableEntity", Description = "لا يمكن معالجة الكيان")]
    UnprocessableEntity = 204,

    [Display(Name = "Accepted", Description = "تم القبول")]
    Accepted = 205,

    [Display(Name = "Server Error", Description = "خطأ في الخادم")]
    ServerError = 500,

    [Display(Name = "Bad Request Error", Description = "طلب غير صالح")]
    BadRequest = 400,

    [Display(Name = "Not Found", Description = "غير موجود")]
    NotFound = 404,

    [Display(Name = "Request Process Error", Description = "خطأ في معالجة الطلب")]
    EntityProcessError = 422,

    [Display(Name = "Authentication Error", Description = "خطأ في المصادقة")]
    UnAuthorized = 401,

    [Display(Name = "Authorization Error", Description = "غير مصرح")]
    Forbidden = 403,

    [Display(Name = "Not Acceptable", Description = "غير مقبول")]
    NotAcceptable = 406,

    [Display(Name = "Failed Dependency", Description = "فشل في الاعتماد")]
    FailedDependency = 424
}
