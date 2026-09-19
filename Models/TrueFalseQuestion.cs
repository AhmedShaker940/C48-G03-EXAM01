using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C48_G03_EXAM01.Models
{
    public class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(string header, string body, int mark, int correctAnswerId)
            : base(header, body, mark, new[]
            {
            new Answer(1, "True"),
            new Answer(2, "False")
            }, correctAnswerId)
        {
        }

        public override void DisplayQuestion()
        {
            Console.WriteLine($"True | False Question: {ToString()}");
            foreach (var answer in AnswerList)
            {
                Console.WriteLine(answer);
            }
        }

        public override object Clone()
        {
            return new TrueFalseQuestion(Header, Body, Mark, CorrectAnswerId);
        }
    }

}
