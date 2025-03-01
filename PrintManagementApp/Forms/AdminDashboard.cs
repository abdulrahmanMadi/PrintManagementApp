using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrintManagementApp.Forms
{
    public partial class AdminDashboard : Form
    {
        private DataGridView dataGridViewPrintRequests;
        private Button btnRefresh;
        private FileSharingServer _tcpServer;

        public AdminDashboard()
        {
            InitializeComponents();
            LoadPrintRequests();

            // Start the TCP server
            _tcpServer = new FileSharingServer("127.0.0.1", 5000); // Replace with the admin PC's IP
            _tcpServer.Start();
        }

        private void InitializeComponents()
        {
            // DataGridView for print requests
            dataGridViewPrintRequests = new DataGridView
            {
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(800, 400),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            // Refresh button
            btnRefresh = new Button
            {
                Location = new System.Drawing.Point(20, 430),
                Text = "Refresh",
                Size = new System.Drawing.Size(100, 30)
            };
            btnRefresh.Click += btnRefresh_Click;

            // Form settings
            this.ClientSize = new System.Drawing.Size(850, 480);
            this.Controls.Add(dataGridViewPrintRequests);
            this.Controls.Add(btnRefresh);
            this.Text = "Admin Dashboard";
        }

        private void LoadPrintRequests()
        {
            using (var context = new AppDbContext())
            {
                var requests = context.PrintJobs
                    .OrderByDescending(p => p.SubmittedAt)
                    .ToList();

                dataGridViewPrintRequests.DataSource = requests;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPrintRequests();
        }

        private void UpdateDashboard(string message)
        {
            // Parse the message and update the DataGridView
            // Example: Add a new print request to the DataGridView
            Console.WriteLine("Updating dashboard: " + message);
        }
    }
}