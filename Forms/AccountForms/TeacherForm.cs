using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Testing_students.Forms.AccountForms.Teachers;
using Testing_students.Forms.AttemptsManage;
using Testing_students.Forms.TestForms;

namespace Testing_students.Forms
{
    public partial class TeacherForm : Form
    {
        private string teacherLogin;
        public TeacherForm()
        {
            InitializeComponent();
        }

        public TeacherForm(string TeacherLogin) : this()
        {
            this.teacherLogin = TeacherLogin;
            RefreshView();
        }

        private void ReviewAttemptsButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ViewCreatedTests.SelectedRows.Count; i++)
            {
                AttemptsListForm attempts = new AttemptsListForm(
                  (int)(ViewCreatedTests.SelectedRows[i].Cells[0].Value)
                );
                attempts.Show();
            }
        }

        private void RateListButton_Click(object sender, EventArgs e)
        {
            RateListForm form = new RateListForm(teacherLogin);
            form.Show();
        }

        private void EditTestButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewCreatedTests.SelectedRows.Count > 0)
                {
                    for (int i = 0; i < ViewCreatedTests.SelectedRows.Count; i++)
                    {
                        EditTestForm editTest = new EditTestForm(
                          (int)(ViewCreatedTests.SelectedRows[i].Cells[0].Value)
                        );
                        editTest.Show();
                        editTest.FormClosing += RefreshView;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CreateTestButton_Click(object sender, EventArgs e)
        {
            DataTable dt = Connector.ExecuteSelectQuery(
                @"SELECT MAX(test_id) FROM test;"
            );
            int index = 0;
            if (dt.Rows.Count > 0)
            {
                try
                {
                    index = dt.Rows[0].Field<int>(0) + 1;
                }
                catch (Exception ex)
                {

                }
            }

            Connector.ExecuteQuery(
                $@"INSERT INTO test(test_id, test_name, test_description, questions_count, test_point, pass_time, teacher_login)
                VALUES({index}, '', '', 0, 0, 0, + '{teacherLogin}');"
            );
            EditTestForm editTest = new EditTestForm(index);
            editTest.Show();
            editTest.FormClosing += RefreshView;
        }

        private void RefreshView(object sender, EventArgs e)
        {
            RefreshView();
        }

        private void RefreshView()
        {
            DataTable testsInfo = Connector.ExecuteSelectQuery(
                $@"SELECT teacher_position, teacher_name
                FROM teacher WHERE teacher_login = '{teacherLogin}';");
            TeacherNameLabel.Text = testsInfo.Rows[0].Field<string>(1);
            TeacherLoginLabel.Text = "Посада: " + testsInfo.Rows[0].Field<string>(0);

            ViewCreatedTests.DataSource = Connector.ExecuteSelectQuery(
                    $@"SELECT test.test_id AS 'Id', test_name AS 'Назва тесту', test_description AS 'Опис',
                    questions_count AS 'Кількість питань', test_point AS 'Кількість балів', AVG(edited_point / test_point) AS 'Середній відсоток', AVG(edited_point) AS 'Середній бал', test.pass_time AS 'Час на проходження'
                    FROM test LEFT JOIN attempt ON test.test_id = attempt.test_id
                    WHERE teacher_login = '{teacherLogin}'
                    GROUP BY test.test_id;");
            (ViewCreatedTests.DataSource as DataTable).DefaultView.RowFilter = $@"[Назва тесту] LIKE '%{SearchBox.Text}%'";
            ViewCreatedTests.Columns[0].Visible = false;
        }

        private void DeleteTestButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewCreatedTests.SelectedRows.Count > 0)
                {
                    for (int i = 0; i < ViewCreatedTests.SelectedRows.Count; i++)
                    {
                        if (MessageBox.Show("Ви впевнені, що хочете видалити тест " + ViewCreatedTests.SelectedRows[i].Cells[1].Value.ToString() + "?",
                            "Увага!",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Connector.ExecuteQuery(
                                $@"DELETE FROM test
                                WHERE test_id = {ViewCreatedTests.SelectedRows[i].Cells[0].Value}"
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка:{ex.Message}", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            (ViewCreatedTests.DataSource as DataTable).DefaultView.RowFilter = $@"[Назва тесту] LIKE '%{SearchBox.Text}%'";
        }
    }
}

