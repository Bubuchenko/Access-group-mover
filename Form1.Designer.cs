namespace AD_browser
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.refreshBtn = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.treetemplate = new System.Windows.Forms.Panel();
            this.listbox1 = new System.Windows.Forms.ListBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.accessgroupSelection = new System.Windows.Forms.ComboBox();
            this.executeBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listboxMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.loadingStatuslabel = new System.Windows.Forms.Label();
            this.buildLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.listboxMenuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // refreshBtn
            // 
            this.refreshBtn.Location = new System.Drawing.Point(71, 455);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(194, 22);
            this.refreshBtn.TabIndex = 0;
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // treetemplate
            // 
            this.treetemplate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treetemplate.Enabled = false;
            this.treetemplate.Location = new System.Drawing.Point(12, 23);
            this.treetemplate.Name = "treetemplate";
            this.treetemplate.Size = new System.Drawing.Size(324, 426);
            this.treetemplate.TabIndex = 1;
            this.treetemplate.Visible = false;
            // 
            // listbox1
            // 
            this.listbox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listbox1.ContextMenuStrip = this.listboxMenuStrip1;
            this.listbox1.FormattingEnabled = true;
            this.listbox1.HorizontalScrollbar = true;
            this.listbox1.ItemHeight = 14;
            this.listbox1.Location = new System.Drawing.Point(400, 23);
            this.listbox1.Name = "listbox1";
            this.listbox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listbox1.Size = new System.Drawing.Size(236, 310);
            this.listbox1.TabIndex = 2;
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(342, 129);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(52, 64);
            this.addBtn.TabIndex = 3;
            this.addBtn.Text = ">>";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // accessgroupSelection
            // 
            this.accessgroupSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.accessgroupSelection.FormattingEnabled = true;
            this.accessgroupSelection.Location = new System.Drawing.Point(22, 39);
            this.accessgroupSelection.Name = "accessgroupSelection";
            this.accessgroupSelection.Size = new System.Drawing.Size(194, 21);
            this.accessgroupSelection.Sorted = true;
            this.accessgroupSelection.TabIndex = 4;
            // 
            // executeBtn
            // 
            this.executeBtn.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.executeBtn.Location = new System.Drawing.Point(65, 68);
            this.executeBtn.Name = "executeBtn";
            this.executeBtn.Size = new System.Drawing.Size(115, 26);
            this.executeBtn.TabIndex = 5;
            this.executeBtn.Text = "Execute";
            this.executeBtn.UseVisualStyleBackColor = true;
            this.executeBtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "New access group";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buildLabel);
            this.groupBox1.Controls.Add(this.loadingStatuslabel);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.addBtn);
            this.groupBox1.Controls.Add(this.listbox1);
            this.groupBox1.Controls.Add(this.treetemplate);
            this.groupBox1.Controls.Add(this.refreshBtn);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(651, 484);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Access group mover";
            // 
            // listboxMenuStrip1
            // 
            this.listboxMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.listboxMenuStrip1.Name = "listboxMenuStrip1";
            this.listboxMenuStrip1.Size = new System.Drawing.Size(108, 48);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.executeBtn);
            this.groupBox2.Controls.Add(this.accessgroupSelection);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(400, 339);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(236, 106);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Actions";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(66, 216);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(194, 26);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 0;
            this.progressBar1.Visible = false;
            // 
            // loadingStatuslabel
            // 
            this.loadingStatuslabel.AutoSize = true;
            this.loadingStatuslabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadingStatuslabel.Location = new System.Drawing.Point(48, 193);
            this.loadingStatuslabel.Name = "loadingStatuslabel";
            this.loadingStatuslabel.Size = new System.Drawing.Size(234, 15);
            this.loadingStatuslabel.TabIndex = 7;
            this.loadingStatuslabel.Text = "Retrieving systems from active directory...";
            this.loadingStatuslabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.loadingStatuslabel.Visible = false;
            // 
            // buildLabel
            // 
            this.buildLabel.AutoSize = true;
            this.buildLabel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buildLabel.Location = new System.Drawing.Point(468, 468);
            this.buildLabel.Name = "buildLabel";
            this.buildLabel.Size = new System.Drawing.Size(34, 13);
            this.buildLabel.TabIndex = 7;
            this.buildLabel.Text = "Build:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(662, 494);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(678, 533);
            this.Name = "Form1";
            this.Text = "Co-Manage";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.listboxMenuStrip1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel treetemplate;
        private System.Windows.Forms.ListBox listbox1;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.ComboBox accessgroupSelection;
        private System.Windows.Forms.Button executeBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ContextMenuStrip listboxMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label loadingStatuslabel;
        private System.Windows.Forms.Label buildLabel;


    }
}

