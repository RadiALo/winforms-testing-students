using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Testing_students
{
    internal class Attempt
    {
        public int TargetQuestions;
        public int TargetPoint;

        public int Point = 0;

        // Id з бази
        public List<int> Questions = new List<int>();
        public List<int> Points = new List<int>();

        // Номери за списком Questions
        public List<int> ChoosedQuestions = new List<int>();

        public static bool GenerateAttemptQuestions(int attemptId, int testId)
        {
            Attempt attempt = new Attempt();

            DataTable TestInfo = Connector.ExecuteSelectQuery(
                $@"SELECT questions_count, test_point FROM test 
                WHERE test_id = {testId}"
            );

            attempt.TargetQuestions = TestInfo.Rows[0].Field<int>(0);
            attempt.TargetPoint = TestInfo.Rows[0].Field<int>(1);

            DataTable QuestionsBank = Connector.ExecuteSelectQuery(
                $@"SELECT question_id, answer_point FROM question 
                WHERE test_id = {testId}"
            );

            for (int i = 0; i < QuestionsBank.Rows.Count; i++)
            {
                attempt.Questions.Add(QuestionsBank.Rows[i].Field<int>(0));
                attempt.Points.Add(QuestionsBank.Rows[i].Field<int>(1));
            }

            int iterator = 0;
            Random random = new Random();

            while (attempt.TargetQuestions != attempt.ChoosedQuestions.Count 
                || attempt.Point != attempt.TargetPoint)
            {
                if (attempt.ChoosedQuestions.Count < attempt.TargetQuestions)
                {
                    List<int> candidates = new List<int>();

                    for (int i = 0; i < attempt.Questions.Count; i++)
                    {
                        if (attempt.Point + attempt.Points[i] <= attempt.TargetPoint
                            && !attempt.ChoosedQuestions.Contains(i))
                        {
                            candidates.Add(i);
                        }
                    }

                    if (candidates.Count > 0)
                    {
                        int choosed = candidates[random.Next(candidates.Count)];
                        attempt.ChoosedQuestions.Add(choosed);
                        attempt.Point += attempt.Points[choosed];
                    }
                    else
                    {
                        if (attempt.ChoosedQuestions.Count == 0)
                        {
                            MessageBox.Show("В тесті немає питань або жодне не може бути додано до тесту через занадто великий бал за його виконання.", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        else if (iterator < 5000)
                        {
                            iterator++;
                            attempt.Point -= attempt.Points[attempt.ChoosedQuestions[0]];
                            attempt.ChoosedQuestions.RemoveAt(0);
                        }
                        else
                        {
                            MessageBox.Show("Невдалось скласти тест! Необхідно додати нові питання або змінити оцінку за тест.", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
                else if (iterator < 5000)
                {
                    iterator++;
                    attempt.Point -= attempt.Points[attempt.ChoosedQuestions[0]];
                    attempt.ChoosedQuestions.RemoveAt(0);
                }
                else
                {
                    MessageBox.Show("Невдалось скласти тест! Необхідно додати нові питання або змінити оцінку за тест.", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            for (int i = 0; i < attempt.ChoosedQuestions.Count; i++)
            {
                Connector.ExecuteQuery(
                    "INSERT INTO answer(attempt_id, question_id, answer_provided)" +
                    "SELECT " + attemptId.ToString() + ", " + attempt.Questions[attempt.ChoosedQuestions[i]] + ", ''"    
                );
            }

            return true;
        }
    }
}
