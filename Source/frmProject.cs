using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Radman
{
    public partial class frmProject : Telerik.WinControls.UI.RadForm
    {
        private List<Customer> Customer_list = new List<Customer>();
        private List<Personel> Personel_list = new List<Personel>();
        private List<ProjectHeader> Project_list = new List<ProjectHeader>();
        
        private DataTable PersonelTable = new DataTable();
        private bool update = false;

        public frmProject()
        {
            InitializeComponent();
        }

        private void frmProject_Load(object sender, EventArgs e)
        {
            try { 
            Icon = Properties.Resources.radman_logo_png;
            FillCustomerList();
            FillPersonelList();
            FillDataList();
            LoadProjectList();
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
            dt = BL.GetProjectHeaderList();
            PersonelTable.Rows.Clear();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    List<Personel> Personel_list_by_Project = new List<Personel>();
                    string Id = dt.Rows[i]["Id"].ToString();                    
                    string Name = dt.Rows[i]["Name"].ToString();
                    string ProjectRefNo = dt.Rows[i]["ProjectRefNo"].ToString();
                    string CustomerRefNo = dt.Rows[i]["CustomerRefNo"].ToString();
                    string CustomerId = dt.Rows[i]["CustomerId"].ToString();                    
                    string EndUserName = dt.Rows[i]["EndUserRefNo"].ToString();
                    string ContactNo = dt.Rows[i]["ContactNo"].ToString();
                    string ContactPerson = dt.Rows[i]["ContactPerson"].ToString();
                    string RadmanRefNo = dt.Rows[i]["RadmanRefNo"].ToString();
                    string Location = dt.Rows[i]["Location"].ToString();
                    string CustomerName = dt.Rows[i]["CustomerName"].ToString();
                    string EnduserNameId = dt.Rows[i]["EndUserNameId"].ToString();
                    string RadmanNote = dt.Rows[i]["RadmanNote"].ToString();
                    string ProjectNote = dt.Rows[i]["ProjectNote"].ToString(); 
                    string CustomerNote = dt.Rows[i]["CustomerNote"].ToString();


                    Personel_list_by_Project = BL.GetPersonelListByProjectHeaderId(Id);
                    

                    Project_list.Add(new ProjectHeader(Id, Name, CustomerName, ProjectRefNo, CustomerRefNo, ContactPerson, ContactNo,
                                      RadmanRefNo, EndUserName, Location, CustomerId, Personel_list_by_Project,
                                      EnduserNameId, RadmanNote, ProjectNote,CustomerNote));
                }
            }
            }
            catch
            {

            }
        }

        private void FillPersonelList()
        {
            try { 
            DataTable dt = new DataTable();
            dt = BL.GetPersonelList();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string Id = dt.Rows[i]["Id"].ToString();
                    string Name = dt.Rows[i]["Name"].ToString();
                    string Family = dt.Rows[i]["Family"].ToString();
                    string PersonelCode = dt.Rows[i]["PersonelyCode"].ToString();
                    string GenderId = dt.Rows[i]["Gender"].ToString();
                    string Gender = "";
                    if (GenderId == "0")
                        Gender = "Female";
                    else
                        Gender = "Male";
                    string Address = dt.Rows[i]["Address"].ToString();
                    string Contact = dt.Rows[i]["Contact"].ToString();
                    string InternalCode = dt.Rows[i]["InternalNo"].ToString();
                    string Email = dt.Rows[i]["Email"].ToString();
                    string JobTitle = dt.Rows[i]["JobTitle"].ToString();
                    string Username = "admin";
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
                    Personel_list.Add(new Personel(UserImage, Id, Name, Family, JobTitle, InternalCode, PersonelCode,
                                      Username, Email, Gender, Contact, Address));                  
                    RadCheckedListDataItem item = new RadCheckedListDataItem();
                    this.cmbPersonel.ListElement.AutoSizeItems = true;
                    item.Text = Name + " " + Family;
                    item.Value = Id;
                    item.TextImageRelation = TextImageRelation.ImageBeforeText;
                    item.Image = BL.GetImageFromData(BL.imageToByteArray((UserImage)));                   
                    cmbPersonel.Items.Add(item);
                }
                cmbPersonel.DisplayMember = Text;
            }
            }
            catch
            {

            }
        }
        private void LoadProjectList()
        {
            try { 
            this.dgvProject.TableElement.BeginUpdate();
            dgvProject.DataSource = null;
            dgvProject.DataSource = Project_list;
            this.dgvProject.TableElement.EndUpdate(true);
            dgvProject.Refresh();
            }
            catch
            {

            }
        }

        private void FillCustomerList()
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
                    RadListDataItem item = new RadListDataItem();
                    RadListDataItem item2 = new RadListDataItem();
                    item.Text = Name;
                    item.Value = Id;
                    item2.Text = Name;
                    item2.Value = Id;
                    cmbCustomer.Items.Add(item);
                    cmbEnduserName.Items.Add(item2);
                }
                cmbCustomer.DisplayMember = Text;
                cmbEnduserName.DisplayMember = Text;
            }
            }
            catch
            {

            }
        }

        private void SetDataGridViewProperties()
        {
            try { 
            dgvProject.Columns["Id"].IsVisible = false;
            dgvProject.Columns["Id"].ReadOnly = true;

            dgvProject.Columns["Name"].Width = 200;
            dgvProject.Columns["Name"].ReadOnly = true;
            dgvProject.Columns["Name"].HeaderText = "Project Name";

            dgvProject.Columns["CustomerName"].Width = 200;
            dgvProject.Columns["CustomerName"].ReadOnly = true;
            dgvProject.Columns["CustomerName"].HeaderText = "Customer Name";

            dgvProject.Columns["ProjectRefNo"].Width = 120;
            dgvProject.Columns["ProjectRefNo"].ReadOnly = true;
            dgvProject.Columns["ProjectRefNo"].TextAlignment = ContentAlignment.MiddleCenter;
            dgvProject.Columns["ProjectRefNo"].HeaderText = "Project Ref. No.";

            dgvProject.Columns["CustomerRefNo"].Width = 120;
            dgvProject.Columns["CustomerRefNo"].TextAlignment = ContentAlignment.MiddleCenter;
            dgvProject.Columns["CustomerRefNo"].ReadOnly = true;
            dgvProject.Columns["CustomerRefNo"].HeaderText = "Customer Ref. No.";

            dgvProject.Columns["ContactPerson"].Width = 100;
            dgvProject.Columns["ContactPerson"].HeaderText = "Contact Person";
            dgvProject.Columns["ContactPerson"].ReadOnly = true;

            dgvProject.Columns["ContactNo"].Width = 100;
            dgvProject.Columns["ContactNo"].HeaderText = "Contact No.";
            dgvProject.Columns["ContactNo"].TextAlignment = ContentAlignment.MiddleCenter;
            dgvProject.Columns["ContactNo"].ReadOnly = true;

            dgvProject.Columns["RadmanRefNo"].Width = 100;
            dgvProject.Columns["RadmanRefNo"].TextAlignment = ContentAlignment.MiddleCenter;
            dgvProject.Columns["RadmanRefNo"].ReadOnly = true;
            dgvProject.Columns["RadmanRefNo"].HeaderText = "Radman Ref. No.";

            dgvProject.Columns["EndUserName"].Width = 120;
            dgvProject.Columns["EndUserName"].HeaderText = "End User Name";
            dgvProject.Columns["EndUserName"].TextAlignment = ContentAlignment.MiddleCenter;
            dgvProject.Columns["EndUserName"].ReadOnly = true;

            dgvProject.Columns["Location"].Width = 120;
            dgvProject.Columns["Location"].ReadOnly = true;

            dgvProject.Columns["CustomerId"].Width = 10;
            dgvProject.Columns["CustomerId"].IsVisible = false;

            dgvProject.Columns["PersonelList"].Width = 10;
            dgvProject.Columns["PersonelList"].IsVisible = false;

            dgvProject.Columns["EnduserNameId"].Width = 10;
            dgvProject.Columns["EnduserNameId"].IsVisible = false;

            dgvProject.Columns["RadmanNote"].Width = 120;
            dgvProject.Columns["RadmanNote"].HeaderText = "Radman Note";            
            dgvProject.Columns["RadmanNote"].ReadOnly = true;

            dgvProject.Columns["ProjectNote"].Width = 120;
            dgvProject.Columns["ProjectNote"].HeaderText = "Project Note";
            dgvProject.Columns["ProjectNote"].ReadOnly = true;

            dgvProject.Columns["CustomerNote"].Width = 120;
            dgvProject.Columns["CustomerNote"].HeaderText = "Customer Note";
            dgvProject.Columns["CustomerNote"].ReadOnly = true;
            }
            catch
            {

            }

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try { 
            update = false;
            txbContact.Text = "";
            txbContactPerson.Text = "";
            txbCustomerRefNo.Text = "";            
            txbLocation.Text = "";
            txbId.Text = "";
            txbName.Text = "";
            txbProjectRefNo.Text = "";
            txbRadmanRefNo.Text = "";
            txbRadmanNote.Text = "";
            txbNoteProject.Text = "";
            txbCustomerNote.Text = "";

            txbContact.ReadOnly = false;
            txbContactPerson.ReadOnly = false;
            txbCustomerRefNo.ReadOnly = false;
            cmbEnduserName.ReadOnly = false;
            txbLocation.ReadOnly = false;
            txbId.ReadOnly = false;
            txbName.ReadOnly = false;
            txbProjectRefNo.ReadOnly = false;
            txbRadmanRefNo.ReadOnly = false;
            cmbCustomer.ReadOnly = false;
            cmbPersonel.ReadOnly = false;
            txbRadmanNote.ReadOnly = false;
            txbNoteProject.ReadOnly = false;
            txbCustomerNote.ReadOnly = false;
            btnUpdate.Text = "Save";
            btnDelete.Text = "Cancel";
            btnNew.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnPrint.Enabled = false;
            }
            catch
            {

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try { 
            if (txbName.Text == "")
            {
                erp.SetError(txbName, "Project Name must be fill");
                return;
            }
            if (cmbCustomer.SelectedItem == null)
            {
                erp.SetError(cmbCustomer, "Customer Name must be fill");
                return;
            }
            if (cmbEnduserName.SelectedItem == null)
            {
                erp.SetError(cmbEnduserName, "EndUser Name must be fill");
                return;
            }
            if (cmbPersonel.SelectedItems.Count == 0)
            {
                erp.SetError(cmbPersonel, "Personel Name must be fill");
                return;
            }
            if (!BL.IsRadmanRefNo_Unique(txbRadmanRefNo.Text.Trim()))
            {
                erp.SetError(txbRadmanRefNo, "Radman Ref. No. must be unique.");
                return;
            }
            if (update == true)
            {
                int result = BL.UpdateProjectHeader(txbId.Text, txbName.Text, txbProjectRefNo.Text, txbCustomerRefNo.Text, txbContactPerson.Text,
                                  txbContact.Text, txbLocation.Text, txbRadmanRefNo.Text,cmbEnduserName.SelectedItem.Text,cmbCustomer.SelectedItem.Value.ToString(), 
                                  cmbPersonel.SelectedItems,txbRadmanNote.Text,txbNoteProject.Text,txbCustomerNote.Text,cmbEnduserName.SelectedItem.Value.ToString());
                if (result == 1)
                {
                    Project_list.Clear();
                    FillDataList();
                    LoadProjectList();
                    SetDataGridViewProperties();

                    btnNew.Enabled = true;
                    btnUpdate.Text = "Update";
                    btnDelete.Text = "Delete";
                    update = true;
                    dgvProject_SelectionChanged(sender, e);
                }
            }
            
            else
            {
                int result = BL.InsertProjectHeader(txbName.Text, txbProjectRefNo.Text, txbCustomerRefNo.Text, txbContactPerson.Text,
                                  txbContact.Text, txbLocation.Text, txbRadmanRefNo.Text, cmbEnduserName.SelectedItem.Text, cmbCustomer.SelectedItem.Value.ToString(),
                                  cmbPersonel.CheckedItems, txbRadmanNote.Text, txbNoteProject.Text, txbCustomerNote.Text, cmbEnduserName.SelectedItem.Value.ToString());
                if (result != 0)
                {
                    Project_list.Clear();
                    FillDataList();
                    LoadProjectList();
                    SetDataGridViewProperties();
                    btnNew.Enabled = true;
                    btnUpdate.Text = "Update";
                    btnDelete.Text = "Delete";
                    update = true;
                    dgvProject_SelectionChanged(sender, e);
                }
            }
            }
            catch
            {

            }
        }
            
        private void txbName_TextChanged(object sender, EventArgs e)
        {
            erp.SetError(txbName, "");
        }

       
        private void dgvProject_SelectionChanged(object sender, EventArgs e)
        {
            try { 
            int selectedIndex = this.dgvProject.Rows.IndexOf(this.dgvProject.CurrentRow);
            if (selectedIndex != -1)
            {
                txbId.Text = Project_list[selectedIndex].Id;                
                txbName.Text = Project_list[selectedIndex].Name;
                txbProjectRefNo.Text = Project_list[selectedIndex].ProjectRefNo;
                txbCustomerRefNo.Text = Project_list[selectedIndex].CustomerRefNo;
                txbContact.Text = Project_list[selectedIndex].ContactNo;
                txbContactPerson.Text = Project_list[selectedIndex].ContactPerson;
                txbRadmanRefNo.Text = Project_list[selectedIndex].RadmanRefNo;
                cmbEnduserName.SelectedIndex = cmbEnduserName.Items.IndexOf(Project_list[selectedIndex].EndUserName); 
                txbLocation.Text = Project_list[selectedIndex].Location;
                cmbCustomer.SelectedIndex = cmbCustomer.Items.IndexOf(Project_list[selectedIndex].CustomerName);
                txbRadmanNote.Text = Project_list[selectedIndex].RadmanNote;
                txbNoteProject.Text = Project_list[selectedIndex].ProjectNote;
                txbCustomerNote.Text = Project_list[selectedIndex].CustomerNote;
                for (int m = 0; m < cmbPersonel.Items.Count; m++)               
                    cmbPersonel.Items[m].Checked = false;                   
                
                for (int i = 0;i< Project_list[selectedIndex].PersonelList.Count; i++)
                {
                    for(int j = 0;j < cmbPersonel.Items.Count; j++)
                    {                        
                        if (Project_list[selectedIndex].PersonelList[i].Id == cmbPersonel.Items[j].Value.ToString())
                        {
                            cmbPersonel.Items[j].Checked = true;                            
                            break;
                        }
                    }
                }
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnPrint.Enabled = true;
               
                txbName.ReadOnly = false;
                txbContact.ReadOnly = false;
                txbContactPerson.ReadOnly = false;
                txbCustomerRefNo.ReadOnly = false;
                cmbEnduserName.ReadOnly = false;
                txbLocation.ReadOnly = false;
                txbId.ReadOnly = false;
                txbName.ReadOnly = false;
                txbProjectRefNo.ReadOnly = false;
                txbRadmanRefNo.ReadOnly = false;
                cmbCustomer.ReadOnly = false;
                cmbPersonel.ReadOnly = false;
                txbNoteProject.ReadOnly = false;
                txbNoteProject.ReadOnly = false;
                txbCustomerNote.ReadOnly = false;
                update = true;
            }
            }
            catch
            {

            }

        }

        private void cmbCustomer_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            erp.SetError(cmbCustomer, "");
        }

        private void cmbPersonel_ItemCheckedChanged(object sender, RadCheckedListDataItemEventArgs e)
        {
            erp.SetError(cmbPersonel, "");
        }

        private void txbRadmanRefNo_TextChanged(object sender, EventArgs e)
        {
            erp.SetError(txbRadmanRefNo, "");
        }

        private void cmbEnduserName_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            erp.SetError(cmbEnduserName, "");
        }
    }

}
