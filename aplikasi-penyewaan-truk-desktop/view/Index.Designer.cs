namespace desktop.view
{
    partial class Index
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Truk");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Jenis Truk");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Rute");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Supir");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Kernet");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Customer");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Master", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Index));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.masterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trukToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jenisTrukToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ruteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.supirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kernetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.customerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.transaksiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sewaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.kwitansiSupirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.suratJalanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.invoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.laporanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sewaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.kwitansiSupirToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.suratJalanToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.invoiceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.keluarAplikasiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblNodeInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.dPHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.masterToolStripMenuItem,
            this.toolStripSeparator6,
            this.transaksiToolStripMenuItem,
            this.toolStripSeparator4,
            this.laporanToolStripMenuItem,
            this.toolStripSeparator5,
            this.keluarAplikasiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(588, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // masterToolStripMenuItem
            // 
            this.masterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trukToolStripMenuItem,
            this.jenisTrukToolStripMenuItem1,
            this.toolStripSeparator1,
            this.ruteToolStripMenuItem,
            this.toolStripSeparator2,
            this.supirToolStripMenuItem,
            this.kernetToolStripMenuItem,
            this.toolStripSeparator3,
            this.customerToolStripMenuItem});
            this.masterToolStripMenuItem.Name = "masterToolStripMenuItem";
            this.masterToolStripMenuItem.Size = new System.Drawing.Size(52, 23);
            this.masterToolStripMenuItem.Text = "Master";
            // 
            // trukToolStripMenuItem
            // 
            this.trukToolStripMenuItem.Name = "trukToolStripMenuItem";
            this.trukToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.trukToolStripMenuItem.Text = "Truk";
            this.trukToolStripMenuItem.Click += new System.EventHandler(this.trukToolStripMenuItem_Click);
            // 
            // jenisTrukToolStripMenuItem1
            // 
            this.jenisTrukToolStripMenuItem1.Name = "jenisTrukToolStripMenuItem1";
            this.jenisTrukToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.jenisTrukToolStripMenuItem1.Text = "Jenis Truk";
            this.jenisTrukToolStripMenuItem1.Click += new System.EventHandler(this.jenisTrukToolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(119, 6);
            // 
            // ruteToolStripMenuItem
            // 
            this.ruteToolStripMenuItem.Name = "ruteToolStripMenuItem";
            this.ruteToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.ruteToolStripMenuItem.Text = "Rute";
            this.ruteToolStripMenuItem.Click += new System.EventHandler(this.ruteToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(119, 6);
            // 
            // supirToolStripMenuItem
            // 
            this.supirToolStripMenuItem.Name = "supirToolStripMenuItem";
            this.supirToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.supirToolStripMenuItem.Text = "Supir";
            this.supirToolStripMenuItem.Click += new System.EventHandler(this.supirToolStripMenuItem_Click);
            // 
            // kernetToolStripMenuItem
            // 
            this.kernetToolStripMenuItem.Name = "kernetToolStripMenuItem";
            this.kernetToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.kernetToolStripMenuItem.Text = "Kernet";
            this.kernetToolStripMenuItem.Click += new System.EventHandler(this.kernetToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(119, 6);
            // 
            // customerToolStripMenuItem
            // 
            this.customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            this.customerToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.customerToolStripMenuItem.Text = "Customer";
            this.customerToolStripMenuItem.Click += new System.EventHandler(this.customerToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 23);
            // 
            // transaksiToolStripMenuItem
            // 
            this.transaksiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sewaToolStripMenuItem,
            this.toolStripSeparator8,
            this.kwitansiSupirToolStripMenuItem,
            this.toolStripSeparator7,
            this.suratJalanToolStripMenuItem,
            this.toolStripSeparator11,
            this.invoiceToolStripMenuItem,
            this.dPHToolStripMenuItem});
            this.transaksiToolStripMenuItem.Name = "transaksiToolStripMenuItem";
            this.transaksiToolStripMenuItem.Size = new System.Drawing.Size(64, 23);
            this.transaksiToolStripMenuItem.Text = "Transaksi";
            // 
            // sewaToolStripMenuItem
            // 
            this.sewaToolStripMenuItem.Name = "sewaToolStripMenuItem";
            this.sewaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sewaToolStripMenuItem.Text = "Sewa";
            this.sewaToolStripMenuItem.Click += new System.EventHandler(this.sewaToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(149, 6);
            // 
            // kwitansiSupirToolStripMenuItem
            // 
            this.kwitansiSupirToolStripMenuItem.Name = "kwitansiSupirToolStripMenuItem";
            this.kwitansiSupirToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.kwitansiSupirToolStripMenuItem.Text = "Kwitansi Supir";
            this.kwitansiSupirToolStripMenuItem.Click += new System.EventHandler(this.kwitansiSupirToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(149, 6);
            // 
            // suratJalanToolStripMenuItem
            // 
            this.suratJalanToolStripMenuItem.Name = "suratJalanToolStripMenuItem";
            this.suratJalanToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.suratJalanToolStripMenuItem.Text = "Surat Jalan";
            this.suratJalanToolStripMenuItem.Click += new System.EventHandler(this.suratJalanToolStripMenuItem_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(149, 6);
            // 
            // invoiceToolStripMenuItem
            // 
            this.invoiceToolStripMenuItem.Name = "invoiceToolStripMenuItem";
            this.invoiceToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.invoiceToolStripMenuItem.Text = "Invoice";
            this.invoiceToolStripMenuItem.Click += new System.EventHandler(this.invoiceToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
            // 
            // laporanToolStripMenuItem
            // 
            this.laporanToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sewaToolStripMenuItem1,
            this.toolStripSeparator10,
            this.kwitansiSupirToolStripMenuItem1,
            this.toolStripSeparator12,
            this.suratJalanToolStripMenuItem1,
            this.toolStripSeparator9,
            this.invoiceToolStripMenuItem1});
            this.laporanToolStripMenuItem.Name = "laporanToolStripMenuItem";
            this.laporanToolStripMenuItem.Size = new System.Drawing.Size(58, 23);
            this.laporanToolStripMenuItem.Text = "Laporan";
            // 
            // sewaToolStripMenuItem1
            // 
            this.sewaToolStripMenuItem1.Name = "sewaToolStripMenuItem1";
            this.sewaToolStripMenuItem1.Size = new System.Drawing.Size(140, 22);
            this.sewaToolStripMenuItem1.Text = "Sewa";
            this.sewaToolStripMenuItem1.Click += new System.EventHandler(this.sewaToolStripMenuItem1_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(137, 6);
            // 
            // kwitansiSupirToolStripMenuItem1
            // 
            this.kwitansiSupirToolStripMenuItem1.Name = "kwitansiSupirToolStripMenuItem1";
            this.kwitansiSupirToolStripMenuItem1.Size = new System.Drawing.Size(140, 22);
            this.kwitansiSupirToolStripMenuItem1.Text = "Kwitansi Supir";
            this.kwitansiSupirToolStripMenuItem1.Click += new System.EventHandler(this.kwitansiSupirToolStripMenuItem1_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(137, 6);
            // 
            // suratJalanToolStripMenuItem1
            // 
            this.suratJalanToolStripMenuItem1.Name = "suratJalanToolStripMenuItem1";
            this.suratJalanToolStripMenuItem1.Size = new System.Drawing.Size(140, 22);
            this.suratJalanToolStripMenuItem1.Text = "Surat Jalan";
            this.suratJalanToolStripMenuItem1.Click += new System.EventHandler(this.suratJalanToolStripMenuItem1_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(137, 6);
            // 
            // invoiceToolStripMenuItem1
            // 
            this.invoiceToolStripMenuItem1.Name = "invoiceToolStripMenuItem1";
            this.invoiceToolStripMenuItem1.Size = new System.Drawing.Size(140, 22);
            this.invoiceToolStripMenuItem1.Text = "Invoice";
            this.invoiceToolStripMenuItem1.Click += new System.EventHandler(this.invoiceToolStripMenuItem1_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 23);
            // 
            // keluarAplikasiToolStripMenuItem
            // 
            this.keluarAplikasiToolStripMenuItem.Name = "keluarAplikasiToolStripMenuItem";
            this.keluarAplikasiToolStripMenuItem.Size = new System.Drawing.Size(49, 23);
            this.keluarAplikasiToolStripMenuItem.Text = "Keluar";
            this.keluarAplikasiToolStripMenuItem.Click += new System.EventHandler(this.keluarAplikasiToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblNodeInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 268);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(588, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblNodeInfo
            // 
            this.lblNodeInfo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNodeInfo.Name = "lblNodeInfo";
            this.lblNodeInfo.Size = new System.Drawing.Size(0, 17);
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Location = new System.Drawing.Point(0, 27);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "NodeTruk";
            treeNode1.Text = "Truk";
            treeNode2.Name = "NodeJenisTruk";
            treeNode2.Text = "Jenis Truk";
            treeNode3.Name = "NodeRute";
            treeNode3.Text = "Rute";
            treeNode4.Name = "NodeSupir";
            treeNode4.Text = "Supir";
            treeNode5.Name = "NodeKernet";
            treeNode5.Text = "Kernet";
            treeNode6.Name = "NodeCustomer";
            treeNode6.Text = "Customer";
            treeNode7.Name = "Node0";
            treeNode7.Text = "Master";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7});
            this.treeView1.Size = new System.Drawing.Size(106, 241);
            this.treeView1.TabIndex = 4;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // dPHToolStripMenuItem
            // 
            this.dPHToolStripMenuItem.Name = "dPHToolStripMenuItem";
            this.dPHToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.dPHToolStripMenuItem.Text = "DPH";
            this.dPHToolStripMenuItem.Click += new System.EventHandler(this.dPHToolStripMenuItem_Click);
            // 
            // Index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(588, 290);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Index";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Utama";
            this.TransparencyKey = System.Drawing.Color.White;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Index_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem masterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trukToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ruteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transaksiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sewaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem laporanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keluarAplikasiToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem supirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kernetToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStripStatusLabel lblNodeInfo;
        private System.Windows.Forms.ToolStripMenuItem suratJalanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invoiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jenisTrukToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem sewaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem suratJalanToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem invoiceToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem kwitansiSupirToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem kwitansiSupirToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripMenuItem dPHToolStripMenuItem;
    }
}