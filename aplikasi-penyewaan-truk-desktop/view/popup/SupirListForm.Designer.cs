namespace desktop.view.popup
{
    partial class SupirListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupirListForm));
            this.lvSupir = new ComponentOwl.BetterListView.BetterListView();
            this.betterListViewColumnHeader4 = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.betterListViewColumnHeader5 = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.betterListViewColumnHeader6 = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.betterListViewColumnHeader7 = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.betterListViewColumnHeader8 = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.betterListViewColumnHeader9 = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ID = new System.Windows.Forms.ToolStripStatusLabel();
            this.NAMA = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnTambah = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.lvSupir)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvSupir
            // 
            this.lvSupir.Columns.Add(this.betterListViewColumnHeader4);
            this.lvSupir.Columns.Add(this.betterListViewColumnHeader5);
            this.lvSupir.Columns.Add(this.betterListViewColumnHeader6);
            this.lvSupir.Columns.Add(this.betterListViewColumnHeader7);
            this.lvSupir.Columns.Add(this.betterListViewColumnHeader8);
            this.lvSupir.Columns.Add(this.betterListViewColumnHeader9);
            this.lvSupir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSupir.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvSupir.Location = new System.Drawing.Point(0, 25);
            this.lvSupir.Name = "lvSupir";
            this.lvSupir.Size = new System.Drawing.Size(627, 257);
            this.lvSupir.TabIndex = 3;
            this.lvSupir.SelectedIndexChanged += new System.EventHandler(this.lvSupir_SelectedIndexChanged);
            this.lvSupir.DoubleClick += new System.EventHandler(this.lvSupir_DoubleClick);
            // 
            // betterListViewColumnHeader4
            // 
            this.betterListViewColumnHeader4.Name = "betterListViewColumnHeader4";
            this.betterListViewColumnHeader4.Text = "ID";
            // 
            // betterListViewColumnHeader5
            // 
            this.betterListViewColumnHeader5.Name = "betterListViewColumnHeader5";
            this.betterListViewColumnHeader5.Text = "Nama";
            // 
            // betterListViewColumnHeader6
            // 
            this.betterListViewColumnHeader6.Name = "betterListViewColumnHeader6";
            this.betterListViewColumnHeader6.Text = "Alamat";
            // 
            // betterListViewColumnHeader7
            // 
            this.betterListViewColumnHeader7.Name = "betterListViewColumnHeader7";
            this.betterListViewColumnHeader7.Text = "Telefon";
            // 
            // betterListViewColumnHeader8
            // 
            this.betterListViewColumnHeader8.Name = "betterListViewColumnHeader8";
            this.betterListViewColumnHeader8.Text = "Kernet ID";
            // 
            // betterListViewColumnHeader9
            // 
            this.betterListViewColumnHeader9.Name = "betterListViewColumnHeader9";
            this.betterListViewColumnHeader9.Text = "Nama Kernet";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ID,
            this.NAMA});
            this.statusStrip1.Location = new System.Drawing.Point(0, 282);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(627, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ID
            // 
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(18, 17);
            this.ID.Text = "ID";
            // 
            // NAMA
            // 
            this.NAMA.Name = "NAMA";
            this.NAMA.Size = new System.Drawing.Size(39, 17);
            this.NAMA.Text = "Nama";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTambah,
            this.btnEdit,
            this.btnRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(627, 25);
            this.toolStrip1.TabIndex = 4;
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
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(49, 22);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // SupirListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 304);
            this.Controls.Add(this.lvSupir);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SupirListForm";
            this.Text = "Data Supir";
            ((System.ComponentModel.ISupportInitialize)(this.lvSupir)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentOwl.BetterListView.BetterListView lvSupir;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ID;
        private System.Windows.Forms.ToolStripStatusLabel NAMA;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader betterListViewColumnHeader4;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader betterListViewColumnHeader5;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader betterListViewColumnHeader6;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader betterListViewColumnHeader7;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader betterListViewColumnHeader8;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader betterListViewColumnHeader9;
        private System.Windows.Forms.ToolStripButton btnTambah;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnRefresh;
    }
}