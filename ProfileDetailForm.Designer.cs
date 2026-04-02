namespace MyFlaglerApp2026
{
    partial class ProfileDetailForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblReport = new Label();
            SuspendLayout();
            // 
            // lblReport
            // 
            lblReport.AutoSize = true;
            lblReport.Location = new Point(88, 104);
            lblReport.Name = "lblReport";
            lblReport.Size = new Size(78, 32);
            lblReport.TabIndex = 0;
            lblReport.Text = "label1";
            // 
            // ProfileDetailForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1434, 786);
            Controls.Add(lblReport);
            Name = "ProfileDetailForm";
            Text = "ProfileDetailForm";
            Controls.SetChildIndex(lblReport, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblReport;
    }
}