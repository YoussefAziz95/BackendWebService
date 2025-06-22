using System.ComponentModel.DataAnnotations;

namespace Domain.Enums;

public enum PaymentEnum
{
    [Display(Name = "Cash", Description = "الدفع نقدًا")]
    Cash,

    [Display(Name = "CreditCard", Description = "بطاقة ائتمان")]
    CreditCard,

    [Display(Name = "DebitCard", Description = "بطاقة خصم مباشر")]
    DebitCard,

    [Display(Name = "MobilePayment", Description = "دفع عبر الهاتف (مثل Apple Pay أو Google Pay)")]
    MobilePayment,

    [Display(Name = "OnlinePayment", Description = "دفع إلكتروني (مثل PayPal أو Stripe)")]
    OnlinePayment,

    [Display(Name = "Crypto", Description = "دفع باستخدام العملات الرقمية")]
    Crypto
}
