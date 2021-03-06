﻿namespace desktop.view.entry
{
    partial class TrukEntryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrukEntryForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnBatal = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblJenisTrukId = new System.Windows.Forms.Label();
            this.txtNomorPolisi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTrukId = new System.Windows.Forms.Label();
            this.txtTrukId = new System.Windows.Forms.TextBox();
            this.txtJenisTrukId = new System.Windows.Forms.TextBox();
            this.lblJenisTruk = new System.Windows.Forms.Label();
            this.txtJenisTruk = new System.Windows.Forms.TextBox();
            this.lblSupirId = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSupirId = new System.Windows.Forms.TextBox();
            this.txtNamaSupir = new System.Windows.Forms.TextBox();
            this.cbRute = new System.Windows.Forms.CheckBox();
            this.btnCariJenisTruk = new System.Windows.Forms.Button();
            this.btnCariSupir = new System.Windows.Forms.Button();
            this.linkLblBatalJenisTruk = new System.Windows.Forms.LinkLabel();
            this.linkLblSupir = new System.Windows.Forms.LinkLabel();
            this.lblKubikasi = new System.Windows.Forms.Label();
            this.lblTonase = new System.Windows.Forms.Label();
            this.txtKubikasi = new System.Windows.Forms.TextBox();
            this.txtTonase = new System.Windows.Forms.TextBox();
            this.lblNomorPolisiWarning = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.panel1.Location = new System.Drawing.Point(0, 294);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(593, 63);
            this.panel1.TabIndex = 15;
            // 
            // btnHapus
            // 
            this.btnHapus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHapus.Location = new System.Drawing.Point(15, 19);
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
            this.btnSimpan.Location = new System.Drawing.Point(425, 19);
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
            this.btnBatal.Location = new System.Drawing.Point(506, 19);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(75, 23);
            this.btnBatal.TabIndex = 16;
            this.btnBatal.Text = "Batal";
            this.btnBatal.UseVisualStyleBackColor = true;
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(593, 1);
            this.label6.TabIndex = 15;
            this.label6.Text = "label6";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lblJenisTrukId, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtNomorPolisi, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTrukId, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtTrukId, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtJenisTrukId, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblJenisTruk, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtJenisTruk, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblSupirId, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.txtSupirId, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.txtNamaSupir, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.cbRute, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.btnCariJenisTruk, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnCariSupir, 2, 10);
            this.tableLayoutPanel1.Controls.Add(this.linkLblBatalJenisTruk, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.linkLblSupir, 3, 10);
            this.tableLayoutPanel1.Controls.Add(this.lblKubikasi, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblTonase, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.txtKubikasi, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtTonase, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblNomorPolisiWarning, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(9);
            this.tableLayoutPanel1.RowCount = 13;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(593, 294);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // lblJenisTrukId
            // 
            this.lblJenisTrukId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblJenisTrukId.AutoSize = true;
            this.lblJenisTrukId.Location = new System.Drawing.Point(12, 100);
            this.lblJenisTrukId.Name = "lblJenisTrukId";
            this.lblJenisTrukId.Size = new System.Drawing.Size(73, 13);
            this.lblJenisTrukId.TabIndex = 6;
            this.lblJenisTrukId.Text = "Jenis Truk ID:";
            // 
            // txtNomorPolisi
            // 
            this.txtNomorPolisi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNomorPolisi.Location = new System.Drawing.Point(91, 39);
            this.txtNomorPolisi.MaxLength = 55;
            this.txtNomorPolisi.Name = "txtNomorPolisi";
            this.txtNomorPolisi.Size = new System.Drawing.Size(383, 21);
            this.txtNomorPolisi.TabIndex = 4;
            this.txtNomorPolisi.TextChanged += new System.EventHandler(this.txtNomorPolisi_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nomor Polisi:";
            // 
            // lblTrukId
            // 
            this.lblTrukId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTrukId.AutoSize = true;
            this.lblTrukId.Location = new System.Drawing.Point(12, 16);
            this.lblTrukId.Name = "lblTrukId";
            this.lblTrukId.Size = new System.Drawing.Size(46, 13);
            this.lblTrukId.TabIndex = 0;
            this.lblTrukId.Text = "Truk ID:";
            this.lblTrukId.Visible = false;
            // 
            // txtTrukId
            // 
            this.txtTrukId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTrukId.Enabled = false;
            this.txtTrukId.Location = new System.Drawing.Point(91, 12);
            this.txtTrukId.MaxLength = 15;
            this.txtTrukId.Name = "txtTrukId";
            this.txtTrukId.Size = new System.Drawing.Size(383, 21);
            this.txtTrukId.TabIndex = 2;
            this.txtTrukId.Visible = false;
            this.txtTrukId.TextChanged += new System.EventHandler(this.txtTrukId_TextChanged);
            // 
            // txtJenisTrukId
            // 
            this.txtJenisTrukId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJenisTrukId.Location = new System.Drawing.Point(91, 96);
            this.txtJenisTrukId.Name = "txtJenisTrukId";
            this.txtJenisTrukId.Size = new System.Drawing.Size(383, 21);
            this.txtJenisTrukId.TabIndex = 7;
            this.txtJenisTrukId.TextChanged += new System.EventHandler(this.txtJenisTrukId_TextChanged);
            // 
            // lblJenisTruk
            // 
            this.lblJenisTruk.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblJenisTruk.AutoSize = true;
            this.lblJenisTruk.Location = new System.Drawing.Point(12, 128);
            this.lblJenisTruk.Name = "lblJenisTruk";
            this.lblJenisTruk.Size = new System.Drawing.Size(59, 13);
            this.lblJenisTruk.TabIndex = 8;
            this.lblJenisTruk.Text = "Jenis Truk:";
            // 
            // txtJenisTruk
            // 
            this.txtJenisTruk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJenisTruk.Location = new System.Drawing.Point(91, 124);
            this.txtJenisTruk.Name = "txtJenisTruk";
            this.txtJenisTruk.Size = new System.Drawing.Size(383, 21);
            this.txtJenisTruk.TabIndex = 9;
            // 
            // lblSupirId
            // 
            this.lblSupirId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSupirId.AutoSize = true;
            this.lblSupirId.Location = new System.Drawing.Point(12, 220);
            this.lblSupirId.Name = "lblSupirId";
            this.lblSupirId.Size = new System.Drawing.Size(49, 13);
            this.lblSupirId.TabIndex = 10;
            this.lblSupirId.Text = "Supir ID:";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 248);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Supir:";
            // 
            // txtSupirId
            // 
            this.txtSupirId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSupirId.Location = new System.Drawing.Point(91, 216);
            this.txtSupirId.Name = "txtSupirId";
            this.txtSupirId.Size = new System.Drawing.Size(383, 21);
            this.txtSupirId.TabIndex = 12;
            this.txtSupirId.TextChanged += new System.EventHandler(this.txtSupirId_TextChanged);
            // 
            // txtNamaSupir
            // 
            this.txtNamaSupir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNamaSupir.Location = new System.Drawing.Point(91, 244);
            this.txtNamaSupir.Name = "txtNamaSupir";
            this.txtNamaSupir.Size = new System.Drawing.Size(383, 21);
            this.txtNamaSupir.TabIndex = 13;
            // 
            // cbRute
            // 
            this.cbRute.AutoSize = true;
            this.cbRute.Enabled = false;
            this.cbRute.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.cbRute.Location = new System.Drawing.Point(91, 272);
            this.cbRute.Name = "cbRute";
            this.cbRute.Size = new System.Drawing.Size(71, 17);
            this.cbRute.TabIndex = 14;
            this.cbRute.Text = "Ada Rute";
            this.cbRute.UseVisualStyleBackColor = true;
            // 
            // btnCariJenisTruk
            // 
            this.btnCariJenisTruk.Location = new System.Drawing.Point(480, 123);
            this.btnCariJenisTruk.Name = "btnCariJenisTruk";
            this.btnCariJenisTruk.Size = new System.Drawing.Size(64, 23);
            this.btnCariJenisTruk.TabIndex = 15;
            this.btnCariJenisTruk.Text = "Cari";
            this.btnCariJenisTruk.UseVisualStyleBackColor = true;
            this.btnCariJenisTruk.Click += new System.EventHandler(this.btnCariJenisTruk_Click);
            // 
            // btnCariSupir
            // 
            this.btnCariSupir.Location = new System.Drawing.Point(480, 243);
            this.btnCariSupir.Name = "btnCariSupir";
            this.btnCariSupir.Size = new System.Drawing.Size(64, 23);
            this.btnCariSupir.TabIndex = 16;
            this.btnCariSupir.Text = "Cari";
            this.btnCariSupir.UseVisualStyleBackColor = true;
            this.btnCariSupir.Click += new System.EventHandler(this.btnCariSupir_Click);
            // 
            // linkLblBatalJenisTruk
            // 
            this.linkLblBatalJenisTruk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.linkLblBatalJenisTruk.AutoSize = true;
            this.linkLblBatalJenisTruk.Location = new System.Drawing.Point(550, 128);
            this.linkLblBatalJenisTruk.Name = "linkLblBatalJenisTruk";
            this.linkLblBatalJenisTruk.Size = new System.Drawing.Size(31, 13);
            this.linkLblBatalJenisTruk.TabIndex = 21;
            this.linkLblBatalJenisTruk.TabStop = true;
            this.linkLblBatalJenisTruk.Text = "Batal";
            this.linkLblBatalJenisTruk.Visible = false;
            this.linkLblBatalJenisTruk.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLblBatalJenisTruk_LinkClicked);
            // 
            // linkLblSupir
            // 
            this.linkLblSupir.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.linkLblSupir.AutoSize = true;
            this.linkLblSupir.Location = new System.Drawing.Point(550, 248);
            this.linkLblSupir.Name = "linkLblSupir";
            this.linkLblSupir.Size = new System.Drawing.Size(31, 13);
            this.linkLblSupir.TabIndex = 22;
            this.linkLblSupir.TabStop = true;
            this.linkLblSupir.Text = "Batal";
            this.linkLblSupir.Visible = false;
            this.linkLblSupir.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLblSupir_LinkClicked);
            // 
            // lblKubikasi
            // 
            this.lblKubikasi.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblKubikasi.AutoSize = true;
            this.lblKubikasi.Location = new System.Drawing.Point(12, 156);
            this.lblKubikasi.Name = "lblKubikasi";
            this.lblKubikasi.Size = new System.Drawing.Size(49, 13);
            this.lblKubikasi.TabIndex = 23;
            this.lblKubikasi.Text = "Kubikasi:";
            this.lblKubikasi.Visible = false;
            // 
            // lblTonase
            // 
            this.lblTonase.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTonase.AutoSize = true;
            this.lblTonase.Location = new System.Drawing.Point(12, 183);
            this.lblTonase.Name = "lblTonase";
            this.lblTonase.Size = new System.Drawing.Size(46, 13);
            this.lblTonase.TabIndex = 24;
            this.lblTonase.Text = "Tonase:";
            this.lblTonase.Visible = false;
            // 
            // txtKubikasi
            // 
            this.txtKubikasi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKubikasi.Location = new System.Drawing.Point(91, 152);
            this.txtKubikasi.Name = "txtKubikasi";
            this.txtKubikasi.Size = new System.Drawing.Size(383, 21);
            this.txtKubikasi.TabIndex = 25;
            this.txtKubikasi.Visible = false;
            // 
            // txtTonase
            // 
            this.txtTonase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTonase.Location = new System.Drawing.Point(91, 179);
            this.txtTonase.Name = "txtTonase";
            this.txtTonase.Size = new System.Drawing.Size(383, 21);
            this.txtTonase.TabIndex = 26;
            this.txtTonase.Visible = false;
            // 
            // lblNomorPolisiWarning
            // 
            this.lblNomorPolisiWarning.AutoSize = true;
            this.lblNomorPolisiWarning.ForeColor = System.Drawing.Color.DarkRed;
            this.lblNomorPolisiWarning.Location = new System.Drawing.Point(91, 63);
            this.lblNomorPolisiWarning.Name = "lblNomorPolisiWarning";
            this.lblNomorPolisiWarning.Size = new System.Drawing.Size(0, 13);
            this.lblNomorPolisiWarning.TabIndex = 27;
            this.lblNomorPolisiWarning.Visible = false;
            // 
            // TrukEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 357);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TrukEntryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TrukEntryForm";
            this.Load += new System.EventHandler(this.TrukEntryForm_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblJenisTrukId;
        private System.Windows.Forms.TextBox txtNomorPolisi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTrukId;
        private System.Windows.Forms.TextBox txtTrukId;
        private System.Windows.Forms.TextBox txtJenisTrukId;
        private System.Windows.Forms.Label lblJenisTruk;
        private System.Windows.Forms.TextBox txtJenisTruk;
        private System.Windows.Forms.Label lblSupirId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSupirId;
        private System.Windows.Forms.TextBox txtNamaSupir;
        private System.Windows.Forms.CheckBox cbRute;
        private System.Windows.Forms.Button btnCariJenisTruk;
        private System.Windows.Forms.Button btnCariSupir;
        private System.Windows.Forms.LinkLabel linkLblBatalJenisTruk;
        private System.Windows.Forms.LinkLabel linkLblSupir;
        private System.Windows.Forms.Label lblKubikasi;
        private System.Windows.Forms.Label lblTonase;
        private System.Windows.Forms.TextBox txtKubikasi;
        private System.Windows.Forms.TextBox txtTonase;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Label lblNomorPolisiWarning;
    }
}