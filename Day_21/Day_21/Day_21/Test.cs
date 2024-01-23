using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_21
{
    internal class Test
    {
        public int totalQuestionCount { get; set; }
        public string QuestionText { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public string CorrectAnswer { get; set; }

        static public Test parseMethod(string qeusetion)
        {
            string[] array = qeusetion.Split('|');

            Test test = new Test();
            test.CorrectAnswer = CorrectAnswerMethod(array);
            HideCorrectAnswer(array);
            test.QuestionText = array[0];
            test.Answer1 = array[1];
            test.Answer2 = array[2];
            test.Answer3 = array[3];
            test.Answer4 = array[4];

            return test;
        }
        private static string CorrectAnswerMethod(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].EndsWith('*'))
                {
                    array[i] = array[i].TrimEnd('*');
                    return array[i];
                }
            }
            return default;
        }
        private static void HideCorrectAnswer(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = array[i].TrimEnd('*');
            }
        }
        public bool IsCorrectAnswer(string answer)
        {
            if (answer == CorrectAnswer)
            {
                return true;
            }
            return false;
        }
    }
}
