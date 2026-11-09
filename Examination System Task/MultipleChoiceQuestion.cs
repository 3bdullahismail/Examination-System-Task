using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_System_Task
{
public class MultipleChoiceQuestion:Question
    {
        public string[] Choices { get; set; } = new string[4];
        public List<int> CorrectAnswers { get; set; } = new List<int>();
        public override void Display()
        {
            Console.WriteLine($"{Header} ({Mark} marks)");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"{i + 1}. {Choices[i]}");
            }

        }
        public override int CheckAnswer()
        {
            string[] parts = Console.ReadLine().Split(',');
            List<int> studentAnswers = new List<int>();
            for (int i = 0; i < parts.Length; i++)
            {
                studentAnswers.Add(int.Parse(parts[i]));
            }
            bool isCorrect = true;

            if (studentAnswers.Count != CorrectAnswers.Count)
            {
                isCorrect = false;
            }

            for (int i = 0; i < CorrectAnswers.Count; i++)
            {
                if (!studentAnswers.Contains(CorrectAnswers[i]))
                {
                    isCorrect = false;
                }
            }
            if (isCorrect)
            {
                return Mark;
            }
            else
            {
                return 0;
            }
        }
    }
}
