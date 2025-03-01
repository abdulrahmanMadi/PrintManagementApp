namespace PrintManagementApp.Forms.Users
{
    partial class HomeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnRegister = new System.Windows.Forms.ToolStripButton();
            this.btnAddRole = new System.Windows.Forms.ToolStripButton();
            this.btnAddIPaddress = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnShareFile = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnSharePrint = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLogout = new System.Windows.Forms.ToolStripButton();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lstReceivedFiles = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRegister,
            this.btnAddRole,
            this.btnAddIPaddress,
            this.toolStripDropDownButton1,
            this.btnLogout});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(800, 37);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnRegister
            // 
            this.btnRegister.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRegister.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.Image = ((System.Drawing.Image)(resources.GetObject("btnRegister.Image")));
            this.btnRegister.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(67, 34);
            this.btnRegister.Text = "تسجيل";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnAddRole
            // 
            this.btnAddRole.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAddRole.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRole.Image = ((System.Drawing.Image)(resources.GetObject("btnAddRole.Image")));
            this.btnAddRole.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddRole.Name = "btnAddRole";
            this.btnAddRole.Size = new System.Drawing.Size(124, 34);
            this.btnAddRole.Text = "اضافه صلاحيات";
            this.btnAddRole.Click += new System.EventHandler(this.btnAddRole_Click);
            // 
            // btnAddIPaddress
            // 
            this.btnAddIPaddress.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAddIPaddress.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddIPaddress.Image = ((System.Drawing.Image)(resources.GetObject("btnAddIPaddress.Image")));
            this.btnAddIPaddress.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddIPaddress.Name = "btnAddIPaddress";
            this.btnAddIPaddress.Size = new System.Drawing.Size(136, 34);
            this.btnAddIPaddress.Text = "اضافه ip address";
            this.btnAddIPaddress.Click += new System.EventHandler(this.btnAddIPaddress_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnShareFile,
            this.BtnSharePrint});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(83, 34);
            this.toolStripDropDownButton1.Text = "مشاركة";
            // 
            // btnShareFile
            // 
            this.btnShareFile.Name = "btnShareFile";
            this.btnShareFile.Size = new System.Drawing.Size(132, 34);
            this.btnShareFile.Text = "ملفات";
            this.btnShareFile.Click += new System.EventHandler(this.btnShareFile_Click);
            // 
            // BtnSharePrint
            // 
            this.BtnSharePrint.Name = "BtnSharePrint";
            this.BtnSharePrint.Size = new System.Drawing.Size(132, 34);
            this.BtnSharePrint.Text = "طباعه";
            this.BtnSharePrint.Click += new System.EventHandler(this.BtnSharePrint_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(104, 34);
            this.btnLogout.Text = "تسجيل خروج";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Cairo", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(12, 49);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(53, 29);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "label1";
            // 
            // lstReceivedFiles
            // 
            this.lstReceivedFiles.HideSelection = false;
            this.lstReceivedFiles.Location = new System.Drawing.Point(29, 136);
            this.lstReceivedFiles.Name = "lstReceivedFiles";
            this.lstReceivedFiles.Size = new System.Drawing.Size(733, 281);
            this.lstReceivedFiles.TabIndex = 2;
            this.lstReceivedFiles.UseCompatibleStateImageBehavior = false;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(129, 26);
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.downloadToolStripMenuItem.Text = "Download";
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstReceivedFiles);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.toolStrip1);
            this.Name = "HomeForm";
            this.Text = "HomePage";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnRegister;
        private System.Windows.Forms.ToolStripButton btnLogout;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.ToolStripButton btnAddRole;
        private System.Windows.Forms.ToolStripButton btnAddIPaddress;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem btnShareFile;
        private System.Windows.Forms.ToolStripMenuItem BtnSharePrint;
        private System.Windows.Forms.ListView lstReceivedFiles;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
    }
}