using PrintManagementApp.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrintManagementApp.Forms
{
    public partial class PrintRequestForm : Form
    {


        public PrintRequestForm()
        {
            InitializeComponent();
        }
        private void InitializeComponents()
        {
            // TextBox for file path
            txtFilePath = new TextBox
            {
                Location = new System.Drawing.Point(20, 20),
                ReadOnly = true,
                Size = new System.Drawing.Size(300, 22)
            };

            // Browse button
            btnBrowse = new Button
            {
                Location = new System.Drawing.Point(330, 20),
                Text = "Browse",
                Size = new System.Drawing.Size(75, 23)
            };
            btnBrowse.Click += btnBrowse_Click;

            // Send Request button
            btnSendRequest = new Button
            {
                Location = new System.Drawing.Point(20, 60),
                Text = "Send Print Request",
                Size = new System.Drawing.Size(385, 30)
            };
            btnSendRequest.Click += btnSendRequest_Click;

            // Form settings
            this.ClientSize = new System.Drawing.Size(425, 110);
            this.Controls.Add(txtFilePath);
            this.Controls.Add(btnBrowse);
            this.Controls.Add(btnSendRequest);
            this.Text = "Print Request";
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            // Open a file dialog to select a Word file
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Word Files|*.docx"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog.FileName;
            }
        }

        private void btnSendRequest_Click(object sender, EventArgs e)
        {
            string filePath = txtFilePath.Text;

            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Please select a file to print.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!filePath.EndsWith(".docx", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Only Word files (.docx) are allowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var context = new AppDbContext())
                {
                    var printJob = new PrintJob
                    {
                        FileName = Path.GetFileName(filePath),
                        FilePath = filePath,
                        Status = "Pending",
                        SubmittedAt = DateTime.Now
                    };

                    context.PrintJobs.Add(printJob);
                    context.SaveChanges();
                }

                MessageBox.Show("Print request submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to submit print request: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}