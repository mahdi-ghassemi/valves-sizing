using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Radman
{
    public partial class frmPersonel : Telerik.WinControls.UI.RadForm
    {
        private List<Personel> personel_list = new List<Personel>();
        private DataTable CustomerTable = new DataTable();

        private bool update = false;        
        public frmPersonel()
        {
            InitializeComponent();
            this.dgvPersonel.TableElement.RowHeight = 64;
        }

        private void frmPersonel_Load(object sender, EventArgs e)
        {
            try { 
            this.Icon = Properties.Resources.radman_logo_png;
            CreateCustomerTable();
            FillDataList();
            LoadPersonelList();
            SetDataGridViewProperties();            
            SetCustomerTable();
            }
            catch
            {

            }
        }

        private void CreateCustomerTable()
        {
            try { 
            CustomerTable.Columns.Add("radif");
            CustomerTable.Columns.Add("Name");
            CustomerTable.Columns.Add("DefultRefNo");
            CustomerTable.Columns.Add("Id");
            CustomerTable.Columns.Add("PersonelId");
            }
            catch
            {

            }
        }

        private void FillDataList()
        {
            try { 
            DataTable dt = new DataTable();
            dt = BL.GetPersonelList();
            CustomerTable.Rows.Clear();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string Id = dt.Rows[i]["Id"].ToString();
                    GetCustomers(Id);
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
                    personel_list.Add(new Personel(UserImage, Id, Name, Family, JobTitle, InternalCode, PersonelCode,
                                      Username, Email, Gender, Contact, Address));
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
            this.dgvPersonel.TableElement.BeginUpdate();
            dgvPersonel.DataSource = null;
            dgvPersonel.DataSource = personel_list;
            this.dgvPersonel.TableElement.EndUpdate(true);
            dgvPersonel.Refresh();
            }
            catch
            {

            }
        }

        private void SetDataGridViewProperties()
        {
            try { 
            dgvPersonel.Columns["UserImage"].HeaderText = "Photo";
            dgvPersonel.Columns["UserImage"].ImageLayout = ImageLayout.Stretch;
            dgvPersonel.Columns["UserImage"].Width = 64;
            dgvPersonel.Columns["UserImage"].ReadOnly = true;

            dgvPersonel.Columns["Id"].IsVisible = false;
            dgvPersonel.Columns["Id"].ReadOnly = true;

            dgvPersonel.Columns["Name"].Width = 80;
            dgvPersonel.Columns["Name"].ReadOnly = true;

            dgvPersonel.Columns["Family"].Width = 80;
            dgvPersonel.Columns["Family"].ReadOnly = true;

            dgvPersonel.Columns["Username"].Width = 100;
            dgvPersonel.Columns["Username"].TextAlignment = ContentAlignment.MiddleCenter;
            dgvPersonel.Columns["Username"].ReadOnly = true;
            dgvPersonel.Columns["Username"].HeaderText = "Username";

            dgvPersonel.Columns["JobTitle"].Width = 100;
            dgvPersonel.Columns["JobTitle"].HeaderText = "Job Title";
            dgvPersonel.Columns["JobTitle"].ReadOnly = true;

            dgvPersonel.Columns["PersonelCode"].Width = 100;
            dgvPersonel.Columns["PersonelCode"].HeaderText = "Personely Code";
            dgvPersonel.Columns["PersonelCode"].TextAlignment = ContentAlignment.MiddleCenter;
            dgvPersonel.Columns["PersonelCode"].ReadOnly = true;

            dgvPersonel.Columns["Gender"].Width = 50;
            dgvPersonel.Columns["Gender"].TextAlignment = ContentAlignment.MiddleCenter;
            dgvPersonel.Columns["Gender"].ReadOnly = true;

            dgvPersonel.Columns["InternalCode"].Width = 80;
            dgvPersonel.Columns["InternalCode"].HeaderText = "Internal No.";
            dgvPersonel.Columns["InternalCode"].TextAlignment = ContentAlignment.MiddleCenter;
            dgvPersonel.Columns["InternalCode"].ReadOnly = true;

            dgvPersonel.Columns["Email"].Width = 180;
            dgvPersonel.Columns["Contact"].Width = 100;
            dgvPersonel.Columns["Address"].Width = 300;

            dgvPersonel.Columns["Email"].ReadOnly = true;
            dgvPersonel.Columns["Contact"].ReadOnly = true;
            dgvPersonel.Columns["Address"].ReadOnly = true;
            }
            catch
            {

            }
        }

        private void SetCustomerTable()
        {
            try { 
            GridViewTemplate template = new GridViewTemplate();
            template.DataSource = CustomerTable;
            //radif, Name,refno, Id, PersonelId
            template.Columns["Id"].IsVisible = false;
            template.Columns["PersonelId"].IsVisible = false;
            template.Columns["radif"].HeaderText = "#";
            template.Columns["Name"].HeaderText = "Customers for This Personel";
            template.Columns["DefultRefNo"].HeaderText = "Defult Ref. No."; 

            template.Columns["radif"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            template.Columns["Name"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            template.Columns["DefultRefNo"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            template.Columns["radif"].TextAlignment = ContentAlignment.MiddleCenter;
            

            template.ReadOnly = true;
            template.AllowAddNewRow = false;
            template.AllowDeleteRow = false;
            template.AllowEditRow = false;

            template.Columns["radif"].Width = 20;
            template.Columns["Name"].Width = 360;
            template.Columns["DefultRefNo"].Width = 150;           

            template.AllowDragToGroup = false;
            dgvPersonel.MasterTemplate.Templates.Add(template);
            
            GridViewRelation relation = new GridViewRelation(dgvPersonel.MasterTemplate);
            relation.ChildTemplate = template;
            relation.RelationName = "InReport";
            relation.ParentColumnNames.Add("Id");
            relation.ChildColumnNames.Add("PersonelId");
            dgvPersonel.Relations.Add(relation);
            }
            catch
            {

            }

        }

        private void GetCustomers(string PersonelId)
        {
            try { 
            DataTable dt = new DataTable();
            dt = BL.GetCustomerListForThisPersonel(PersonelId);
            
            if (dt.Rows.Count > 0)
            {                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string id = dt.Rows[i]["Id"].ToString();
                    string radif = (i + 1).ToString();
                    string name = dt.Rows[i]["Name"].ToString();
                    string refno = dt.Rows[i]["DefultRefNo"].ToString();                    
                             
                    CustomerTable.Rows.Add(radif, name, refno, id, PersonelId);
                }

            }
            }
            catch
            {

            }
        }
        private void dgvPersonel_SelectionChanged(object sender, EventArgs e)
        {
            try { 
            int selectedIndex = this.dgvPersonel.Rows.IndexOf(this.dgvPersonel.CurrentRow);
            if (selectedIndex != -1)
            {
                txbId.Text = personel_list[selectedIndex].Id;
                pibPersonelImage.Image = personel_list[selectedIndex].UserImage;
                txbName.Text = personel_list[selectedIndex].Name;
                txbFamily.Text = personel_list[selectedIndex].Family;
                txbAddress.Text = personel_list[selectedIndex].Address;
                txbContact.Text = personel_list[selectedIndex].Contact;
                txbEmail.Text = personel_list[selectedIndex].Email;
                txbInternalNo.Text = personel_list[selectedIndex].InternalCode;
                txbJobTitle.Text = personel_list[selectedIndex].JobTitle;
                txbPersonelyCode.Text = personel_list[selectedIndex].PersonelCode;
                cmbGender.SelectedIndex = cmbGender.Items.IndexOf(personel_list[selectedIndex].Gender);
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnPrint.Enabled = true;
                btnAddCustomer.Enabled = true;
                btnRemoveCustomer.Enabled = true;
                btnSelectPic.Enabled = true;
                txbName.ReadOnly = false;
                txbFamily.ReadOnly = false;
                txbAddress.ReadOnly = false;
                txbContact.ReadOnly = false;
                txbEmail.ReadOnly = false;
                txbInternalNo.ReadOnly = false;
                txbJobTitle.ReadOnly = false;
                txbPersonelyCode.ReadOnly = false;
                cmbGender.ReadOnly = false;
                update = true;
            }
            }
            catch
            {

            }
        }

        private void btnSelectPic_Click(object sender, EventArgs e)
        {
            try { 
            //Ask user to select file.
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.AutoUpgradeEnabled = false;
            dlg.Title = "Select a picture";
            dlg.Filter = "Image File|*.jpg";
            DialogResult dlgRes = new System.Windows.Forms.DialogResult();
            dlgRes = dlg.ShowDialog();
            if (dlgRes != DialogResult.Cancel)
            {
                FileInfo fi = new FileInfo(dlg.FileName);
                dlg.Dispose();
                GC.Collect();
                if (fi.Length > 50000)
                {
                    frmShowInfo fm = new frmShowInfo("Picture size must be less than 50 KB", 2, "", "Ok", "", "Error");
                    fm.ShowDialog();
                    pibPersonelImage.ImageLocation = null;
                    pibPersonelImage.Image = Properties.Resources._71;
                }
                else
                    pibPersonelImage.ImageLocation = dlg.FileName; //Set image in picture box
            }
            else
            {
                pibPersonelImage.ImageLocation = null;
                //pibPersonelImage.Image = Properties.Resources._71;
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
            pibPersonelImage.Image = Properties.Resources.unknown;
            txbName.Text = "";
            txbFamily.Text = "";
            txbAddress.Text = "";
            txbContact.Text = "";
            txbEmail.Text = "";
            txbInternalNo.Text = "";
            txbJobTitle.Text = "";
            txbPersonelyCode.Text = "";
            cmbGender.SelectedIndex = 0;
            btnNew.Enabled = false;
            update = false;
            btnUpdate.Text = "Save";
            btnDelete.Text = "Cancel";
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnPrint.Enabled = false;
            btnAddCustomer.Enabled = false;
            txbName.ReadOnly = false;
            txbFamily.ReadOnly = false;
            txbAddress.ReadOnly = false;
            txbContact.ReadOnly = false;
            txbEmail.ReadOnly = false;
            txbInternalNo.ReadOnly = false;
            txbJobTitle.ReadOnly = false;
            txbPersonelyCode.ReadOnly = false;
            cmbGender.ReadOnly = false;
            btnSelectPic.Enabled = true;
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
                pibPersonelImage.Image = Properties.Resources.unknown;
                txbName.Text = "";
                txbFamily.Text = "";
                txbAddress.Text = "";
                txbContact.Text = "";
                txbEmail.Text = "";
                txbInternalNo.Text = "";
                txbJobTitle.Text = "";
                txbPersonelyCode.Text = "";
                cmbGender.SelectedIndex = 0;
                btnNew.Enabled = true;
                update = true;
                btnUpdate.Text = "Update";
                btnDelete.Text = "Delete";
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnPrint.Enabled = false;
                btnAddCustomer.Enabled = false;
                dgvPersonel_SelectionChanged(sender, e);
            }
            else
            {
                frmShowInfo fsh = new frmShowInfo("Are you sure for deleting this personel?", 5, "", "Yes", "No", "Warning");
                fsh.ShowDialog();
                if (fsh.DialogResult == DialogResult.OK)
                {
                    int result = BL.DeletePersonel(txbId.Text);
                    if (result == 1)
                    {
                        personel_list.Clear();                       
                        FillDataList();
                        LoadPersonelList();
                        SetDataGridViewProperties();                       
                        btnNew.Enabled = true;
                        btnUpdate.Text = "Update";
                        btnDelete.Text = "Delete";
                        update = true;
                        txbId.Text = "";
                        pibPersonelImage.Image = Properties.Resources.unknown;
                        txbName.Text = "";
                        txbFamily.Text = "";
                        txbAddress.Text = "";
                        txbContact.Text = "";
                        txbEmail.Text = "";
                        txbInternalNo.Text = "";
                        txbJobTitle.Text = "";
                        txbPersonelyCode.Text = "";
                        cmbGender.SelectedIndex = 0;
                        dgvPersonel_SelectionChanged(sender, e);
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
                if (txbName.Text != "" && txbFamily.Text != "")
                {

                    int result = BL.UpdatePersonel(txbId.Text, txbName.Text, txbFamily.Text, txbPersonelyCode.Text, cmbGender.SelectedIndex,
                                      txbInternalNo.Text, txbAddress.Text, txbContact.Text, txbJobTitle.Text, txbEmail.Text,
                                      pibPersonelImage.Image);
                    if(result == 1)
                    {
                        personel_list.Clear();                        
                        FillDataList();
                        LoadPersonelList();
                        SetDataGridViewProperties();
                        
                        btnNew.Enabled = true;
                        btnUpdate.Text = "Update";
                        btnDelete.Text = "Delete";
                        update = true;
                        dgvPersonel_SelectionChanged(sender, e);
                    }
                }
                else
                {
                    frmShowInfo fshi = new frmShowInfo("Name and Family must be entered", 2, "", "Ok", "", "Error");
                    fshi.ShowDialog();
                    if (txbName.Text == "")
                        txbName.Focus();
                    else
                        txbFamily.Focus();
                }
            }
            else
            {
                if (txbName.Text != "" && txbFamily.Text != "")
                {

                    int result = BL.InsertPersonel(txbName.Text, txbFamily.Text, txbPersonelyCode.Text, cmbGender.SelectedIndex,
                                      txbInternalNo.Text, txbAddress.Text, txbContact.Text, txbJobTitle.Text, txbEmail.Text,
                                      pibPersonelImage.Image);
                    if (result == 1)
                    {
                        personel_list.Clear();                        
                        FillDataList();
                        LoadPersonelList();
                        SetDataGridViewProperties();                        
                        btnNew.Enabled = true;
                        btnUpdate.Text = "Update";
                        btnDelete.Text = "Delete";
                        update = true;
                        dgvPersonel_SelectionChanged(sender, e);
                    }
                }
                else
                {
                    frmShowInfo fshi = new frmShowInfo("Name and Family must be entered", 2, "", "Ok", "", "Error");
                    fshi.ShowDialog();
                    if (txbName.Text == "")
                        txbName.Focus();
                    else
                        txbFamily.Focus();
                }
            }
            }
            catch
            {

            }
        }

      
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            try { 
            frmCustomerToPersonel fctop = new frmCustomerToPersonel(txbId.Text, txbName.Text, txbFamily.Text,"Add");
            fctop.ShowDialog();
            if(fctop.DialogResult == DialogResult.OK)
            {
                personel_list.Clear();
                FillDataList();
                LoadPersonelList();
                SetDataGridViewProperties();
            }
            }
            catch
            {

            }
        }

        private void btnRemoveCustomer_Click(object sender, EventArgs e)
        {
            try { 
            frmCustomerToPersonel fctop = new frmCustomerToPersonel(txbId.Text, txbName.Text, txbFamily.Text, "Remove");
            fctop.ShowDialog();
            if (fctop.DialogResult == DialogResult.OK)
            {
                personel_list.Clear();
                FillDataList();
                LoadPersonelList();
                SetDataGridViewProperties();
            }
            }
            catch
            {

            }
        }
    }
   
}
