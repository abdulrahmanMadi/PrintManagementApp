using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintManagementApp.Data.Models
{
    public class FileTransfer
    {
        public int FileTransferId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime TransferredAt { get; set; }

        // Foreign key to Sender (User)
        public int SenderUserId { get; set; }
        public User Sender { get; set; } // Navigation property to User

        // Foreign key to Receiver (User)
        public int ReceiverUserId { get; set; }
        public User Receiver { get; set; } // Navigation property to User
    }
}
