using PrintManagementApp.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrintManagementApp.Forms.Users
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            LoadRoles();

        }
        private void LoadRoles()
        {
            using (var context = new AppDbContext())
            {
                var roles = context.Roles.ToList();
                cmbRole.DataSource = roles;
                cmbRole.DisplayMember = "RoleName";
                cmbRole.ValueMember = "RoleId";
            }
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            int roleId = (int)cmbRole.SelectedValue;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username and password are required.");
                return;
            }

            using (var context = new AppDbContext())
            {
                // Check if the username already exists
                if (context.Users.Any(u => u.Username == username))
                {
                    MessageBox.Show("Username already exists. Please choose a different username.");
                    return;
                }

                var user = new User
                {
                    Username = username,
                    PasswordHash = password, // Hash the password
                    RoleId = roleId
                };

                context.Users.Add(user);
                context.SaveChanges();
                MessageBox.Show("User registered successfully!");
                this.Close(); // Close the form after registration
            }
        }
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(bytes);
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

    }
}

