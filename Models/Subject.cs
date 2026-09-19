using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C48_G03_EXAM01.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam Exam { get; set; }

        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }

        public void CreateExam()
        {

            Console.Write("Enter the type of exam (1 for Practical, 2 for Final): ");
            int examType;
            while (!int.TryParse(Console.ReadLine(), out examType) || (examType != 1 && examType != 2))
            {
                Console.Write("Invalid input. Please enter 1 or 2: ");
            }

            Console.Write("Please enter the time for the exam (30 to 180 minutes): ");
            int time;
            while (!int.TryParse(Console.ReadLine(), out time) || time < 30 || time > 180)
            {
                Console.Write("Invalid time. Please enter a value from 30 to 180: ");
            }

            Console.Write("Please enter the number of questions: ");
            int numberOfQuestions;
            while (!int.TryParse(Console.ReadLine(), out numberOfQuestions) || numberOfQuestions <= 0)
            {
                Console.Write("Invalid number. Please enter a number greater than 0: ");
            }

            Question[] questions = new Question[numberOfQuestions];

            for (int i = 0; i < numberOfQuestions; i++)
            {
                Console.WriteLine("\nEnter details for question " + (i + 1) + ":");

                if (examType == 2)
                {

                    Console.Write("Choose question type: 1 for MCQ, 2 for True/False: ");
                    int questionType;
                    while (!int.TryParse(Console.ReadLine(), out questionType) || (questionType != 1 && questionType != 2))
                    {
                        Console.Write("Invalid input. Please enter 1 or 2: ");
                    }

                    if (questionType == 1)
                        questions[i] = CreateMCQQuestion();
                    else
                        questions[i] = CreateTrueFalseQuestion();
                }
                else
                {

                    questions[i] = CreateMCQQuestion();
                }
            }

            if (examType == 2)
                Exam = new FinalExam(time, numberOfQuestions, questions);
            else
                Exam = new PracticalExam(time, numberOfQuestions, questions);
        }

        private MCQQuestion CreateMCQQuestion()
        {
            Console.Write("Please enter the question body: ");
            string body = Console.ReadLine();


            Console.Write("Please enter the question mark: ");
            int mark;
            while (!int.TryParse(Console.ReadLine(), out mark) || mark <= 0)
            {
                Console.Write("Invalid mark. Please enter a number greater than 0: ");
            }

            Console.WriteLine("Choices of Question:");
            Answer[] answers = new Answer[4];

            Console.Write("Please enter choice number 1: ");
            answers[0] = new Answer(1, Console.ReadLine());

            Console.Write("Please enter choice number 2: ");
            answers[1] = new Answer(2, Console.ReadLine());

            Console.Write("Please enter choice number 3: ");
            answers[2] = new Answer(3, Console.ReadLine());

            Console.Write("Please enter choice number 4: ");
            answers[3] = new Answer(4, Console.ReadLine());


            Console.Write("Please enter the ID of the correct answer (1 to 4): ");
            int correctId;
            while (!int.TryParse(Console.ReadLine(), out correctId) || correctId < 1 || correctId > 4)
            {
                Console.Write("Invalid ID. Please enter a number from 1 to 4: ");
            }

            return new MCQQuestion("Question", body, mark, answers, correctId);
        }

        private TrueFalseQuestion CreateTrueFalseQuestion()
        {
            Console.Write("Please enter the question body: ");
            string body = Console.ReadLine();


            Console.Write("Please enter the question mark: ");
            int mark;
            while (!int.TryParse(Console.ReadLine(), out mark) || mark <= 0)
            {
                Console.Write("Invalid mark. Please enter a number greater than 0: ");
            }


            Console.Write("Please enter the correct answer ID (1 for True, 2 for False): ");
            int correctId;
            while (!int.TryParse(Console.ReadLine(), out correctId) || (correctId != 1 && correctId != 2))
            {
                Console.Write("Invalid ID. Please enter 1 or 2: ");
            }

            return new TrueFalseQuestion("Question", body, mark, correctId);
        }

        public override string ToString()
        {
            return "Subject [" + SubjectId + "] " + SubjectName;
        }
    }

}
