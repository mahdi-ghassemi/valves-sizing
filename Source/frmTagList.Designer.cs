namespace Radman
{
    partial class frmTagList
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
            Telerik.WinControls.UI.RadTreeNode radTreeNode1 = new Telerik.WinControls.UI.RadTreeNode();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tslSort = new System.Windows.Forms.ToolStripLabel();
            this.tcmSort = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tslGroup = new System.Windows.Forms.ToolStripLabel();
            this.tcmGroup = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tslFilter = new System.Windows.Forms.ToolStripLabel();
            this.txbSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.lblCountTitle = new System.Windows.Forms.ToolStripLabel();
            this.lblTagsCount = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.lblTagsSelected = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.cmbAllNone = new System.Windows.Forms.ToolStripComboBox();
            this.livTags = new Telerik.WinControls.UI.RadListView();
            this.btnOpenTags = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.lblNode1 = new System.Windows.Forms.ToolStripLabel();
            this.cmbN1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.cmbN2 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.cmbN3 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.cmbN4 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            this.cmbN5 = new System.Windows.Forms.ToolStripComboBox();
            this.trvMain = new Telerik.WinControls.UI.RadTreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.livTags)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpenTags)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trvMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslSort,
            this.tcmSort,
            this.toolStripSeparator1,
            this.tslGroup,
            this.tcmGroup,
            this.toolStripSeparator2,
            this.toolStripSeparator3,
            this.tslFilter,
            this.txbSearch,
            this.toolStripSeparator5,
            this.toolStripSeparator4,
            this.lblCountTitle,
            this.lblTagsCount,
            this.toolStripSeparator6,
            this.toolStripSeparator7,
            this.toolStripLabel1,
            this.lblTagsSelected,
            this.toolStripSeparator8,
            this.toolStripSeparator9,
            this.toolStripLabel2,
            this.cmbAllNone});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1200, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tslSort
            // 
            this.tslSort.Name = "tslSort";
            this.tslSort.Size = new System.Drawing.Size(47, 22);
            this.tslSort.Text = "Sort by:";
            // 
            // tcmSort
            // 
            this.tcmSort.ForeColor = System.Drawing.Color.Navy;
            this.tcmSort.Name = "tcmSort";
            this.tcmSort.Size = new System.Drawing.Size(121, 25);
            this.tcmSort.SelectedIndexChanged += new System.EventHandler(this.tcmSort_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tslGroup
            // 
            this.tslGroup.Name = "tslGroup";
            this.tslGroup.Size = new System.Drawing.Size(59, 22);
            this.tslGroup.Text = "Group by:";
            // 
            // tcmGroup
            // 
            this.tcmGroup.ForeColor = System.Drawing.Color.Navy;
            this.tcmGroup.Name = "tcmGroup";
            this.tcmGroup.Size = new System.Drawing.Size(121, 25);
            this.tcmGroup.SelectedIndexChanged += new System.EventHandler(this.tcmGroup_SelectedIndexChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tslFilter
            // 
            this.tslFilter.Name = "tslFilter";
            this.tslFilter.Size = new System.Drawing.Size(39, 22);
            this.tslFilter.Text = "Filter :";
            // 
            // txbSearch
            // 
            this.txbSearch.AutoSize = false;
            this.txbSearch.ForeColor = System.Drawing.Color.Navy;
            this.txbSearch.Name = "txbSearch";
            this.txbSearch.Size = new System.Drawing.Size(300, 25);
            this.txbSearch.TextChanged += new System.EventHandler(this.txbSearch_TextChanged);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // lblCountTitle
            // 
            this.lblCountTitle.Name = "lblCountTitle";
            this.lblCountTitle.Size = new System.Drawing.Size(79, 22);
            this.lblCountTitle.Text = "Tag(s) Count:";
            // 
            // lblTagsCount
            // 
            this.lblTagsCount.ForeColor = System.Drawing.Color.Maroon;
            this.lblTagsCount.Name = "lblTagsCount";
            this.lblTagsCount.Size = new System.Drawing.Size(13, 22);
            this.lblTagsCount.Text = "0";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(93, 22);
            this.toolStripLabel1.Text = "Tag(s) Selected: ";
            // 
            // lblTagsSelected
            // 
            this.lblTagsSelected.ForeColor = System.Drawing.Color.Maroon;
            this.lblTagsSelected.Name = "lblTagsSelected";
            this.lblTagsSelected.Size = new System.Drawing.Size(13, 22);
            this.lblTagsSelected.Text = "0";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(41, 22);
            this.toolStripLabel2.Text = "Select:";
            // 
            // cmbAllNone
            // 
            this.cmbAllNone.ForeColor = System.Drawing.Color.Navy;
            this.cmbAllNone.Items.AddRange(new object[] {
            "All",
            "None"});
            this.cmbAllNone.Name = "cmbAllNone";
            this.cmbAllNone.Size = new System.Drawing.Size(121, 25);
            this.cmbAllNone.SelectedIndexChanged += new System.EventHandler(this.cmbAllNone_SelectedIndexChanged);
            // 
            // livTags
            // 
            this.livTags.CheckOnClickMode = Telerik.WinControls.UI.CheckOnClickMode.FirstClick;
            this.livTags.EnableColumnSort = true;
            this.livTags.ItemSpacing = -1;
            this.livTags.Location = new System.Drawing.Point(3, 3);
            this.livTags.Name = "livTags";
            this.livTags.ShowCheckBoxes = true;
            this.livTags.ShowGridLines = true;
            this.livTags.Size = new System.Drawing.Size(782, 535);
            this.livTags.TabIndex = 8;
            this.livTags.Text = "radListView1";
            this.livTags.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView;
            this.livTags.SelectedItemChanged += new System.EventHandler(this.livTags_SelectedItemChanged);
            this.livTags.ItemMouseDoubleClick += new Telerik.WinControls.UI.ListViewItemEventHandler(this.livTags_ItemMouseDoubleClick);
            this.livTags.CellFormatting += new Telerik.WinControls.UI.ListViewCellFormattingEventHandler(this.livTags_CellFormatting);
            // 
            // btnOpenTags
            // 
            this.btnOpenTags.Location = new System.Drawing.Point(959, 600);
            this.btnOpenTags.Name = "btnOpenTags";
            this.btnOpenTags.Size = new System.Drawing.Size(110, 24);
            this.btnOpenTags.TabIndex = 10;
            this.btnOpenTags.Text = "Open Tag(s)";
            this.btnOpenTags.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1075, 600);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 24);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblNode1,
            this.cmbN1,
            this.toolStripLabel3,
            this.cmbN2,
            this.toolStripLabel4,
            this.cmbN3,
            this.toolStripLabel5,
            this.cmbN4,
            this.toolStripLabel6,
            this.cmbN5});
            this.toolStrip2.Location = new System.Drawing.Point(0, 25);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1200, 25);
            this.toolStrip2.TabIndex = 13;
            this.toolStrip2.Text = "toolStrip2";
            this.toolStrip2.Visible = false;
            // 
            // lblNode1
            // 
            this.lblNode1.ForeColor = System.Drawing.Color.DarkRed;
            this.lblNode1.Name = "lblNode1";
            this.lblNode1.Size = new System.Drawing.Size(45, 22);
            this.lblNode1.Text = "Node 1";
            // 
            // cmbN1
            // 
            this.cmbN1.ForeColor = System.Drawing.Color.Navy;
            this.cmbN1.Items.AddRange(new object[] {
            "Personnel",
            "End User",
            "Customer",
            "Project",
            "Radman Ref. No."});
            this.cmbN1.Name = "cmbN1";
            this.cmbN1.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.ForeColor = System.Drawing.Color.DarkRed;
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(45, 22);
            this.toolStripLabel3.Text = "Node 2";
            // 
            // cmbN2
            // 
            this.cmbN2.ForeColor = System.Drawing.Color.Navy;
            this.cmbN2.Items.AddRange(new object[] {
            "Personnel",
            "End User",
            "Customer",
            "Project",
            "Radman Ref. No."});
            this.cmbN2.Name = "cmbN2";
            this.cmbN2.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.ForeColor = System.Drawing.Color.DarkRed;
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(45, 22);
            this.toolStripLabel4.Text = "Node 3";
            // 
            // cmbN3
            // 
            this.cmbN3.ForeColor = System.Drawing.Color.Navy;
            this.cmbN3.Items.AddRange(new object[] {
            "Personnel",
            "End User",
            "Customer",
            "Project",
            "Radman Ref. No."});
            this.cmbN3.Name = "cmbN3";
            this.cmbN3.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.ForeColor = System.Drawing.Color.DarkRed;
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(45, 22);
            this.toolStripLabel5.Text = "Node 4";
            // 
            // cmbN4
            // 
            this.cmbN4.ForeColor = System.Drawing.Color.Navy;
            this.cmbN4.Items.AddRange(new object[] {
            "Personnel",
            "End User",
            "Customer",
            "Project",
            "Radman Ref. No."});
            this.cmbN4.Name = "cmbN4";
            this.cmbN4.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripLabel6
            // 
            this.toolStripLabel6.ForeColor = System.Drawing.Color.DarkRed;
            this.toolStripLabel6.Name = "toolStripLabel6";
            this.toolStripLabel6.Size = new System.Drawing.Size(45, 22);
            this.toolStripLabel6.Text = "Node 5";
            // 
            // cmbN5
            // 
            this.cmbN5.ForeColor = System.Drawing.Color.Navy;
            this.cmbN5.Items.AddRange(new object[] {
            "Personnel",
            "End User",
            "Customer",
            "Project",
            "Radman Ref. No."});
            this.cmbN5.Name = "cmbN5";
            this.cmbN5.Size = new System.Drawing.Size(121, 25);
            // 
            // trvMain
            // 
            this.trvMain.BackColor = System.Drawing.Color.White;
            this.trvMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.trvMain.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.trvMain.ForeColor = System.Drawing.Color.Black;
            this.trvMain.LineColor = System.Drawing.Color.Navy;
            this.trvMain.LineStyle = Telerik.WinControls.UI.TreeLineStyle.Solid;
            this.trvMain.Location = new System.Drawing.Point(3, 3);
            this.trvMain.Name = "trvMain";
            radTreeNode1.Expanded = true;
            radTreeNode1.ForeColor = System.Drawing.Color.Navy;
            radTreeNode1.Name = "nodRoot";
            radTreeNode1.Text = "Radman Corp.";
            this.trvMain.Nodes.AddRange(new Telerik.WinControls.UI.RadTreeNode[] {
            radTreeNode1});
            this.trvMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trvMain.ShowLines = true;
            this.trvMain.Size = new System.Drawing.Size(390, 538);
            this.trvMain.SpacingBetweenNodes = -1;
            this.trvMain.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(0, 53);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.trvMain);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.livTags);
            this.splitContainer1.Size = new System.Drawing.Size(1188, 541);
            this.splitContainer1.SplitterDistance = 396;
            this.splitContainer1.TabIndex = 14;
            // 
            // frmTagList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 636);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOpenTags);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTagList";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmTagList";
            this.Load += new System.EventHandler(this.frmTagList_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.livTags)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpenTags)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trvMain)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel tslSort;
        private System.Windows.Forms.ToolStripComboBox tcmSort;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel tslGroup;
        private System.Windows.Forms.ToolStripComboBox tcmGroup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel tslFilter;
        private System.Windows.Forms.ToolStripTextBox txbSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel lblTagsCount;
        private Telerik.WinControls.UI.RadListView livTags;
        private Telerik.WinControls.UI.RadButton btnOpenTags;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel lblTagsSelected;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox cmbAllNone;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private System.Windows.Forms.ToolStripLabel lblCountTitle;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel lblNode1;
        private System.Windows.Forms.ToolStripComboBox cmbN1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripComboBox cmbN2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripComboBox cmbN3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripComboBox cmbN4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel6;
        private System.Windows.Forms.ToolStripComboBox cmbN5;
        private Telerik.WinControls.UI.RadTreeView trvMain;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
