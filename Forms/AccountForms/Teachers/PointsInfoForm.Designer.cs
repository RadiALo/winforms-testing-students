namespace Testing_students.Forms.AccountForms.Teachers
{
    partial class PointsInfoForm
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
            this.PointsGridView = new System.Windows.Forms.DataGridView();
            this.StudentIdLabel = new System.Windows.Forms.Label();
            this.SearchNameBox = new System.Windows.Forms.TextBox();
            this.SearchNameLabel = new System.Windows.Forms.Label();
            this.FilterByTeacherBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.PointsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // PointsGridView
            // 
            this.PointsGridView.AllowUserToAddRows = false;
            this.PointsGridView.AllowUserToDeleteRows = false;
            this.PointsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PointsGridView.Location = new System.Drawing.Point(12, 35);
            this.PointsGridView.Name = "PointsGridView";
            this.PointsGridView.ReadOnly = true;
            this.PointsGridView.RowHeadersWidth = 51;
            this.PointsGridView.RowTemplate.Height = 24;
            this.PointsGridView.Size = new System.Drawing.Size(776, 384);
            this.PointsGridView.TabIndex = 0;
            // 
            // StudentIdLabel
            // 
            this.StudentIdLabel.AutoSize = true;
            this.StudentIdLabel.Location = new System.Drawing.Point(12, 9);
            this.StudentIdLabel.Name = "StudentIdLabel";
            this.StudentIdLabel.Size = new System.Drawing.Size(63, 16);
            this.StudentIdLabel.TabIndex = 1;
            this.StudentIdLabel.Text = "StudentId";
            // 
            // SearchNameBox
            // 
            this.SearchNameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchNameBox.Location = new System.Drawing.Point(70, 422);
            this.SearchNameBox.Name = "SearchNameBox";
            this.SearchNameBox.Size = new System.Drawing.Size(183, 22);
            this.SearchNameBox.TabIndex = 2;
            this.SearchNameBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            // 
            // SearchNameLabel
            // 
            this.SearchNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SearchNameLabel.AutoSize = true;
            this.SearchNameLabel.Location = new System.Drawing.Point(12, 425);
            this.SearchNameLabel.Name = "SearchNameLabel";
            this.SearchNameLabel.Size = new System.Drawing.Size(52, 16);
            this.SearchNameLabel.TabIndex = 3;
            this.SearchNameLabel.Text = "Назва:";
            // 
            // FilterByTeacherBox
            // 
            this.FilterByTeacherBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FilterByTeacherBox.AutoSize = true;
            this.FilterByTeacherBox.Location = new System.Drawing.Point(259, 424);
            this.FilterByTeacherBox.Name = "FilterByTeacherBox";
            this.FilterByTeacherBox.Size = new System.Drawing.Size(199, 20);
            this.FilterByTeacherBox.TabIndex = 4;
            this.FilterByTeacherBox.Text = "Показати тільки мої тести";
            this.FilterByTeacherBox.UseVisualStyleBackColor = true;
            this.FilterByTeacherBox.CheckedChanged += new System.EventHandler(this.FilterByTeacherBox_CheckedChanged);
            // 
            // PointsInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.FilterByTeacherBox);
            this.Controls.Add(this.SearchNameLabel);
            this.Controls.Add(this.SearchNameBox);
            this.Controls.Add(this.StudentIdLabel);
            this.Controls.Add(this.PointsGridView);
            this.Name = "PointsInfoForm";
            this.Text = "Оцінки";
            ((System.ComponentModel.ISupportInitialize)(this.PointsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView PointsGridView;
        private System.Windows.Forms.Label StudentIdLabel;
        private System.Windows.Forms.TextBox SearchNameBox;
        private System.Windows.Forms.Label SearchNameLabel;
        private System.Windows.Forms.CheckBox FilterByTeacherBox;
    }
}