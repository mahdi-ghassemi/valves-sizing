using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using Telerik.WinControls.UI;

namespace Radman
{
    public partial class frmNewTag : Telerik.WinControls.UI.RadForm
    {
        private bool newClick = false;   
        public int ProjectId { get; set; }

        private List<ProjectHeader> Project_List = new List<ProjectHeader>();
        public frmNewTag(string Title)
        {
            InitializeComponent();          
            this.Text = Title;
            newClick = true;
        }

        public frmNewTag(int Project_Id,string Tag_No, string ProjectName,string Project_Ref, string Client,
                         string End_User_Ref, string RadmanRef,string Location, string PID_No,
                         string Service, string Line_No,string Quantity, Telerik.WinControls.UI.RadGridView NewFields)
        {
            InitializeComponent();
            newClick = false;
            ProjectId = Project_Id;
            txbCustomer.Text = Client;
            txbCustomerRefNo.Text = End_User_Ref;
            txbRadmanRefNo.Text = RadmanRef;
            txbProjectName.Text = ProjectName;
            txbProjectRefNo.Text = Project_Ref;
            txbLocation.Text = Location;
            txbTagNumber.Text = Tag_No;
            txbPID.Text = PID_No;
            txbService.Text = Service;
            txbLineNumber.Text = Line_No;
            txbQuantity.Text = Quantity;
            grvNewField.DataSource = NewFields.DataSource;
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;           
        }   

      

       

        private void btnOk_Click(object sender, EventArgs e)
        {
            try { 
            string table_id = BL.IsTagExist(txbTagNumber.Text.Trim());
            int index2 = Program.ProjectList.FindIndex(item => item.Tag_No == txbTagNumber.Text.Trim());
            if(index2 != -1)
            {
                frmShowInfo info = new frmShowInfo("Tag Number is already exist.Please enter correct Tag Number",
                                                                   2, "", "OK", "", "Error");
                DialogResult dr = info.ShowDialog();
                if (dr == DialogResult.OK)
                    txbTagNumber.Focus();
            }
            else if(txbTagNumber.Text.Trim() == "")
            {
                frmShowInfo info = new frmShowInfo("Tag Number is empty.Please enter a Tag Number",
                                                   2, "", "OK", "", "Error");
                DialogResult dr = info.ShowDialog();
                if (dr == DialogResult.OK)
                    txbTagNumber.Focus();
            }
            else if (table_id == "0" && newClick == true)
            {
                int project_id = Program.ProjectList.Count + 1;
                Project new_project = new Project();
                new_project.Id = project_id;
                ProjectId = project_id;
                new_project.Tag_No = txbTagNumber.Text.Trim();
                new_project.Client = txbCustomer.Text;
                new_project.PID_No = txbPID.Text.Trim();
                new_project.Service = txbService.Text.Trim();
                new_project.Line_No = txbLineNumber.Text.Trim();
                new_project.Quantity = txbQuantity.Text.Trim();
                new_project.Project_Ref = txbProjectRefNo.Text.Trim();
                new_project.ProjectName = txbProjectName.Text;
                new_project.RadmanRef = txbRadmanRefNo.Text.Trim();
                new_project.Location = txbLocation.Text.Trim();
                new_project.End_User_Ref = txbCustomerRefNo.Text.Trim();
                new_project.NewFields = grvNewField;
                new_project.IsQuickProject = false;
                new_project.Saved = false;
                new_project.Current_TabPage_Name = "pageCalculationType";
                Program.ProjectList.Add(new_project);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else if (newClick == false)
            {
                int index = Program.ProjectList.FindIndex(item => item.Id == ProjectId);
                Program.ProjectList[index].Tag_No = txbTagNumber.Text.Trim();
                Program.ProjectList[index].Client = txbCustomer.Text;
                Program.ProjectList[index].PID_No = txbPID.Text.Trim();
                Program.ProjectList[index].Service = txbService.Text.Trim();
                Program.ProjectList[index].Line_No = txbLineNumber.Text.Trim();
                Program.ProjectList[index].Quantity = txbQuantity.Text.Trim();
                Program.ProjectList[index].Project_Ref = txbProjectRefNo.Text.Trim();
                Program.ProjectList[index].ProjectName = txbProjectName.Text;
                Program.ProjectList[index].RadmanRef = txbRadmanRefNo.Text.Trim();
                Program.ProjectList[index].Location = txbLocation.Text.Trim();
                Program.ProjectList[index].End_User_Ref = txbCustomerRefNo.Text.Trim();
                Program.ProjectList[index].NewFields = grvNewField;
                if (txbRadmanRefNo.Text == "")
                    Program.ProjectList[index].IsQuickProject = true;
                else
                    Program.ProjectList[index].IsQuickProject = false;
                Program.ProjectList[index].Saved = false;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else if (table_id != "0" && newClick == true)
            {
                frmShowInfo info = new frmShowInfo("Tag Number is already exist.Please enter correct Tag Number",
                                                   2, "", "OK", "", "Error");
                DialogResult dr = info.ShowDialog();
                if (dr == DialogResult.OK)
                    txbTagNumber.Focus();
            }
            }
            catch
            {

            }

        }

        private void frmNewTag_Load(object sender, EventArgs e)
        {
            try { 
            grvNewField.EnableGrouping = false;
            FillProjects();
            int index = Program.ProjectList.FindIndex(item => item.Id == ProjectId);
            if (index != -1)
            {
                if (Program.ProjectList[index].IsQuickProject == true)
                {
                    btnOk.Enabled = true;
                }
            }
            }
            catch
            {

            }

        }

        private void FillProjects()
        {
            try { 
            DataTable dt = new DataTable();
            dt = BL.GetProjectHeaderList();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
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

                    Project_List.Add(new ProjectHeader(Id, Name, CustomerName, ProjectRefNo, CustomerRefNo, ContactPerson, ContactNo,
                                     RadmanRefNo, EndUserName, Location, CustomerId, null, EnduserNameId, RadmanNote, ProjectNote, CustomerNote));
                    RadListDataItem item = new RadListDataItem();
                    item.Text = Name;
                    item.Value = Id;
                    //cmbProjects.Items.Add(item);
                    
                }

            }
            }
            catch
            {

            }
        }       

