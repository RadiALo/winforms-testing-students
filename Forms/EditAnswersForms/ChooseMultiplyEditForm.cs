using System;
using System.Data;
using System.Windows.Forms;

namespace Testing_students.Forms.EditAnswersForms
{
    public partial class ChooseMultiplyEditForm : Form
    {
        private int questionId;

        public ChooseMultiplyEditForm()
        {
            InitializeComponent();
        }

        public ChooseMultiplyEditForm(int questionId) : this()
        {
            this.questionId = questionId;
            DataTable questionInfo = null;

            try
            {
                questionInfo = Connector.ExecuteSelectQuery(
                    @"SELECT answer_right, answer_options
                    FROM question
                    WHERE question_id = " + questionId.ToString()
                );
            } catch (Exception ex)
            {
                MessageBox.Show($"Помилка:{ex.Message}", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

            if (questionInfo.Rows[0].Field<string>(0) == null)
            {
                Option1Check.Checked = true;
            }
            else
            {
                string[] rightAnswers = questionInfo.Rows[0].Field<string>(0).Split(' ');

                for (int i = 0; i < rightAnswers.Length; i++)
                {
                    switch (rightAnswers[i])
                    {
                        case "a":
                            Option1Check.Checked = true;
                            break;
                        case "b":
                            Option2Check.Checked = true;
                            break;
                        case "c":
                            Option3Check.Checked = true;
                            break;
                        case "d":
                            Option4Check.Checked = true;
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
                    else
                    {
                        return;
                    }

                    content = Question.GetContentTag(questionInfo.Rows[0].Field<string>(1), "b", out exist);

                    if (exist)
                    {
                        Option2Box.Text = content;
                    }
                    else
                    {
                        return;
                    }

                    content = Question.GetContentTag(questionInfo.Rows[0].Field<string>(1), "c", out exist);

                    if (exist)
                    {
                        Option3Box.Text = content;
                    }
                    else
                    {
                        return;
                    }

                    content = Question.GetContentTag(questionInfo.Rows[0].Field<string>(1), "d", out exist);

                    if (exist)
                    {
                        Option4Box.Text = content;
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        private string GenerateAnswerOptions()
        {
            string options = "";
            bool space = false;

            if (Option1Box.Text != "")
            {
                options += "<a>" + Option1Box.Text + "<a/>";
            }
            else
            {
                space = true;
            }

            if (Option2Box.Text != "")
            {
                if (space)
                {
                    MessageBox.Show("Пункт b не було додано! Спочатку треба заповнити попередні!",
                        "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    options += "<b>" + Option2Box.Text + "<b/>";
                }
            }
            else
            {
                space = true;
            }

            if (Option3Box.Text != "")
            {
                if (space)
                {
                    MessageBox.Show("Пункт c не було додано! Спочатку треба заповнити попередні!",
                        "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    options += "<c>" + Option3Box.Text + "<c/>";
                }
            }
            else
            {
                space = true;
            }

            if (Option4Box.Text != "")
            {
                if (space)
                {
                    MessageBox.Show("Пункт d не було додано! Спочатку треба заповнити попередні!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    options += "<d>" + Option4Box.Text + "<d/>";
                }
            }

            return options;
        }

        private void ChooseMultiplyEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string Rights = "";
            bool space = false;

            if (Option1Box.Text != "")
            {
                if (Option1Check.Checked)
                {
                    Rights += "a ";
                }
            }
            else
            {
                space = true;
            }

            if (!space && Option2Box.Text != "")
            {
                if (Option2Check.Checked)
                {
                    Rights += "b ";
                }
            }
            else
            {
                space = true;
            }

            if (!space && Option3Box.Text != "")
            {
                if (Option3Check.Checked && Option3Box.Text != "")
                {
                    Rights += "c ";
                }
            }
            else
            {
                space = true;
            }

            if (!space && Option4Box.Text != "")
            {
                if (Option4Check.Checked && Option4Box.Text != "")
                {
                    Rights += "d ";
                }
            }

            if (Rights != "")
            {

                Rights = Rights.Substring(0, Rights.Length - 1);
                Connector.ExecuteQuery(
                    $@"UPDATE question
                    SET answer_right = '{Rights}',
                    answer_options = '{GenerateAnswerOptions()}'
                    WHERE question_id = {questionId};"
                );
            }
            else
            {
                MessageBox.Show("Має існувати хоч один не пустий обраний варіант!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }
    }
}
