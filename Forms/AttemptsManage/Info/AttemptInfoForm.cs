using System;
using System.Data;
using System.Windows.Forms;
using Testing_students.Forms.TestForms;
using IronPdf;

namespace Testing_students.Forms.AttemptsManage.Info
{
    public partial class AttemptInfoForm : Form
    {
        DateTime dateTime;
        string comment;
        int testId;
        ChangePointForm form;

        bool change;
        float point;

        public AttemptInfoForm()
        {
            InitializeComponent();
        }

        public AttemptInfoForm(DateTime dateTime, string comment, int testId) : this()
        {
            this.dateTime = dateTime;
            this.comment = comment;
            this.testId = testId;

            RefreshView();
        }

        private void ChangePointButton_Click(object sender, EventArgs e)
        {
            if (AttemptInfoGrid.SelectedRows.Count > 0)
            {
                // Отримання значення оцінки
                form = new ChangePointForm((int)AttemptInfoGrid.Rows[0].Cells[6].Value);
                form.ShowDialog();
                CheckPoint();

                if (change)
                {
                    // Зміна оцінки
                    for (int i = 0; i < AttemptInfoGrid.SelectedRows.Count; i++)
                    {
                        if (AttemptInfoGrid.SelectedRows[i].Cells[2].Value.ToString() != "Passed")
                        {
                            if (MessageBox.Show(
                                "Ви впевнені, що хочете змінити оцінку студента " +
                                AttemptInfoGrid.SelectedRows[i].Cells[1].Value.ToString() +
                                ", статус проходження якого " +
                                AttemptInfoGrid.SelectedRows[i].Cells[2].Value.ToString() + "?",
                                "Увага!",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.No)
                            {
                                continue;
                            }
                        }

                        Connector.ExecuteQuery(
                            $@"UPDATE attempt
                            SET edited_point = {point} 
                            WHERE attempt_id = {AttemptInfoGrid.SelectedRows[i].Cells[0].Value};"
                        );
                    }

                    RefreshView();
                }
            }
        }

        private void ClearAttempButton_Click(object sender, EventArgs e)
        {
            if (AttemptInfoGrid.SelectedRows.Count > 0)
            {
                // Запит на очищення
                if (MessageBox.Show("Ви впевнені, що бажаєте очистити "
                    + AttemptInfoGrid.SelectedRows.Count.ToString() + " спроб?", "Увага!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Очищення
                    for (int i = 0; i < AttemptInfoGrid.SelectedRows.Count; i++)
                    {
                        Connector.ExecuteQuery(
                            $@"UPDATE answer
                            SET answer_provided = NULL
                            WHERE attempt_id = {AttemptInfoGrid.SelectedRows[i].Cells[0].Value};"
                        );

                        Connector.ExecuteQuery(
                            $@"UPDATE attempt
                            SET start_time = NULL,
                            received_point = NULL,
                            edited_point = NULL,
                            pass_status = 5
                            WHERE attempt_id = {AttemptInfoGrid.SelectedRows[i].Cells[0].Value};"
                        );
                    }

                    RefreshView();
                }
            }
        }

        private void DeleteAttempButton_Click(object sender, EventArgs e)
        {
            if (AttemptInfoGrid.SelectedRows.Count > 0)
            {
                // Запит на видалення
                if (MessageBox.Show("Ви впевнені, що бажаєте видалити "
                    + AttemptInfoGrid.SelectedRows.Count.ToString() + " спроб?", "Увага!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Видалення
                    for (int i = 0; i < AttemptInfoGrid.SelectedRows.Count; i++)
                    {
                        Connector.ExecuteQuery(
                            $@"DELETE FROM attempt
                            WHERE attempt_id = {AttemptInfoGrid.SelectedRows[i].Cells[0].Value};"
                        );
                    }

                    RefreshView();
                }
            }
        }

        private void RefreshView()
        {
            DataTable attemptsInfo = Connector.ExecuteSelectQuery(
                $@"SELECT attempt_id AS 'Номер спроби', student_name AS 'ПІБ студента', pass_status_name AS 'Статус спроби',
                received_point AS 'Розрахована оцінка', edited_point AS 'Ітогова оцінка',
                target_point 'Максимальна оцінка', start_time AS 'Час початку'
                FROM attempt JOIN student
                ON attempt.student_id = student.student_id
                JOIN pass_status ON attempt.pass_status = pass_status_id
                WHERE comment = '{comment}'
                AND pass_time = '{dateTime:yyyy-MM-dd HH:mm:ss}'"
            );

            try
            {
                attemptsInfo.DefaultView.RowFilter = $@"[ПІБ студента] LIKE '%{SearchNameBox.Text}%' AND
                [Статус спроби] LIKE '%{SearchStatusBox.Text}%' AND [Ітогова оцінка] > {SearchPointBox.Text}";
            }
            catch (Exception ex)
            {
                attemptsInfo.DefaultView.RowFilter = $@"[ПІБ студента] LIKE '%{SearchNameBox.Text}%' AND
                [Статус спроби] LIKE '%{SearchStatusBox.Text}%'";
            }
            AttemptInfoGrid.DataSource = attemptsInfo;
        }

        private void CheckPoint()
        {
            change = form.Change;
            point = form.Point;
        }

        private void CheckAnswersButton_Click(object sender, EventArgs e)
        {
            if (AttemptInfoGrid.SelectedRows.Count > 0)
            {
                for (int i = 0; i < AttemptInfoGrid.SelectedRows.Count; i++)
                {
                    // Відкриття форм перевірки відповідей
                    ReviewAttemptForm form = 
                        new ReviewAttemptForm((int)AttemptInfoGrid.SelectedRows[i].Cells[0].Value);
                    form.Show();
                }
            }
        }

        private void ReviewPDFButton_Click(object sender, EventArgs e)
        {
            DataTable attemptsInfo = Connector.ExecuteSelectQuery(
                $@"SELECT attempt_id, student_name, class_name, pass_status_name, edited_point, start_time
                FROM attempt JOIN student
                ON attempt.student_id = student.student_id
                JOIN pass_status ON attempt.pass_status = pass_status_id
                JOIN class ON student.class_id = class.class_id
                WHERE comment = '{comment}'
                AND pass_time = '{dateTime:yyyy-MM-dd HH:mm:ss}'
                ORDER BY class_name, edited_point DESC, student_name, start_time"
            );

            DataTable testInfo = Connector.ExecuteSelectQuery(
                $@"SELECT test_name FROM test
                WHERE test_id = {testId}"
            );

            string testName = testInfo.Rows[0].Field<string>(0);

            string html = $@"<h1>Тест: {testName} </h1>
                            <h2>Дата створення звіту: {DateTime.Now:yyyy-MM-dd HH:mm:ss}</h2>
                            <table>
	                            <tr>
		                            <td>ПІБ</td>
		                            <td>ГРУПА</td>
		                            <td>СТАТУС</td>
		                            <td>ОЦІНКА</td>
		                            <td>ЧАС ПОЧАТКУ</td>
	                            </tr>";

            for (int i = 0; i < attemptsInfo.Rows.Count; i++)
            {
                string studentName = attemptsInfo.Rows[i].Field<string>(1);
                string studentClass = attemptsInfo.Rows[i].Field<string>(2);
                string passStatus = attemptsInfo.Rows[i].Field<string>(3);
                string point;
                if (attemptsInfo.Rows[i].Field<int?>(4) != null)
                {
                    point = attemptsInfo.Rows[i].Field<int>(4).ToString();
                }
                else
                {
                    point = "-";
                }


                if (attemptsInfo.Rows[i].Field<DateTime?>(5) != null)
                {
                    DateTime startTime = attemptsInfo.Rows[i].Field<DateTime>(5);
                    html += $@"<tr>
		                    <td>{studentName}</td>
		                    <td>{studentClass}</td>
		                    <td>{passStatus}</td>
		                    <td>{point}</td>
		                    <td>{startTime:yyyy-MM-dd HH-mm}</td>
	                    </tr>";
                }
                else
                {
                    html += $@"<tr>
		                    <td>{studentName}</td>
		                    <td>{studentClass}</td>
		                    <td>{passStatus}</td>
		                    <td>{point}</td>
		                    <td>-</td>
	                    </tr>";
                }

                
            }

            html += $@"</table>";

            var Renderer = new ChromePdfRenderer();
            var AttemptView = Renderer.RenderHtmlAsPdf(html);
            AttemptView.SaveAs($"Reviews\\Session_{dateTime:yyyy_MM_dd}_{testName}_review.pdf");
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (AttemptInfoGrid.DataSource as DataTable).DefaultView.RowFilter = $@"[ПІБ студента] LIKE '%{SearchNameBox.Text}%' AND
                [Статус спроби] LIKE '%{SearchStatusBox.Text}%' AND [Ітогова оцінка] >= {SearchPointBox.Text}";
            }
            catch (Exception ex)
            {
                (AttemptInfoGrid.DataSource as DataTable).DefaultView.RowFilter = $@"[ПІБ студента] LIKE '%{SearchNameBox.Text}%' AND
                [Статус спроби] LIKE '%{SearchStatusBox.Text}%'";
            }
        }
    }
}
