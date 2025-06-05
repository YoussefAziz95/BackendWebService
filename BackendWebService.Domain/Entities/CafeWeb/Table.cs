using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Table : BaseEntity
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

        public Table(int tableNumber, int tableSecret, string tableQRCode)
        {
            TableNumber = tableNumber;
            _tableSecret = tableSecret;
            TableQRCode = tableQRCode;
        }
    }
}
