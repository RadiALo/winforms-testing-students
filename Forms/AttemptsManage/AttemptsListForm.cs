using System;
using System.Data;
using System.Windows.Forms;
using Testing_students.Forms.AttemptsManage.CreateAttempt;
using Testing_students.Forms.AttemptsManage.Info;

namespace Testing_students.Forms.AttemptsManage
{
    public partial class AttemptsListForm : Form
    {
        int testId;

        public AttemptsListForm()
        {
            InitializeComponent();
        }

        public AttemptsListForm(int testId) : this()
        {
            this.testId = testId;
            TestNameLabel.Text = Connector.ExecuteSelectQuery($"SELECT test_name FROM test WHERE test_id = {testId}").Rows[0].Field<string>(0);

            RefreshView();
        }

        private void AttemptViewButton_Click(object sender, EventArgs e)
        {
            // Відкриття форм перегляду детальної інформації
            if (AttemptsGridView.SelectedRows.Count > 0)
            {
                for (int i = 0; i < AttemptsGridView.SelectedRows.Count; i++)
                {
                    AttemptInfoForm form =
                        new AttemptInfoForm((DateTime)AttemptsGridView.SelectedRows[i].Cells[0].Value,
                            (string)AttemptsGridView.SelectedRows[i].Cells[3].Value, testId);
                    form.FormClosed += RefreshView;
                    form.Show();
                }
            }
        }

        private void CreateNewAttemptView_Click(object sender, EventArgs e)
        {
            // Відкриття форми створення нових спроб
            CreateAttemptForm form = new CreateAttemptForm(testId);
            form.ShowDialog();
            RefreshView();
        }


        private void RefreshView(object sender, EventArgs e)
        {
            RefreshView();
        }

        private void RefreshView()
        {
            DataTable attemptsInfo = Connector.ExecuteSelectQuery(
                $@"SELECT attempt.pass_time AS 'Дата закінчення', target_point AS 'Максимальна оцінка',
                AVG(edited_point) AS 'Середня оцінка', comment AS 'Коментар'
                FROM attempt JOIN test
                ON attempt.test_id = test.test_id
                WHERE attempt.test_id = {testId}
                GROUP BY attempt.pass_time, test_point, comment
                ORDER BY attempt.pass_time;"
            );

            AttemptsGridView.DataSource = attemptsInfo;
        }
    }
}
