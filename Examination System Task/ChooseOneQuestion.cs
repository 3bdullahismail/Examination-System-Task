using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_System_Task
{
  public class ChooseOneQuestion:Question
    {
        public string[] Choices { get; set; } = new string[4];
        public int CorrectChoice { get; set; }
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
            int answer = int.Parse(Console.ReadLine());
        

            if (answer == CorrectChoice)
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
