using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyFlaglerApp2026
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        private void uploadImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UploadImage_Click(sender, e); // Call the overridable method
        }

        //This is the overriable method, which will be implemented by the MainForm
        protected virtual void UploadImage_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Upload image not available in this form.");
        }
    }
}
