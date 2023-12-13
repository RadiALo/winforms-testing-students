using IronPdf;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Testing_students.Forms.TestForms
{
    public partial class ReviewAttemptForm : Form
    {
        // Інформація про питання
        int attemptId;
        DataTable questionsInfo;

        public ReviewAttemptForm()
        {
            InitializeComponent();
        }

        public ReviewAttemptForm(int attemptId) : this()
        {
            this.attemptId = attemptId;

            try
            {
                // Запит данних про тест
                questionsInfo = Connector.ExecuteSelectQuery(
                    $@"SELECT answer.question_id, question_type_id, question_content, answer_options, answer_right, answer_provided, answer_point
                    FROM answer JOIN question
                    ON answer.question_id = question.question_id
                    JOIN attempt ON answer.attempt_id = attempt.attempt_id
                    JOIN test ON test.test_id = attempt.test_id
                    WHERE answer.attempt_id = {attemptId};"
                );;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка:{ex.Message}", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

            for (int i = 0; i < questionsInfo.Rows.Count; i++)
            {
                // Додання сторінки питання
                QuestionsList.TabPages.Add(new TabPage()
                {
                    Location = new Point(4, 25),
                    Name = "Question" + i.ToString(),
                    Size = QuestionsList.Size,
                    Text = "Питання " + (i + 1).ToString(),
                    UseVisualStyleBackColor = true
                });

                // Заповнити сторінку відповідно до типу питання
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

        private void GenerateChooseOneTab(int i)
        {
            // Інформація з питання
            string content = questionsInfo.Rows[i].Field<string>(2);
            string options = questionsInfo.Rows[i].Field<string>(3);
            string right = questionsInfo.Rows[i].Field<string>(4);
            string answer = questionsInfo.Rows[i].Field<string>(5);
            int point = questionsInfo.Rows[i].Field<int>(6);

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
            Label Option1 = new Label() {
                AutoSize = true,
                Location = new Point(3, 99),
                Name = "Option1",
                Size = new Size(89, 20)
            };

            // Варіант 2
            Label Option2 = new Label() {
                AutoSize = true,
                Location = new Point(3, 125),
                Name = "Option2",
                Size = new Size(89, 20)
            };

            // Варіант 3
            Label Option3 = new Label() {
                AutoSize = true,
                Location = new Point(3, 151),
                Name = "Option3",
                Size = new Size(89, 20)
            };

            // Варіант 4
            Label Option4 = new Label()
            {
                AutoSize = true,
                Location = new Point(3, 177),
                Name = "Option4",
                Size = new Size(89, 20)
            };

            // Оцінка
            Label Point = new Label() {
                AutoSize = true,
                Location = new Point(3, 203),
                Name = "ChoosedOption",
                Size = new Size(89, 20),
                Text = answer == right ? "Отримана оцінка: " + point.ToString() : "Отримана оцінка: 0"
            };

            // Додання елементів
            QuestionsList.TabPages[i].Controls.Add(ContentBox);
            QuestionsList.TabPages[i].Controls.Add(Point);

            tagContent = Question.GetContentTag(options, "a", out tagFounded);
            if (tagFounded)
            {
                if (answer == "a")
                {
                    Option1.Font = new Font(Option1.Font, FontStyle.Bold);
                }
                Option1.Text = "a) " + tagContent;
                QuestionsList.TabPages[i].Controls.Add(Option1);
            }

            tagContent = Question.GetContentTag(options, "b", out tagFounded);
            if (tagFounded)
            {
                if (answer == "b")
                {
                    Option2.Font = new Font(Option1.Font, FontStyle.Bold);
                }
                Option2.Text = "b) " + tagContent;
                QuestionsList.TabPages[i].Controls.Add(Option2);
            }

            tagContent = Question.GetContentTag(options, "c", out tagFounded);
            if (tagFounded)
            {
                if (answer == "c")
                {
                    Option3.Font = new Font(Option1.Font, FontStyle.Bold);
                }
                Option3.Text = "c) " + tagContent;
                QuestionsList.TabPages[i].Controls.Add(Option3);
            }

            tagContent = Question.GetContentTag(options, "d", out tagFounded);
            if (tagFounded)
            {
                if (answer == "d")
                {
                    Option4.Font = new Font(Option1.Font, FontStyle.Bold);
                }
                Option4.Text = "d) " + tagContent;
                QuestionsList.TabPages[i].Controls.Add(Option4);
            }
        }

        private void GenerateChooseMultiplyTab(int i)
        {
            // Інформація з питання
            string content = questionsInfo.Rows[i].Field<string>(2);
            string options = questionsInfo.Rows[i].Field<string>(3);
            string right = questionsInfo.Rows[i].Field<string>(4);
            string answer = questionsInfo.Rows[i].Field<string>(5);
            int point = questionsInfo.Rows[i].Field<int>(6);

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
            Label Option1 = new Label()
            {
                AutoSize = true,
                Location = new Point(3, 99),
                Name = "Option1",
                Size = new Size(89, 20)
            };

            // Варіант 2
            Label Option2 = new Label()
            {
                AutoSize = true,
                Location = new Point(3, 125),
                Name = "Option2",
                Size = new Size(89, 20)
            };

            // Варіант 3
            Label Option3 = new Label()
            {
                AutoSize = true,
                Location = new Point(3, 151),
                Name = "Option3",
                Size = new Size(89, 20)
            };

            // Варіант 4
            Label Option4 = new Label()
            {
                AutoSize = true,
                Location = new Point(3, 177),
                Name = "Option4",
                Size = new Size(89, 20)
            };

            // Оцінка
            Label Point = new Label()
            {
                AutoSize = true,
                Location = new Point(3, 203),
                Name = "Point",
                Size = new Size(89, 20),
                Text = answer == right ? "Отримана оцінка: " + point.ToString() : "Отримана оцінка: 0"
            };

            // Додання елементів
            QuestionsList.TabPages[i].Controls.Add(ContentBox);

            tagContent = Question.GetContentTag(options, "a", out tagFounded);
            if (tagFounded)
            {
                if (answer.Contains("a"))
                {
                    Option1.Font = new Font(Option1.Font, FontStyle.Bold);
                }

                Option1.Text = "a) " + tagContent;
                QuestionsList.TabPages[i].Controls.Add(Option1);                
            }

            tagContent = Question.GetContentTag(options, "b", out tagFounded);
            if (tagFounded)
            {
                if (answer.Contains("b"))
                {
                    Option2.Font = new Font(Option1.Font, FontStyle.Bold);
                }
                Option2.Text = "b) " + tagContent;
                QuestionsList.TabPages[i].Controls.Add(Option2);                
            }

            tagContent = Question.GetContentTag(options, "c", out tagFounded);
            if (tagFounded)
            { 
                if (answer.Contains("c"))
                {
                    Option3.Font = new Font(Option1.Font, FontStyle.Bold);
                }
                Option3.Text = "c) " + tagContent;
                QuestionsList.TabPages[i].Controls.Add(Option3);               
            }

            tagContent = Question.GetContentTag(options, "d", out tagFounded);
            if (tagFounded)
            {
                if (answer.Contains("d"))
                {
                    Option4.Font = new Font(Option1.Font, FontStyle.Bold);
                }
                Option4.Text = "d) " + tagContent;
                QuestionsList.TabPages[i].Controls.Add(Option4);                
            }

            QuestionsList.TabPages[i].Controls.Add(Point);
        }

        private void GenerateInputTab(int i)
        {
            // Інформація з питання
            string content = questionsInfo.Rows[i].Field<string>(2);
            string right = questionsInfo.Rows[i].Field<string>(4);
            string answer = questionsInfo.Rows[i].Field<string>(5);
            int point = questionsInfo.Rows[i].Field<int>(6);

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
            Label Answer = new Label()
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                Location = new Point(3, 99),
                Size = new Size(QuestionsList.Width - 25, 20),
                Name = "Answer",
                Text = answer
            };

            // Оцінка
            Label Point = new Label()
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                Location = new Point(3, 125),
                Size = new Size(QuestionsList.Width - 25, 20),
                Name = "Answer",
                Text = answer == right ? "Отримана оцінка: " + point.ToString() : "Отримана оцінка: 0"
            };

            // Додання елементів
            QuestionsList.TabPages[i].Controls.Add(ContentBox);
            QuestionsList.TabPages[i].Controls.Add(Answer);
            QuestionsList.TabPages[i].Controls.Add(Point);
        }

        private void GenerateRelationTab(int i)
        {
            // Інформація про питання
            string content = questionsInfo.Rows[i].Field<string>(2);
            string options = questionsInfo.Rows[i].Field<string>(3);
            string right = questionsInfo.Rows[i].Field<string>(4);
            string answer = questionsInfo.Rows[i].Field<string>(5);
            int point = questionsInfo.Rows[i].Field<int>(6);

            bool tagFounded;
            string tagOptionContent;
            string tagAnswerContent;

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
            Label Answer1 = new Label()
            {
                AutoSize = true,
                Location = new Point(3, 96),
                Name = "Answer1",
                Size = new Size(269, 53)
            };

            // Варіант 2
            Label Answer2 = new Label()
            {
                AutoSize = true,
                Location = new Point(3, 122),
                Name = "Answer2",
                Size = new Size(269, 24)
            };

            // Варіант 3
            Label Answer3 = new Label()
            {
                AutoSize = true,
                Location = new Point(3, 148),
                Name = "Answer3",
                Size = new Size(269, 24)
            };

            // Варіант 4
            Label Answer4 = new Label()
            {
                AutoSize = true,
                Location = new Point(3, 174),
                Name = "Answer4",
                Size = new Size(269, 24)
            };

            // Оцінка
            Label Point = new Label()
            {
                AutoSize = true,
                Location = new Point(3, 200),
                Name = "Point",
                Size = new Size(269, 24),
                Text = answer == right ? "Отримана оцінка: " + point.ToString() : "Отримана оцінка: 0"
            };

            // Додання елементів
            QuestionsList.TabPages[i].Controls.Add(ContentBox);
            QuestionsList.TabPages[i].Controls.Add(Point);

            tagOptionContent = Question.GetContentTag(options, "a", out tagFounded);

            if (tagFounded)
            {
                tagAnswerContent = Question.GetContentTag(answer, "a", out tagFounded);
                if (!tagFounded)
                {
                    Answer1.Text = tagOptionContent;
                }
                else
                {
                    Answer1.Font = new Font(Answer1.Font, FontStyle.Bold);
                    Answer1.Text = tagOptionContent + " -> " + tagAnswerContent;
                }
                QuestionsList.TabPages[i].Controls.Add(Answer1);
            }

            tagOptionContent = Question.GetContentTag(options, "b", out tagFounded);

            if (tagFounded)
            {
                tagAnswerContent = Question.GetContentTag(answer, "b", out tagFounded);
                if (!tagFounded)
                {
                    Answer2.Text = tagOptionContent;
                }
                else
                {
                    Answer2.Font = new Font(Answer1.Font, FontStyle.Bold);
                    Answer2.Text = tagOptionContent + " -> " + tagAnswerContent;
                }
                QuestionsList.TabPages[i].Controls.Add(Answer2);
            }

            tagOptionContent = Question.GetContentTag(options, "c", out tagFounded);

            if (tagFounded)
            {
                tagAnswerContent = Question.GetContentTag(answer, "c", out tagFounded);
                if (!tagFounded)
                {
                    Answer3.Text = tagOptionContent;
                }
                else
                {
                    Answer3.Font = new Font(Answer1.Font, FontStyle.Bold);
                    Answer3.Text = tagOptionContent + " -> " + tagAnswerContent;
                }
                QuestionsList.TabPages[i].Controls.Add(Answer3);
            }


            tagOptionContent = Question.GetContentTag(options, "d", out tagFounded);

            if (tagFounded)
            {
                tagAnswerContent = Question.GetContentTag(answer, "d", out tagFounded);
                if (!tagFounded)
                {
                    Answer4.Text = tagOptionContent;
                }
                else
                {
                    Answer4.Font = new Font(Answer1.Font, FontStyle.Bold);
                    Answer4.Text = tagOptionContent + " -> " + tagAnswerContent;
                }
                QuestionsList.TabPages[i].Controls.Add(Answer4);
            }
        }

        private void ReviewPDFButton_Click(object sender, EventArgs e)
        {
            DataTable testInfo = Connector.ExecuteSelectQuery(
                $@"SELECT test_name, comment, student_name, class_name, target_point, received_point, edited_point FROM test
                JOIN attempt
                ON attempt.test_id = test.test_id
                JOIN student
                ON attempt.student_id = student.student_id
                JOIN class
                ON student.class_id = class.class_id
                WHERE attempt.attempt_id = {attemptId}"
            );

            string testName = testInfo.Rows[0].Field<string>(0);
            string comment = testInfo.Rows[0].Field<string>(1);
            string studentName = testInfo.Rows[0].Field<string>(2);
            string className = testInfo.Rows[0].Field<string>(3);
            int targetPoint = testInfo.Rows[0].Field<int>(4);
            int receivedPoint = testInfo.Rows[0].Field<int>(5);
            int editedPoint = testInfo.Rows[0].Field<int>(6);

            string html = $@"<h1>Тест: {testName} </h1><h2>Коментар: {comment}</h2>
                            <h2>Дата створення звіту: {DateTime.Now:yyyy-MM-dd HH:mm:ss}</h2>
                            <h3>Виконав: {studentName} {className}</h3>
                            <table>
	                            <tr>
		                            <td>ПИТАННЯ</td>
		                            <td>ВІДПОВІДЬ</td>
		                            <td>ОЦІНКА</td>
	                            </tr>";
            for (int i = 0; i < questionsInfo.Rows.Count; i++)
            {
                int questionType = questionsInfo.Rows[i].Field<int>(1);
                string options = questionsInfo.Rows[i].Field<string>(3);
                string content = questionsInfo.Rows[i].Field<string>(2);
                string right = questionsInfo.Rows[i].Field<string>(4);
                string answer = questionsInfo.Rows[i].Field<string>(5);
                int point = questionsInfo.Rows[i].Field<int>(6);

                switch (questionType)
                {
                    case 0:
                        {
                            bool tagFounded;
                            string tagContent = Question.GetContentTag(options, answer, out tagFounded);
                            if (!tagFounded)
                            {
                                tagContent = "-";
                            }

                            html += $@"<tr>
                                        <td>{content}</td>
                                        <td>{tagContent}</td>
                                        <td>{(answer == right ? point : 0)}</td>
                                    </tr>";
                        }
                        break;
                    case 1:
                        {
                            string answerText = "";

                            String[] choosedOptions = answer.Split(' ');

                            for (int j = 0; j < choosedOptions.Length; j++)
                            {
                                bool tagFounded;
                                string tagContent = Question.GetContentTag(options, choosedOptions[j], out tagFounded);
                                
                                if (!tagFounded)
                                {
                                    tagContent = "-";
                                }

                                answerText += tagContent + ", ";
                            }

                            if (answerText == "")
                            {
                                answerText = "-";
                            }
                            else
                            {
                                answerText = answerText.Substring(0, answerText.Length - 2);
                            }

                            html += $@"<tr>
                                        <td>{content}</td>
                                        <td>{answerText}</td>
                                        <td>{(answer == right ? point : 0)}</td>
                                    </tr>";
                        }
                        break;
                    case 2:
                        {
                            html += $@"<tr>
                                        <td>{content}</td>
                                        <td>{answer}</td>
                                        <td>{(answer == right ? 1 : 0)}</td>
                                    </tr>";
                        }
                        break;
                    case 3:
                        {
                            bool tagFounded;
                            string tagOptionContent = Question.GetContentTag(options, "a", out tagFounded);
                            string tagAnswerContent;
                            string answerText = "";

                            if (tagFounded)
                            {
                                tagAnswerContent = Question.GetContentTag(answer, "a", out tagFounded);
                                if (tagFounded)
                                {
                                    answerText += tagOptionContent + " -> " + tagAnswerContent + ", ";
                                }
                            }

                            tagOptionContent = Question.GetContentTag(options, "b", out tagFounded);

                            if (tagFounded)
                            {
                                tagAnswerContent = Question.GetContentTag(answer, "b", out tagFounded);
                                if (tagFounded)
                                {
                                    answerText  += tagOptionContent + " -> " + tagAnswerContent + ", ";
                                }
                            }

                            tagOptionContent = Question.GetContentTag(options, "c", out tagFounded);

                            if (tagFounded)
                            {
                                tagAnswerContent = Question.GetContentTag(answer, "c", out tagFounded);
                                if (tagFounded)
                                {
                                    answerText += tagOptionContent + " -> " + tagAnswerContent + ", ";
                                }
                            }

                            tagOptionContent = Question.GetContentTag(options, "d", out tagFounded);

                            if (tagFounded)
                            {
                                tagAnswerContent = Question.GetContentTag(answer, "d", out tagFounded);
                                if (tagFounded)
                                {
                                    answerText += tagOptionContent + " -> " + tagAnswerContent + ", "; ;
                                }
                            }

                            if (answerText == "")
                            {
                                answerText = "-";
                            }
                            else
                            {
                                answerText = answerText.Substring(0, answerText.Length - 2);
                            }

                            html += $@"<tr>
                                        <td>{content}</td>
                                        <td>{answerText}</td>
                                        <td>{(answer == right ? point : 0)}</td>
                                    </tr>";
                        }
                        break;
                }
            }

            if (editedPoint == receivedPoint)
            {
                html += $@"</table>
                    <p>Отримана оцінка: {editedPoint}/{targetPoint}</p>";
            }
            else
            {
                html += $@"</table>
                    <p>Отримана оцінка: {receivedPoint}({editedPoint})/{targetPoint}</p>";
            }

            var Renderer = new ChromePdfRenderer();
            var AttemptView = Renderer.RenderHtmlAsPdf(html);
            AttemptView.SaveAs($"Reviews\\Attempt_{attemptId}_{testName}_review.pdf");
        }
    }
}
