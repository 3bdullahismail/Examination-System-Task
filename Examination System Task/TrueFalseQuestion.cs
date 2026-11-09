using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_System_Task
{
    public class TrueFalseQuestion : Question
    {
        public bool CorrectAnswer { get; set; }

        public override void Display()
        {
            Console.WriteLine($"{Header} ({Mark} marks)");
            Console.WriteLine("1. True");
            Console.WriteLine("2. False");
        }

        public override int CheckAnswer()
        {
            int answer = int.Parse(Console.ReadLine());
            bool studentAnswer = (answer == 1);

            if (studentAnswer == CorrectAnswer)
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