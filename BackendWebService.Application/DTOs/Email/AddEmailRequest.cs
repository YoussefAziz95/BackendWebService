
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Email
{
    public class AddEmailRequest
    {
        public string Subject { get; set; }

        public string Body { get; set; }

        public DateTime SentAt { get; set; }

      
        public int SenderId { get; set; }

       

    }
}
