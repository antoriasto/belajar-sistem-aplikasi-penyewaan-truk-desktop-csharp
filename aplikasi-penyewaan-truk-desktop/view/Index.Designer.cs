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
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Sewa");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Report", new System.Windows.Forms.TreeNode[] {
            treeNode8});
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.masterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trukToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trukToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.jenisTrukToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ruteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.supirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kernetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.customerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transaksiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sewaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suratJalanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.laporanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keluarAplikasiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblNodeInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.invoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.masterToolStripMenuItem,
            this.transaksiToolStripMenuItem,
            this.laporanToolStripMenuItem,
            this.keluarAplikasiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(588, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // masterToolStripMenuItem
            // 
            this.masterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trukToolStripMenuItem,
            this.ruteToolStripMenuItem,
            this.toolStripSeparator1,
            this.supirToolStripMenuItem,
            this.kernetToolStripMenuItem,
            this.toolStripSeparator2,
            this.customerToolStripMenuItem});
            this.masterToolStripMenuItem.Name = "masterToolStripMenuItem";
            this.masterToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.masterToolStripMenuItem.Text = "Master";
            // 
            // trukToolStripMenuItem
            // 
            this.trukToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trukToolStripMenuItem1,
            this.jenisTrukToolStripMenuItem});
            this.trukToolStripMenuItem.Name = "trukToolStripMenuItem";
            this.trukToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.trukToolStripMenuItem.Text = "Truk";
            // 
            // trukToolStripMenuItem1
            // 
            this.trukToolStripMenuItem1.Name = "trukToolStripMenuItem1";
            this.trukToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.trukToolStripMenuItem1.Text = "Truk";
            this.trukToolStripMenuItem1.Click += new System.EventHandler(this.trukToolStripMenuItem1_Click);
            // 
            // jenisTrukToolStripMenuItem
            // 
            this.jenisTrukToolStripMenuItem.Name = "jenisTrukToolStripMenuItem";
            this.jenisTrukToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.jenisTrukToolStripMenuItem.Text = "Jenis Truk";
            // 
            // ruteToolStripMenuItem
            // 
            this.ruteToolStripMenuItem.Name = "ruteToolStripMenuItem";
            this.ruteToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.ruteToolStripMenuItem.Text = "Rute";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(117, 6);
            // 
            // supirToolStripMenuItem
            // 
            this.supirToolStripMenuItem.Name = "supirToolStripMenuItem";
            this.supirToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.supirToolStripMenuItem.Text = "Supir";
            this.supirToolStripMenuItem.Click += new System.EventHandler(this.supirToolStripMenuItem_Click);
            // 
            // kernetToolStripMenuItem
            // 
            this.kernetToolStripMenuItem.Name = "kernetToolStripMenuItem";
            this.kernetToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.kernetToolStripMenuItem.Text = "Kernet";
            this.kernetToolStripMenuItem.Click += new System.EventHandler(this.kernetToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(117, 6);
            // 
            // customerToolStripMenuItem
            // 
            this.customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            this.customerToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.customerToolStripMenuItem.Text = "Customer";
            // 
            // transaksiToolStripMenuItem
            // 
            this.transaksiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sewaToolStripMenuItem,
            this.suratJalanToolStripMenuItem,
            this.invoiceToolStripMenuItem});
            this.transaksiToolStripMenuItem.Name = "transaksiToolStripMenuItem";
            this.transaksiToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.transaksiToolStripMenuItem.Text = "Transaksi";
            // 
            // sewaToolStripMenuItem
            // 
            this.sewaToolStripMenuItem.Name = "sewaToolStripMenuItem";
            this.sewaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sewaToolStripMenuItem.Text = "Sewa";
            this.sewaToolStripMenuItem.Click += new System.EventHandler(this.sewaToolStripMenuItem_Click);
            // 
            // suratJalanToolStripMenuItem
            // 
            this.suratJalanToolStripMenuItem.Name = "suratJalanToolStripMenuItem";
            this.suratJalanToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.suratJalanToolStripMenuItem.Text = "Surat Jalan";
            this.suratJalanToolStripMenuItem.Click += new System.EventHandler(this.suratJalanToolStripMenuItem_Click);
            // 
            // laporanToolStripMenuItem
            // 
            this.laporanToolStripMenuItem.Name = "laporanToolStripMenuItem";
            this.laporanToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.laporanToolStripMenuItem.Text = "Laporan";
            // 
            // keluarAplikasiToolStripMenuItem
            // 
            this.keluarAplikasiToolStripMenuItem.Name = "keluarAplikasiToolStripMenuItem";
            this.keluarAplikasiToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.keluarAplikasiToolStripMenuItem.Text = "Keluar Aplikasi";
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
            this.treeView1.Location = new System.Drawing.Point(0, 24);
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
            treeNode8.Name = "NodeSewa";
            treeNode8.Text = "Sewa";
            treeNode9.Name = "Node7";
            treeNode9.Text = "Report";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode9});
            this.treeView1.Size = new System.Drawing.Size(133, 244);
            this.treeView1.TabIndex = 4;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // invoiceToolStripMenuItem
            // 
            this.invoiceToolStripMenuItem.Name = "invoiceToolStripMenuItem";
            this.invoiceToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.invoiceToolStripMenuItem.Text = "Invoice";
            this.invoiceToolStripMenuItem.Click += new System.EventHandler(this.invoiceToolStripMenuItem_Click);
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
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Index";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Index";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
        private System.Windows.Forms.ToolStripMenuItem trukToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem jenisTrukToolStripMenuItem;
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
    }
}