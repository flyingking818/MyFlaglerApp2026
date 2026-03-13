namespace MyFlaglerApp2026
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            //Easier place to add event handlers
            //They will trigger the event handler method
            //when the user clicks on the radio button.
            rdoProfessor.CheckedChanged += PersonTypeChanged;
            rdoStudent.CheckedChanged += PersonTypeChanged;
            rdoStaff.CheckedChanged += PersonTypeChanged;
            

        }



        //We add the method here manually. :)
        private void PersonTypeChanged(object sender, EventArgs e)
        {
            //check the status of the button and then assign state.
            //this is better! :)

            grpProfessor.Visible = rdoProfessor.Checked;
            grpStudent.Visible = rdoStudent.Checked;
            grpStaff.Visible = rdoStaff.Checked;

            //alternative use if...else
            /*
            if(rdoProfessor.Checked) 
                grpProfessor.Visible = true;
            else
                grpProfessor.Visible = false;
            */
                        


        }

        private void btnDisplayProfile_Click(object sender, EventArgs e)
        {
            //Main event handler! :)

            //Let's validate user inputs
            if (!ValidateInput()) return;

        }

        private bool ValidateInput() {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                txtName.Focus();
                return ShowError("Name is requried!");
            }

            if (string.IsNullOrEmpty(txtID.Text))
            {
                txtID.Focus();
                return ShowError("ID is requried!");
            }

            if (rdoStudent.Checked && !double.TryParse(txtGPA.Text, out double gpa))
            {
                txtGPA.Focus();
                return ShowError("Please enter a valid GPA!");
            }

            return true;
        
        }

        //A helper method to generate the alert box!
        private bool ShowError(string message) {
            MessageBox.Show(message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }



    }
}
