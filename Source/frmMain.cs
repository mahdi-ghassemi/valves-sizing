using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;
using Telerik.WinControls.UI;

namespace Radman
{
    public partial class frmMain : Telerik.WinControls.UI.RadForm
    {
        private Thread thrFluid;
        private ThreadStart thsFluid;

        private Thread thrUnits;
        private ThreadStart thsUnits;

        private Thread thrBodyMaterials;
        private ThreadStart thsBodyMaterials;

        private int CurrentProjectSelectedId;
        private int SelectedPageIndex;

        private List<RadPageViewPage> PageList = new List<RadPageViewPage>();

        public frmMain()
        {
            InitializeComponent();
        }    

        private void frmMain_Load(object sender, EventArgs e)
        {
            try { 
            this.Icon = Properties.Resources.radman_logo_png;
            thsFluid = new ThreadStart(FillFluidList);
            thrFluid = new Thread(thsFluid);
            thrFluid.Start();

            thsUnits = new ThreadStart(FillUnitsList);
            thrUnits = new Thread(thsUnits);
            thrUnits.Start();

            thsBodyMaterials = new ThreadStart(FillBodyMaterials);
            thrBodyMaterials = new Thread(thsBodyMaterials);
            thrBodyMaterials.Start();

            Program.ProgramPath = Application.ExecutablePath;
            Program.DatabasePath = Application.StartupPath + "\\Data";
            Program.ImagesPath = Application.StartupPath + "\\Images\\";
           
            toolTip1.SetToolTip(lblQuickCalc, "Click to Start a New Quick Calculation [CTRL + Q]");
            toolTip1.SetToolTip(lblNewTag, "Click to Create New Tag [CTRL + N]");
            toolTip1.SetToolTip(lblOpenTag, "Click to Open Existing Tag [CTRL + O]");
            toolTip1.SetToolTip(lblOpenCatalog, "Click to Open Catalogs [CTRL + C]");

            mnuItemClose.Click += MnuItemClose_Click;
            mnuItemProperties.Click += MnuItemProperties_Click;
            mnuItemSave.Click += MnuItemSave_Click;
            }
            catch
            {

            }

        }

        private void FillBodyMaterials()
        {
            BL.GetBodyMaterialAll();
        }

        private void MnuItemSave_Click(object sender, EventArgs e)
        {
            try { 
            int index = Program.ProjectList.FindIndex(item => item.Id == CurrentProjectSelectedId);
            if (Program.ProjectList[index].Safety_Relief != "")
            {
                if (Program.ProjectList[index].TableId == "")
                {
                    bool isTagNumberUniq = BL.IsTagNumber_Unique(Program.ProjectList[index].Tag_No);
                    if (isTagNumberUniq)
                    {
                        int save_result = BL.SaveProjectToDatabase(index);
                        if (save_result == 1)
                        {
                            Program.ProjectList[index].Saved = true;
                        }
                    }
                    else
                    {
                        frmShowInfo fsh = new frmShowInfo("Tag Number must be Unique.Please Correct it.", 2, "", "Ok", "", "Error");
                        fsh.ShowDialog();
                    }
                }
                else
                {
                    int save_result = BL.SaveProjectToDatabase(index);
                    if (save_result == 1)
                    {
                        Program.ProjectList[index].Saved = true;
                        frmShowInfo finfo = new frmShowInfo("Project saved successfully.", 2, "", "Ok", "", "");
                        finfo.ShowDialog();
                    }
                }
            }
            }
            catch
            {

            }
        }
    

        private void MnuItemProperties_Click(object sender, EventArgs e)
        {
            try { 
            int index = Program.ProjectList.FindIndex(item => item.Id == CurrentProjectSelectedId);
            frmNewTag fnt = new frmNewTag(CurrentProjectSelectedId,Program.ProjectList[index].Tag_No, Program.ProjectList[index].ProjectName,
                                          Program.ProjectList[index].Project_Ref, Program.ProjectList[index].Client,
                                          Program.ProjectList[index].End_User_Ref, Program.ProjectList[index].RadmanRef,
                                          Program.ProjectList[index].Location, Program.ProjectList[index].PID_No,
                                          Program.ProjectList[index].Service, Program.ProjectList[index].Line_No,
                                          Program.ProjectList[index].Quantity, Program.ProjectList[index].NewFields);
            fnt.ShowDialog();
            tabPageMain.Pages[index].Text = Program.ProjectList[index].Tag_No;
            }
            catch
            {

            }
        }

