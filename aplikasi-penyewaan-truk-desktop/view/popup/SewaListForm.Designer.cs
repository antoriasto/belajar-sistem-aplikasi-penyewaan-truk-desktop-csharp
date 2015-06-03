namespace desktop.view.popup
{
    partial class SewaListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SewaListForm));
            this.lvSewa = new ComponentOwl.BetterListView.BetterListView();
            this.betterListViewColumnHeader10 = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.betterListViewColumnHeader1 = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.betterListViewColumnHeader2 = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.betterListViewColumnHeader11 = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.betterListViewColumnHeader12 = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.btnBatal = new System.Windows.Forms.Button();
            this.btnPilih = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.lvSewa)).BeginInit();
            this.SuspendLayout();
            // 
            // lvSewa
            // 
            this.lvSewa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSewa.Columns.Add(this.betterListViewColumnHeader10);
            this.lvSewa.Columns.Add(this.betterListViewColumnHeader1);
            this.lvSewa.Columns.Add(this.betterListViewColumnHeader2);
            this.lvSewa.Columns.Add(this.betterListViewColumnHeader11);
            this.lvSewa.Columns.Add(this.betterListViewColumnHeader12);
            this.lvSewa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvSewa.FontGroups = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvSewa.GridLines = ComponentOwl.BetterListView.BetterListViewGridLines.Grid;
            this.lvSewa.Location = new System.Drawing.Point(12, 12);
            this.lvSewa.Name = "lvSewa";
            this.lvSewa.Size = new System.Drawing.Size(511, 211);
            this.lvSewa.TabIndex = 22;
            this.lvSewa.SelectedIndexChanged += new System.EventHandler(this.lvSewa_SelectedIndexChanged);
            this.lvSewa.DoubleClick += new System.EventHandler(this.lvSewa_DoubleClick);
            // 
            // betterListViewColumnHeader10
            // 
            this.betterListViewColumnHeader10.Name = "betterListViewColumnHeader10";
            this.betterListViewColumnHeader10.Text = "Sewa ID";
            this.betterListViewColumnHeader10.Width = 124;
            // 
            // betterListViewColumnHeader1
            // 
            this.betterListViewColumnHeader1.Name = "betterListViewColumnHeader1";
            this.betterListViewColumnHeader1.Text = "Tanggal";
            this.betterListViewColumnHeader1.Width = 73;
            // 
            // betterListViewColumnHeader2
            // 
            this.betterListViewColumnHeader2.Name = "betterListViewColumnHeader2";
            this.betterListViewColumnHeader2.Text = "Harga Total";
            this.betterListViewColumnHeader2.Width = 121;
            // 
            // betterListViewColumnHeader11
            // 
            this.betterListViewColumnHeader11.Name = "betterListViewColumnHeader11";
            this.betterListViewColumnHeader11.Text = "Customer ID";
            this.betterListViewColumnHeader11.Width = 76;
            // 
            // betterListViewColumnHeader12
            // 
            this.betterListViewColumnHeader12.Name = "betterListViewColumnHeader12";
            this.betterListViewColumnHeader12.Text = "Nama Customer";
            this.betterListViewColumnHeader12.Width = 186;
            // 
            // btnBatal
            // 
            this.btnBatal.Location = new System.Drawing.Point(439, 242);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(75, 23);
            this.btnBatal.TabIndex = 23;
            this.btnBatal.Text = "Batal";
            this.btnBatal.UseVisualStyleBackColor = true;
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // btnPilih
            // 
            this.btnPilih.Location = new System.Drawing.Point(358, 242);
            this.btnPilih.Name = "btnPilih";
            this.btnPilih.Size = new System.Drawing.Size(75, 23);
            this.btnPilih.TabIndex = 24;
            this.btnPilih.Text = "Pilih";
            this.btnPilih.UseVisualStyleBackColor = true;
            this.btnPilih.Click += new System.EventHandler(this.btnPilih_Click);
            // 
            // SewaListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 282);
            this.Controls.Add(this.btnPilih);
            this.Controls.Add(this.btnBatal);
            this.Controls.Add(this.lvSewa);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SewaListForm";
            this.Text = "SewaListForm";
            this.Load += new System.EventHandler(this.SewaListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lvSewa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentOwl.BetterListView.BetterListView lvSewa;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader betterListViewColumnHeader10;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader betterListViewColumnHeader1;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader betterListViewColumnHeader2;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader betterListViewColumnHeader11;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader betterListViewColumnHeader12;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.Button btnPilih;
    }
}