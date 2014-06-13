namespace aplikasi_penyewaan_truk_desktop.view.popup
{
    partial class TrukListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrukListForm));
            this.lvTruk = new ComponentOwl.BetterListView.BetterListView();
            this.betterListViewColumnHeader1 = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.betterListViewColumnHeader2 = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.betterListViewColumnHeader3 = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.betterListViewColumnHeader4 = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.betterListViewColumnHeader5 = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.betterListViewColumnHeader6 = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnTambah = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.lvTruk)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvTruk
            // 
            this.lvTruk.Columns.Add(this.betterListViewColumnHeader1);
            this.lvTruk.Columns.Add(this.betterListViewColumnHeader2);
            this.lvTruk.Columns.Add(this.betterListViewColumnHeader3);
            this.lvTruk.Columns.Add(this.betterListViewColumnHeader4);
            this.lvTruk.Columns.Add(this.betterListViewColumnHeader5);
            this.lvTruk.Columns.Add(this.betterListViewColumnHeader6);
            this.lvTruk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTruk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvTruk.Location = new System.Drawing.Point(0, 25);
            this.lvTruk.Name = "lvTruk";
            this.lvTruk.Size = new System.Drawing.Size(591, 234);
            this.lvTruk.TabIndex = 0;
            this.lvTruk.ItemSelectionChanged += new ComponentOwl.BetterListView.BetterListViewItemSelectionChangedEventHandler(this.lvTruk_ItemSelectionChanged);
            // 
            // betterListViewColumnHeader1
            // 
            this.betterListViewColumnHeader1.Name = "betterListViewColumnHeader1";
            this.betterListViewColumnHeader1.Text = "ID";
            this.betterListViewColumnHeader1.Width = 68;
            // 
            // betterListViewColumnHeader2
            // 
            this.betterListViewColumnHeader2.Name = "betterListViewColumnHeader2";
            this.betterListViewColumnHeader2.Text = "Nomor Polisi";
            this.betterListViewColumnHeader2.Width = 114;
            // 
            // betterListViewColumnHeader3
            // 
            this.betterListViewColumnHeader3.Name = "betterListViewColumnHeader3";
            this.betterListViewColumnHeader3.Text = "Jenis Truk ID";
            this.betterListViewColumnHeader3.Width = 83;
            // 
            // betterListViewColumnHeader4
            // 
            this.betterListViewColumnHeader4.Name = "betterListViewColumnHeader4";
            this.betterListViewColumnHeader4.Text = "Jenis Truk";
            // 
            // betterListViewColumnHeader5
            // 
            this.betterListViewColumnHeader5.Name = "betterListViewColumnHeader5";
            this.betterListViewColumnHeader5.Text = "Supi ID";
            this.betterListViewColumnHeader5.Width = 63;
            // 
            // betterListViewColumnHeader6
            // 
            this.betterListViewColumnHeader6.Name = "betterListViewColumnHeader6";
            this.betterListViewColumnHeader6.Text = "Supir";
            this.betterListViewColumnHeader6.Width = 121;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTambah});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(591, 25);
            this.toolStrip1.TabIndex = 1;
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
            // TrukListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 259);
            this.Controls.Add(this.lvTruk);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TrukListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TrukListForm";
            ((System.ComponentModel.ISupportInitialize)(this.lvTruk)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentOwl.BetterListView.BetterListView lvTruk;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader betterListViewColumnHeader1;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader betterListViewColumnHeader2;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader betterListViewColumnHeader3;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader betterListViewColumnHeader4;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader betterListViewColumnHeader5;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader betterListViewColumnHeader6;
        private System.Windows.Forms.ToolStripButton btnTambah;
    }
}