        private void MnuItemClose_Click(object sender, EventArgs e)
        {
            try { 
            int index = Program.ProjectList.FindIndex(item => item.Id == CurrentProjectSelectedId);
            if (Program.ProjectList[index].Saved)
            {
                frmShowInfo info = new frmShowInfo("Are you sure?", 5, "", "Yes", "No", "");
                DialogResult dr = info.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    tabPageMain.Pages.RemoveAt(index);
                    Program.ProjectList.RemoveAt(index);
                    if (tabPageMain.Pages.Count == 0)
                    {
                        btn_Home_ts_Click(sender, e);
                    }
                }
                else
                    return;
            }
            else
            {
                string tagname = Program.ProjectList[index].Tag_No;
                frmShowInfo info2 = new frmShowInfo(tagname + " has not been saved.Do you want to save it?", 6, "Save", "Don't Save", "Cancel", "");
                DialogResult dr = info2.ShowDialog();
                if (dr == DialogResult.Yes)
                {
                    MnuItemSave_Click(sender, e);
                    if (Program.ProjectList[index].Saved)
                    {
                        frmShowInfo finfo = new frmShowInfo("Project saved successfully.", 2, "", "Ok", "", "");
                        finfo.ShowDialog();
                        tabPageMain.Pages.RemoveAt(index);
                        Program.ProjectList.RemoveAt(index);
                        if (tabPageMain.Pages.Count == 0)
                        {
                            btn_Home_ts_Click(sender, e);
                        }
                    }

                }
                else if (dr == DialogResult.OK)
                {
                    tabPageMain.Pages.RemoveAt(index);
                    Program.ProjectList.RemoveAt(index);
                    if (tabPageMain.Pages.Count == 0)
                    {
                        btn_Home_ts_Click(sender, e);
                    }
                }
                else
                    return;
            }
            }
            catch
            {

            }

        }

        private void FillFluidList()
        {
            int error = BL.GetFluidList();           
        }

        private void FillUnitsList()
        {
            BL.FillUnitsList();
        }

