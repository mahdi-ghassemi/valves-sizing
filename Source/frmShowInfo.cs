using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;


namespace Radman
{
    public partial class frmShowInfo : Telerik.WinControls.UI.RadForm
    {        
        private string _message1;
        private int _bottum;
        private string _title;
        private string _bottum_msg1;
        private string _bottum_msg2;
        private string _bottum_msg3;

        public frmShowInfo(string Message1, int Bottum,string Bottum1Msg, string Bottum2Msg, string Bottum3Msg,string Title)
        {           
            _message1 = Message1;
            _bottum = Bottum;
            _title = Title;
            _bottum_msg1 = Bottum1Msg;
            _bottum_msg2 = Bottum2Msg;
            _bottum_msg3 = Bottum3Msg;
            InitializeComponent();
        }

        private void frmShowInfo_Load(object sender, EventArgs e)
        {
            lblInfo1.Text = _message1;
            this.Text = _title;
            ShowBottums(); 
        }

        private void ShowBottums()
        {            
            switch (_bottum)
            {
                case 1:
                    {
                        btn1.Visible = true;
                        btn1.Text = _bottum_msg1;
                        break;
                    }
                case 2:
                    {
                        btn2.Visible = true;
                        btn2.Text = _bottum_msg2;
                        break;
                    }
                case 3:
                    {
                        btn1.Visible = true;
                        btn2.Visible = true;
                        btn1.Text = _bottum_msg1;
                        btn2.Text = _bottum_msg2;
                        break;
                    }
                case 5:
                    {
                        btn2.Visible = true;
                        btn3.Visible = true;                        
                        btn2.Text = _bottum_msg2;
                        btn3.Text = _bottum_msg3;
                        break;
                    }
                case 6:
                    {
                        btn1.Visible = true;
                        btn2.Visible = true;
                        btn3.Visible = true;
                        btn1.Text = _bottum_msg1;
                        btn2.Text = _bottum_msg2;
                        btn3.Text = _bottum_msg3;
                        break;
                    }
            }

        }

        private void btn2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.Close();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

    }
}
