namespace ProjectManagement
{
    partial class frmMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbNotFound = new System.Windows.Forms.Label();
            this.llbAll = new System.Windows.Forms.LinkLabel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchSmall = new System.Windows.Forms.TextBox();
            this.gvSmallList = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbAllProject = new System.Windows.Forms.LinkLabel();
            this.btnViewDetailPartner = new System.Windows.Forms.Button();
            this.cbPartners = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbCompanyName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.picUpdate = new System.Windows.Forms.PictureBox();
            this.picNew = new System.Windows.Forms.PictureBox();
            this.picDelete = new System.Windows.Forms.PictureBox();
            this.gvBigList = new System.Windows.Forms.DataGridView();
            this.lbCompany = new System.Windows.Forms.Label();
            this.lbProject = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSmallList)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBigList)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectToolStripMenuItem,
            this.employeeToolStripMenuItem});
            this.viewToolStripMenuItem.Image = global::ProjectManagement.Properties.Resources.menu_318_8688;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.projectToolStripMenuItem.Text = "Project";
            this.projectToolStripMenuItem.Click += new System.EventHandler(this.projectToolStripMenuItem_Click);
            // 
            // employeeToolStripMenuItem
            // 
            this.employeeToolStripMenuItem.Name = "employeeToolStripMenuItem";
            this.employeeToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.employeeToolStripMenuItem.Text = "Employee";
            this.employeeToolStripMenuItem.Click += new System.EventHandler(this.employeeToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::ProjectManagement.Properties.Resources.img_167289;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.editToolStripMenuItem.Text = "New Project";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1344, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // panel2
            // 
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel2.Controls.Add(this.lbNotFound);
            this.panel2.Controls.Add(this.llbAll);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.txtSearchSmall);
            this.panel2.Controls.Add(this.gvSmallList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(428, 653);
            this.panel2.TabIndex = 14;
            // 
            // lbNotFound
            // 
            this.lbNotFound.AutoSize = true;
            this.lbNotFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNotFound.ForeColor = System.Drawing.Color.Red;
            this.lbNotFound.Location = new System.Drawing.Point(56, 161);
            this.lbNotFound.Name = "lbNotFound";
            this.lbNotFound.Size = new System.Drawing.Size(185, 31);
            this.lbNotFound.TabIndex = 4;
            this.lbNotFound.Text = "NOT FOUND!";
            this.lbNotFound.Visible = false;
            // 
            // llbAll
            // 
            this.llbAll.AutoSize = true;
            this.llbAll.Location = new System.Drawing.Point(351, 26);
            this.llbAll.Name = "llbAll";
            this.llbAll.Size = new System.Drawing.Size(26, 13);
            this.llbAll.TabIndex = 3;
            this.llbAll.TabStop = true;
            this.llbAll.Text = "ALL";
            this.llbAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbAll_LinkClicked);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnSearch.Location = new System.Drawing.Point(252, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "SEARCH";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchSmall
            // 
            this.txtSearchSmall.Location = new System.Drawing.Point(24, 20);
            this.txtSearchSmall.Name = "txtSearchSmall";
            this.txtSearchSmall.Size = new System.Drawing.Size(204, 20);
            this.txtSearchSmall.TabIndex = 1;
            // 
            // gvSmallList
            // 
            this.gvSmallList.AllowUserToAddRows = false;
            this.gvSmallList.AllowUserToDeleteRows = false;
            this.gvSmallList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.gvSmallList.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gvSmallList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvSmallList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvSmallList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSmallList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gvSmallList.Location = new System.Drawing.Point(0, 109);
            this.gvSmallList.Name = "gvSmallList";
            this.gvSmallList.ReadOnly = true;
            this.gvSmallList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvSmallList.Size = new System.Drawing.Size(428, 544);
            this.gvSmallList.TabIndex = 0;
            this.gvSmallList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvSmallList_CellClick);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.lbAllProject);
            this.panel4.Controls.Add(this.btnViewDetailPartner);
            this.panel4.Controls.Add(this.cbPartners);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.lbCompanyName);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.picUpdate);
            this.panel4.Controls.Add(this.picNew);
            this.panel4.Controls.Add(this.picDelete);
            this.panel4.Controls.Add(this.gvBigList);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(428, 68);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(916, 653);
            this.panel4.TabIndex = 15;
            // 
            // lbAllProject
            // 
            this.lbAllProject.AutoSize = true;
            this.lbAllProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAllProject.Location = new System.Drawing.Point(448, 106);
            this.lbAllProject.Name = "lbAllProject";
            this.lbAllProject.Size = new System.Drawing.Size(61, 15);
            this.lbAllProject.TabIndex = 18;
            this.lbAllProject.TabStop = true;
            this.lbAllProject.Text = "All Project";
            this.lbAllProject.VisitedLinkColor = System.Drawing.Color.Blue;
            this.lbAllProject.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbAllProject_LinkClicked);
            // 
            // btnViewDetailPartner
            // 
            this.btnViewDetailPartner.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnViewDetailPartner.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewDetailPartner.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnViewDetailPartner.Location = new System.Drawing.Point(575, 98);
            this.btnViewDetailPartner.Name = "btnViewDetailPartner";
            this.btnViewDetailPartner.Size = new System.Drawing.Size(109, 23);
            this.btnViewDetailPartner.TabIndex = 17;
            this.btnViewDetailPartner.Text = "PARTNER DETAIL";
            this.btnViewDetailPartner.UseVisualStyleBackColor = false;
            this.btnViewDetailPartner.Click += new System.EventHandler(this.btnViewDetailPartner_Click);
            // 
            // cbPartners
            // 
            this.cbPartners.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPartners.FormattingEnabled = true;
            this.cbPartners.Location = new System.Drawing.Point(199, 100);
            this.cbPartners.Name = "cbPartners";
            this.cbPartners.Size = new System.Drawing.Size(204, 21);
            this.cbPartners.TabIndex = 16;
            this.cbPartners.TabStop = false;
            this.cbPartners.SelectedIndexChanged += new System.EventHandler(this.cbPartners_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(29, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "Partners :";
            // 
            // lbCompanyName
            // 
            this.lbCompanyName.AutoSize = true;
            this.lbCompanyName.Font = new System.Drawing.Font("MS Mincho", 9.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCompanyName.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lbCompanyName.Location = new System.Drawing.Point(196, 72);
            this.lbCompanyName.Name = "lbCompanyName";
            this.lbCompanyName.Size = new System.Drawing.Size(0, 13);
            this.lbCompanyName.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(26, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Comapany Name :";
            // 
            // picUpdate
            // 
            this.picUpdate.BackgroundImage = global::ProjectManagement.Properties.Resources._012_restart_512;
            this.picUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picUpdate.Location = new System.Drawing.Point(637, 20);
            this.picUpdate.Name = "picUpdate";
            this.picUpdate.Size = new System.Drawing.Size(34, 26);
            this.picUpdate.TabIndex = 1;
            this.picUpdate.TabStop = false;
            this.picUpdate.Click += new System.EventHandler(this.picUpdate_Click);
            // 
            // picNew
            // 
            this.picNew.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.picNew.BackgroundImage = global::ProjectManagement.Properties.Resources.rTLo5A5zc;
            this.picNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picNew.Location = new System.Drawing.Point(329, 20);
            this.picNew.Name = "picNew";
            this.picNew.Size = new System.Drawing.Size(34, 26);
            this.picNew.TabIndex = 1;
            this.picNew.TabStop = false;
            this.picNew.Click += new System.EventHandler(this.picNew_Click);
            // 
            // picDelete
            // 
            this.picDelete.BackgroundImage = global::ProjectManagement.Properties.Resources.remove_icon_png_26;
            this.picDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDelete.Location = new System.Drawing.Point(475, 17);
            this.picDelete.Name = "picDelete";
            this.picDelete.Size = new System.Drawing.Size(34, 26);
            this.picDelete.TabIndex = 1;
            this.picDelete.TabStop = false;
            this.picDelete.Click += new System.EventHandler(this.picDelete_Click);
            // 
            // gvBigList
            // 
            this.gvBigList.AllowUserToAddRows = false;
            this.gvBigList.AllowUserToDeleteRows = false;
            this.gvBigList.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvBigList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gvBigList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvBigList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gvBigList.Location = new System.Drawing.Point(0, 146);
            this.gvBigList.Name = "gvBigList";
            this.gvBigList.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvBigList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gvBigList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvBigList.Size = new System.Drawing.Size(912, 503);
            this.gvBigList.TabIndex = 12;
            this.gvBigList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvBigList_CellClick);
            this.gvBigList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvBigList_CellDoubleClick);
            // 
            // lbCompany
            // 
            this.lbCompany.AutoSize = true;
            this.lbCompany.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCompany.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbCompany.Location = new System.Drawing.Point(84, 3);
            this.lbCompany.Name = "lbCompany";
            this.lbCompany.Size = new System.Drawing.Size(144, 32);
            this.lbCompany.TabIndex = 0;
            this.lbCompany.Text = "COMPANY";
            // 
            // lbProject
            // 
            this.lbProject.AutoSize = true;
            this.lbProject.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProject.ForeColor = System.Drawing.Color.Sienna;
            this.lbProject.Location = new System.Drawing.Point(865, 3);
            this.lbProject.Name = "lbProject";
            this.lbProject.Size = new System.Drawing.Size(124, 32);
            this.lbProject.TabIndex = 0;
            this.lbProject.Text = "PROJECT";
            // 
            // panel3
            // 
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel3.Controls.Add(this.lbProject);
            this.panel3.Controls.Add(this.lbCompany);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 24);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1344, 44);
            this.panel3.TabIndex = 13;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = global::ProjectManagement.Properties.Resources.download;
            this.ClientSize = new System.Drawing.Size(1344, 721);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "PROJECT MANAGEMENT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSmallList)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBigList)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeeToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView gvSmallList;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchSmall;
        private System.Windows.Forms.LinkLabel llbAll;
        private System.Windows.Forms.Label lbCompany;
        private System.Windows.Forms.Label lbProject;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView gvBigList;
        private System.Windows.Forms.Label lbNotFound;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbCompanyName;
        private System.Windows.Forms.ComboBox cbPartners;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnViewDetailPartner;
        private System.Windows.Forms.LinkLabel lbAllProject;
        private System.Windows.Forms.PictureBox picUpdate;
        private System.Windows.Forms.PictureBox picNew;
        private System.Windows.Forms.PictureBox picDelete;
    }
}

