using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintManagementApp.Data.Models
{
    public class PrintJob
    {
        public int PrintJobId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string Status { get; set; } // Pending, Approved, Declined, Printed
        public DateTime SubmittedAt { get; set; }
        public DateTime? ProcessedAt { get; set; } // Nullable for pending requests

        // Foreign key to User
        public int UserId { get; set; }
        public User User { get; set; } // Navigation property to User

        // Printer details
        public string PrinterName { get; set; }
        public string PrinterLocation { get; set; }
    }
}
