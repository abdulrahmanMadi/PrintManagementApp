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

namespace PrintManagementApp.Forms.Users
{
    public partial class AddRoleForm : Form
    {
        public AddRoleForm()
        {
            InitializeComponent();
        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            string roleName = txtRoleName.Text;

            if (string.IsNullOrEmpty(roleName))
            {
                MessageBox.Show("Role name is required.");
                return;
            }

            using (var context = new AppDbContext())
            {
                // Check if the role already exists
                if (context.Roles.Any(r => r.RoleName == roleName))
                {
                    MessageBox.Show("Role already exists. Please choose a different role name.");
                    return;
                }

                var role = new Role
                {
                    RoleName = roleName
                };

                context.Roles.Add(role);
                context.SaveChanges();
                MessageBox.Show("Role added successfully!");
                this.Close(); // Close the form after adding the role
            }
        }
    }
}