        private void txbQuantity_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            try { 
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) //&& (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            }
            catch
            {

            }

        }

        private void cmbCustomer_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
           // int selectIndex = cmbCustomer.Items.IndexOf(cmbCustomer.SelectedItem.Text);
           // if (selectIndex != -1)
           //     txbEndUserRef.Text = Customer_list[selectIndex].DefultRefNo;
        }

        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            frmCustomer fc = new frmCustomer();
            fc.ShowDialog();
        }
    

        private void txbRadmanRefNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try { 
            btnOk.Enabled = false;
            if(e.KeyChar == (char)13)
            {
                DataTable dt = new DataTable();
                dt = BL.GetProjectHeaderByRadmanRefNo(txbRadmanRefNo.Text.Trim());
                if(dt.Rows.Count == 1)
                {
                    txbProjectName.Text = dt.Rows[0]["Name"].ToString();
                    txbProjectRefNo.Text = dt.Rows[0]["ProjectRefNo"].ToString();
                    txbLocation.Text = dt.Rows[0]["Location"].ToString();
                    txbCustomer.Text = dt.Rows[0]["CustomerName"].ToString();
                    txbCustomerRefNo.Text = dt.Rows[0]["CustomerRefNo"].ToString();
                    btnOk.Enabled = true;
                    txbTagNumber.Focus();
                }
                else
                {
                    frmShowInfo fsh = new frmShowInfo("Radman Ref. No. is wrong.Please enter correct number.", 2, "", "Ok", "", "Error");
                    fsh.ShowDialog();
                    btnOk.Enabled = false;
                    txbRadmanRefNo.Focus();

                }
            }
            }
            catch
            {

            }
        }
    }
    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
