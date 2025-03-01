using PrintManagementApp.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrintManagementApp.Forms.Users
{

    public partial class HomeForm : Form
    {
        private User _loggedInUser;
        private TcpListener _tcpListener;
        private Thread _listenerThread;
        private string _receivedFilesDir;

        public HomeForm(User user)
        {
            InitializeComponent();
            _loggedInUser = user;
            lblWelcome.Text = $"Welcome, {user.Username} ({user.Role.RoleName})";

            // Set up the ReceivedFiles directory
            _receivedFilesDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ReceivedFiles");
            if (!Directory.Exists(_receivedFilesDir))
            {
                Directory.CreateDirectory(_receivedFilesDir);
            }

            // Configure the ListView
            ConfigureListView();

            // Start the TCP server to listen for incoming files
            StartTcpServer();
        }
        private void ConfigureListView()
        {
            // Set up the ListView
            lstReceivedFiles.View = View.LargeIcon;
            lstReceivedFiles.LargeImageList = new ImageList();
            lstReceivedFiles.LargeImageList.ImageSize = new Size(64, 64); // Set icon size

            // Add context menu for downloading/saving files
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Download/Save", null, DownloadFile);
            lstReceivedFiles.ContextMenuStrip = contextMenu;

            // Load existing files in the ReceivedFiles directory
            LoadReceivedFiles();
        }

        // Load existing files in the ReceivedFiles directory
        private void LoadReceivedFiles()
        {
            foreach (string filePath in Directory.GetFiles(_receivedFilesDir))
            {
                string fileName = Path.GetFileName(filePath);
                AddFileToListView(fileName);
            }
        }

        // Add a file to the ListView
        private void AddFileToListView(string fileName)
        {
            // Get the file icon
            Icon fileIcon = Icon.ExtractAssociatedIcon(Path.Combine(_receivedFilesDir, fileName));

            // Add the icon to the ImageList
            lstReceivedFiles.LargeImageList.Images.Add(fileIcon);

            // Add the file to the ListView
            ListViewItem item = new ListViewItem(fileName, lstReceivedFiles.LargeImageList.Images.Count - 1);
            lstReceivedFiles.Items.Add(item);
        }

        // Start the TCP server
        private void StartTcpServer()
        {
            _tcpListener = new TcpListener(IPAddress.Any, 5000); // Listen on port 5000
            _listenerThread = new Thread(ListenForFiles);
            _listenerThread.IsBackground = true; // Ensure the thread exits when the application closes
            _listenerThread.Start();
        }

        // Listen for incoming files
        private void ListenForFiles()
        {
            _tcpListener.Start();
            while (true)
            {
                try
                {
                    TcpClient client = _tcpListener.AcceptTcpClient();
                    Thread clientThread = new Thread(() => HandleClient(client));
                    clientThread.IsBackground = true;
                    clientThread.Start();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error accepting client: " + ex.Message);
                }
            }
        }

        // Handle an incoming file transfer
        private void HandleClient(TcpClient client)
        {
            using (NetworkStream stream = client.GetStream())
            {
                // Read the file name
                byte[] fileNameBytes = new byte[1024];
                int fileNameLength = stream.Read(fileNameBytes, 0, fileNameBytes.Length);
                string fileName = Encoding.UTF8.GetString(fileNameBytes, 0, fileNameLength).TrimEnd('\0');

                // Save the file to the ReceivedFiles directory
                string filePath = Path.Combine(_receivedFilesDir, fileName);
                using (FileStream fileStream = File.Create(filePath))
                {
                    stream.CopyTo(fileStream);
                }

                // Update the UI with the received file
                UpdateReceivedFilesList(fileName);
            }
        }

        // Update the UI with the received file
        private void UpdateReceivedFilesList(string fileName)
        {
            if (lstReceivedFiles.InvokeRequired)
            {
                lstReceivedFiles.Invoke(new Action<string>(UpdateReceivedFilesList), fileName);
            }
            else
            {
                AddFileToListView(fileName);
            }
        }

        // Context menu handler for downloading/saving files
        private void DownloadFile(object sender, EventArgs e)
        {
            if (lstReceivedFiles.SelectedItems.Count > 0)
            {
                string fileName = lstReceivedFiles.SelectedItems[0].Text;
                string filePath = Path.Combine(_receivedFilesDir, fileName);

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    FileName = fileName,
                    Filter = "All Files|*.*"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.Copy(filePath, saveFileDialog.FileName, overwrite: true);
                    MessageBox.Show("File saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (_loggedInUser.Role.RoleName == "Admin")
            {
                RegisterForm registerForm = new RegisterForm();
                registerForm.ShowDialog(); // Show the register form as a dialog
            }
            else
            {
                MessageBox.Show("Only admins can register users.");
            }
        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            if (_loggedInUser.Role.RoleName == "Admin")
            {
                AddRoleForm addRoleForm = new AddRoleForm();
                addRoleForm.ShowDialog(); // Show the add role form as a dialog
            }
            else
            {
                MessageBox.Show("Only admins can add roles.");
            }
        }

        private void btnAddIPaddress_Click(object sender, EventArgs e)
        {
            AddIPAddressForm addIPForm = new AddIPAddressForm(_loggedInUser.UserId);
            addIPForm.ShowDialog();
        }

        private void btnShareFile_Click(object sender, EventArgs e)
        {
            FileSharingForm FileSharingForm = new FileSharingForm(_loggedInUser.UserId);
            FileSharingForm.ShowDialog();
        }



        private void BtnSharePrint_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Word Documents|*.doc;*.docx";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    MessageBox.Show($"Print request sent for {System.IO.Path.GetFileName(filePath)}.");
                    // TODO: Implement print request logic
                }
            }
        }
    }
}
