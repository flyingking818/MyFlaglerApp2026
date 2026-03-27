namespace MyFlaglerApp2026
{
    public partial class MainForm : Form
    {
        //Declare some variables
        string selectedImagePath = "";

        public MainForm()
        {
            InitializeComponent();

            //Easier place to add event handlers
            //They will trigger the event handler method
            //when the user clicks on the radio button.
            rdoProfessor.CheckedChanged += PersonTypeChanged;
            rdoStudent.CheckedChanged += PersonTypeChanged;
            rdoStaff.CheckedChanged += PersonTypeChanged;

            //Intialize our DGV
            InitializeDataGridView();

        }

        private void InitializeDataGridView()
        {
            dgvPeople.Columns.Clear();
            dgvPeople.Columns.Add("Type", "Person Type");
            dgvPeople.Columns.Add("Name", "Name");
            dgvPeople.Columns.Add("ID", "ID");
            dgvPeople.Columns.Add("Details", "Details");

            //don't forget to add the image column
            var imageColumn = new DataGridViewImageColumn();
            imageColumn.Name = "Image";  //ID
            imageColumn.HeaderText = "Profile Image"; //Display text 
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; //Scales automatically
            dgvPeople.Columns.Add(imageColumn);

            //Set the widths of the columns based on the data fields.
            dgvPeople.Columns["Type"].Width = 220;
            dgvPeople.Columns["Name"].Width = 300;
            dgvPeople.Columns["ID"].Width = 200;
            dgvPeople.Columns["Details"].Width = 800;
            dgvPeople.Columns["Details"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvPeople.Columns["Image"].Width = 300;

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
                lblResult.Text = person.GetDetails(); //Call the method to generate output!

            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error: {ex.Message}");
            }



        }

        private bool ValidateInput()
        {
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
        private bool ShowError(string message)
        {
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

            return person;  //Don't forget to return the object back!

        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())  //using is a safter way for handling run-time error
            {
                ofd.Filter = "Image Files|*.jpg;*.png;*.gif;*.jpeg"; //* wild card
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = ofd.FileName;
                    picProfile.Image = Image.FromFile(selectedImagePath);
                    picProfile.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }


    }
}
