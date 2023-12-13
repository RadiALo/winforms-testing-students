using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Testing_students.Forms.AttemptsManage.CreateAttempt
{
    public partial class CreateAttemptForm : Form
    {
        private List<string> studentIds = new List<string>();
        private List<string> studentNames = new List<string>();
        private List<int> clasessId = new List<int>();

        private int testId;

        public CreateAttemptForm()
        {
            InitializeComponent();
            ChooseDate.MinDate = DateTime.Now;
        }

        public CreateAttemptForm(int testId) : this()
        {
            this.testId = testId;

            DataTable classes = Connector.ExecuteSelectQuery(
                "SELECT class_id, class_name FROM class;"    
            );

            for (int i = 0; i < classes.Rows.Count; i++)
            {
                ChooseGroupsList.Items.Add(classes.Rows[i].Field<string>(1));
                clasessId.Add(classes.Rows[i].Field<int>(0));
            }

            DataTable students = Connector.ExecuteSelectQuery(
                "SELECT student_id, student_name FROM student;"
            );

            
            for (int i = 0; i < students.Rows.Count; i++)
            {
                ChooseStudentsList.Items.Add(students.Rows[i].Field<string>(1));
                studentIds.Add(students.Rows[i].Field<string>(0));
                studentNames.Add(students.Rows[i].Field<string>(1));
            }
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            List<string> students = new List<string>();
            List<string> names = new List<string>();

            foreach (int index in ChooseGroupsList.CheckedIndices)
            {
                DataTable stud = Connector.ExecuteSelectQuery(
                    $@"SELECT student_id, student_name FROM student
                    WHERE class_id = {clasessId[index]}"
                );

                for (int i = 0; i < stud.Rows.Count; i++)
                {
                    students.Add(stud.Rows[i].Field<string>(0));
                    names.Add(stud.Rows[i].Field<string>(1));
                }
            }

            foreach (int index in ChooseStudentsList.CheckedIndices)
            {
                if (!students.Contains(studentIds[index]))
                {
                    students.Add(studentIds[index]);
                    names.Add(studentNames[index]);
                }
            }

            BlackListForm form = new BlackListForm(students, names);
            form.ShowDialog();


            int maxId;
            DataTable dt =
                Connector.ExecuteSelectQuery("SELECT MAX(attempt_id) FROM attempt");

            if (dt.Rows[0].Field<int?>(0) != null) {
                maxId = dt.Rows[0].Field<int>(0);
            }
            else
            {
                maxId = -1;
            }

            int startId = maxId;
            int targetPoint = 
                Connector.ExecuteSelectQuery($"SELECT test_point FROM test WHERE test_id = {testId}").Rows[0].Field<int>(0);

            foreach (string index in students)
            {
                Connector.ExecuteQuery(
                    $@"INSERT INTO attempt(attempt_id, pass_status, pass_time, student_id, test_id, comment, target_point)
                    SELECT {++maxId}, 1, '{ChooseDate.Value:yyyy-MM-dd HH:mm:ss}', '{index}', {testId}, '{CommentBox.Text}', {targetPoint}"
                );

                if (!Attempt.GenerateAttemptQuestions(maxId, testId))
                {
                    while (maxId > startId) {
                        Connector.ExecuteQuery(
                            @"DELETE FROM answer
                            WHERE attempt_id = " + (--maxId).ToString() 
                        );

                        Connector.ExecuteQuery(
                            @"DELETE FROM attempt
                            WHERE attempt_id = " + (maxId).ToString()
                        );
                    }
                    Close();
                    return;
                }
            }

            Close();
        }
    }
}
