namespace Testing_students.Forms.AccountForms.Teachers
{
    partial class RateListForm
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
            this.RateGridView = new System.Windows.Forms.DataGridView();
            this.PointsInfoButton = new System.Windows.Forms.Button();
            this.SeacrhNameLabel = new System.Windows.Forms.Label();
            this.SearchNameBox = new System.Windows.Forms.TextBox();
            this.SearchGroupBox = new System.Windows.Forms.TextBox();
            this.SearchGroupLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.RateGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // RateGridView
            // 
            this.RateGridView.AllowUserToAddRows = false;
            this.RateGridView.AllowUserToDeleteRows = false;
            this.RateGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RateGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RateGridView.Location = new System.Drawing.Point(12, 12);
            this.RateGridView.Name = "RateGridView";
            this.RateGridView.ReadOnly = true;
            this.RateGridView.RowHeadersWidth = 51;
            this.RateGridView.RowTemplate.Height = 24;
            this.RateGridView.Size = new System.Drawing.Size(558, 395);
            this.RateGridView.TabIndex = 0;
            // 
            // PointsInfoButton
            // 
            this.PointsInfoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PointsInfoButton.Location = new System.Drawing.Point(454, 418);
            this.PointsInfoButton.Name = "PointsInfoButton";
            this.PointsInfoButton.Size = new System.Drawing.Size(116, 23);
            this.PointsInfoButton.TabIndex = 1;
            this.PointsInfoButton.Text = "Оцінки";
            this.PointsInfoButton.UseVisualStyleBackColor = true;
            this.PointsInfoButton.Click += new System.EventHandler(this.PointsInfoButton_Click);
            // 
            // SeacrhNameLabel
            // 
            this.SeacrhNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SeacrhNameLabel.AutoSize = true;
            this.SeacrhNameLabel.Location = new System.Drawing.Point(12, 421);
            this.SeacrhNameLabel.Name = "SeacrhNameLabel";
            this.SeacrhNameLabel.Size = new System.Drawing.Size(32, 16);
            this.SeacrhNameLabel.TabIndex = 2;
            this.SeacrhNameLabel.Text = "Ім\'я:";
            // 
            // SearchNameBox
            // 
            this.SearchNameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchNameBox.Location = new System.Drawing.Point(50, 419);
            this.SearchNameBox.Name = "SearchNameBox";
            this.SearchNameBox.Size = new System.Drawing.Size(222, 22);
            this.SearchNameBox.TabIndex = 3;
            this.SearchNameBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            // 
            // SearchGroupBox
            // 
            this.SearchGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchGroupBox.Location = new System.Drawing.Point(333, 419);
            this.SearchGroupBox.Name = "SearchGroupBox";
            this.SearchGroupBox.Size = new System.Drawing.Size(115, 22);
            this.SearchGroupBox.TabIndex = 5;
            this.SearchGroupBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            // 
            // SearchGroupLabel
            // 
            this.SearchGroupLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchGroupLabel.AutoSize = true;
            this.SearchGroupLabel.Location = new System.Drawing.Point(278, 422);
            this.SearchGroupLabel.Name = "SearchGroupLabel";
            this.SearchGroupLabel.Size = new System.Drawing.Size(49, 16);
            this.SearchGroupLabel.TabIndex = 4;
            this.SearchGroupLabel.Text = "Група:";
            // 
            // RateListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 453);
            this.Controls.Add(this.SearchGroupBox);
            this.Controls.Add(this.SearchGroupLabel);
            this.Controls.Add(this.SearchNameBox);
            this.Controls.Add(this.SeacrhNameLabel);
            this.Controls.Add(this.PointsInfoButton);
            this.Controls.Add(this.RateGridView);
            this.MaximumSize = new System.Drawing.Size(1200, 1000);
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "RateListForm";
            this.Text = "Рейтинговий список";
            ((System.ComponentModel.ISupportInitialize)(this.RateGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView RateGridView;
        private System.Windows.Forms.Button PointsInfoButton;
        private System.Windows.Forms.Label SeacrhNameLabel;
        private System.Windows.Forms.TextBox SearchNameBox;
        private System.Windows.Forms.TextBox SearchGroupBox;
        private System.Windows.Forms.Label SearchGroupLabel;
    }
}