namespace Testing_students.Forms.TestForms
{
    partial class TestingForm
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
            this.components = new System.ComponentModel.Container();
            this.QuestionsList = new System.Windows.Forms.TabControl();
            this.testing_studentsDataSet1 = new Testing_students.testing_studentsDataSet();
            this.TimeToEnd = new System.Windows.Forms.Timer(this.components);
            this.EndTestButton = new System.Windows.Forms.Button();
            this.TimerLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.testing_studentsDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // QuestionsList
            // 
            this.QuestionsList.AllowDrop = true;
            this.QuestionsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.QuestionsList.Location = new System.Drawing.Point(12, 12);
            this.QuestionsList.Name = "QuestionsList";
            this.QuestionsList.SelectedIndex = 0;
            this.QuestionsList.Size = new System.Drawing.Size(458, 356);
            this.QuestionsList.TabIndex = 0;
            // 
            // testing_studentsDataSet1
            // 
            this.testing_studentsDataSet1.DataSetName = "testing_studentsDataSet";
            this.testing_studentsDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // TimeToEnd
            // 
            this.TimeToEnd.Enabled = true;
            this.TimeToEnd.Interval = 1000;
            this.TimeToEnd.Tick += new System.EventHandler(this.TimeToEnd_Tick);
            // 
            // EndTestButton
            // 
            this.EndTestButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.EndTestButton.Location = new System.Drawing.Point(378, 372);
            this.EndTestButton.Name = "EndTestButton";
            this.EndTestButton.Size = new System.Drawing.Size(92, 23);
            this.EndTestButton.TabIndex = 2;
            this.EndTestButton.Text = "Закінчити";
            this.EndTestButton.UseVisualStyleBackColor = true;
            this.EndTestButton.Click += new System.EventHandler(this.EndTestButton_Click);
            // 
            // TimerLabel
            // 
            this.TimerLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.TimerLabel.AutoSize = true;
            this.TimerLabel.Location = new System.Drawing.Point(212, 375);
            this.TimerLabel.Name = "TimerLabel";
            this.TimerLabel.Size = new System.Drawing.Size(0, 16);
            this.TimerLabel.TabIndex = 1;
            // 
            // TestingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 406);
            this.Controls.Add(this.EndTestButton);
            this.Controls.Add(this.TimerLabel);
            this.Controls.Add(this.QuestionsList);
            this.MinimumSize = new System.Drawing.Size(500, 450);
            this.Name = "TestingForm";
            this.Text = "Тестування";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TestingForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.testing_studentsDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl QuestionsList;
        private testing_studentsDataSet testing_studentsDataSet1;
        private System.Windows.Forms.Timer TimeToEnd;
        private System.Windows.Forms.Button EndTestButton;
        private System.Windows.Forms.Label TimerLabel;
    }
}