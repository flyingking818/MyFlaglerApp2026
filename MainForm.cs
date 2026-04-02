namespace MyFlaglerApp2026
{
    public partial class MainForm : BaseForm
    {
        //Declare some variables
        string selectedImagePath = "";
        private List<Person> people = new List<Person>();
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

        protected override void UploadImage_Click(object sender, EventArgs e)
        {
            btnUploadImage.PerformClick(); // This triggers your button
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

        private void btnAddProfile_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                Person person = CreatePerson();
                if (person == null) return;

                //Set the image to the Image property, convert the physical image into bytes[]
                if (!string.IsNullOrEmpty(selectedImagePath))
                {
                    person.ProfileImage = File.ReadAllBytes(selectedImagePath);
                }

                //Add the person object into the people list
                people.Add(person);

                //Display the people in the data view grid (table)
                UpdateDisplay();

                //ClearForm;

            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void UpdateDisplay()
        {
            dgvPeople.Rows.Clear(); // Clear existing rows

            foreach (var person in people)
            {
                // Create a new row
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvPeople);

                // Populate the row with data
                row.Cells[0].Value = person.GetType().Name; // Type (Student, Professor, Staff)
                row.Cells[1].Value = person.Name; // Name
                row.Cells[2].Value = person.ID; // ID
                row.Cells[3].Value = person.GetDetails(); // Details

                // Handle the image column
                if (person.ProfileImage != null && person.ProfileImage.Length > 0)
                {
                    // Convert byte[] to Image
                    using (var ms = new MemoryStream(person.ProfileImage))
                    {
                        Image image = Image.FromStream(ms); // Create the Image object
                        row.Cells[4].Value = image; // Assign the Image to the cell
                    }
                }
                else
                {
                    row.Cells[4].Value = null; // No image
                }

                row.Height = 70;

                //Don't forget to add the row the grid
                dgvPeople.Rows.Add(row);
            }

        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            // Ensure the user has selected a row in the DataGridView
            if (dgvPeople.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a profile to view details.");
                return; // Stop execution if nothing is selected
            }

            // Get the index of the selected row
            int selectedIndex = dgvPeople.SelectedRows[0].Index;

            // Validate that the index is within the bounds of the people list
            if (selectedIndex < 0 || selectedIndex >= people.Count)
            {
                MessageBox.Show("Invalid selection. Please try again.");
                return;
            }

            // Retrieve the corresponding Person object from the list
            Person selectedPerson = people[selectedIndex];

            // Instantiate the secondary form and pass the selected Person object
            ProfileDetailForm frmDetail = new ProfileDetailForm(selectedPerson);

            // Hide the current form AFTER validation and object creation
            // (prevents UI from disappearing if an error occurs earlier)
            this.Hide();

            // Show the detail form as a modal dialog
            // This pauses the current form until the detail form is closed
            frmDetail.ShowDialog();

            // When the detail form is closed, show the main form again
            this.Show();

        }
    }
}
