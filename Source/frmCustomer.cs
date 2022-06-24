using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Radman
{
    public partial class frmCustomer : Telerik.WinControls.UI.RadForm
    {
        private List<Customer> Customer_list = new List<Customer>();
        private bool update = false;
        public frmCustomer()
        {
            InitializeComponent();
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            try { 
            Icon = Properties.Resources.radman_logo_png;
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
            dt = BL.GetCustomerList();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string Id = dt.Rows[i]["Id"].ToString();
                    string Name = dt.Rows[i]["Name"].ToString();
                    string DefultRefNo = dt.Rows[i]["DefultRefNo"].ToString();
                    string Fax = dt.Rows[i]["Fax"].ToString();                   
                    string Address = dt.Rows[i]["Address"].ToString();
                    string Contact = dt.Rows[i]["Contact"].ToString();                    
                    string Email = dt.Rows[i]["Email"].ToString();
                    Customer_list.Add(new Customer(Id, Name, DefultRefNo, Contact, Fax, Email, Address));
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
            try
            {
                dgvCustomer.Columns["Check"].IsVisible = false;
                dgvCustomer.Columns["Check"].ReadOnly = true;

                dgvCustomer.Columns["Id"].IsVisible = false;
                dgvCustomer.Columns["Id"].ReadOnly = true;

                dgvCustomer.Columns["Name"].Width = 150;
                dgvCustomer.Columns["Name"].ReadOnly = true;

                dgvCustomer.Columns["DefultRefNo"].Width = 150;
                dgvCustomer.Columns["DefultRefNo"].ReadOnly = true;
                dgvCustomer.Columns["DefultRefNo"].HeaderText = "Default Ref. No.";

                dgvCustomer.Columns["Fax"].Width = 80;
                dgvCustomer.Columns["Fax"].ReadOnly = true;

                dgvCustomer.Columns["Email"].Width = 180;
                dgvCustomer.Columns["Contact"].Width = 100;
                dgvCustomer.Columns["Address"].Width = 300;

                dgvCustomer.Columns["Email"].ReadOnly = true;
                dgvCustomer.Columns["Contact"].ReadOnly = true;
                dgvCustomer.Columns["Address"].ReadOnly = true;
            }
            catch
            {

            }
        }

        private void dgvCustomer_SelectionChanged(object sender, EventArgs e)
        {
            try { 
            int selectedIndex = this.dgvCustomer.Rows.IndexOf(this.dgvCustomer.CurrentRow);
            if (selectedIndex != -1)
            {
                txbId.Text = Customer_list[selectedIndex].Id;
                txbName.Text = Customer_list[selectedIndex].Name;
                txbDefultRefNo.Text = Customer_list[selectedIndex].DefultRefNo;
                txbAddress.Text = Customer_list[selectedIndex].Address;
                txbContact.Text = Customer_list[selectedIndex].Contact;
                txbEmail.Text = Customer_list[selectedIndex].Email;
                txbFax.Text = Customer_list[selectedIndex].Fax;
                txbName.ReadOnly = false;
                txbDefultRefNo.ReadOnly = false;
                txbAddress.ReadOnly = false;
                txbContact.ReadOnly = false;
                txbEmail.ReadOnly = false;
                txbFax.ReadOnly = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnPrint.Enabled = true;
                btnAddProject.Enabled = true;
                update = true;
            }
            }
            catch
            {

            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try { 
            txbId.Text = "";
            txbName.Text = "";
            txbDefultRefNo.Text = "";
            txbAddress.Text = "";
            txbContact.Text = "";
            txbEmail.Text = "";
            txbFax.Text = "";
            txbEmail.Text = "";
           
            btnNew.Enabled = false;
            update = false;
            btnUpdate.Text = "Save";
            btnDelete.Text = "Cancel";
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnPrint.Enabled = false;
            btnAddProject.Enabled = false;
            txbName.ReadOnly = false;
            txbDefultRefNo.ReadOnly = false;
            txbAddress.ReadOnly = false;
            txbContact.ReadOnly = false;
            txbEmail.ReadOnly = false;
            txbFax.ReadOnly = false;            
            txbName.Focus();
            }
            catch
            {

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try { 
            if (update == false)
            {
                txbId.Text = "";               
                txbName.Text = "";
                txbDefultRefNo.Text = "";
                txbAddress.Text = "";
                txbContact.Text = "";
                txbEmail.Text = "";
                txbFax.Text = "";               
                btnNew.Enabled = true;
                update = true;
                btnUpdate.Text = "Update";
                btnDelete.Text = "Delete";
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnPrint.Enabled = false;
                btnAddProject.Enabled = false;
                dgvCustomer_SelectionChanged(sender, e);
            }
            else
            {
                frmShowInfo fsh = new frmShowInfo("Are you sure for deleting this Customer?", 5, "", "Yes", "No", "Warning");
                fsh.ShowDialog();
                if (fsh.DialogResult == DialogResult.OK)
                {
                    int result = BL.DeleteCustomer(txbId.Text);
                    if (result == 1)
                    {
                        Customer_list.Clear();
                        FillDataList();
                        LoadPersonelList();
                        SetDataGridViewProperties();
                        btnNew.Enabled = true;
                        btnUpdate.Text = "Update";
                        btnDelete.Text = "Delete";
                        update = true;
                        txbId.Text = "";                       
                        txbName.Text = "";
                        txbDefultRefNo.Text = "";
                        txbAddress.Text = "";
                        txbContact.Text = "";
                        txbEmail.Text = "";
                        txbFax.Text = "";
                        txbName.ReadOnly = true;
                        txbDefultRefNo.ReadOnly = true;
                        txbAddress.ReadOnly = true;
                        txbContact.ReadOnly = true;
                        txbEmail.ReadOnly = true;
                        txbFax.ReadOnly = true;
                        dgvCustomer_SelectionChanged(sender, e);
                    }
                }
            }
            }
            catch
            {

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try { 
            if (update == true)
            {
                if (txbName.Text != "")
                {

                    int result = BL.UpdateCustomer(txbId.Text, txbName.Text, txbDefultRefNo.Text,txbFax.Text, txbAddress.Text, txbContact.Text,txbEmail.Text);
                    if (result == 1)
                    {
                        Customer_list.Clear();
                        FillDataList();
                        LoadPersonelList();
                        SetDataGridViewProperties();
                        btnNew.Enabled = true;
                        btnUpdate.Text = "Update";
                        btnDelete.Text = "Delete";
                        update = true;
                        dgvCustomer_SelectionChanged(sender, e);
                    }
                }
                else
                {
                    frmShowInfo fshi = new frmShowInfo("Name must be entered", 2, "", "Ok", "", "Error");
                    fshi.ShowDialog();
                    txbName.Focus();                   
                }
            }
            else
            {
                if (txbName.Text != "")
                {

                    int result = BL.InsertCustomer(txbName.Text, txbDefultRefNo.Text, txbFax.Text, txbAddress.Text, txbContact.Text, txbEmail.Text);
                    if (result == 1)
                    {
                        Customer_list.Clear();
                        FillDataList();
                        LoadPersonelList();
                        SetDataGridViewProperties();
                        btnNew.Enabled = true;
                        btnUpdate.Text = "Update";
                        btnDelete.Text = "Delete";
                        update = true;
                        dgvCustomer_SelectionChanged(sender, e);
                    }
                }
                else
                {
                    frmShowInfo fshi = new frmShowInfo("Name must be entered", 2, "", "Ok", "", "Error");
                    fshi.ShowDialog();
                    txbName.Focus();
                   
                }
            }
            }
            catch
            {

            }
        }

        private void txbAddress_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
