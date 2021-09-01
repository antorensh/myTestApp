using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyTestApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //correggere con manager
            Form2 help = new Form2();
            help.Show();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Form2 settings = new Form2();
            settings.ShowDialog();
            settings.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form3 = FormManager.Current.CreateForm<Form3>();
            form3.Show();
            this.Close();
        }
    }
}
