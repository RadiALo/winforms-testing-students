using System;
using System.Data;
using System.Windows.Forms;

namespace Testing_students.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        // Натискання кнопки "Вхід"
        private void SignInButton_Click(object sender, EventArgs e)
        {
            // Введена інформація
            string login = LoginTextBox.Text;
            string password = PasswordTextBox.Text;

            // Перевірка чи здійснено вхід як адмін
            if (login == "admin" && password == "12345")
            {
                // Повідомлення про вхід в адмінський аккаунт
                MessageBox.Show("Ви увійшли як адміністратор", "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Відкриття адмінської форми
                AdminForm adminForm = new AdminForm();
                adminForm.FormClosing += UserLogout;
                adminForm.Show();
                Hide();
            }
            else
            {
                try
                {
                    // Запит даних для входу
                    DataTable studentsLoginInfo =
                        Connector.ExecuteSelectQuery(
                            $"SELECT student_id FROM student WHERE student_id = '{login}' AND student_password = '{password}'"
                        );
                    DataTable teachersLoginInfo =
                        Connector.ExecuteSelectQuery(
                            $"SELECT teacher_login FROM teacher WHERE teacher_login = '{login}' AND teacher_password = '{password}'"
                        );

                    // Перевірка чи здійснено вхід як студент
                    if (studentsLoginInfo.Rows.Count == 1)
                    {
                        // Відкриття студентської форми
                        StudentForm studentForm = new StudentForm(login);
                        studentForm.FormClosed += UserLogout;
                        studentForm.Show();
                        Hide();
                    }
                    // Перевірка чи здійснено вхід як викладач
                    else if (teachersLoginInfo.Rows.Count == 1)
                    {
                        // Відкриття викладатьскої форми
                        TeacherForm teacherForm = new TeacherForm(login);
                        teacherForm.FormClosed += UserLogout;
                        teacherForm.Show();
                        Hide();
                    }
                    else
                    {
                        // Повідомлення про те, що було введено невірні дані
                        MessageBox.Show("Неправильный логін або пароль!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(@"Помилка: " + ex.Message, "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        // Повернення головної форми після закриття аккаунту
        private void UserLogout(object sender, EventArgs e)
        {
            Show();
        }
    }
}
