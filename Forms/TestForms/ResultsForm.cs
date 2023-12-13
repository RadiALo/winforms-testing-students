using System;
using System.Data;
using System.Windows.Forms;

namespace Testing_students.Forms.TestForms
{
    public partial class ResultsForm : Form
    {
        int attemptId;

        public ResultsForm()
        {
            InitializeComponent();
        }

        public ResultsForm(int attemptId) : this()
        {
            this.attemptId = attemptId;

            // Запит інформації прл спробу
            DataTable dt = Connector.ExecuteSelectQuery(
                $@"SELECT edited_point, received_point, target_point
                FROM attempt WHERE attempt_id = {attemptId};"
            );

            int editedPoint = dt.Rows[0].Field<int>(0);
            int receivedPoint = dt.Rows[0].Field<int>(1);
            int targetPoint = dt.Rows[0].Field<int>(2);


            if (editedPoint == receivedPoint)
            {
                PointLabel.Text = $"{editedPoint}/{targetPoint}";
            }
            else
            {
                PointLabel.Text = $"{editedPoint}({receivedPoint})/{targetPoint}";
            }
        }

        private void AnswersInfoButton_Click(object sender, EventArgs e)
        {
            // Відкриття форми перегляду відповідей
            ReviewAttemptForm form = new ReviewAttemptForm(attemptId);
            form.Show();
            Close();
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            // Закриття форми
            Close();
        }
    }
}