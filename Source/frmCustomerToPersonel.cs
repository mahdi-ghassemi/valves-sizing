using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Radman
{
    public partial class frmCustomerToPersonel : Telerik.WinControls.UI.RadForm
    {
        private List<Customer> Customer_list = new List<Customer>();
        private string personelId;
        private string personelFullName;
        private string action;
        public frmCustomerToPersonel(string PersonelId,string PersonelName,string PersonelFamily,string Action)
        {
            InitializeComponent();
            personelId = PersonelId;
            personelFullName = PersonelName + " " + PersonelFamily;
            action = Action;
        }

        private void frmCustomerToPersonel_Load(object sender, EventArgs e)
        {
            try { 
            Icon = Properties.Resources.radman_logo_png;

            if (action == "Add")
            {
                this.Text = "Adding Customers to " + personelFullName;
                btnAdd.Text = "Add";
            }
            else if (action == "Remove")
            {
                this.Text = "Removing Customers from " + personelFullName;
                btnAdd.Text = "Remove";
            }

            FillDataList();
            LoadPersonelList();
            SetDataGridViewProperties();
            }
            catch
            {

            }
        }
        private void FillDataList()
        {
            try { 
            DataTable dt = new DataTable();
            if (action == "Add")
                dt = BL.GetCustomerListNoAddToThisPersonel(personelId);
            else if (action == "Remove")
                dt = BL.GetCustomerListForThisPersonel(personelId);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string Id = dt.Rows[i]["Id"].ToString();
                    string Name = dt.Rows[i]["Name"].ToString();
                    string DefultRefNo = dt.Rows[i]["DefultRefNo"].ToString();                   
                    Customer_list.Add(new Customer(false,Id, Name, DefultRefNo, "", "", "", ""));
                }
            }
            }
            catch
            {

            }
        }

        private void LoadPersonelList()
        {
            try { 
            this.dgvCustomer.TableElement.BeginUpdate();
            dgvCustomer.DataSource = null;
            dgvCustomer.DataSource = Customer_list;
            this.dgvCustomer.TableElement.EndUpdate(true);
            dgvCustomer.Refresh();
            }
            catch
            {

            }
        }

        private void SetDataGridViewProperties()
        {
            try { 
            dgvCustomer.Columns["Id"].IsVisible = false;
            dgvCustomer.Columns["Id"].ReadOnly = true;

            dgvCustomer.Columns["Name"].Width =360;
            dgvCustomer.Columns["Name"].ReadOnly = true;

            dgvCustomer.Columns["DefultRefNo"].Width = 150;
            dgvCustomer.Columns["DefultRefNo"].ReadOnly = true;
            dgvCustomer.Columns["DefultRefNo"].HeaderText = "Default Ref. No.";

            dgvCustomer.Columns["Fax"].IsVisible = false;
            dgvCustomer.Columns["Email"].IsVisible = false;
            dgvCustomer.Columns["Contact"].IsVisible = false;
            dgvCustomer.Columns["Address"].IsVisible = false;
            }
            catch
            {

            }
        }

        private void dgvCustomer_SelectionChanged(object sender, EventArgs e)
        {
            try { 
            int selectedIndex = this.dgvCustomer.Rows.IndexOf(this.dgvCustomer.CurrentRow);
            if(selectedIndex != -1)
            {
               
            }
            }
            catch
            {

            }
        }

        private void dgvCustomer_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    if ((bool)e.Value == true)
                        dgvCustomer.Rows[e.RowIndex].Cells[0].Value = false;
                    else if ((bool)e.Value == false)
                        dgvCustomer.Rows[e.RowIndex].Cells[0].Value = true;

                }            
            }
            catch
            {

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try { 
            if (action == "Add")
                DoAdd();
            else if (action == "Remove")
                DoRemove();
            }
            catch
            {

            }

        }

        private void DoAdd()
        {
            try { 
            int result = 0;
            int rowCount = 0;
            foreach (GridViewRowInfo row in dgvCustomer.Rows)
            {
                if ((bool)row.Cells[0].Value == true)
                {
                    rowCount++;
                    string cust_id = row.Cells["Id"].Value.ToString();
                    result = BL.InsertPersonelToCustomer(personelId, cust_id);
                    if (result == 0)
                        break;
                }
            }
            if (rowCount == 0)
            {
                frmShowInfo fsi = new frmShowInfo("At least one customer must be select", 2, "", "Ok", "", "Error");
                fsi.ShowDialog();
                return;
            }
            if (result == 1)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            }
            catch
            {

            }
        }

        private void DoRemove()
        {
            try { 
            int result = 0;
            int rowCount = 0;
            foreach (GridViewRowInfo row in dgvCustomer.Rows)
            {
                if ((bool)row.Cells[0].Value == true)
                {
                    rowCount++;
                    string cust_id = row.Cells["Id"].Value.ToString();
                    result = BL.DeletePersonelFromCustomer(personelId, cust_id);
                    if (result == 0)
                        break;
                }
            }
            if (rowCount == 0)
            {
                frmShowInfo fsi = new frmShowInfo("At least one customer must be select", 2, "", "Ok", "", "Error");
                fsi.ShowDialog();
                return;
            }
            if (result == 1)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            }
            catch
            {

            }
        }
    }
}
