using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyFlaglerApp2026
{
    public partial class ProfileDetailForm : BaseForm
    {
        private Person _person;
        public ProfileDetailForm(Person person) //Custom constructor!
        {
            InitializeComponent();
            _person = person;
            DisplayDetails();
        }

        private void DisplayDetails()
        {
            if (_person == null) return;

            // Use polymorphism to get a formatted report
            lblReport.Text = _person.GetDetails();

            // Optional: improve readability
            lblReport.AutoSize = false;
            lblReport.Width = 500;
            lblReport.Height = 300;
        }
    }
}
