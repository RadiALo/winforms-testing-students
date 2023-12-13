using System;
using System.Data;
using System.Windows.Forms;

namespace Testing_students.Forms.EditAnswersForms
{
    public partial class RelateEditForm : Form
    {
        int questionId;

        public RelateEditForm()
        {
            InitializeComponent();
        }

        public RelateEditForm(int questionId) : this()
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

            if (questionInfo.Rows[0].Field<string>(0) != null)
            {
                bool exist;

                string content = Question.GetContentTag(questionInfo.Rows[0].Field<string>(0), "a", out exist);

                if (exist)
                {
                    Answer1Box.Text = content;
                }

                content = Question.GetContentTag(questionInfo.Rows[0].Field<string>(0), "b", out exist);

                if (exist)
                {
                    Answer2Box.Text = content;
                }

                content = Question.GetContentTag(questionInfo.Rows[0].Field<string>(0), "c", out exist);

                if (exist)
                {
                    Answer3Box.Text = content;
                }

                content = Question.GetContentTag(questionInfo.Rows[0].Field<string>(0), "d", out exist);

                if (exist)
                {
                    Answer4Box.Text = content;
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

        private string GenerateOptions()
        {
            string options = "";
            bool space = false;

            if (Option1Box.Text != "" && Answer1Box.Text != "")
            {
                options += "<a>" + Option1Box.Text + "<a/>";
            }
            else
            {
                space = true;
            }

            if (Option2Box.Text != "" && Answer2Box.Text != "")
            {
                if (!space)
                {
                    options += "<b>" + Option2Box.Text + "<b/>";
                }
                else
                {
                    MessageBox.Show("Відношення b не було додано! Спочатку треба заповнити попередні!",
                        "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                space = true;
            }

            if (Option3Box.Text != "" && Answer3Box.Text != "")
            {
                if (!space)
                {
                    options += "<c>" + Option3Box.Text + "<c/>";
                }
                else
                {
                    MessageBox.Show("Відношення c не було додано! Спочатку треба заповнити попередні!",
                        "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                space = true;
            }

            if (Option4Box.Text != "" && Answer4Box.Text != "")
            {
                if (!space)
                {
                    options += "<d>" + Option4Box.Text + "<d/>";
                }
                else
                {
                    MessageBox.Show("Відношення d не було додано! Спочатку треба заповнити попередні!",
                        "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }

            return options;
        }

        private string GenerateAnswers()
        {
            string options = "";

            if (Option1Box.Text != "" && Answer1Box.Text != "")
            {
                options += "<a>" + Answer1Box.Text + "<a/>";
            }
            else
            {
                return options;
            }

            if (Option2Box.Text != "" && Answer2Box.Text != "")
            {
                options += "<b>" + Answer2Box.Text + "<b/>";
            }
            else
            {
                return options;
            }

            if (Option3Box.Text != "" && Answer3Box.Text != "")
            {
                options += "<c>" + Answer3Box.Text + "<c/>";
            }
            else
            {
                return options;
            }

            if (Option4Box.Text != "" && Answer4Box.Text != "")
            {
                options += "<d>" + Answer4Box.Text + "<d/>";
            }
            else
            {
                return options;
            }

            return options;
        }

        private void RelateEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string options = "";
            string answers = "";
            bool space = false;

            if (Option1Box.Text != "" || Answer1Box.Text != "")
            {
                if (Option1Box.Text != "" && Answer1Box.Text != "")
                {
                    options += "<a>" + Option1Box.Text + "<a/>";
                    answers += "<a>" + Answer1Box.Text + "<a/>";
                }
                else
                {
                    MessageBox.Show("Жодна пара співвідношення не може мати пустих значень!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }
            }
            else
            {
                space = true;
            }

            if (!space)
            {
                if (Option2Box.Text != "" || Answer2Box.Text != "")
                {
                    if (Option2Box.Text != "" && Answer2Box.Text != "")
                    {
                        options += "<b>" + Option1Box.Text + "<b/>";
                        answers += "<b>" + Answer1Box.Text + "<b/>";
                    }
                    else
                    {
                        MessageBox.Show("Жодна пара співвідношення не може мати пустих значень!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        return;
                    }
                }
                else
                {
                    space = true;
                }
            }

            if (!space)
            {
                if (Option3Box.Text != "" || Answer3Box.Text != "")
                {
                    if (Option3Box.Text != "" && Answer3Box.Text != "")
                    {
                        options += "<c>" + Option1Box.Text + "<c/>";
                        answers += "<c>" + Answer1Box.Text + "<c/>";
                    }
                    else
                    {
                        MessageBox.Show("Жодна пара співвідношення не може мати пустих значень!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        return;
                    }
                }
                else
                {
                    space = true;
                }
            }

            if (!space)
            {
                if (Option4Box.Text != "" || Answer4Box.Text != "")
                {
                    if (Option4Box.Text != "" && Answer4Box.Text != "")
                    {
                        options += "<d>" + Option1Box.Text + "<d/>";
                        answers += "<d>" + Answer1Box.Text + "<d/>";
                    }
                    else
                    {
                        MessageBox.Show("Жодна пара співвідношення не може мати пустих значень!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        return;
                    }
                }
                else
                {
                    space = true;
                }
            }

            if (options != "" && answers != "")
            {
                Connector.ExecuteQuery(
                    $@"UPDATE question
                    SET answer_right = '{GenerateAnswers()}',
                    answer_options = '{GenerateOptions()}' 
                    WHERE question_id = {questionId}"
                );
            }
            else
            {
                MessageBox.Show("Має існувати хоч одна повна пара!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }
    }
}
