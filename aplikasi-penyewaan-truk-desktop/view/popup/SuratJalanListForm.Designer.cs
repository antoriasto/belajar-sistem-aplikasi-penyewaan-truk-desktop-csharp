namespace desktop.view.popup
{
    partial class SuratJalanListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuratJalanListForm));
            this.lvSuratJalan = new ComponentOwl.BetterListView.BetterListView();
            this.betterListViewColumnHeader10 = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.betterListViewColumnHeader1 = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.betterListViewColumnHeader11 = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            ((System.ComponentModel.ISupportInitialize)(this.lvSuratJalan)).BeginInit();
            this.SuspendLayout();
            // 
            // lvSuratJalan
            // 
            this.lvSuratJalan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSuratJalan.Columns.Add(this.betterListViewColumnHeader10);
            this.lvSuratJalan.Columns.Add(this.betterListViewColumnHeader1);
            this.lvSuratJalan.Columns.Add(this.betterListViewColumnHeader11);
            this.lvSuratJalan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvSuratJalan.FontGroups = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvSuratJalan.GridLines = ComponentOwl.BetterListView.BetterListViewGridLines.Grid;
            this.lvSuratJalan.Location = new System.Drawing.Point(12, 12);
            this.lvSuratJalan.Name = "lvSuratJalan";
            this.lvSuratJalan.Size = new System.Drawing.Size(639, 232);
            this.lvSuratJalan.TabIndex = 23;
            this.lvSuratJalan.SelectedIndexChanged += new System.EventHandler(this.lvSuratJalan_SelectedIndexChanged);
            this.lvSuratJalan.DoubleClick += new System.EventHandler(this.lvSuratJalan_DoubleClick);
            // 
            // betterListViewColumnHeader10
            // 
            this.betterListViewColumnHeader10.Name = "betterListViewColumnHeader10";
            this.betterListViewColumnHeader10.Text = "Nomor Surat Jalan";
            this.betterListViewColumnHeader10.Width = 127;
            // 
            // betterListViewColumnHeader1
            // 
            this.betterListViewColumnHeader1.Name = "betterListViewColumnHeader1";
            this.betterListViewColumnHeader1.Text = "Tanggal";
            this.betterListViewColumnHeader1.Width = 73;
            // 
            // betterListViewColumnHeader11
            // 
            this.betterListViewColumnHeader11.Name = "betterListViewColumnHeader11";
            this.betterListViewColumnHeader11.Text = "Customer ID";
            this.betterListViewColumnHeader11.Width = 146;
            // 
            // SuratJalanListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 256);
            this.Controls.Add(this.lvSuratJalan);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SuratJalanListForm";
            this.Text = "SuratJalanListForm";
            ((System.ComponentModel.ISupportInitialize)(this.lvSuratJalan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentOwl.BetterListView.BetterListView lvSuratJalan;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader betterListViewColumnHeader10;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader betterListViewColumnHeader1;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader betterListViewColumnHeader11;
    }
}