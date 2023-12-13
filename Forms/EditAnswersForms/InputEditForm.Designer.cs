namespace Testing_students.Forms.EditAnswersForms
{
    partial class InputEditForm
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
            this.AnswerRightBox = new System.Windows.Forms.TextBox();
            this.AnswerRightLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AnswerRightBox
            // 
            this.AnswerRightBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AnswerRightBox.Location = new System.Drawing.Point(165, 12);
            this.AnswerRightBox.Name = "AnswerRightBox";
            this.AnswerRightBox.Size = new System.Drawing.Size(255, 22);
            this.AnswerRightBox.TabIndex = 0;
            // 
            // AnswerRightLabel
            // 
            this.AnswerRightLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.AnswerRightLabel.AutoSize = true;
            this.AnswerRightLabel.Location = new System.Drawing.Point(12, 15);
            this.AnswerRightLabel.Name = "AnswerRightLabel";
            this.AnswerRightLabel.Size = new System.Drawing.Size(147, 16);
            this.AnswerRightLabel.TabIndex = 1;
            this.AnswerRightLabel.Text = "Правильна відповідь:";
            // 
            // InputEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 43);
            this.Controls.Add(this.AnswerRightLabel);
            this.Controls.Add(this.AnswerRightBox);
            this.MaximumSize = new System.Drawing.Size(900, 90);
            this.MinimumSize = new System.Drawing.Size(450, 90);
            this.Name = "InputEditForm";
            this.Text = "З введенням";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InputEditForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox AnswerRightBox;
        private System.Windows.Forms.Label AnswerRightLabel;
    }
}