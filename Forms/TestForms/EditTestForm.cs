using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Testing_students.Forms.EditAnswersForms;

namespace Testing_students.Forms.TestForms
{
    public partial class EditTestForm : Form
    {
        // Номер тесту
        private int testId;

        // Лічильник питань
        private int questionsCount = 0;

        // Вікна питань
        List<QuestionBox> questions = new List<QuestionBox>();

        public EditTestForm()
        {
            InitializeComponent();
        }

        public EditTestForm(int TestId) : this()
        {
            try
            {
                testId = TestId;

                // Запит даних про тест
                DataTable testInfo = Connector.ExecuteSelectQuery(
                    $@"SELECT test_id, test_name, test_description, questions_count, test_point, pass_time, teacher_login
                    FROM test WHERE test_id = {testId};"
                );

                TestNameBox.Text = testInfo.Rows[0].Field<string>(1);
                DescriptionBox.Text = testInfo.Rows[0].Field<string>(2);
                QuestionsCountBox.Text = testInfo.Rows[0].Field<int>(3).ToString();
                PointBox.Text = testInfo.Rows[0].Field<int>(4).ToString();
                PassTimeBox.Text = testInfo.Rows[0].Field<int>(5).ToString();

                // Запит даних про питання
                DataTable questionsInfo = Connector.ExecuteSelectQuery(
                    $@"SELECT question_id, question_content, question_type_id, answer_point
                    FROM question WHERE test_id = {testId};"
                );

                // Відображення питань
                foreach (DataRow row in questionsInfo.Rows)
                {
                    GroupBox box = CreateQuestionGroup(questionsCount);
                    questions.Add(new QuestionBox(box, row.Field<int>(0), row.Field<string>(1), row.Field<int>(2), row.Field<int>(3)));
                    QuestionsPanel.Controls.Add(box);
                    questionsCount++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void EditTestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Перевірка всіх полей на заповненісь
            if (TestNameBox.Text == "" || QuestionsCountBox.Text == ""
                || PassTimeBox.Text == "" || PointBox.Text == "")
            {
                // Запит на видалення неповного тесту
                if (MessageBox.Show("В тесті має бути вказана Назва, Кількість питань, Час на проходження та Оцінка. Видалити тест?",
                    "Помилка!", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    try
                    {
                        // Видалення тесту
                        Connector.ExecuteQuery($"DELETE FROM test WHERE test_id =  {testId}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Помилка: " + ex.Message, "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                }
                else 
                {
                    e.Cancel = true;
                    return;
                }
            }
            else
            {
                try
                {
                    // Перевірка правильності введення
                    int.Parse(PointBox.Text);
                    int.Parse(QuestionsCountBox.Text);
                    int.Parse(PassTimeBox.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Поля Оцінка, Кількість питань та Час на проходження мають містити цілі числа!",
                        "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }

                // Запит на збереження
                DialogResult result = MessageBox.Show("Зберігти дані перед виходом?", "Увага", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    // Збереження даних про тест
                    try
                    {
                        Connector.ExecuteQuery(
                        $@"UPDATE test
                        SET test_name = '{TestNameBox.Text}', questions_count = {QuestionsCountBox.Text},
                        test_point = {PointBox.Text}, pass_time = {PassTimeBox.Text}, test_description = '{DescriptionBox.Text}'
                        WHERE test_id = {testId}"
                        );
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Помилка: " + ex.Message, "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        return;
                    }

                    // Оновлення даних про питання
                    for (int i = 0; i < questions.Count; i++)
                    {
                        questions[i].Update();
                    }

                    // Запит даних про питання
                    DataTable questionsInfo = Connector.ExecuteSelectQuery(
                        $@"SELECT question_content, answer_options, answer_right
                        FROM question WHERE test_id = {testId}"
                    );

                    // Перевірка питань на цілістність
                    for (int i = 0; i < questionsInfo.Rows.Count; i++)
                    {
                        // Якщо одне з значень відсутнє
                        if (questionsInfo.Rows[i].Field<string>(0) == null ||
                            questionsInfo.Rows[i].Field<string>(1) == null ||
                            questionsInfo.Rows[i].Field<string>(2) == null)
                        {
                            MessageBox.Show($"Питання {i + 1} має мати зміст, варіанти та правильну відповідь!",
                               "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            e.Cancel = true;
                            return;
                        }
                        // Якщо одне з значень пусте
                        else if (questionsInfo.Rows[i].Field<string>(0) == "" ||
                            questionsInfo.Rows[i].Field<string>(1) == "" ||
                            questionsInfo.Rows[i].Field<string>(2) == "")
                        {
                            MessageBox.Show($"Питання {i + 1} має мати зміст, варіанти та правильну відповідь!",
                                "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            e.Cancel = true;
                            return;
                        }
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }            
        }

        // Створення вікна редагування питання
        public GroupBox CreateQuestionGroup(int Index)
        {
            // Створення нової групи
            GroupBox newGroup = new GroupBox()
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                Location = new Point(0, 0),
                Size = new Size(720, 84),
                Name = "groupBox" + Index,
                Text = "Питання " + (Index + 1)
            };

            // Поле редагування назви питання
            Label questionNameLabel = new Label()
            {
                AutoSize = true,
                Location = new Point(9, 24),
                Name = "questionNameLabel",
                Size = new Size(106, 16),
                Text = "Назва питання"
            };

            TextBox questionNameBox = new TextBox()
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                Location = new Point(121, 21),
                Name = "questionNameBox",
                Size = new Size(newGroup.Width - 132, 22)
            };

            // Поле редагування оцінки за питання
            Label pointLabel = new Label()
            {
                AutoSize = true,
                Text = "Оцінка",
                Location = new Point(59, 52),
                Name = "pointLabel",
                Size = new Size(51, 16)
            };

            TextBox pointBox = new TextBox()
            {
                Location = new Point(121, 49),
                Name = "pointBox",
                Size = new Size(51, 22)
            };


            // Тип питання
            Label questionTypeLabel = new Label()
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                AutoSize = true,
                Location = new Point(newGroup.Width - 420, 52),
                Size = new Size(70, 16),
                Name = "questionTypeLabel",
                Text = "Тип питання"
            };

            ComboBox questionTypeCombo = new ComboBox()
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                FormattingEnabled = true,
                Location = new Point(newGroup.Width - 350, 49),
                Name = "questionTypeCombo",
                Size = new Size(140, 24)
            };

            questionTypeCombo.Items.AddRange(new object[] {
                "З вибором одного",
                "З вибором декількох",
                "З введенням",
                "Співвідношення"
            });
            questionTypeCombo.SelectedIndex = 0;

            // Кнопка редагування питання
            Button editQuestionButton = new Button()
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(newGroup.Width - 180, 49),
                Name = "editButton",
                Size = new Size(104, 23),
                Text = "Редагувати відповіді",
                UseVisualStyleBackColor = true
            };

            // Кнопка видалення питання
            Button deleteQuestionButton = new Button()
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(newGroup.Width - 66, 49),
                Name = "deleteButton",
                Size = new Size(23, 23),
                Text = "X",
                UseVisualStyleBackColor = true
            };

            // Додання створених елементів до групи
            newGroup.Controls.AddRange(new Control[] {questionNameLabel, questionNameBox, pointLabel,
                pointBox, questionTypeLabel, questionTypeCombo, editQuestionButton, deleteQuestionButton});

            return newGroup;
        }
        
        // Додання нового вікна з питанням
        private void AddQuestionButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = Connector.ExecuteSelectQuery(
                    @"SELECT MAX(question_id) FROM question;"
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

                // Додання нового питання
                Connector.ExecuteQuery(
                   $@"INSERT INTO question(question_id, test_id, question_type_id, question_content, answer_point)
                      VALUES({index}, {testId}, 0, '', 0);"
                );

                DataTable maxId = Connector.ExecuteSelectQuery(
                   @"SELECT MAX(question_id)
                    FROM question;"
                );

                // Нове вікно
                GroupBox groupBox = CreateQuestionGroup(questionsCount);
                questions.Add(new QuestionBox(groupBox, maxId.Rows[0].Field<int>(0)));
                QuestionsPanel.Controls.Add(groupBox);
                questionsCount++;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка:{ex.Message}", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private class QuestionBox
        {
            public GroupBox groupBox;
            private int questionId;

            // Пусте вікно питання
            public QuestionBox(GroupBox groupBox, int questionId)
            {
                (groupBox.Controls["editButton"] as Button).Click += EditQuestion;
                (groupBox.Controls["deleteButton"] as Button).Click += DeleteQuestion;

                this.groupBox = groupBox;
                this.questionId = questionId;
            }

            // Вікно питання, що вже існує
            public QuestionBox(GroupBox groupBox, int questionId, string questionContent,
                int questionTypeId, int answerPoint) : this(groupBox, questionId)
            {
                groupBox.Controls["questionNameBox"].Text = questionContent;
                groupBox.Controls["pointBox"].Text = answerPoint.ToString();
                (groupBox.Controls["questionTypeCombo"] as ComboBox).SelectedIndex = questionTypeId;
            }
            
            // Збереження даних питання з вікна
            public void Update()
            {
                ComboBox box = groupBox.Controls["questionTypeCombo"] as ComboBox;

                int questionType = 0;
                int points = 0;

                try
                {
                    // Отримання оцінки
                    if (groupBox.Controls["pointBox"].Text != "")
                    {
                        points = int.Parse(groupBox.Controls["pointBox"].Text);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Оцінка за тест має бути у вигляді цілого числа!","Помилка!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }

                // Отримання типу питання
                if (box.SelectedIndex >= 0)
                {
                    questionType = box.SelectedIndex;
                }

                try
                {
                    // Виконання запиту
                    Connector.ExecuteQuery(
                        $@"UPDATE question SET
                        question_content = '{groupBox.Controls["questionNameBox"].Text}',
                        question_type_id = {questionType},
                        answer_point = {points}
                        WHERE question_id = {questionId};"
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка:{ex.Message}", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Видалення питання
            public void Delete()
            {
                // Викли підтверження
                if (MessageBox.Show("Ви впевнені, що хочете видалити це питання?", "Увага!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }

                groupBox.Hide();

                try
                {
                    // Виконання запиту
                    Connector.ExecuteQuery(
                        @"UPDATE question
                        SET test_id = NULL
                        WHERE question_id = " + questionId.ToString()
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка:{ex.Message}", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
            private void DeleteQuestion(object sender, EventArgs e)
            {
                Delete();
            }

            private void EditQuestion(object sender, EventArgs e)
            {
                // Отримання типу питання
                ComboBox box = groupBox.Controls["questionTypeCombo"] as ComboBox;
                int questionType = 0;

                if (box.SelectedIndex >= 0)
                {
                    questionType = box.SelectedIndex;
                }

                // Відкриття відповідної форми редагування варіантів відповідей
                switch (questionType)
                {
                    case 0:
                        {
                            ChooseOneEditForm form = new ChooseOneEditForm(questionId);
                            form.ShowDialog();
                        }
                        break;
                    case 1:
                        {
                            ChooseMultiplyEditForm form = new ChooseMultiplyEditForm(questionId);
                            form.ShowDialog();
                        }
                        break;
                    case 2:
                        {
                            InputEditForm form = new InputEditForm(questionId);
                            form.ShowDialog();
                        }
                        break;
                    case 3:
                        {
                            RelateEditForm form = new RelateEditForm(questionId);
                            form.ShowDialog();
                        }
                        break;
                }

                // Оновлення
                Update();
            }
        }
    }
}
