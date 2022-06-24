using System;
using System.Data;
using System.Drawing;
using Telerik.WinControls.UI;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using Telerik.WinControls.Enumerations;
using System.IO;

namespace Radman
{
    public partial class frmTagList : Telerik.WinControls.UI.RadForm
    {
        private int SelectedCount = 0;
        public frmTagList()
        {
            InitializeComponent();
        }

        private void frmTagList_Load(object sender, EventArgs e)
        {
            try { 
            this.trvMain.TreeViewElement.AutoSizeItems = true;
            FillNodes();
            cmbN1.SelectedIndex = 0;
            cmbN2.SelectedIndex = 1;            
            cmbN3.SelectedIndex = 2;
            cmbN4.SelectedIndex = 3;
            cmbN5.SelectedIndex = 4;
            
            DataTable dt = new DataTable();
            dt = BL.GetTags();
            if (dt != null)
            {
                SetListView(dt);
            }
            lblTagsSelected.Text = SelectedCount.ToString();
            cmbAllNone.SelectedIndex = 1;
            }
            catch
            {

            }

        }

        private void FillNodes()
        {
            try { 
            DataTable dt = new DataTable();
            dt = BL.GetPersonelList();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    RadTreeNode node = new RadTreeNode();
                    string Id = dt.Rows[i]["Id"].ToString();
                    string name = dt.Rows[i]["Name"].ToString();
                    string family = dt.Rows[i]["Family"].ToString();
                    byte[] UserImageData;
                    Image UserImage = null;
                    if (dt.Rows[0]["Image"] != DBNull.Value)
                    {
                        UserImageData = (byte[])dt.Rows[i]["Image"];
                        MemoryStream ms = new MemoryStream(UserImageData);
                        UserImage = Image.FromStream(ms);
                    }
                    else
                    {
                        UserImage = Properties.Resources.unknown;
                    }
                    string fullname = name + " " + family;
                    node.Text = fullname;
                    node.Image = BL.GetImageFromData24(BL.imageToByteArray((UserImage)));
                    node.Value = Id;
                    trvMain.Nodes[0].Nodes.Add(node);
                    trvMain.Nodes[0].Nodes[i].ForeColor = Color.Maroon;
                    DataTable dt2 = new DataTable();
                    dt2 = BL.GetCustomerListByPersonnelId(Id);
                    if (dt2.Rows.Count > 0)
                    {
                        for(int j = 0; j < dt2.Rows.Count; j++)
                        {
                            RadTreeNode node2 = new RadTreeNode();
                            RadTreeNode node3 = new RadTreeNode();
                            RadTreeNode node4 = new RadTreeNode();
                            RadTreeNode node5 = new RadTreeNode();
                            string customerId = dt2.Rows[j]["CustomerId"].ToString();
                            string customerName = dt2.Rows[j]["CustomerName"].ToString();
                            string projectId = dt2.Rows[j]["ProjectId"].ToString();
                            string projectName = dt2.Rows[j]["ProjectName"].ToString();
                            string enduserName = dt2.Rows[j]["EndUserRefNo"].ToString();
                            string radmanrefNo = dt2.Rows[j]["RadmanRefNo"].ToString();
                            node2.Text = enduserName;
                            node2.Value = "";
                            node3.Text = customerName;
                            node4.Text = projectName;
                            node4.Value = projectId;
                            node5.Text = radmanrefNo;
                            trvMain.Nodes[0].Nodes[i].Nodes.Add(node2);
                            trvMain.Nodes[0].Nodes[i].Nodes[j].ForeColor = Color.DarkBlue;
                            trvMain.Nodes[0].Nodes[i].Nodes[j].Nodes.Add(node3);
                            trvMain.Nodes[0].Nodes[i].Nodes[j].Nodes[customerName].Nodes.Add(node4);
                            trvMain.Nodes[0].Nodes[i].Nodes[j].Nodes[customerName].Nodes[projectName].Nodes.Add(node5);
                        }                       
                    }
                }
            }
            }
            catch
            {

            }
        }

        private void SetListView(DataTable TagList)
        {
            try { 
            this.livTags.AllowEdit = false;
            this.livTags.AllowRemove = false;
            this.livTags.ShowCheckBoxes = true;
            this.livTags.AllowColumnReorder = true;
            this.livTags.Items.BeginUpdate();
            this.livTags.DataSource = TagList;
            this.livTags.ViewType = ListViewType.DetailsView;
            this.livTags.ValueMember = "Id";

            livTags.CheckBoxesAlignment = CheckBoxesAlignment.Center;

            livTags.Columns["Id"].Visible = false;
            livTags.Columns["Tag No."].Width = 120;
            livTags.Columns["Customer"].Width = 120;
            livTags.Columns["Customer Ref No."].Width = 100;
            livTags.Columns["Radman Ref. No."].Width = 100;
            livTags.Columns["Project"].Width = 120;
            livTags.Columns["Project Ref. No."].Width = 100;
            livTags.Columns["Location"].Width = 120;
            livTags.Columns["P&ID No."].Width = 100;
            livTags.Columns["Service"].Width = 100;
            livTags.Columns["Line No."].Width = 100;
            livTags.Columns["Quantity"].Width = 50;


            this.livTags.Items.EndUpdate();
            lblTagsCount.Text = TagList.Rows.Count.ToString();
            lblTagsCount.ForeColor = Color.Maroon;
            FillDropDownList();
            }
            catch
            {

            }

        }

        private void livTags_CellFormatting(object sender, ListViewCellFormattingEventArgs e)
        {
            try { 
            if (e.CellElement.Text != null)
            {
                e.CellElement.TextAlignment = ContentAlignment.MiddleCenter;
                e.CellElement.ForeColor = Color.Navy;
            }
            if (e.CellElement is DetailListViewHeaderCellElement)
            {
                e.CellElement.ForeColor = Color.Red;
            }
            }
            catch
            {

            }

        }

        private void FillDropDownList()
        {
            try { 
            tcmSort.Items.Add("None");
            tcmSort.Items.Add("Tag No.");
            //tcmSort.Items.Add("Customer");
            //tcmSort.Items.Add("Customer Ref No.");
            //tcmSort.Items.Add("Radman Ref. No.");
            //tcmSort.Items.Add("Project");
            //tcmSort.Items.Add("Project Ref. No.");
            tcmSort.Items.Add("Location");
            tcmSort.Items.Add("P&ID No.");
            tcmSort.Items.Add("Service");
            tcmSort.Items.Add("Line No.");
            tcmSort.Items.Add("Quantity");

            tcmGroup.Items.Add("None");
            tcmGroup.Items.Add("Tag No.");
           // tcmGroup.Items.Add("Customer");
           // tcmGroup.Items.Add("Customer Ref No.");
           // tcmGroup.Items.Add("Radman Ref. No.");
            //tcmGroup.Items.Add("Project");
           // tcmGroup.Items.Add("Project Ref. No.");
            tcmGroup.Items.Add("Location");
            tcmGroup.Items.Add("P&ID No.");
            tcmGroup.Items.Add("Service");
            tcmGroup.Items.Add("Line No.");
            tcmGroup.Items.Add("Quantity");


            tcmSort.SelectedIndex = 0;
            tcmGroup.SelectedIndex = 0;
            }
            catch
            {

            }
        }

        private void tcmGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { 
            this.livTags.GroupDescriptors.Clear();
            switch (this.tcmGroup.SelectedIndex)
            {
                case 0:
                    this.livTags.EnableGrouping = false;
                    this.livTags.ShowGroups = false;
                    break;
                case 1:
                    this.livTags.GroupDescriptors.Add(new GroupDescriptor(
                        new SortDescriptor[] { new SortDescriptor("Tag No.", ListSortDirection.Ascending) }));
                    this.livTags.EnableGrouping = true;
                    this.livTags.ShowGroups = true;
                    break;
                case 2:
                    this.livTags.GroupDescriptors.Add(new GroupDescriptor(
                        new SortDescriptor[] { new SortDescriptor("Customer", ListSortDirection.Ascending) }));
                    this.livTags.EnableGrouping = true;
                    this.livTags.ShowGroups = true;
                    break;
                case 3:
                    this.livTags.GroupDescriptors.Add(new GroupDescriptor(
                        new SortDescriptor[] { new SortDescriptor("Customer Ref No.", ListSortDirection.Ascending) }));
                    this.livTags.EnableGrouping = true;
                    this.livTags.ShowGroups = true;
                    break;
                case 4:
                    this.livTags.GroupDescriptors.Add(new GroupDescriptor(
                        new SortDescriptor[] { new SortDescriptor("Radman Ref. No.", ListSortDirection.Ascending) }));
                    this.livTags.EnableGrouping = true;
                    this.livTags.ShowGroups = true;
                    break;
                case 5:
                    this.livTags.GroupDescriptors.Add(new GroupDescriptor(
                        new SortDescriptor[] { new SortDescriptor("Project", ListSortDirection.Ascending) }));
                    this.livTags.EnableGrouping = true;
                    this.livTags.ShowGroups = true;
                    break;
                case 6:
                    this.livTags.GroupDescriptors.Add(new GroupDescriptor(
                       new SortDescriptor[] { new SortDescriptor("Project Ref. No.", ListSortDirection.Ascending) }));
                    this.livTags.EnableGrouping = true;
                    this.livTags.ShowGroups = true;
                    break;
                case 7:
                    this.livTags.GroupDescriptors.Add(new GroupDescriptor(
                       new SortDescriptor[] { new SortDescriptor("Location", ListSortDirection.Ascending) }));
                    this.livTags.EnableGrouping = true;
                    this.livTags.ShowGroups = true;
                    break;
                case 8:
                    this.livTags.GroupDescriptors.Add(new GroupDescriptor(
                       new SortDescriptor[] { new SortDescriptor("P&ID No.", ListSortDirection.Ascending) }));
                    this.livTags.EnableGrouping = true;
                    this.livTags.ShowGroups = true;
                    break;
                case 9:
                    this.livTags.GroupDescriptors.Add(new GroupDescriptor(
                       new SortDescriptor[] { new SortDescriptor("Service", ListSortDirection.Ascending) }));
                    this.livTags.EnableGrouping = true;
                    this.livTags.ShowGroups = true;
                    break;
                case 10:
                    this.livTags.GroupDescriptors.Add(new GroupDescriptor(
                       new SortDescriptor[] { new SortDescriptor("Line No.", ListSortDirection.Ascending) }));
                    this.livTags.EnableGrouping = true;
                    this.livTags.ShowGroups = true;
                    break;
                case 11:
                    this.livTags.GroupDescriptors.Add(new GroupDescriptor(
                       new SortDescriptor[] { new SortDescriptor("Quantity", ListSortDirection.Ascending) }));
                    this.livTags.EnableGrouping = true;
                    this.livTags.ShowGroups = true;
                    break;
            }
            }
            catch
            {

            }
        }

        private void tcmSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { 
            this.livTags.SortDescriptors.Clear();
            switch (this.tcmSort.SelectedIndex)
            {
                case 0:
                    this.livTags.EnableSorting = false;
                    this.livTags.ShowGroups = false;
                    break;
                case 1:
                    this.livTags.SortDescriptors.Add(new SortDescriptor("Tag No.", ListSortDirection.Ascending));
                    this.livTags.EnableSorting = true;
                    break;
                case 2:
                    this.livTags.SortDescriptors.Add(new SortDescriptor("Customer", ListSortDirection.Ascending));
                    this.livTags.EnableSorting = true;
                    break;
                case 3:
                    this.livTags.SortDescriptors.Add(new SortDescriptor("Customer Ref No.", ListSortDirection.Ascending));
                    this.livTags.EnableSorting = true;
                    break;
                case 4:
                    this.livTags.SortDescriptors.Add(new SortDescriptor("Radman Ref. No.", ListSortDirection.Ascending));
                    this.livTags.EnableSorting = true;
                    break;
                case 5:
                    this.livTags.SortDescriptors.Add(new SortDescriptor("Project", ListSortDirection.Ascending));
                    this.livTags.EnableSorting = true;
                    break;
                case 6:
                    this.livTags.SortDescriptors.Add(new SortDescriptor("Project Ref. No.", ListSortDirection.Ascending));
                    this.livTags.EnableSorting = true;
                    break;
                case 7:
                    this.livTags.SortDescriptors.Add(new SortDescriptor("Location", ListSortDirection.Ascending));
                    this.livTags.EnableSorting = true;
                    break;
                case 8:
                    this.livTags.SortDescriptors.Add(new SortDescriptor("P&ID No.", ListSortDirection.Ascending));
                    this.livTags.EnableSorting = true;
                    break;
                case 9:
                    this.livTags.SortDescriptors.Add(new SortDescriptor("Service", ListSortDirection.Ascending));
                    this.livTags.EnableSorting = true;
                    break;
                case 10:
                    this.livTags.SortDescriptors.Add(new SortDescriptor("Line No.", ListSortDirection.Ascending));
                    this.livTags.EnableSorting = true;
                    break;
                case 11:
                    this.livTags.SortDescriptors.Add(new SortDescriptor("Quantity", ListSortDirection.Ascending));
                    this.livTags.EnableSorting = true;
                    break;
            }
            }
            catch
            {

            }
        }

        private void txbSearch_TextChanged(object sender, EventArgs e)
        {
            try { 
            this.livTags.FilterDescriptors.Clear();

            if (String.IsNullOrEmpty(this.txbSearch.Text))
            {
                this.livTags.EnableFiltering = false;
            }
            else
            {
                this.livTags.FilterDescriptors.LogicalOperator = FilterLogicalOperator.Or;
                this.livTags.FilterDescriptors.Add("Tag No.", FilterOperator.Contains, this.txbSearch.Text);
                this.livTags.FilterDescriptors.Add("Customer", FilterOperator.Contains, this.txbSearch.Text);
                this.livTags.FilterDescriptors.Add("Customer Ref No.", FilterOperator.Contains, this.txbSearch.Text);
                this.livTags.FilterDescriptors.Add("Radman Ref. No.", FilterOperator.Contains, this.txbSearch.Text);
                this.livTags.FilterDescriptors.Add("Project", FilterOperator.Contains, this.txbSearch.Text);
                this.livTags.FilterDescriptors.Add("Project Ref. No.", FilterOperator.Contains, this.txbSearch.Text);
                this.livTags.FilterDescriptors.Add("Location", FilterOperator.Contains, this.txbSearch.Text);
                this.livTags.FilterDescriptors.Add("P&ID No.", FilterOperator.Contains, this.txbSearch.Text);
                this.livTags.FilterDescriptors.Add("Service", FilterOperator.Contains, this.txbSearch.Text);
                this.livTags.FilterDescriptors.Add("Line No.", FilterOperator.Contains, this.txbSearch.Text);
                this.livTags.FilterDescriptors.Add("Quantity", FilterOperator.Contains, this.txbSearch.Text);
                this.livTags.EnableFiltering = true;
            }
            }
            catch
            {

            }
        }

        private void cmbAllNone_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { 
            if (cmbAllNone.SelectedIndex == 0)
            {
                for(int i = 0; i < livTags.Items.Count; i++)
                {
                    if (livTags.Items[i].CheckState == ToggleState.Off)
                        livTags.Items[i].CheckState = ToggleState.On;
                                         
                }
                SelectedCount = livTags.Items.Count;
            }
            else
            {
                for (int i = 0; i < livTags.Items.Count; i++)
                {
                    if (livTags.Items[i].CheckState == ToggleState.On)
                        livTags.Items[i].CheckState = ToggleState.Off;
                }
                SelectedCount = 0;
            }
            lblTagsSelected.Text = SelectedCount.ToString();
            }
            catch
            {

            }
        }

        private void livTags_SelectedItemChanged(object sender, EventArgs e)
        {
           /* if (livTags.SelectedItem.CheckState == ToggleState.Off)
            {
                livTags.SelectedItem.CheckState = ToggleState.On;
                SelectedCount++;
                Program.SelectedProjectsIndex.Add(livTags.SelectedItem.Value.ToString());
            }           
            else if (livTags.SelectedItem.CheckState == ToggleState.On)
            {
                livTags.SelectedItem.CheckState = ToggleState.Off;
                SelectedCount--;
                string id = livTags.SelectedItem.Value.ToString();
                int index = Program.SelectedProjectsIndex.FindIndex(item => item == id);
                Program.SelectedProjectsIndex.RemoveAt(index);
            }
            lblTagsSelected.Text = SelectedCount.ToString();
            */
        }

        private void livTags_ItemMouseDoubleClick(object sender, ListViewItemEventArgs e)
        {
            try { 
            string id = e.Item.Value.ToString();
            int index = Program.ProjectList.FindIndex(item => item.TableId == id);
            if (index != -1)
            {
                //dar tab page vojud daarad
            }
            else
            {
                //dar tab page vojud nadaarad
                Program.SelectedProjectsIdTable.Add(id);               
                this.Dispose();               
            }
            }
            catch
            {

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try { 
            Program.SelectedProjectsIdTable.Clear();
            this.Dispose();
            }
            catch
            {

            }
        }
    }

}
