using System;
using System.Data;
using System.Windows.Forms;

namespace Testing_students.Forms.EditAnswersForms
{
    public partial class InputEditForm : Form
    {
        int questionId;

        public InputEditForm()
        {
            InitializeComponent();
        }

        public InputEditForm(int questionId) : this()
        {
            this.questionId = questionId;
            DataTable questionInfo = null;
            try
            {
                questionInfo = Connector.ExecuteSelectQuery(
                    $@"SELECT answer_right
                    FROM question
                    WHERE question_id = {questionId};"
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка:{ex.Message}", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

            if (questionInfo.Rows[0].Field<string>(0) != null)
            {
                AnswerRightBox.Text = questionInfo.Rows[0].Field<string>(0);
            }
        }

        private void InputEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AnswerRightBox.Text != "")
            {
                Connector.ExecuteQuery(
                    $@"UPDATE question
                    SET answer_right = '{AnswerRightBox.Text}',
                    answer_options = '-'
                    WHERE question_id = {questionId}"
                );
            }
            else
            {
                MessageBox.Show("Відповідь не може бути пустою!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }
    }
}
