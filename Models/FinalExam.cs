using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C48_G03_EXAM01.Models
{
    public class FinalExam : Exam
    {
        public FinalExam(int time, int numberOfQuestions, Question[] questions)
            : base(time, numberOfQuestions, questions)
        {
        }

        public override void ShowExam()
        {
            Console.WriteLine("\nFinal Exam");

            int[] userAnswers = new int[Questions.Length];
            Stopwatch stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < Questions.Length; i++)
            {
                Question question = Questions[i];
                Console.WriteLine("Question " + (i + 1) + ": " + question.Body);
                question.DisplayQuestion();

                Console.Write("Enter your answer ID: ");
                int answerId;
                while (!int.TryParse(Console.ReadLine(), out answerId) || answerId < 1 || answerId > question.AnswerList.Length)
                {
                    Console.Write("Invalid answer. Please enter a number from 1 to " + question.AnswerList.Length + ": ");
                }

                userAnswers[i] = answerId;
            }

            stopwatch.Stop();

            int totalMark = 0;
            int obtainedMark = 0;

            Console.WriteLine("\nFinal Exam Results:");
            for (int i = 0; i < Questions.Length; i++)
            {
                Question question = Questions[i];
                totalMark += question.Mark;

                if (question.CheckAnswer(userAnswers[i]))
                    obtainedMark += question.Mark;

                Console.WriteLine("Question " + (i + 1) + ": " + question.Body);
                Console.WriteLine("Your Answer => " + question.GetAnswerText(userAnswers[i]));
                Console.WriteLine("Correct Answer => " + question.GetCorrectAnswerText());
                Console.WriteLine();
            }

            Console.WriteLine("Your Grade is " + obtainedMark + " from " + totalMark);
            Console.WriteLine("Time = " + stopwatch.Elapsed);
            Console.WriteLine("Thank you");
        }
    }

}
