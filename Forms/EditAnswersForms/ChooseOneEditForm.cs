using System;
using System.Data;
using System.Windows.Forms;

namespace Testing_students.Forms.EditAnswersForms
{
    public partial class ChooseOneEditForm : Form
    {
        int questionId;

        public ChooseOneEditForm()
        {
            InitializeComponent();
        }

        public ChooseOneEditForm(int questionId) : this()
        {
            this.questionId = questionId;

            DataTable questionInfo = null;

            try
            {
                questionInfo = Connector.ExecuteSelectQuery(
                    $@"SELECT answer_right, answer_options
                    FROM question
                    WHERE question_id = {questionId}"
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка:{ex.Message}", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

            if (questionInfo.Rows[0].Field<string>(0) == null)
            {
                RadioButton1.Checked = true;
            }
            else
            {
                switch (questionInfo.Rows[0].Field<string>(0))
                {
                    case "a":
                        RadioButton1.Checked = true;
                        break;
                    case "b":
                        RadioButton2.Checked = true;
                        break;
                    case "c":
                        RadioButton3.Checked = true;
                        break;
                    case "d":
                        RadioButton4.Checked = true;
                        break;
                    default:
                        RadioButton1.Checked = true;
                        break;
                }
            }

            if (questionInfo.Rows[0].Field<string>(1) != null)
            {
                bool exist = true;
                string content = Question.GetContentTag(questionInfo.Rows[0].Field<string>(1), "a", out exist);

                if (exist)
                {
                    Option1Box.Text = content;
                }

                content = Question.GetContentTag(questionInfo.Rows[0].Field<string>(1), "b", out exist);

                if (exist)
                {
                    Option2Box.Text = content;
                }

                content = Question.GetContentTag(questionInfo.Rows[0].Field<string>(1), "c", out exist);

                if (exist)
                {
                    Option3Box.Text = content;
                }

                content = Question.GetContentTag(questionInfo.Rows[0].Field<string>(1), "d", out exist);

                if (exist)
                {
                    Option4Box.Text = content;
                }
            }
        }

        private string GenerateAnswerOptions()
        {
            string options = "";
            bool space = false;

            if (Option1Box.Text != "")
            {
                if (!space)
                {
                    options += "<a>" + Option1Box.Text + "<a/>";
                }
                else
                {
                    MessageBox.Show("Пункт b не було додано! Спочатку треба заповнити попередні!",
                        "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                space = true;
            }

            if (Option2Box.Text != "")
            {
                if (!space)
                {
                    options += "<b>" + Option2Box.Text + "<b/>";
                }
                else
                {
                    MessageBox.Show("Пункт b не було додано! Спочатку треба заповнити попередні!",
                        "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                space = true;
            }

            if (Option3Box.Text != "")
            {
                if (!space)
                {
                    options += "<c>" + Option3Box.Text + "<c/>";
                }
                else
                {
                    MessageBox.Show("Пункт c не було додано! Спочатку треба заповнити попередні!",
                        "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                space = true;
            }

            if (Option4Box.Text != "")
            {
                if (!space)
                {
                    options += "<d>" + Option4Box.Text + "<d/>";
                }
                else
                {
                    MessageBox.Show("Пункт d не було додано! Спочатку треба заповнити попередні!",
                        "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                space = true;
            }

            return options;
        }


        private void ChooseOneEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            string AnswerRight = "error";

            if (RadioButton1.Checked)
            {
                AnswerRight = "a";
            }
            else if (Option1Box.Text == "")
            {
                e.Cancel = true;
                MessageBox.Show("Мають існувати всі варіанти до обраного!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (RadioButton2.Checked && Option2Box.Text != "")
            {
                
                AnswerRight = "b";
            }
            else if (Option2Box.Text == "")
            {
                e.Cancel = true;
                MessageBox.Show("Мають існувати всі варіанти до обраного!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (RadioButton3.Checked && Option3Box.Text != "")
            {
                AnswerRight = "c";
            }
            else if (Option3Box.Text == "")
            {
                e.Cancel = true;
                MessageBox.Show("Мають існувати всі варіанти до обраного!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (RadioButton4.Checked && Option4Box.Text != "")
            {
                AnswerRight = "d";
            }

            if (AnswerRight != "error")
            {
                Connector.ExecuteQuery(
                    $@"UPDATE question
                    SET answer_right = '{AnswerRight}',
                    answer_options = '{GenerateAnswerOptions()}' 
                    WHERE question_id = {questionId};"
                );
            }
            else
            {
                MessageBox.Show("Обраний варіант має мати зміст!", "Помилка!", MessageBoxButtons.OK,MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }
    }
}
