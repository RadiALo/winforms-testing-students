using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Testing_students.Forms.AccountForms.Teachers
{
    public partial class PointsInfoForm : Form
    {
        string studentId;
        string teacherLogin;
        public PointsInfoForm()
        {
            InitializeComponent();
        }

        public PointsInfoForm(string studentId, string teacherLogin) : this()
        {
            StudentIdLabel.Text = this.studentId = studentId;
            this.teacherLogin = teacherLogin;

            PointsGridView.DataSource = Connector.ExecuteSelectQuery(
                $@"SELECT test_name AS 'Назва тесту', comment AS 'Коментар', pass_status_name AS 'Статус виконання', edited_point AS 'Оцінка', start_time AS 'Час початку'
                FROM test JOIN attempt
                ON test.test_id = attempt.test_id
                JOIN pass_status ON attempt.pass_status = pass_status.pass_status_id
                WHERE attempt.student_id = '{studentId}'"
            );
            (PointsGridView.DataSource as DataTable).DefaultView.RowFilter = $@"[Назва тесту] LIKE '%{SearchNameBox.Text}%'";
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            (PointsGridView.DataSource as DataTable).DefaultView.RowFilter = $@"[Назва тесту] LIKE '%{SearchNameBox.Text}%'";
        }

        private void FilterByTeacherBox_CheckedChanged(object sender, EventArgs e)
        {
            if (FilterByTeacherBox.Checked)
            {
                PointsGridView.DataSource = Connector.ExecuteSelectQuery(
                    $@"SELECT test_name AS 'Назва тесту', comment AS 'Коментар', pass_status_name AS 'Статус виконання', edited_point AS 'Оцінка', start_time AS 'Час початку'
                    FROM test JOIN attempt
                    ON test.test_id = attempt.test_id
                    JOIN pass_status ON attempt.pass_status = pass_status.pass_status_id
                    WHERE attempt.student_id = '{studentId}'
                    AND teacher_login = '{teacherLogin}'"
                );
            }
            else
            {
                PointsGridView.DataSource = Connector.ExecuteSelectQuery(
                    $@"SELECT test_name AS 'Назва тесту', comment AS 'Коментар', pass_status_name AS 'Статус виконання', edited_point AS 'Оцінка', start_time AS 'Час початку'
                    FROM test JOIN attempt
                    ON test.test_id = attempt.test_id
                    JOIN pass_status ON attempt.pass_status = pass_status.pass_status_id
                    WHERE attempt.student_id = '{studentId}'"
                );
            }
        }
    }
}
