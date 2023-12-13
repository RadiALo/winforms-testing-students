using System;
using System.Data;
using System.Windows.Forms;
using Testing_students.Forms.TestForms;

namespace Testing_students
{
    public partial class StudentForm : Form
    {
        private string studentId;
        public StudentForm()
        {
            InitializeComponent();
        }

        public StudentForm(string StudentId) : this()
        {
            this.studentId = StudentId;
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable studentInfo = Connector.ExecuteSelectQuery(
                    $@"SELECT student.student_id, student_name, class_name 
                    FROM student INNER JOIN class ON student.class_id = class.class_id
                    WHERE student_id = '{studentId}';"
                );
                StudentNameLabel.Text = studentInfo.Rows[0].Field<string>(1);
                StudentGroupLabel.Text = "Група: " + studentInfo.Rows[0].Field<string>(2);
                StudentIdLabel.Text = "Номер студентського: " + studentInfo.Rows[0].Field<string>(0);

                RefreshView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка:{ex.Message}", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void MenuTabs_Selected(object sender, TabControlEventArgs e)
        {
            RefreshView();
        }

        private void StartTestButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewEnabledTests.SelectedRows.Count > 0)
                {
                    PrestartTestForm form = new PrestartTestForm(
                        (int)ViewEnabledTests.SelectedRows[0].Cells[0].Value
                    );

                    form.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReviewAttemptButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewEndedTests.SelectedRows.Count > 0)
                {
                    ReviewAttemptForm form = new ReviewAttemptForm(
                        (int)ViewEndedTests.SelectedRows[0].Cells[0].Value
                    );

                    form.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshView(object sender, EventArgs e)
        {
            RefreshView();
        }
        private void RefreshView()
        {
            CheckPassStatuses();

            ViewEnabledTests.DataSource = Connector.ExecuteSelectQuery(
                 $@"SELECT attempt_id AS 'Номер спроби', test_name AS 'Назва тесту', test_description AS 'Опис',
                 questions_count AS 'Кількість питань', target_point AS 'Кількість балів', attempt.pass_time AS 'Пройти до'
                 FROM test JOIN attempt ON test.test_id = attempt.test_id
                 WHERE attempt.pass_status = 1 AND attempt.student_id = '{studentId}';"
            );

            (ViewEnabledTests.DataSource as DataTable).DefaultView.RowFilter = $"[Назва тесту] LIKE '%{SeacrhBox.Text}%'";

            ViewEndedTests.DataSource = Connector.ExecuteSelectQuery(
                $@"SELECT attempt_id AS 'Номер спроби', test_name AS 'Назва тесту', test_description AS 'Опис', CONCAT(edited_point, '/', target_point) AS 'Оцінка', pass_status_name AS 'Статус'
                FROM test JOIN attempt ON test.test_id = attempt.test_id
                JOIN pass_Status ON attempt.pass_status = pass_status_id
                WHERE (attempt.pass_status = 3 OR attempt.pass_status = 4)
                AND attempt.student_id = '{studentId}';"
           );

            (ViewEndedTests.DataSource as DataTable).DefaultView.RowFilter = $"[Назва тесту] LIKE '%{SeacrhBox.Text}%'";
        }

        private void CheckPassStatuses()
        {
            DataTable attemptsInfo = Connector.ExecuteSelectQuery(
                 $@"SELECT pass_status, attempt_id, test_name, test_description,
                 questions_count, test_point, attempt.pass_time, attempt.start_time
                 FROM test JOIN attempt ON test.test_id = attempt.test_id
                 WHERE attempt.student_id = '{studentId}';"
            );

            for (int i = 0; i < attemptsInfo.Rows.Count; i++)
            {
                int passStatus = attemptsInfo.Rows[i].Field<int>(0);
                if (passStatus == 1)
                {
                    DateTime passTime = attemptsInfo.Rows[i].Field<DateTime>(6);
                    string testName = attemptsInfo.Rows[i].Field<string>(2);
                    int attemptId = attemptsInfo.Rows[i].Field<int>(1);
                    if (passTime <= DateTime.Now)
                    {
                        // Змінити на Wasted
                        Connector.ExecuteQuery(
                            $@"UPDATE attempt
                            SET pass_status = 3
                            WHERE attempt_id = {attemptId}"    
                        );

                        MessageBox.Show($"Час на проходження тесту {testName}({attemptId}) вичерпано!",
                            "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (passTime <= DateTime.Now.AddDays(3))
                    {
                        // Повідомлення про те, що тест скоро закриється
                        MessageBox.Show($"До закриття тесту {testName}({attemptId}) залишилося меньше ніж 3 дні!",
                            "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (passStatus == 5)
                {
                    string testName = attemptsInfo.Rows[i].Field<string>(2);
                    int attemptId = attemptsInfo.Rows[i].Field<int>(1);
                    // Змінити тест на запланований
                    Connector.ExecuteQuery(
                            $@"UPDATE attempt
                            SET pass_status = 1
                            WHERE attempt_id = {attemptId}"
                        );
                    // Повідомленя про очищнення спроби
                    MessageBox.Show($"Вашу спробу виконання тесту {testName}({attemptId}) було очищено. Необіхдно знову виконати тест!",
                           "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            RefreshView();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            (ViewEnabledTests.DataSource as DataTable).DefaultView.RowFilter = $"[Назва тесту] LIKE '%{SeacrhBox.Text}%'";
            (ViewEndedTests.DataSource as DataTable).DefaultView.RowFilter = $"[Назва тесту] LIKE '%{SeacrhBox.Text}%'";
        }
    }
}