        private void lblQuickCalc_MouseHover(object sender, EventArgs e)
        {
            try { 
            lblQuickCalc.BackgroundImage = Properties.Resources._14;
            lblQuickCalc.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch
            {

            }
        }

        private void lblQuickCalc_MouseLeave(object sender, EventArgs e)
        {
            try { 
            lblQuickCalc.BackgroundImage = Properties.Resources._13;
            lblQuickCalc.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch
            {

            }
        }

        private void lblNewTag_MouseHover(object sender, EventArgs e)
        {
            try { 
            lblNewTag.BackgroundImage = Properties.Resources._12;
            lblNewTag.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch
            {

            }
        }

        private void lblNewTag_MouseLeave(object sender, EventArgs e)
        {
            try { 
            lblNewTag.BackgroundImage = Properties.Resources._11;
            lblNewTag.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch
            {

            }
        }

        private void lblOpenTag_MouseHover(object sender, EventArgs e)
        {
            try
            {
                lblOpenTag.BackgroundImage = Properties.Resources._10;
                lblOpenTag.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch
            {

            }

        }

        private void lblOpenTag_MouseLeave(object sender, EventArgs e)
        {
            try { 
            lblOpenTag.BackgroundImage = Properties.Resources._9;
            lblOpenTag.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch
            {

            }
        }

        private void lblOpenCatalog_MouseHover(object sender, EventArgs e)
        {
            try { 
            lblOpenCatalog.BackgroundImage = Properties.Resources._8;
            lblOpenCatalog.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch
            {

            }
        }

        private void lblOpenCatalog_MouseLeave(object sender, EventArgs e)
        {
            try { 
            lblOpenCatalog.BackgroundImage = Properties.Resources._7;
            lblOpenCatalog.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch
            {

            }
        }

        private void mnuQuickCalc_Click(object sender, EventArgs e)
        {
            lblQuickCalc_Click(sender,e);
        }

        private void lblQuickCalc_Click(object sender, EventArgs e)
        {
            btn_QuickCalc_ts_Click(sender, e);
        }

    
        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblNewTag_Click(object sender, EventArgs e)
        {
            try { 
            frmNewTag newtag = new frmNewTag("Create New Tag");
            DialogResult dr =  newtag.ShowDialog();
            if(dr == DialogResult.OK)
            {
                int project_id = newtag.ProjectId;
                int index = Program.ProjectList.FindIndex(item => item.Id == project_id);
                frmQuickCalc newQuickCalcForm = new frmQuickCalc(Program.ProjectList[index].Id, Program.ProjectList[index].Tag_No, Program.ProjectList[index].Client, Program.ProjectList[index].PID_No, Program.ProjectList[index].Service, Program.ProjectList[index].Line_No, Program.ProjectList[index].Quantity, Program.ProjectList[index].End_User_Ref, Program.ProjectList[index].Project_Ref, Program.ProjectList[index].ProjectName, Program.ProjectList[index].RadmanRef, Program.ProjectList[index].Location, Program.ProjectList[index].NewFields);
                pnlMain.SendToBack();
                tabPageMain.BringToFront();

                newQuickCalcForm.TopLevel = false;
                newQuickCalcForm.Dock = DockStyle.Fill;
                newQuickCalcForm.Tag = project_id;


                RadPageViewPage tbp = new RadPageViewPage();
                tbp.Name = Program.ProjectList[index].Tag_No;
                tbp.Text = Program.ProjectList[index].Tag_No;
                tbp.Tag = project_id;
                tabPageMain.AutoScroll = true;
                tbp.AutoScroll = true;
                tbp.ContextMenuStrip = menuTags;
                tbp.Controls.Add(newQuickCalcForm);
                tabPageMain.Pages.Add(tbp);                
                newQuickCalcForm.Location = new Point(0, 0);
                tabPageMain.SelectedPage = tbp;
                newQuickCalcForm.Show();
            }
            }
            catch
            {

            }
        }    

        private void btn_QuickCalc_ts_Click(object sender, EventArgs e)
        {
            try { 
            List<Project> QuickProjectList = new List<Project>();
            QuickProjectList = Program.ProjectList.FindAll(item => item.IsQuickProject == true);
            int quick_count = QuickProjectList.Count;
            int project_id = Program.ProjectList.Count + 1;
            string tag_no = "Quick Calc " + (quick_count + 1).ToString();
            Project nqp = new Project();
            nqp.IsQuickProject = true;
            nqp.Id = project_id;
            nqp.Tag_No = tag_no;
            nqp.Saved = false;
            nqp.Current_TabPage_Name = "pageCalculationType";

            Program.ProjectList.Add(nqp);
            pnlMain.SendToBack();
            tabPageMain.BringToFront();
            frmQuickCalc fqc = new frmQuickCalc(project_id, tag_no);

            fqc.TopLevel = false;
            fqc.Dock = DockStyle.Fill;  
            fqc.Tag = project_id; 

            RadPageViewPage tbp = new RadPageViewPage();
            tbp.Name = tag_no;
            tbp.Text = tag_no;
            tbp.Tag = project_id;
            tbp.ContextMenuStrip = menuTags; 
                      
            tabPageMain.AutoScroll = true;
            tbp.AutoScroll = true;
            tbp.Controls.Add(fqc);
            tabPageMain.Pages.Add(tbp);
           
                        
            
            fqc.Location = new Point(0, 0);
            tabPageMain.SelectedPage = tbp;
            fqc.Show();
            }
            catch
            {

            }
        }
        private void tabPageMain_SelectedPageChanged(object sender, EventArgs e)
        {
            try { 
            if (tabPageMain.Pages.Count > 0)
            {
                pnlMain.SendToBack();
                tabPageMain.BringToFront();
                CurrentProjectSelectedId = (int)tabPageMain.SelectedPage.Controls[0].Tag;
                btnSave_ts.Enabled = true;
            }
            else
            {
                pnlMain.BringToFront();
                tabPageMain.SendToBack();
                btnSave_ts.Enabled = false;
            }
            }
            catch
            {

            }
        }
        

        private void btnNewTag_ts_Click(object sender, EventArgs e)
        {
            lblNewTag_Click(sender, e);
        }

        private void btn_Home_ts_Click(object sender, EventArgs e)
        {
            try { 
            pnlMain.BringToFront();
            tabPageMain.SendToBack();
            if(pnlMain.Controls.Count == 8)
            {
                pnlMain.Controls[7].Dispose();
            }

            MainPanelItemVisibility(true);
            }
            catch
            {

            }
        }

        private void menuTags_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try { 
            int index = Program.ProjectList.FindIndex(item => item.Id == CurrentProjectSelectedId);
            if (Program.ProjectList[index].Saved == false)
                mnuItemSave.Enabled = true;
            else
                mnuItemSave.Enabled = false;
            }
            catch
            {

            }
        }

        private void lblOpenTag_Click(object sender, EventArgs e)
        {
            try { 
            frmTagList taglist = new frmTagList();
            taglist.TopLevel = false;
            taglist.Dock = DockStyle.Fill;
            
            tabPageMain.SendToBack();
            pnlMain.BringToFront();
            MainPanelItemVisibility(false);            
            pnlMain.Controls.Add(taglist);
            taglist.Show();
            }
            catch
            {

            }
        }

        private void MainPanelItemVisibility(bool Status)
        {
            try { 
            pictureBox1.Visible = Status;
            pictureBox2.Visible = Status;
            pictureBox3.Visible = Status;
            lblNewTag.Visible = Status;
            lblOpenCatalog.Visible = Status;
            lblOpenTag.Visible = Status;
            lblQuickCalc.Visible = Status;
            }
            catch
            {

            }
        }

        private void tabPageMain_Click(object sender, EventArgs e)
        {
            try { 
            tabPageMain.BringToFront();
            pnlMain.SendToBack();
            }
            catch
            {

            }
        }        

        private void pnlMain_ControlRemoved(object sender, ControlEventArgs e)
        {
            try { 
            if (Program.SelectedProjectsIdTable.Count > 0)
            {
                for(int i = 0; i < Program.SelectedProjectsIdTable.Count; i++)
                {
                    OpenProjectInNewPage(Program.SelectedProjectsIdTable[i]);
                }
                Program.SelectedProjectsIdTable.Clear();
            }
            else
            {
                btn_Home_ts_Click(sender, e);
            }
            }
            catch
            {

            }
        }

        private void OpenProjectInNewPage(string TableId)
        {
            try { 
            int index = BL.AddProjectToList(TableId);
            if(index != -1)
            {
                pnlMain.SendToBack();
                tabPageMain.BringToFront();
                frmQuickCalc fqc = new frmQuickCalc(index);
                fqc.TopLevel = false;
                fqc.Dock = DockStyle.Fill;
                fqc.Tag = Program.ProjectList[index].Id;
                RadPageViewPage tbp = new RadPageViewPage();
                tbp.Name = Program.ProjectList[index].Tag_No;
                tbp.Text = Program.ProjectList[index].Tag_No;
                tbp.Tag = Program.ProjectList[index].Id;
                tbp.ContextMenuStrip = menuTags;
                tabPageMain.AutoScroll = true;
                tbp.AutoScroll = true;
                tbp.Controls.Add(fqc);
                tabPageMain.Pages.Add(tbp);
                fqc.Location = new Point(0, 0);
                tabPageMain.SelectedPage = tbp;
                fqc.Show();
            }
            }
            catch
            {

            }
        }

        private void btn_Customer_ts_Click(object sender, EventArgs e)
        {
            try { 
            frmCustomer fcus = new frmCustomer();
            fcus.ShowDialog();
            }
            catch
            {

            }
        }

        private void btn_Personel_ts_Click(object sender, EventArgs e)
        {
            try { 
            frmPersonel fper = new frmPersonel();
            fper.ShowDialog();
            }
            catch
            {

            }
        }

        private void btn_Project_ts_Click(object sender, EventArgs e)
        {
            try { 
            frmProject fpr = new frmProject();
            fpr.Show();
            }
            catch
            {

            }
        }

        private void btnLabTest_Click(object sender, EventArgs e)
        {
            try { 
            frmTestLab ftl = new frmTestLab();
            ftl.Show();
            }
            catch
            {

            }
        }

        private void btnTagLibrary_ts_Click(object sender, EventArgs e)
        {
            lblOpenTag_Click(sender, e);
        }

        private void mnuOpenTag_Click(object sender, EventArgs e)
        {
            lblOpenTag_Click(sender, e);
        }

        private void mnuNewTag_Click(object sender, EventArgs e)
        {
            lblNewTag_Click(sender, e);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try { 
            frmShowInfo info = new frmShowInfo("Are you sure?", 5, "", "Yes", "No", "");
            DialogResult dr = info.ShowDialog();
            if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            }
            catch
            {

            }
        }
    }
}
