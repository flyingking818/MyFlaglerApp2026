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

            //Let's do a dynamic object instantiation

            try
            {
                //Polymophism the person class can hold any subclass instance!
                Person person = CreatePerson();
                if (person == null) return; //Did we instantiate any object?
                lblResult.Text = person.GetDetails();

            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error: {ex.Message}");
            }



        }

        private bool ValidateInput() {
            //early exit is preferred!
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

        //A method to dynamically instantiate profile classes.

        private Person CreatePerson()
        {
            Person person = null;
            if (rdoProfessor.Checked)
            {
                person = new Professor
                {
                    //Grab the values from the input form for each profile.
                    //These three are handled by the parent class.
                    Name = txtName.Text,
                    ID = txtID.Text,
                    Email = txtEmail.Text,
                    //These three are handled by the Professor subclass.
                    Department = cboDepartment.Text,
                    ResearchArea = txtResearchArea.Text,
                    IsTerminalDegree = chkTerminalDegree.Checked,
                };
            }
            else if (rdoStudent.Checked)
            {
                person = new Student
                {
                    Name = txtName.Text,
                    ID = txtID.Text,
                    Email = txtEmail.Text,
                    Major = cboMajor.Text,
                    GPA = double.Parse(txtGPA.Text), //this is safe because we already did the validation.
                    IsFullTime = chkFullTime.Checked,
                    EnrollmentDate = Convert.ToDateTime(dtpEnrollmentDate.Text)
                };
            }
            else if (rdoStaff.Checked)
            {
                person = new Staff
                {
                    Name = txtName.Text,
                    ID = txtID.Text,
                    Email = txtEmail.Text,
                    Position = txtPosition.Text,
                    Division = txtDivision.Text,
                    IsAdministrative = chkAdministrative.Checked
                };
            }

            return person;

        }




    }
}
