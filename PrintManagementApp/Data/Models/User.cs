using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintManagementApp.Data.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; } // Navigation property to Role
        public string IPAddress { get; set; }


        // Navigation properties for relationships
        public ICollection<PrintJob> PrintJobs { get; set; } // A user can have many print jobs
        public ICollection<FileTransfer> SentFileTransfers { get; set; } // A user can send many files
        public ICollection<FileTransfer> ReceivedFileTransfers { get; set; } // A user can receive many files
    }
}
