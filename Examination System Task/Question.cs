using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_System_Task
{
    public abstract class Question
    {
        public string Header { get; set; } = "";
        public int Mark { get; set; }
        public Level Level { get; set; }
        public abstract void Display();
        public abstract int CheckAnswer();


    }
}