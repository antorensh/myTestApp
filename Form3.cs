using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyTestApp
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            ProgressBar();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            FindPrevTab();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            FindNextTab();
        }

        private void FindNextTab()
        {
            int ind = tabControl1.SelectedIndex; //index of the curr tab
            if (++ind < tabControl1.TabCount && ind != -1)
                tabControl1.SelectedIndex = ind;
            progressBar1.Value = tabControl1.SelectedIndex+1;
        }

        private void FindPrevTab()
        {
            int ind = tabControl1.SelectedIndex; //index of the curr tab
            if (--ind >= 0 && ind < tabControl1.TabCount)
                tabControl1.SelectedIndex = ind;
            progressBar1.Value = tabControl1.SelectedIndex+1;
        }

        private void ProgressBar()
        {
            // Display the ProgressBar control.
            progressBar1.Visible = true;
            // Set Minimum to 1 to represent the first tab.
            progressBar1.Minimum = 0;
            // Set Maximum to the total number of tabs
            progressBar1.Maximum = tabControl1.TabPages.Count;
            progressBar1.Step = 1;
            // Set the initial value of the ProgressBar.
            progressBar1.Value = 1;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            //register data
            var form4 = FormManager.Current.CreateForm<Form4>();
            form4.Show();
            this.Close();

        }
    }
}
