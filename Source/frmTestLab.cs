using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.IO;

namespace Radman
{
    public partial class frmTestLab : Telerik.WinControls.UI.RadForm
    {
        private List<Customer> Customer_list = new List<Customer>();
        public frmTestLab()
        {
            InitializeComponent();
        }

        private void frmTestLab_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.radman_logo_png;
            FillCustomer();
        }

        private void FillCustomer()
        {
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
                    cmbCustomers.Items.Add(Name);
                }
                cmbCustomers.SelectedIndex = 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo("C:\\Users\\Mahdi\\Downloads\\DS hamkar.xlsm");
            if (fi.Exists)
            {
                System.Diagnostics.Process.Start(@"C:\Users\Mahdi\Downloads\DS hamkar.xlsm");
            }
            else
            {
                //file doesn't exist
            }

        }
    }
}
