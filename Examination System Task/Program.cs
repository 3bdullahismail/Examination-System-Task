namespace Examination_System_Task
{
    public enum Level
    {
        Easy = 1, Medium = 2, Hard = 3

    }
    internal class Program
    {
        static List<Question> questionBank = new List<Question>();
        static void DoctorMode()
        {
            Console.Write("How many questions? ");
            int count = int.Parse(Console.ReadLine());

            for (int i = 1; i <= count; i++)
            {
                Console.WriteLine($"--- Question {i} ---");

                Console.Write("Type (1. True/False, 2. Choose One, 3. Multiple Choice): ");
                int type = int.Parse(Console.ReadLine());

                Console.Write("Level (1. Easy, 2. Medium, 3. Hard): ");
                Level level = (Level)int.Parse(Console.ReadLine());

                Console.Write("Question header: ");
                string header = Console.ReadLine();

                Console.Write("Marks: ");
                int mark = int.Parse(Console.ReadLine());

                Question q = null;
                if (type == 1)
                {
                    TrueFalseQuestion t = new TrueFalseQuestion();
                    Console.Write("Correct answer (1. True, 2. False): ");
                    int ans = int.Parse(Console.ReadLine());
                    t.CorrectAnswer = (ans == 1);
                    q = t;
                }
                else if (type == 2)
                {
                    ChooseOneQuestion c = new ChooseOneQuestion();

                    for (int j = 0; j < 4; j++)
                    {
                        Console.Write($"Choice {j + 1}: ");
                        c.Choices[j] = Console.ReadLine();
                    }

                    Console.Write("Correct choice number (1-4): ");
                    c.CorrectChoice = int.Parse(Console.ReadLine());

                    q = c;
                }
                else
                {
                    MultipleChoiceQuestion m = new MultipleChoiceQuestion();
                    for (int l = 0; l < 4; l++)
                    {

                        Console.Write($"Choice {l + 1}: ");
                        m.Choices[l] = Console.ReadLine();
                    }
                    Console.Write("Correct answers  ");
                    string[] parts = Console.ReadLine().Split(',');
                    for (int j = 0; j < parts.Length; j++)
                    {
                        m.CorrectAnswers.Add(int.Parse(parts[j]));
                    }
                    q = m;
                }
                q.Header = header;
                q.Mark = mark;
                q.Level = level;
                questionBank.Add(q);
            }
        }
        static void StudentMode()
        {
            Console.Write("Exam type (1. Practical, 2. Final): ");
            int examType = int.Parse(Console.ReadLine());

            Console.Write("Level (1. Easy, 2. Medium, 3. Hard): ");
            Level level = (Level)int.Parse(Console.ReadLine());
            List<Question> examQuestions = new List<Question>();

            for (int i = 0; i < questionBank.Count; i++)
            {
                if (questionBank[i].Level == level)
                {
                    examQuestions.Add(questionBank[i]);
                }
            }
            if (examQuestions.Count == 0)
            {
                Console.WriteLine("No questions for this level.");
                return;
            }
            int numberOfQuestions = examQuestions.Count;

            if (examType == 1)
            {
                numberOfQuestions = examQuestions.Count / 2;
                if (numberOfQuestions == 0)
                {
                    numberOfQuestions = 1;
                }
            }
            int score = 0;
            int totalMarks = 0;

            for (int i = 0; i < numberOfQuestions; i++)
            {
                Console.WriteLine($"\nQ{i + 1}:");
                examQuestions[i].Display();
                score += examQuestions[i].CheckAnswer();
                totalMarks += examQuestions[i].Mark;
            }

            Console.WriteLine($"\nYour Result: {score} / {totalMarks}");
        }
        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n===== Examination System =====");
                Console.WriteLine("1. Doctor Mode");
                Console.WriteLine("2. Student Mode");
                Console.WriteLine("3. Exit");
                Console.Write("Choose: ");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    DoctorMode();
                }
                else if (choice == 2)
                {
                    StudentMode();
                }
                else if (choice == 3)
                {
                    running = false;
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                }
            }
        }
    }
}