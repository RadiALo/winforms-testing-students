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
    public partial class RateListForm : Form
    {
        string teacherLogin;
        public RateListForm()
        {
            InitializeComponent();
        }

        public RateListForm(string teacherLogin) : this()
        {
            this.teacherLogin = teacherLogin;
            DataTable pointsInfo = Connector.ExecuteSelectQuery(
                $@"SELECT student.student_name AS 'ПІБ студента', student.student_id AS 'Номер студентського', class.class_name AS 'Група', AVG(attempt.received_point / attempt.target_point) AS 'Відсоток отриманих балів'
                FROM teacher JOIN test
                ON teacher.teacher_login = test.teacher_login
                JOIN attempt
                ON attempt.test_id = test.test_id
                JOIN student
                ON attempt.student_id = student.student_id
                JOIN class
                ON student.class_id = class.class_id
                GROUP BY student.student_id
                ORDER BY AVG(attempt.received_point / attempt.target_point) DESC"
            );

            pointsInfo.DefaultView.RowFilter = $"'ПІБ студента' LIKE '%{SearchNameBox.Text}%' AND 'Група' LIKE '%{SearchGroupBox.Text}%'";

            RateGridView.DataSource = pointsInfo;
        }

        private void PointsInfoButton_Click(object sender, EventArgs e)
        {
            if (RateGridView.SelectedRows.Count > 0)
            {
                for (int i = 0; i < RateGridView.SelectedRows.Count; i++)
                {
                    PointsInfoForm form = new PointsInfoForm(RateGridView.SelectedRows[i].Cells[1].Value.ToString(), teacherLogin);
                    form.Show();
                }
            }
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            (RateGridView.DataSource as DataTable).DefaultView.RowFilter = $"[ПІБ студента] LIKE '%{SearchNameBox.Text}%' AND [Група] LIKE '%{SearchGroupBox.Text}%'";
        }
    }
}
