namespace desktop.view.popup
{
    partial class KernetListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KernetListForm));
            this.lvKernet = new ComponentOwl.BetterListView.BetterListView();
            this.betterListViewColumnHeader1 = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.betterListViewColumnHeader2 = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.betterListViewColumnHeader3 = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.betterListViewColumnHeader4 = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnTambah = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblInfoId = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblInfoNama = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.lvKernet)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvKernet
            // 
            this.lvKernet.Columns.Add(this.betterListViewColumnHeader1);
            this.lvKernet.Columns.Add(this.betterListViewColumnHeader2);
            this.lvKernet.Columns.Add(this.betterListViewColumnHeader3);
            this.lvKernet.Columns.Add(this.betterListViewColumnHeader4);
            this.lvKernet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvKernet.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvKernet.Location = new System.Drawing.Point(0, 25);
            this.lvKernet.Name = "lvKernet";
            this.lvKernet.Size = new System.Drawing.Size(634, 260);
            this.lvKernet.TabIndex = 1;
            this.lvKernet.SelectedIndexChanged += new System.EventHandler(this.lvKernet_SelectedIndexChanged);
            this.lvKernet.DoubleClick += new System.EventHandler(this.lvKernet_DoubleClick);
            // 
            // betterListViewColumnHeader1
            // 
            this.betterListViewColumnHeader1.Name = "betterListViewColumnHeader1";
            this.betterListViewColumnHeader1.Text = "Kernet ID";
            this.betterListViewColumnHeader1.Width = 95;
            // 
            // betterListViewColumnHeader2
            // 
            this.betterListViewColumnHeader2.Name = "betterListViewColumnHeader2";
            this.betterListViewColumnHeader2.Text = "Nama";
            this.betterListViewColumnHeader2.Width = 240;
            // 
            // betterListViewColumnHeader3
            // 
            this.betterListViewColumnHeader3.Name = "betterListViewColumnHeader3";
            this.betterListViewColumnHeader3.Text = "Alamat";
            // 
            // betterListViewColumnHeader4
            // 
            this.betterListViewColumnHeader4.Name = "betterListViewColumnHeader4";
            this.betterListViewColumnHeader4.Text = "Telepon";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTambah,
            this.btnEdit,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(634, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnTambah
            // 
            this.btnTambah.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnTambah.Image = ((System.Drawing.Image)(resources.GetObject("btnTambah.Image")));
            this.btnTambah.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(49, 22);
            this.btnTambah.Text = "Tambah";
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnEdit.Enabled = false;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(29, 22);
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblInfoId,
            this.lblInfoNama});
            this.statusStrip1.Location = new System.Drawing.Point(0, 263);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(634, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblInfoId
            // 
            this.lblInfoId.Name = "lblInfoId";
            this.lblInfoId.Size = new System.Drawing.Size(18, 17);
            this.lblInfoId.Text = "ID";
            this.lblInfoId.Visible = false;
            // 
            // lblInfoNama
            // 
            this.lblInfoNama.Name = "lblInfoNama";
            this.lblInfoNama.Size = new System.Drawing.Size(39, 17);
            this.lblInfoNama.Text = "Nama";
            this.lblInfoNama.Visible = false;
            // 
            // KernetListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 285);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lvKernet);
            this.Controls.Add(this.toolStrip1);
            this.Name = "KernetListForm";
            this.Text = "KernetListForm";
            ((System.ComponentModel.ISupportInitialize)(this.lvKernet)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentOwl.BetterListView.BetterListView lvKernet;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader betterListViewColumnHeader1;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader betterListViewColumnHeader2;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader betterListViewColumnHeader3;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader betterListViewColumnHeader4;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnTambah;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblInfoId;
        private System.Windows.Forms.ToolStripStatusLabel lblInfoNama;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}