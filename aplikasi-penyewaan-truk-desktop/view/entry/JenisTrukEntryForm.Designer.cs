namespace desktop.view.entry
{
    partial class JenisTrukEntryForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnBatal = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblKubikasi = new System.Windows.Forms.Label();
            this.txtNamaJenis = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblJenisTrukId = new System.Windows.Forms.Label();
            this.txtJenisTrukId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nuTonase = new System.Windows.Forms.NumericUpDown();
            this.nuKubikasi = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuTonase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuKubikasi)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnHapus);
            this.panel1.Controls.Add(this.btnSimpan);
            this.panel1.Controls.Add(this.btnBatal);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 147);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(512, 63);
            this.panel1.TabIndex = 19;
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(12, 19);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(75, 23);
            this.btnHapus.TabIndex = 18;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Visible = false;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnSimpan
            // 
            this.btnSimpan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSimpan.Location = new System.Drawing.Point(344, 19);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(75, 23);
            this.btnSimpan.TabIndex = 17;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnBatal
            // 
            this.btnBatal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatal.Location = new System.Drawing.Point(425, 19);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(75, 23);
            this.btnBatal.TabIndex = 16;
            this.btnBatal.Text = "Batal";
            this.btnBatal.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(512, 1);
            this.label6.TabIndex = 15;
            this.label6.Text = "label6";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.nuKubikasi, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblKubikasi, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtNamaJenis, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblJenisTrukId, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtJenisTrukId, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.nuTonase, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(9);
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(512, 147);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // lblKubikasi
            // 
            this.lblKubikasi.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblKubikasi.AutoSize = true;
            this.lblKubikasi.Location = new System.Drawing.Point(12, 70);
            this.lblKubikasi.Name = "lblKubikasi";
            this.lblKubikasi.Size = new System.Drawing.Size(49, 13);
            this.lblKubikasi.TabIndex = 6;
            this.lblKubikasi.Text = "Kubikasi:";
            // 
            // txtNamaJenis
            // 
            this.txtNamaJenis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNamaJenis.Location = new System.Drawing.Point(83, 39);
            this.txtNamaJenis.Name = "txtNamaJenis";
            this.txtNamaJenis.Size = new System.Drawing.Size(417, 21);
            this.txtNamaJenis.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nama Jenis:";
            // 
            // lblJenisTrukId
            // 
            this.lblJenisTrukId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblJenisTrukId.AutoSize = true;
            this.lblJenisTrukId.Location = new System.Drawing.Point(12, 16);
            this.lblJenisTrukId.Name = "lblJenisTrukId";
            this.lblJenisTrukId.Size = new System.Drawing.Size(22, 13);
            this.lblJenisTrukId.TabIndex = 0;
            this.lblJenisTrukId.Text = "ID:";
            // 
            // txtJenisTrukId
            // 
            this.txtJenisTrukId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJenisTrukId.Enabled = false;
            this.txtJenisTrukId.Location = new System.Drawing.Point(83, 12);
            this.txtJenisTrukId.Name = "txtJenisTrukId";
            this.txtJenisTrukId.Size = new System.Drawing.Size(417, 21);
            this.txtJenisTrukId.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tonase:";
            // 
            // nuTonase
            // 
            this.nuTonase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nuTonase.Location = new System.Drawing.Point(83, 93);
            this.nuTonase.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nuTonase.Name = "nuTonase";
            this.nuTonase.Size = new System.Drawing.Size(417, 21);
            this.nuTonase.TabIndex = 9;
            // 
            // nuKubikasi
            // 
            this.nuKubikasi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nuKubikasi.Location = new System.Drawing.Point(83, 66);
            this.nuKubikasi.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nuKubikasi.Name = "nuKubikasi";
            this.nuKubikasi.Size = new System.Drawing.Size(417, 21);
            this.nuKubikasi.TabIndex = 11;
            // 
            // JenisTrukEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 210);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "JenisTrukEntryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JenisTrukEntryForm";
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuTonase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuKubikasi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblKubikasi;
        private System.Windows.Forms.TextBox txtNamaJenis;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblJenisTrukId;
        private System.Windows.Forms.TextBox txtJenisTrukId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nuTonase;
        private System.Windows.Forms.NumericUpDown nuKubikasi;
    }
}