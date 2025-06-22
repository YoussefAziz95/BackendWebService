using System.ComponentModel.DataAnnotations;

namespace BackendWebService.Domain.Entities.EmployeeModule.Franchise
{
    public class ATMachine : BaseEntity
    {
        [Required]
        public int TableNumber { get; set; }

        [Required, MaxLength(255)]
        public string TableQRCode { get; set; } = string.Empty;

        private int _tableSecret;

        [Required]
        public int TableSecret
        {
            get => _tableSecret;
            private set => _tableSecret = value;
        }

        public ATMachine(int tableNumber, int tableSecret, string tableQRCode)
        {
            TableNumber = tableNumber;
            _tableSecret = tableSecret;
            TableQRCode = tableQRCode;
        }
    }
}
