using PrintManagementApp.Data.Models;
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
    public partial class AddIPAddressForm : Form
    {
        private int _userId;

        public AddIPAddressForm(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }
          
        private void btnSave_Click(object sender, EventArgs e)
        {
            string ipAddress = txtIPAddress.Text;

            // Validate the IP address
            if (string.IsNullOrEmpty(ipAddress) || !System.Net.IPAddress.TryParse(ipAddress, out _))
            {
                MessageBox.Show("Please enter a valid IP address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Save the IP address to the user's profile
            try
            {
                using (var context = new AppDbContext())
                {
                    var user = context.Users.Find(_userId);
                    if (user != null)
                    {
                        user.IPAddress = ipAddress;
                        context.SaveChanges();
                        MessageBox.Show("IP address saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); // Close the form after saving
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save IP address: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}