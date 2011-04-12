using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InputBox
{
    public partial class InputBoxSingleline : Form
    {
        private string text;

        enum buttonpressed { Ok = 1, Annuller = 2};
        private int lastButton;
        public InputBoxSingleline()
        {
            InitializeComponent();
        }

        public InputBoxSingleline(string text)
        {
            InitializeComponent();
            this.text = text;
            txtText.Text = text;
        }

        private void btnOk_Click_1(object sender, EventArgs e)
        {
            text = txtText.Text;
            lastButton = (int)buttonpressed.Ok;
            this.Close();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            lastButton = (int)buttonpressed.Annuller;
            this.Close();
        }

        
        public string Text
        {
            get { return text; }
        }

        public int Lastbutton
        {
            get { return lastButton; }
        }


 


            
    }
}
