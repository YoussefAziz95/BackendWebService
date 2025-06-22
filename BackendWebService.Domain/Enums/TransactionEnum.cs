using System.ComponentModel.DataAnnotations;

namespace Domain.Enums;
public enum TransactionEnum
{
    [Display(Name = "Subscription", Description = "اشتراك")]
    Subscription = 1,

    [Display(Name = "Payment", Description = "دفع")]
    Payment = 2,

    [Display(Name = "Refund", Description = "استرداد")]
    Refund = 3,

    [Display(Name = "Withdrawal", Description = "سحب")]
    Withdrawal = 4,

    [Display(Name = "Deposit", Description = "إيداع")]
    Deposit = 5,

    [Display(Name = "Transfer", Description = "تحويل")]
    Transfer = 6,

    [Display(Name = "Adjustment", Description = "تسوية")]
    Adjustment = 7,

    [Display(Name = "Charge", Description = "رسوم")]
    Charge = 8,

    [Display(Name = "Fee", Description = "عمولة")]
    Fee = 9,

    [Display(Name = "Interest", Description = "فائدة")]
    Interest = 10,

    [Display(Name = "Dividend", Description = "توزيع أرباح")]
    Dividend = 11,

    [Display(Name = "Bonus", Description = "مكافأة")]
    Bonus = 12,

    [Display(Name = "Rebate", Description = "خصم نقدي")]
    Rebate = 13,

    [Display(Name = "Reward", Description = "جائزة")]
    Reward = 14,

    [Display(Name = "Commission", Description = "عمولة")]
    Commission = 15,

    [Display(Name = "Tax", Description = "ضريبة")]
    Tax = 16,

    [Display(Name = "Penalty", Description = "غرامة")]
    Penalty = 17,

    [Display(Name = "Fine", Description = "عقوبة مالية")]
    Fine = 18,

    [Display(Name = "Loan", Description = "قرض")]
    Loan = 19,

    [Display(Name = "Repayment", Description = "سداد")]
    Repayment = 20,

    [Display(Name = "Insurance", Description = "تأمين")]
    Insurance = 21,

    [Display(Name = "Claim", Description = "مطالبة")]
    Claim = 22,

    [Display(Name = "Settlement", Description = "تسوية نهائية")]
    Settlement = 23,

    [Display(Name = "Trade", Description = "صفقة تجارية")]
    Trade = 24,

    [Display(Name = "Order", Description = "طلب")]
    Order = 25
}
