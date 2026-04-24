using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace MyFlaglerApp2026
{
    public partial class MainFormDB : BaseForm
    {
        //Declare some variables
        string selectedImagePath = "";

        public MainFormDB()
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

            // Load all data initially (no filter)
            LoadSummary("");
        }

        private void InitializeDataGridView()
        {
            dgvPeople.Columns.Clear();
            dgvPeople.AutoGenerateColumns = true; // Let the DataTable drive the columns
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
                //Polymorphism: the person class can hold any subclass instance!
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
                return ShowError("Name is required!");
            }

            if (string.IsNullOrEmpty(txtID.Text))
            {
                txtID.Focus();
                return ShowError("ID is required!");
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

            return person; //Don't forget to return the object back!
        }

        protected override void UploadImage_Click(object sender, EventArgs e)
        {
            btnUploadImage.PerformClick(); // This triggers your button
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog()) //using is a safer way for handling run-time errors
            {
                ofd.Filter = "Image Files|*.jpg;*.png;*.gif;*.jpeg"; //* wildcard
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

                // ✅ Save to Supabase database
                InsertToDatabase(person);

                // Reload grid from database to reflect latest saved data
                LoadSummary("");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        // ─────────────────────────────────────────────
        // This mirrors our web version's LoadSummary exactly
        // DataAdapter + DataTable pattern instead of manual row building
        // ─────────────────────────────────────────────
        private void LoadSummary(string keyword = "")
        {
            // Get database connection string from App.config
            string connStr = ConfigurationManager.ConnectionStrings["PersonApp"].ConnectionString;

            // Create connection to PostgreSQL (Supabase)
            using (NpgsqlConnection conn = new NpgsqlConnection(connStr))
            {
                // SQL query to retrieve combined data from multiple tables
                // persons = main table
                // students, professors, staff = subtype tables
                string query = @"
                    SELECT 
                        p.person_id,
                        p.name,
                        p.person_code AS campus_id,
                        p.email,
                        p.person_type,
                        s.major,
                        s.gpa,
                        s.is_full_time,
                        s.enrollment_date,
                        pr.department,
                        pr.research_area,
                        pr.is_terminal_degree,
                        st.position,
                        st.division,
                        st.is_administrative
                    FROM persons p

                    -- LEFT JOIN ensures every person appears,
                    -- even if they are only in one role
                    LEFT JOIN students s ON p.person_id = s.person_id
                    LEFT JOIN professors pr ON p.person_id = pr.person_id
                    LEFT JOIN staff st ON p.person_id = st.person_id

                    -- Search filter:
                    -- If keyword is empty → return all records
                    -- Otherwise → search name or email
                    WHERE (@Keyword = '' 
                           OR p.name ILIKE '%' || @Keyword || '%'
                           OR p.email ILIKE '%' || @Keyword || '%')

                    -- Sort results by ID
                    ORDER BY p.person_id ASC;";

                // DataAdapter executes the query and fills a DataTable
                // (acts as a bridge between database and memory)
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, conn);

                // Add parameter value (prevents SQL injection)
                adapter.SelectCommand.Parameters.AddWithValue("@Keyword", keyword);

                // Create in-memory table to store results
                DataTable table = new DataTable();

                // Execute query and load results into DataTable
                adapter.Fill(table);

                // Bind DataTable to DataGridView for display
                // Windows Forms: DataSource instead of web's DataBind()
                dgvPeople.DataSource = table;

            } // connection automatically closes here
        }

        //Same method we used for the web app - Handles all database operations (PostgreSQL / Supabase)
        private void InsertToDatabase(Person person)
        {
            // Read connection string from App.config
            string connString = ConfigurationManager.ConnectionStrings["PersonApp"].ConnectionString;

            // Create connection to PostgreSQL
            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                conn.Open(); // must open connection before executing SQL

                // Transaction ensures all operations succeed or fail together
                using (NpgsqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // STEP 1: Insert into main table (persons)
                        // This table stores common fields for ALL people
                        string insertPersonSql = @"
                            INSERT INTO persons (name, person_code, email, person_type, created_at)
                            VALUES (@name, @person_code, @email, @person_type, @created_at)
                            RETURNING person_id;"; // PostgreSQL returns the new ID

                        using (NpgsqlCommand cmdPerson = new NpgsqlCommand(insertPersonSql, conn, transaction))
                        {
                            // Add parameter values (safe, prevents SQL injection)
                            cmdPerson.Parameters.AddWithValue("@name", person.Name);
                            cmdPerson.Parameters.AddWithValue("@person_code", person.ID);
                            cmdPerson.Parameters.AddWithValue("@email", person.Email);
                            cmdPerson.Parameters.AddWithValue("@person_type", person.GetType().Name);
                            cmdPerson.Parameters.AddWithValue("@created_at", DateTime.Now);

                            // Execute query and get generated person_id
                            int personID = Convert.ToInt32(cmdPerson.ExecuteScalar());

                            // STEP 2: Insert into subtype table (example: Professor)
                            // Each role has its own table with additional fields
                            // person_id links the tables together

                            if (person is Professor professor)
                            {
                                string insertProfessorSql = @"
                                    INSERT INTO professors (person_id, department, research_area, is_terminal_degree)
                                    VALUES (@person_id, @department, @research_area, @is_terminal_degree);";

                                using (NpgsqlCommand cmd = new NpgsqlCommand(insertProfessorSql, conn, transaction))
                                {
                                    // Link to persons table
                                    cmd.Parameters.AddWithValue("@person_id", personID);

                                    // Professor-specific fields
                                    cmd.Parameters.AddWithValue("@department", professor.Department ?? (object)DBNull.Value);
                                    cmd.Parameters.AddWithValue("@research_area", professor.ResearchArea ?? (object)DBNull.Value);
                                    cmd.Parameters.AddWithValue("@is_terminal_degree", professor.IsTerminalDegree);

                                    cmd.ExecuteNonQuery(); // run INSERT
                                }
                            }
                            else if (person is Student student)
                            {
                                string insertStudentSql = @"
                                    INSERT INTO students (person_id, major, gpa, is_full_time, enrollment_date)
                                    VALUES (@person_id, @major, @gpa, @is_full_time, @enrollment_date);";

                                using (NpgsqlCommand cmd = new NpgsqlCommand(insertStudentSql, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@person_id", personID);
                                    cmd.Parameters.AddWithValue("@major", student.Major ?? (object)DBNull.Value);
                                    cmd.Parameters.AddWithValue("@gpa", student.GPA);
                                    cmd.Parameters.AddWithValue("@is_full_time", student.IsFullTime);
                                    cmd.Parameters.AddWithValue("@enrollment_date", student.EnrollmentDate);

                                    cmd.ExecuteNonQuery();
                                }
                            }
                            else if (person is Staff staff)
                            {
                                string insertStaffSql = @"
                                    INSERT INTO staff (person_id, position, division, is_administrative)
                                    VALUES (@person_id, @position, @division, @is_administrative);";

                                using (NpgsqlCommand cmd = new NpgsqlCommand(insertStaffSql, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@person_id", personID);
                                    cmd.Parameters.AddWithValue("@position", staff.Position ?? (object)DBNull.Value);  //optionals
                                    cmd.Parameters.AddWithValue("@division", staff.Division ?? (object)DBNull.Value);
                                    cmd.Parameters.AddWithValue("@is_administrative", staff.IsAdministrative);

                                    cmd.ExecuteNonQuery();
                                }
                            }

                            //Classes match the relational tables!!! Entity Framework approach!
                        }

                        // Save all changes permanently
                        transaction.Commit();

                        MessageBox.Show("Profile saved to Supabase database!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        // Undo everything if any step fails
                        transaction.Rollback();

                        MessageBox.Show($"Database error: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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

            // Retrieve person_id directly from the DataTable bound to the grid
            int personId = Convert.ToInt32(dgvPeople.SelectedRows[0].Cells["person_id"].Value);

            MessageBox.Show($"Selected Person ID: {personId}", "Detail",
                MessageBoxButtons.OK, MessageBoxIcon.Information);


        }


        // ─────────────────────────────────────────────
        // Search button — mirrors web version's btnSearch_Click
        // ─────────────────────────────────────────────
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Reload data with search keyword
            LoadSummary(txtSearch.Text.Trim());
        }
    }
}