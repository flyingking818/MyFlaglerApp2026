namespace MyFlaglerApp2026
{
    partial class MainFormDB
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grpPersonnel = new GroupBox();
            rdoStaff = new RadioButton();
            rdoStudent = new RadioButton();
            rdoProfessor = new RadioButton();
            grpBasicInfo = new GroupBox();
            txtEmail = new TextBox();
            label3 = new Label();
            txtID = new TextBox();
            label2 = new Label();
            txtName = new TextBox();
            label1 = new Label();
            grpProfessor = new GroupBox();
            chkTerminalDegree = new CheckBox();
            cboDepartment = new ComboBox();
            label4 = new Label();
            txtResearchArea = new TextBox();
            label5 = new Label();
            label6 = new Label();
            grpStudent = new GroupBox();
            dtpEnrollmentDate = new DateTimePicker();
            chkFullTime = new CheckBox();
            cboMajor = new ComboBox();
            txtGPA = new TextBox();
            label8 = new Label();
            label9 = new Label();
            grpStaff = new GroupBox();
            chkAdministrative = new CheckBox();
            txtPosition = new TextBox();
            txtDivision = new TextBox();
            label10 = new Label();
            label11 = new Label();
            btnDisplayProfile = new Button();
            lblResult = new Label();
            picProfile = new PictureBox();
            btnUploadImage = new Button();
            dgvPeople = new DataGridView();
            btnAddProfile = new Button();
            btnViewDetail = new Button();
            txtSearch = new TextBox();
            btnSearch = new Button();
            grpPersonnel.SuspendLayout();
            grpBasicInfo.SuspendLayout();
            grpProfessor.SuspendLayout();
            grpStudent.SuspendLayout();
            grpStaff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picProfile).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPeople).BeginInit();
            SuspendLayout();
            // 
            // grpPersonnel
            // 
            grpPersonnel.Controls.Add(rdoStaff);
            grpPersonnel.Controls.Add(rdoStudent);
            grpPersonnel.Controls.Add(rdoProfessor);
            grpPersonnel.Location = new Point(41, 103);
            grpPersonnel.Name = "grpPersonnel";
            grpPersonnel.Size = new Size(688, 166);
            grpPersonnel.TabIndex = 0;
            grpPersonnel.TabStop = false;
            grpPersonnel.Text = "Personnel";
            // 
            // rdoStaff
            // 
            rdoStaff.AutoSize = true;
            rdoStaff.Location = new Point(425, 73);
            rdoStaff.Name = "rdoStaff";
            rdoStaff.Size = new Size(93, 36);
            rdoStaff.TabIndex = 2;
            rdoStaff.TabStop = true;
            rdoStaff.Text = "Staff";
            rdoStaff.UseVisualStyleBackColor = true;
            // 
            // rdoStudent
            // 
            rdoStudent.AutoSize = true;
            rdoStudent.Location = new Point(228, 73);
            rdoStudent.Name = "rdoStudent";
            rdoStudent.Size = new Size(128, 36);
            rdoStudent.TabIndex = 1;
            rdoStudent.TabStop = true;
            rdoStudent.Text = "Student";
            rdoStudent.UseVisualStyleBackColor = true;
            // 
            // rdoProfessor
            // 
            rdoProfessor.AutoSize = true;
            rdoProfessor.Location = new Point(29, 73);
            rdoProfessor.Name = "rdoProfessor";
            rdoProfessor.Size = new Size(143, 36);
            rdoProfessor.TabIndex = 0;
            rdoProfessor.TabStop = true;
            rdoProfessor.Text = "Professor";
            rdoProfessor.UseVisualStyleBackColor = true;
            // 
            // grpBasicInfo
            // 
            grpBasicInfo.Controls.Add(txtEmail);
            grpBasicInfo.Controls.Add(label3);
            grpBasicInfo.Controls.Add(txtID);
            grpBasicInfo.Controls.Add(label2);
            grpBasicInfo.Controls.Add(txtName);
            grpBasicInfo.Controls.Add(label1);
            grpBasicInfo.Location = new Point(41, 293);
            grpBasicInfo.Name = "grpBasicInfo";
            grpBasicInfo.Size = new Size(688, 263);
            grpBasicInfo.TabIndex = 1;
            grpBasicInfo.TabStop = false;
            grpBasicInfo.Text = "Basic Information";
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.FromArgb(255, 224, 192);
            txtEmail.Location = new Point(198, 197);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(462, 39);
            txtEmail.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 195);
            label3.Name = "label3";
            label3.Size = new Size(76, 32);
            label3.TabIndex = 4;
            label3.Text = "Email:";
            // 
            // txtID
            // 
            txtID.BackColor = Color.FromArgb(255, 224, 192);
            txtID.Location = new Point(198, 128);
            txtID.Name = "txtID";
            txtID.Size = new Size(462, 39);
            txtID.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 126);
            label2.Name = "label2";
            label2.Size = new Size(42, 32);
            label2.TabIndex = 2;
            label2.Text = "ID:";
            // 
            // txtName
            // 
            txtName.BackColor = Color.FromArgb(255, 224, 192);
            txtName.Location = new Point(198, 67);
            txtName.Name = "txtName";
            txtName.Size = new Size(462, 39);
            txtName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 65);
            label1.Name = "label1";
            label1.Size = new Size(83, 32);
            label1.TabIndex = 0;
            label1.Text = "Name:";
            // 
            // grpProfessor
            // 
            grpProfessor.Controls.Add(chkTerminalDegree);
            grpProfessor.Controls.Add(cboDepartment);
            grpProfessor.Controls.Add(label4);
            grpProfessor.Controls.Add(txtResearchArea);
            grpProfessor.Controls.Add(label5);
            grpProfessor.Controls.Add(label6);
            grpProfessor.Location = new Point(41, 609);
            grpProfessor.Name = "grpProfessor";
            grpProfessor.Size = new Size(688, 263);
            grpProfessor.TabIndex = 6;
            grpProfessor.TabStop = false;
            grpProfessor.Text = "Professor Information";
            // 
            // chkTerminalDegree
            // 
            chkTerminalDegree.AutoSize = true;
            chkTerminalDegree.Location = new Point(29, 195);
            chkTerminalDegree.Name = "chkTerminalDegree";
            chkTerminalDegree.Size = new Size(28, 27);
            chkTerminalDegree.TabIndex = 7;
            chkTerminalDegree.UseVisualStyleBackColor = true;
            // 
            // cboDepartment
            // 
            cboDepartment.FormattingEnabled = true;
            cboDepartment.Items.AddRange(new object[] { "Math & Technology", "Business Administration", "Fine Arts", "Sociology", "Hospitality", "Other" });
            cboDepartment.Location = new Point(200, 65);
            cboDepartment.Name = "cboDepartment";
            cboDepartment.Size = new Size(460, 40);
            cboDepartment.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(63, 191);
            label4.Name = "label4";
            label4.Size = new Size(312, 32);
            label4.TabIndex = 4;
            label4.Text = "Terminal degree? (e.g., PhD)";
            // 
            // txtResearchArea
            // 
            txtResearchArea.BackColor = Color.FromArgb(255, 224, 192);
            txtResearchArea.Location = new Point(198, 128);
            txtResearchArea.Name = "txtResearchArea";
            txtResearchArea.Size = new Size(462, 39);
            txtResearchArea.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(21, 126);
            label5.Name = "label5";
            label5.Size = new Size(168, 32);
            label5.TabIndex = 2;
            label5.Text = "Research Area:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(21, 65);
            label6.Name = "label6";
            label6.Size = new Size(147, 32);
            label6.TabIndex = 0;
            label6.Text = "Department:";
            // 
            // grpStudent
            // 
            grpStudent.Controls.Add(dtpEnrollmentDate);
            grpStudent.Controls.Add(chkFullTime);
            grpStudent.Controls.Add(cboMajor);
            grpStudent.Controls.Add(txtGPA);
            grpStudent.Controls.Add(label8);
            grpStudent.Controls.Add(label9);
            grpStudent.Location = new Point(823, 609);
            grpStudent.Name = "grpStudent";
            grpStudent.Size = new Size(688, 263);
            grpStudent.TabIndex = 8;
            grpStudent.TabStop = false;
            grpStudent.Text = "Student Information";
            grpStudent.Visible = false;
            // 
            // dtpEnrollmentDate
            // 
            dtpEnrollmentDate.Format = DateTimePickerFormat.Short;
            dtpEnrollmentDate.Location = new Point(207, 186);
            dtpEnrollmentDate.Name = "dtpEnrollmentDate";
            dtpEnrollmentDate.Size = new Size(219, 39);
            dtpEnrollmentDate.TabIndex = 8;
            // 
            // chkFullTime
            // 
            chkFullTime.AutoSize = true;
            chkFullTime.Location = new Point(21, 187);
            chkFullTime.Name = "chkFullTime";
            chkFullTime.Size = new Size(155, 36);
            chkFullTime.TabIndex = 7;
            chkFullTime.Text = "Full Time?";
            chkFullTime.UseVisualStyleBackColor = true;
            // 
            // cboMajor
            // 
            cboMajor.FormattingEnabled = true;
            cboMajor.Items.AddRange(new object[] { "Computer Information Systems", "Data Science", "Math", "Psychology", "History", "Graphic Design", "Other" });
            cboMajor.Location = new Point(200, 65);
            cboMajor.Name = "cboMajor";
            cboMajor.Size = new Size(460, 40);
            cboMajor.TabIndex = 6;
            // 
            // txtGPA
            // 
            txtGPA.BackColor = Color.FromArgb(255, 224, 192);
            txtGPA.Location = new Point(198, 128);
            txtGPA.Name = "txtGPA";
            txtGPA.Size = new Size(161, 39);
            txtGPA.TabIndex = 3;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(21, 126);
            label8.Name = "label8";
            label8.Size = new Size(61, 32);
            label8.TabIndex = 2;
            label8.Text = "GPA:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(21, 65);
            label9.Name = "label9";
            label9.Size = new Size(81, 32);
            label9.TabIndex = 0;
            label9.Text = "Major:";
            // 
            // grpStaff
            // 
            grpStaff.Controls.Add(chkAdministrative);
            grpStaff.Controls.Add(txtPosition);
            grpStaff.Controls.Add(txtDivision);
            grpStaff.Controls.Add(label10);
            grpStaff.Controls.Add(label11);
            grpStaff.Location = new Point(1620, 609);
            grpStaff.Name = "grpStaff";
            grpStaff.Size = new Size(688, 263);
            grpStaff.TabIndex = 8;
            grpStaff.TabStop = false;
            grpStaff.Text = "Staff Information";
            grpStaff.Visible = false;
            // 
            // chkAdministrative
            // 
            chkAdministrative.AutoSize = true;
            chkAdministrative.Location = new Point(21, 191);
            chkAdministrative.Name = "chkAdministrative";
            chkAdministrative.Size = new Size(230, 36);
            chkAdministrative.TabIndex = 9;
            chkAdministrative.Text = "Is administrative?";
            chkAdministrative.UseVisualStyleBackColor = true;
            // 
            // txtPosition
            // 
            txtPosition.BackColor = Color.FromArgb(255, 224, 192);
            txtPosition.Location = new Point(198, 66);
            txtPosition.Name = "txtPosition";
            txtPosition.Size = new Size(462, 39);
            txtPosition.TabIndex = 8;
            // 
            // txtDivision
            // 
            txtDivision.BackColor = Color.FromArgb(255, 224, 192);
            txtDivision.Location = new Point(198, 128);
            txtDivision.Name = "txtDivision";
            txtDivision.Size = new Size(462, 39);
            txtDivision.TabIndex = 3;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(21, 126);
            label10.Name = "label10";
            label10.Size = new Size(104, 32);
            label10.TabIndex = 2;
            label10.Text = "Division:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(21, 65);
            label11.Name = "label11";
            label11.Size = new Size(103, 32);
            label11.TabIndex = 0;
            label11.Text = "Position:";
            // 
            // btnDisplayProfile
            // 
            btnDisplayProfile.Location = new Point(47, 906);
            btnDisplayProfile.Name = "btnDisplayProfile";
            btnDisplayProfile.Size = new Size(335, 46);
            btnDisplayProfile.TabIndex = 9;
            btnDisplayProfile.Text = "Display Profile";
            btnDisplayProfile.UseVisualStyleBackColor = true;
            btnDisplayProfile.Click += btnDisplayProfile_Click;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(485, 920);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(134, 32);
            lblResult.TabIndex = 8;
            lblResult.Text = "ResultLabel";
            // 
            // picProfile
            // 
            picProfile.Location = new Point(823, 124);
            picProfile.Name = "picProfile";
            picProfile.Size = new Size(368, 417);
            picProfile.TabIndex = 10;
            picProfile.TabStop = false;
            // 
            // btnUploadImage
            // 
            btnUploadImage.Location = new Point(1267, 495);
            btnUploadImage.Name = "btnUploadImage";
            btnUploadImage.Size = new Size(335, 46);
            btnUploadImage.TabIndex = 11;
            btnUploadImage.Text = "Upload Image";
            btnUploadImage.UseVisualStyleBackColor = true;
            btnUploadImage.Click += btnUploadImage_Click;
            // 
            // dgvPeople
            // 
            dgvPeople.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPeople.Location = new Point(41, 1044);
            dgvPeople.Name = "dgvPeople";
            dgvPeople.RowHeadersWidth = 82;
            dgvPeople.Size = new Size(2151, 454);
            dgvPeople.TabIndex = 12;
            // 
            // btnAddProfile
            // 
            btnAddProfile.Location = new Point(1738, 992);
            btnAddProfile.Name = "btnAddProfile";
            btnAddProfile.Size = new Size(220, 46);
            btnAddProfile.TabIndex = 13;
            btnAddProfile.Text = "Add Profile";
            btnAddProfile.UseVisualStyleBackColor = true;
            btnAddProfile.Click += btnAddProfile_Click;
            // 
            // btnViewDetail
            // 
            btnViewDetail.Location = new Point(1972, 992);
            btnViewDetail.Name = "btnViewDetail";
            btnViewDetail.Size = new Size(220, 46);
            btnViewDetail.TabIndex = 14;
            btnViewDetail.Text = "View Detail";
            btnViewDetail.UseVisualStyleBackColor = true;
            btnViewDetail.Click += btnViewDetail_Click;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.FromArgb(255, 224, 192);
            txtSearch.Location = new Point(41, 999);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(462, 39);
            txtSearch.TabIndex = 6;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(529, 995);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(335, 46);
            btnSearch.TabIndex = 15;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // MainFormDB
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 255, 192);
            ClientSize = new Size(2374, 1510);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(btnViewDetail);
            Controls.Add(btnAddProfile);
            Controls.Add(dgvPeople);
            Controls.Add(btnUploadImage);
            Controls.Add(grpStudent);
            Controls.Add(picProfile);
            Controls.Add(lblResult);
            Controls.Add(btnDisplayProfile);
            Controls.Add(grpStaff);
            Controls.Add(grpProfessor);
            Controls.Add(grpBasicInfo);
            Controls.Add(grpPersonnel);
            Name = "MainFormDB";
            Text = "Main Form";
            Controls.SetChildIndex(grpPersonnel, 0);
            Controls.SetChildIndex(grpBasicInfo, 0);
            Controls.SetChildIndex(grpProfessor, 0);
            Controls.SetChildIndex(grpStaff, 0);
            Controls.SetChildIndex(btnDisplayProfile, 0);
            Controls.SetChildIndex(lblResult, 0);
            Controls.SetChildIndex(picProfile, 0);
            Controls.SetChildIndex(grpStudent, 0);
            Controls.SetChildIndex(btnUploadImage, 0);
            Controls.SetChildIndex(dgvPeople, 0);
            Controls.SetChildIndex(btnAddProfile, 0);
            Controls.SetChildIndex(btnViewDetail, 0);
            Controls.SetChildIndex(txtSearch, 0);
            Controls.SetChildIndex(btnSearch, 0);
            grpPersonnel.ResumeLayout(false);
            grpPersonnel.PerformLayout();
            grpBasicInfo.ResumeLayout(false);
            grpBasicInfo.PerformLayout();
            grpProfessor.ResumeLayout(false);
            grpProfessor.PerformLayout();
            grpStudent.ResumeLayout(false);
            grpStudent.PerformLayout();
            grpStaff.ResumeLayout(false);
            grpStaff.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picProfile).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPeople).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpPersonnel;
        private RadioButton rdoProfessor;
        private RadioButton rdoStaff;
        private RadioButton rdoStudent;
        private GroupBox grpBasicInfo;
        private TextBox txtName;
        private Label label1;
        private TextBox txtEmail;
        private Label label3;
        private TextBox txtID;
        private Label label2;
        private GroupBox grpProfessor;
        private Label label4;
        private TextBox txtResearchArea;
        private Label label5;
        private Label label6;
        private ComboBox cboDepartment;
        private CheckBox chkTerminalDegree;
        private GroupBox grpStudent;
        private CheckBox chkFullTime;
        private ComboBox cboMajor;
        private TextBox txtGPA;
        private Label label8;
        private Label label9;
        private DateTimePicker dtpEnrollmentDate;
        private GroupBox grpStaff;
        private CheckBox checkBox1;
        private ComboBox comboBox1;
        private Label label7;
        private TextBox txtDivision;
        private Label label10;
        private Label label11;
        private TextBox txtPosition;
        private CheckBox chkAdministrative;
        private Button btnDisplayProfile;
        private Label lblResult;
        private PictureBox picProfile;
        private Button btnUploadImage;
        private DataGridView dgvPeople;
        private Button btnAddProfile;
        private Button btnViewDetail;
        private TextBox txtSearch;
        private Button btnSearch;
    }
}
