using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrintManagementApp.Forms
{
    public partial class FileSharingForm : Form
    {
        private int _currentUserId; // Store the current user's ID

        public FileSharingForm(int currentUserId)
        {
            InitializeComponent();
            _currentUserId = currentUserId;
            LoadUsers(); // Load users into the ComboBox
        }

        // Load all users into the ComboBox
        private void LoadUsers()
        {
            using (var context = new AppDbContext())
            {
                // Get all users except the current user
                var users = context.Users
                    .Where(u => u.UserId != _currentUserId) // Exclude the current user
                    .Select(u => new { u.UserId, u.Username, u.IPAddress })
                    .ToList();

                // Bind the ComboBox to the list of users
                cmbUsers.DataSource = users;
                cmbUsers.DisplayMember = "Username"; // Display the username
                cmbUsers.ValueMember = "IPAddress"; // Use the IP address as the value
            }
        }
        private void FileSharingForm_Load(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "All Files|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog.FileName;
            }

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string receiverIP = cmbUsers.SelectedValue?.ToString(); // Get the selected user's IP address
            string filePath = txtFilePath.Text;

            if (string.IsNullOrEmpty(receiverIP))
            {
                MessageBox.Show("Please select a receiver.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Please select a file to send.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Send the file over TCP
                SendFile(receiverIP, filePath);
                MessageBox.Show("File sent successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SendFile(string receiverIP, string filePath)
        {
            using (TcpClient client = new TcpClient(receiverIP, 5000))
            using (NetworkStream stream = client.GetStream())
            using (FileStream fileStream = File.OpenRead(filePath))
            {
                // Send the file name
                string fileName = Path.GetFileName(filePath);
                byte[] fileNameBytes = Encoding.UTF8.GetBytes(fileName);
                stream.Write(fileNameBytes, 0, fileNameBytes.Length);
                stream.WriteByte(0); // Null terminator

                // Send the file content
                fileStream.CopyTo(stream);
            }
        }
    }
}
