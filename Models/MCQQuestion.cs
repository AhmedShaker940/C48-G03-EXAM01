using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C48_G03_EXAM01.Models
{
    public class MCQQuestion : Question
    {
        public MCQQuestion(string header, string body, int mark, Answer[] answerList, int correctAnswerId)
            : base(header, body, mark, answerList, correctAnswerId)
        {
        }

        public override void DisplayQuestion()
        {
            Console.WriteLine($"MCQ Question: {ToString()}");
            foreach (var answer in AnswerList)
            {
                Console.WriteLine(answer);
            }
        }

        public override object Clone()
        {
            var clonedAnswers = new Answer[AnswerList.Length];
            for (int i = 0; i < AnswerList.Length; i++)
                clonedAnswers[i] = (Answer)AnswerList[i].Clone();

            return new MCQQuestion(Header, Body, Mark, clonedAnswers, CorrectAnswerId);
        }
    }

}
