using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Testing_students.Forms.TestForms
{
    public partial class TestingForm : Form
    {
        int attemptId;

        DataTable questionsInfo;

        int seconds;
        bool testEnded;
        int point;

        public TestingForm()
        {
            InitializeComponent();
        }

        public TestingForm(int attemptId) : this()
        {
            this.attemptId = attemptId;

            try
            {
                // Запит інформації про питання
                questionsInfo = Connector.ExecuteSelectQuery(
                    $@"SELECT answer.question_id, question_type_id, question_content, answer_options, answer_right, start_time, test.pass_time, answer_point
                    FROM answer
                    JOIN question
                    ON answer.question_id = question.question_id
                    JOIN attempt
                    ON answer.attempt_id = attempt.attempt_id
                    JOIN test
                    ON test.test_id = attempt.test_id
                    WHERE answer.attempt_id = " + attemptId.ToString()
                );

                // Розрахування часу до кінця тесту
                DateTime start = questionsInfo.Rows[0].Field<DateTime>(5);
                seconds = questionsInfo.Rows[0].Field<int>(6) - (int)DateTime.Now.Subtract(start).TotalSeconds;

                // Додання сторінок для відповідей
                for (int i = 0; i < questionsInfo.Rows.Count; i++)
                {
                    QuestionsList.TabPages.Add(new TabPage()
                    {
                        Location = new Point(4, 25),
                        Text = "Питання " + (i + 1).ToString(),
                        Name = "Question" + i.ToString(),
                        Size = QuestionsList.Size,
                        UseVisualStyleBackColor = true
                    });

                    // Заповнення сторінки відповідно до типу питання
                    switch (questionsInfo.Rows[i].Field<int>(1))
                    {
                        case 0:
                            GenerateChooseOneTab(i);
                            break;
                        case 1:
                            GenerateChooseMultiplyTab(i);
                            break;
                        case 2:
                            GenerateInputTab(i);
                            break;
                        case 3:
                            GenerateRelationTab(i);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка:{ex.Message}", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void GenerateChooseOneTab(int i)
        {
            // Інформація про питання
            string content = questionsInfo.Rows[i].Field<string>(2);
            string options = questionsInfo.Rows[i].Field<string>(3);

            bool tagFounded;
            string tagContent;

            // Зміст питання
            TextBox ContentBox = new TextBox()
            {
                ReadOnly = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                Location = new Point(3, 3),
                Multiline = true,
                Name = "ContentBox",
                Size = new Size(QuestionsList.Width - 5, 90),
                Text = content
            };

            // Варіант 1
            RadioButton Option1 = new RadioButton()
            {
                AutoSize = true,
                Location = new Point(3, 99),
                Name = "Option1",
                Size = new Size(89, 20),
                UseVisualStyleBackColor = true
            };

            // Варіант 2
            RadioButton Option2 = new RadioButton()
            {
                AutoSize = true,
                Location = new Point(3, 125),
                Name = "Option2",
                Size = new Size(89, 20),
                UseVisualStyleBackColor = true
            };


            // Варіант 3
            RadioButton Option3 = new RadioButton()
            {
                AutoSize = true,
                Location = new Point(3, 151),
                Name = "Option3",
                Size = new Size(89, 20),
                UseVisualStyleBackColor = true
            };

            // Варіант 4
            RadioButton Option4 = new RadioButton()
            {
                AutoSize = true,
                Location = new Point(3, 177),
                Name = "Option4",
                Size = new Size(89, 20),
                UseVisualStyleBackColor = true
            };
            
            // Додання елементів
            QuestionsList.TabPages[i].Controls.Add(ContentBox);

            tagContent = Question.GetContentTag(options, "a", out tagFounded);
            if (tagFounded)
            {
                Option1.Text = tagContent;
                QuestionsList.TabPages[i].Controls.Add(Option1);
            }

            tagContent = Question.GetContentTag(options, "b", out tagFounded);
            if (tagFounded)
            {
                Option2.Text = tagContent;
                QuestionsList.TabPages[i].Controls.Add(Option2);
            }

            tagContent = Question.GetContentTag(options, "c", out tagFounded);
            if (tagFounded)
            {
                Option3.Text = tagContent;
                QuestionsList.TabPages[i].Controls.Add(Option3);
            }

            tagContent = Question.GetContentTag(options, "d", out tagFounded);
            if (tagFounded)
            {
                Option4.Text = tagContent;
                QuestionsList.TabPages[i].Controls.Add(Option4);
            }
        }
        private void GenerateChooseMultiplyTab(int i)
        {
            // Інформація про питання
            string content = questionsInfo.Rows[i].Field<string>(2);
            string options = questionsInfo.Rows[i].Field<string>(3);

            bool tagFounded;
            string tagContent;

            // Зміст питання
            TextBox ContentBox = new TextBox()
            {
                ReadOnly = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                Location = new Point(3, 3),
                Multiline = true,
                Name = "ContentBox",
                Size = new Size(QuestionsList.Width - 5, 90),
                Text = content
            };

            // Варіант 1
            CheckBox Option1 = new CheckBox()
            {
                AutoSize = true,
                Location = new Point(3, 99),
                Name = "Option1",
                Size = new Size(89, 20),
                UseVisualStyleBackColor = true
            };

            // Варіант 2
            CheckBox Option2 = new CheckBox()
            {
                AutoSize = true,
                Location = new Point(3, 125),
                Name = "Option2",
                Size = new Size(89, 20),
                UseVisualStyleBackColor = true
            };

            // Варіант 3
            CheckBox Option3 = new CheckBox()
            {
                AutoSize = true,
                Location = new Point(3, 151),
                Name = "Option3",
                Size = new Size(89, 20),
                UseVisualStyleBackColor = true
            };

            // Варіант 4
            CheckBox Option4 = new CheckBox()
            {
                AutoSize = true,
                Location = new Point(3, 177),
                Name = "Option4",
                Size = new Size(89, 20),
                UseVisualStyleBackColor = true,
                Text = "Варіант 4"
            };

            // Додання елементів
            QuestionsList.TabPages[i].Controls.Add(ContentBox);

            tagContent = Question.GetContentTag(options, "a", out tagFounded);
            if (tagFounded)
            {
                Option1.Text = tagContent;
                QuestionsList.TabPages[i].Controls.Add(Option1);
            }

            tagContent = Question.GetContentTag(options, "b", out tagFounded);
            if (tagFounded)
            {
                Option2.Text = tagContent;
                QuestionsList.TabPages[i].Controls.Add(Option2);
            }

            tagContent = Question.GetContentTag(options, "c", out tagFounded);
            if (tagFounded)
            {
                Option3.Text = tagContent;
                QuestionsList.TabPages[i].Controls.Add(Option3);
            }

            tagContent = Question.GetContentTag(options, "d", out tagFounded);
            if (tagFounded)
            {
                Option4.Text = tagContent;
                QuestionsList.TabPages[i].Controls.Add(Option4);
            }
        }
        private void GenerateInputTab(int i)
        {
            // Інформація про питання
            string content = questionsInfo.Rows[i].Field<string>(2);

            // Зміст питання
            TextBox ContentBox = new TextBox()
            {
                ReadOnly = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                Location = new Point(3, 3),
                Multiline = true,
                Name = "ContentBox",
                Size = new Size(QuestionsList.Width - 5, 90),
                Text = content
            };

            // Відповідь
            TextBox InputBox = new TextBox()
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                Location = new Point(3, 99),
                Size = new Size(QuestionsList.Width - 25, 20),
                Name = "InputBox"
            };

            // Додання елементів
            QuestionsList.TabPages[i].Controls.Add(ContentBox);
            QuestionsList.TabPages[i].Controls.Add(InputBox);
        }
        private void GenerateRelationTab(int i)
        {
            // Інформація про питання
            string content = questionsInfo.Rows[i].Field<string>(2);
            string options = questionsInfo.Rows[i].Field<string>(3);
            string answers = questionsInfo.Rows[i].Field<string>(4);

            bool tagFounded;
            string tagOptionContent;
            string tagAnswerContent;

            // Списки опцій та відповідей
            List<string> optionsList = new List<string>();
            List<string> answersList = new List<string>();

            // Зміст
            TextBox ContentBox = new TextBox()
            {
                ReadOnly = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                Location = new Point(3, 3),
                Multiline = true,
                Name = "ContentBox",
                Size = new Size(QuestionsList.Width - 5, 90),
                Text = content
            };

            // Варіант 1
            TextBox Option1 = new TextBox()
            {
                Location = new Point(3, 96),
                Multiline = true,
                Name = "Option1",
                ScrollBars = ScrollBars.Vertical,
                Size = new Size(269, 53)
            };

            // Варіант 2
            TextBox Option2 = new TextBox()
            {
                Location = new Point(3, 155),
                Multiline = true,
                Name = "Option2",
                ScrollBars = ScrollBars.Vertical,
                Size = new Size(269, 53)
            };
            
            // Варіант 3
            TextBox Option3 = new TextBox()
            {
                Location = new Point(3, 214),
                Multiline = true,
                Name = "Option3",
                ScrollBars = ScrollBars.Vertical,
                Size = new Size(269, 53)
            };

            // Варіант 4
            TextBox Option4 = new TextBox()
            {
                Location = new Point(3, 273),
                Multiline = true,
                Name = "Option4",
                ScrollBars = ScrollBars.Vertical,
                Size = new Size(269, 53)
            };

            // Відповідь 1
            ComboBox ChooseBox1 = new ComboBox()
            {
                FormattingEnabled = true,
                Location = new Point(278, 112),
                Name = "ChooseBox1",
                Size = new Size(43, 24)
            };

            // Відповідь 2
            ComboBox ChooseBox2 = new ComboBox()
            {
                FormattingEnabled = true,
                Location = new Point(278, 168),
                Name = "ChooseBox2",
                Size = new Size(43, 24)
            };

            // Відповідь 3
            ComboBox ChooseBox3 = new ComboBox()
            {
                FormattingEnabled = true,
                Location = new Point(278, 224),
                Name = "ChooseBox3",
                Size = new Size(43, 24)
            };

            // Відповідь 4
            ComboBox ChooseBox4 = new ComboBox()
            {
                FormattingEnabled = true,
                Location = new Point(278, 280),
                Name = "ChooseBox4",
                Size = new Size(43, 24)
            };

            // Відношення 1
            TextBox Answer1 = new TextBox()
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(QuestionsList.Width - 274, 96),
                Multiline = true,
                Name = "AnswerBox1",
                ScrollBars = ScrollBars.Vertical,
                Size = new Size(269, 53)
            };

            // Відношення 2
            TextBox Answer2 = new TextBox()
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(QuestionsList.Width - 274, 155),
                Multiline = true,
                Name = "AnswerBox2",
                ScrollBars = ScrollBars.Vertical,
                Size = new Size(269, 53)
            };

            // Відношення 3
            TextBox Answer3 = new TextBox()
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(QuestionsList.Width - 274, 214),
                Multiline = true,
                Name = "AnswerBox3",
                ScrollBars = ScrollBars.Vertical,
                Size = new Size(269, 53)
            };

            // Відношення 4
            TextBox Answer4 = new TextBox()
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(QuestionsList.Width - 274, 273),
                Multiline = true,
                Name = "AnswerBox4",
                ScrollBars = ScrollBars.Vertical,
                Size = new Size(269, 53)
            };

            // Додання елементів
            QuestionsList.TabPages[i].Controls.Add(ContentBox);
            
            tagOptionContent = Question.GetContentTag(options, "a", out tagFounded);

            if (tagFounded)
            {
                optionsList.Add("a");
                tagAnswerContent = Question.GetContentTag(answers, "a");
                answersList.Add(tagAnswerContent);
                Option1.Text = tagOptionContent;
                QuestionsList.TabPages[i].Controls.Add(Option1);
                QuestionsList.TabPages[i].Controls.Add(Answer1);
                QuestionsList.TabPages[i].Controls.Add(ChooseBox1);
            }

            tagOptionContent = Question.GetContentTag(options, "b", out tagFounded);

            if (tagFounded)
            {
                optionsList.Add("b");
                tagAnswerContent = Question.GetContentTag(answers, "b");
                answersList.Add(tagAnswerContent);
                Option2.Text = tagOptionContent;
                QuestionsList.TabPages[i].Controls.Add(Option2);
                QuestionsList.TabPages[i].Controls.Add(Answer2);
                QuestionsList.TabPages[i].Controls.Add(ChooseBox2);
            }

            tagOptionContent = Question.GetContentTag(options, "c", out tagFounded);

            if (tagFounded)
            {
                optionsList.Add("c");
                tagAnswerContent = Question.GetContentTag(answers, "c");
                answersList.Add(tagAnswerContent);
                Option3.Text = tagOptionContent;
                QuestionsList.TabPages[i].Controls.Add(Option3);
                QuestionsList.TabPages[i].Controls.Add(Answer3);
                QuestionsList.TabPages[i].Controls.Add(ChooseBox3);
            }

            tagOptionContent = Question.GetContentTag(options, "d", out tagFounded);

            if (tagFounded)
            {
                optionsList.Add("d");
                tagAnswerContent = Question.GetContentTag(answers, "d");
                Option4.Text = tagOptionContent;
                answersList.Add(tagAnswerContent);
                QuestionsList.TabPages[i].Controls.Add(Option4);
                QuestionsList.TabPages[i].Controls.Add(Answer4);
                QuestionsList.TabPages[i].Controls.Add(ChooseBox4);
            }

            Random random = new Random();

            if (answersList.Count > 0)
            {
                int r = random.Next(answersList.Count);
                Answer1.Text = answersList[r];
                answersList.RemoveAt(r);
            }

            if (answersList.Count > 0)
            {
                int r = random.Next(answersList.Count);
                Answer2.Text = answersList[r];
                answersList.RemoveAt(r);
            }

            if (answersList.Count > 0)
            {
                int r = random.Next(answersList.Count);
                Answer3.Text = answersList[r];
                answersList.RemoveAt(r);
            }

            if (answersList.Count > 0)
            {
                int r = random.Next(answersList.Count);
                Answer4.Text = answersList[r];
                answersList.RemoveAt(r);
            }

            ChooseBox1.Items.AddRange(optionsList.ToArray());
            ChooseBox2.Items.AddRange(optionsList.ToArray());
            ChooseBox3.Items.AddRange(optionsList.ToArray());
            ChooseBox4.Items.AddRange(optionsList.ToArray());
        }

        // Таймер
        private void TimeToEnd_Tick(object sender, EventArgs e)
        {
            if (seconds > 0)
            {
                seconds--;
                // Відображення таймеру
                TimerLabel.Text = 
                    (seconds / 60 > 10 ? (seconds / 60).ToString() : "0" + (seconds / 60).ToString()) + ":" + 
                    (seconds > 10 ? (seconds % 60).ToString() : "0" + (seconds % 60).ToString());
                if (seconds <= 5)
                {
                    TimerLabel.ForeColor = Color.Red;
                }
            }
            else
            {
                EndTest();
            }
        }

        private void EndTestButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ви впевнені, що бажаєте закінчити виконання тесту?","Увага!", 
                MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                EndTest();
            }
        }

        // Закінчення тесту
        private void EndTest()
        {
            for (int i = 0; i < questionsInfo.Rows.Count; i++)
            {
                // Виклик функції перевірки відповіді відповідно до типу питання
                switch (questionsInfo.Rows[i].Field<int>(1))
                {
                    case 0:
                        CheckChooseOne(i);
                        break;
                    case 1:
                        CheckChooseMultiply(i);
                        break;
                    case 2:
                        CheckInput(i);
                        break;
                    case 3:
                        CheckRelation(i);
                        break;
                }
            }

            try
            {
                Connector.ExecuteQuery(
                    $@"UPDATE attempt
                    SET received_point = {point},
                    edited_point = {point},
                    pass_status = 4 
                    WHERE attempt_id = {attemptId};"
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка:{ex.Message}", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            testEnded = true;

            // Відкриття форми з результатами
            ResultsForm form = new ResultsForm(attemptId);
            form.Show();
            Close();
        }

        private void CheckChooseOne(int i)
        {
            if (QuestionsList.TabPages[i].Controls.ContainsKey("Option1"))
            {
                RadioButton radioButton = QuestionsList.TabPages[i].Controls["Option1"] as RadioButton;
                if (radioButton.Checked)
                {
                    SaveAnswer(i, "a");
                    if (Compare(i, "a"))
                    {
                        point += questionsInfo.Rows[i].Field<int>(7);
                    }
                    return;
                }
            }

            if (QuestionsList.TabPages[i].Controls.ContainsKey("Option2"))
            {
                RadioButton radioButton = QuestionsList.TabPages[i].Controls["Option2"] as RadioButton;
                if (radioButton.Checked)
                {
                    SaveAnswer(i, "b");
                    if (Compare(i, "b"))
                    {
                        point += questionsInfo.Rows[i].Field<int>(7);
                    }
                    return;
                }
            }

            if (QuestionsList.TabPages[i].Controls.ContainsKey("Option3"))
            {
                RadioButton radioButton = QuestionsList.TabPages[i].Controls["Option3"] as RadioButton;
                if (radioButton.Checked)
                {
                    SaveAnswer(i, "c");
                    if (Compare(i, "c"))
                    {
                        point += questionsInfo.Rows[i].Field<int>(7);
                    }
                    return;
                }
            }

            if (QuestionsList.TabPages[i].Controls.ContainsKey("Option4"))
            {
                RadioButton radioButton = QuestionsList.TabPages[i].Controls["Option4"] as RadioButton;
                if (radioButton.Checked)
                {
                    SaveAnswer(i, "d");
                    if (Compare(i, "d"))
                    {
                        point += questionsInfo.Rows[i].Field<int>(7);
                    }
                    return;
                }
            }

            SaveAnswer(i, "");
        }

        private void CheckChooseMultiply(int i)
        {
            string answer = "";

            if (QuestionsList.TabPages[i].Controls.ContainsKey("Option1"))
            {
                CheckBox checkBox = QuestionsList.TabPages[i].Controls["Option1"] as CheckBox;
                if (checkBox.Checked)
                {
                    answer += "a ";
                }
            }

            if (QuestionsList.TabPages[i].Controls.ContainsKey("Option2"))
            {
                CheckBox checkBox = QuestionsList.TabPages[i].Controls["Option2"] as CheckBox;
                if (checkBox.Checked)
                {
                    answer += "b ";
                }
            }

            if (QuestionsList.TabPages[i].Controls.ContainsKey("Option3"))
            {
                CheckBox checkBox = QuestionsList.TabPages[i].Controls["Option3"] as CheckBox;
                if (checkBox.Checked)
                {
                    answer += "c ";
                }
            }

            if (QuestionsList.TabPages[i].Controls.ContainsKey("Option4"))
            {
                CheckBox checkBox = QuestionsList.TabPages[i].Controls["Option4"] as CheckBox;
                if (checkBox.Checked)
                {
                    answer += "d ";
                }
            }

            if (answer.Length > 0)
            {
                answer = answer.Substring(0, answer.Length - 1);
                SaveAnswer(i, answer);
                if (Compare(i, answer))
                {
                    point += questionsInfo.Rows[i].Field<int>(7);
                }
            }
            else
            {
                SaveAnswer(i, "");
                if (Compare(i, ""))
                {
                    point += questionsInfo.Rows[i].Field<int>(7);
                }
            }
        }

        private void CheckInput(int i)
        {
            TextBox input = QuestionsList.TabPages[i].Controls["InputBox"] as TextBox;

            if (Compare(i, input.Text))
            {
                point += questionsInfo.Rows[i].Field<int>(7);
                SaveAnswer(i, questionsInfo.Rows[i].Field<string>(4));
            }
            else
            {
                SaveAnswer(i, input.Text);
            }
        }

        private void CheckRelation(int i)
        {
            string answer = "";

            if (QuestionsList.TabPages[i].Controls.ContainsKey("ChooseBox1"))
            {
                ComboBox combo = QuestionsList.TabPages[i].Controls["ChooseBox1"] as ComboBox;
                if (combo.SelectedIndex != -1)
                {
                    TextBox text = QuestionsList.TabPages[i].Controls["AnswerBox" + (combo.SelectedIndex + 1)] as TextBox;
                    answer += "<a>" + text.Text + "<a/>";
                }
            }

            if (QuestionsList.TabPages[i].Controls.ContainsKey("ChooseBox2"))
            {
                ComboBox combo = QuestionsList.TabPages[i].Controls["ChooseBox2"] as ComboBox;
                if (combo.SelectedIndex != -1)
                {
                    TextBox text = QuestionsList.TabPages[i].Controls["AnswerBox" + (combo.SelectedIndex + 1)] as TextBox;
                    answer += "<b>" + text.Text + "<b/>";
                }
            }

            if (QuestionsList.TabPages[i].Controls.ContainsKey("ChooseBox3"))
            {
                ComboBox combo = QuestionsList.TabPages[i].Controls["ChooseBox3"] as ComboBox;
                if (combo.SelectedIndex != -1)
                {
                    TextBox text = QuestionsList.TabPages[i].Controls["AnswerBox" + (combo.SelectedIndex + 1)] as TextBox;
                    answer += "<c>" + text.Text + "<c/>";
                }
            }

            if (QuestionsList.TabPages[i].Controls.ContainsKey("ChooseBox4"))
            {
                ComboBox combo = QuestionsList.TabPages[i].Controls["ChooseBox4"] as ComboBox;
                if (combo.SelectedIndex != -1)
                {
                    TextBox text = QuestionsList.TabPages[i].Controls["AnswerBox" + (combo.SelectedIndex + 1)] as TextBox;
                    answer += "<d>" + text.Text + "<d/>";
                }
            }

            SaveAnswer(i, answer);

            if (Compare(i, answer))
            {
                point += questionsInfo.Rows[i].Field<int>(7);
            }
        }

        private bool Compare(int i, string answer)
        {
            if (questionsInfo.Rows[i].Field<string>(4).ToLower() == answer.ToLower())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void SaveAnswer(int i, string answer)
        {
            Connector.ExecuteQuery(
                $@"UPDATE answer
                SET answer_provided = '{answer}' 
                WHERE attempt_id = {attemptId} 
                AND question_id = {questionsInfo.Rows[i].Field<int>(0)}"
            );
        }

        private void TestingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!testEnded)
            {
                if (MessageBox.Show("Завершити виконання тесту?","Увага!",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    e.Cancel = true;
                    EndTest();
                }
            }
        }
    }
}
