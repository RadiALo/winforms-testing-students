namespace Testing_students.Forms.TestForms
{
    partial class EditTestForm
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
            this.TestNameLabel = new System.Windows.Forms.Label();
            this.TestNameBox = new System.Windows.Forms.TextBox();
            this.QuestionsCountBox = new System.Windows.Forms.TextBox();
            this.QuestionsCountLabel = new System.Windows.Forms.Label();
            this.PointBox = new System.Windows.Forms.TextBox();
            this.PointLabel = new System.Windows.Forms.Label();
            this.PassTimeBox = new System.Windows.Forms.TextBox();
            this.PassTimeLabel = new System.Windows.Forms.Label();
            this.AddQuestionButton = new System.Windows.Forms.Button();
            this.testing_studentsDataSet1 = new Testing_students.testing_studentsDataSet();
            this.DescriptionBox = new System.Windows.Forms.TextBox();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.QuestionsPanel = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.testing_studentsDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // TestNameLabel
            // 
            this.TestNameLabel.AutoSize = true;
            this.TestNameLabel.Location = new System.Drawing.Point(13, 13);
            this.TestNameLabel.Name = "TestNameLabel";
            this.TestNameLabel.Size = new System.Drawing.Size(89, 16);
            this.TestNameLabel.TabIndex = 0;
            this.TestNameLabel.Text = "Назва тесту";
            // 
            // TestNameBox
            // 
            this.TestNameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TestNameBox.Location = new System.Drawing.Point(108, 10);
            this.TestNameBox.Name = "TestNameBox";
            this.TestNameBox.Size = new System.Drawing.Size(619, 22);
            this.TestNameBox.TabIndex = 1;
            // 
            // QuestionsCountBox
            // 
            this.QuestionsCountBox.Location = new System.Drawing.Point(131, 38);
            this.QuestionsCountBox.Name = "QuestionsCountBox";
            this.QuestionsCountBox.Size = new System.Drawing.Size(65, 22);
            this.QuestionsCountBox.TabIndex = 5;
            // 
            // QuestionsCountLabel
            // 
            this.QuestionsCountLabel.AutoSize = true;
            this.QuestionsCountLabel.Location = new System.Drawing.Point(13, 41);
            this.QuestionsCountLabel.Name = "QuestionsCountLabel";
            this.QuestionsCountLabel.Size = new System.Drawing.Size(113, 16);
            this.QuestionsCountLabel.TabIndex = 4;
            this.QuestionsCountLabel.Text = "Кількість питань";
            // 
            // PointBox
            // 
            this.PointBox.Location = new System.Drawing.Point(259, 38);
            this.PointBox.Name = "PointBox";
            this.PointBox.Size = new System.Drawing.Size(51, 22);
            this.PointBox.TabIndex = 7;
            // 
            // PointLabel
            // 
            this.PointLabel.AutoSize = true;
            this.PointLabel.Location = new System.Drawing.Point(202, 41);
            this.PointLabel.Name = "PointLabel";
            this.PointLabel.Size = new System.Drawing.Size(51, 16);
            this.PointLabel.TabIndex = 6;
            this.PointLabel.Text = "Оцінка";
            // 
            // PassTimeBox
            // 
            this.PassTimeBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PassTimeBox.Location = new System.Drawing.Point(627, 38);
            this.PassTimeBox.Name = "PassTimeBox";
            this.PassTimeBox.Size = new System.Drawing.Size(100, 22);
            this.PassTimeBox.TabIndex = 9;
            // 
            // PassTimeLabel
            // 
            this.PassTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PassTimeLabel.AutoSize = true;
            this.PassTimeLabel.Location = new System.Drawing.Point(482, 41);
            this.PassTimeLabel.Name = "PassTimeLabel";
            this.PassTimeLabel.Size = new System.Drawing.Size(139, 16);
            this.PassTimeLabel.TabIndex = 8;
            this.PassTimeLabel.Text = "Час на проходження";
            // 
            // AddQuestionButton
            // 
            this.AddQuestionButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.AddQuestionButton.Location = new System.Drawing.Point(359, 279);
            this.AddQuestionButton.Name = "AddQuestionButton";
            this.AddQuestionButton.Size = new System.Drawing.Size(40, 35);
            this.AddQuestionButton.TabIndex = 15;
            this.AddQuestionButton.Text = "+";
            this.AddQuestionButton.UseVisualStyleBackColor = true;
            this.AddQuestionButton.Click += new System.EventHandler(this.AddQuestionButton_Click);
            // 
            // testing_studentsDataSet1
            // 
            this.testing_studentsDataSet1.DataSetName = "testing_studentsDataSet";
            this.testing_studentsDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionBox.Location = new System.Drawing.Point(12, 317);
            this.DescriptionBox.Multiline = true;
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.Size = new System.Drawing.Size(708, 74);
            this.DescriptionBox.TabIndex = 16;
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(13, 298);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(43, 16);
            this.DescriptionLabel.TabIndex = 17;
            this.DescriptionLabel.Text = "Опис:";
            // 
            // QuestionsPanel
            // 
            this.QuestionsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.QuestionsPanel.AutoScroll = true;
            this.QuestionsPanel.Location = new System.Drawing.Point(16, 66);
            this.QuestionsPanel.Name = "QuestionsPanel";
            this.QuestionsPanel.Size = new System.Drawing.Size(711, 207);
            this.QuestionsPanel.TabIndex = 18;
            // 
            // EditTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(732, 403);
            this.Controls.Add(this.AddQuestionButton);
            this.Controls.Add(this.QuestionsPanel);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.DescriptionBox);
            this.Controls.Add(this.PassTimeBox);
            this.Controls.Add(this.PassTimeLabel);
            this.Controls.Add(this.PointBox);
            this.Controls.Add(this.PointLabel);
            this.Controls.Add(this.QuestionsCountBox);
            this.Controls.Add(this.QuestionsCountLabel);
            this.Controls.Add(this.TestNameBox);
            this.Controls.Add(this.TestNameLabel);
            this.MinimumSize = new System.Drawing.Size(750, 450);
            this.Name = "EditTestForm";
            this.Text = "Редагування тесту";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditTestForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.testing_studentsDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TestNameLabel;
        private System.Windows.Forms.TextBox TestNameBox;
        private System.Windows.Forms.TextBox QuestionsCountBox;
        private System.Windows.Forms.Label QuestionsCountLabel;
        private System.Windows.Forms.TextBox PointBox;
        private System.Windows.Forms.Label PointLabel;
        private System.Windows.Forms.TextBox PassTimeBox;
        private System.Windows.Forms.Label PassTimeLabel;
        private System.Windows.Forms.Button AddQuestionButton;
        private testing_studentsDataSet testing_studentsDataSet1;
        private System.Windows.Forms.TextBox DescriptionBox;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.FlowLayoutPanel QuestionsPanel;
    }
}