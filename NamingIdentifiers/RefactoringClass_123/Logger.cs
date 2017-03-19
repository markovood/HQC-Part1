namespace RefactoringClass_123
{
    using System;
    
    public class Logger
    {
        public void Log(bool isLogable)
        {
            string isLogableAsString = isLogable.ToString();
            Console.WriteLine(isLogableAsString);
        }
    }
}