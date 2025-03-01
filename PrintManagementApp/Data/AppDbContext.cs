using PrintManagementApp.Data;
using PrintManagementApp.Data.Models;
using System.Data;
using System.Data.Entity;

public class AppDbContext : DbContext
{
    public AppDbContext() : base("name=AppDbContext")
    {
        // Set the initializer
        Database.SetInitializer(new DatabaseInitializer());
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<FileTransfer> FileTransfers { get; set; }
    public DbSet<PrintJob> PrintJobs { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        // Configure the one-to-many relationship between Role and User
        modelBuilder.Entity<User>()
            .HasRequired(u => u.Role) // A user must have a role
            .WithMany(r => r.Users) // A role can have many users
            .HasForeignKey(u => u.RoleId); // Foreign key is RoleId

        // Configure the one-to-many relationship between User and PrintJob
        modelBuilder.Entity<PrintJob>()
            .HasRequired(p => p.User) // A print job must have a user
            .WithMany(u => u.PrintJobs) // A user can have many print jobs
            .HasForeignKey(p => p.UserId); // Foreign key is UserId

        // Configure the one-to-many relationship between User and FileTransfer (Sender)
        modelBuilder.Entity<FileTransfer>()
            .HasRequired(f => f.Sender) // A file transfer must have a sender
            .WithMany(u => u.SentFileTransfers) // A user can send many files
            .HasForeignKey(f => f.SenderUserId) // Foreign key is SenderUserId
            .WillCascadeOnDelete(false); // Disable cascade delete

        // Configure the one-to-many relationship between User and FileTransfer (Receiver)
        modelBuilder.Entity<FileTransfer>()
            .HasRequired(f => f.Receiver) // A file transfer must have a receiver
            .WithMany(u => u.ReceivedFileTransfers) // A user can receive many files
            .HasForeignKey(f => f.ReceiverUserId) // Foreign key is ReceiverUserId
            .WillCascadeOnDelete(false); // Disable cascade delete

        base.OnModelCreating(modelBuilder);
    }
}
