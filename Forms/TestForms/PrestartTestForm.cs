using System;
using System.Data;
using System.Windows.Forms;

namespace Testing_students.Forms.TestForms
{
    public partial class PrestartTestForm : Form
    {
        private int attemptId;

        public PrestartTestForm()
        {
            InitializeComponent();
        }

        public PrestartTestForm(int attemptId) : this()
        {
            this.attemptId = attemptId;

            try
            {
                // Запит інформації про спробу
                DataTable attemptInfo = Connector.ExecuteSelectQuery(
                    $@"SELECT test.pass_time, test.test_description, test.test_name, test.questions_count, comment
                    FROM attempt JOIN test
                    ON attempt.test_id = test.test_id
                    WHERE attempt_id = {attemptId}"
                );

                // Відображення інформації
                TestNameLabel.Text = attemptInfo.Rows[0].Field<string>(2);
                TestDescriptionBox.Text = attemptInfo.Rows[0].Field<string>(1);
                QuestionsCountLabel.Text = "Кількість питань: " + attemptInfo.Rows[0].Field<int>(3).ToString();
                CommentBox.Text = attemptInfo.Rows[0].Field<string>(4);

                // Розрахування часу на проходження
                int seconds = attemptInfo.Rows[0].Field<int>(0);
                int minutes = seconds / 60;
                seconds = seconds % 60;
                PassTimeLabel.Text = $"Час на проходження: {minutes} хв. {seconds} с.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка:{ex.Message}", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void StartTestButton_Click(object sender, EventArgs e)
        {
            try
            {
                Connector.ExecuteQuery(
                    $@"UPDATE attempt
                    SET pass_status = 2,
                    start_time = '{DateTime.Now:yyyy-MM-dd HH:mm:ss}'
                    WHERE attempt_id = " + attemptId.ToString()
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка:{ex.Message}", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Відкриття форми тестування
            TestingForm form = new TestingForm(attemptId);
            form.Show();
            Close();
        }
    }
}
