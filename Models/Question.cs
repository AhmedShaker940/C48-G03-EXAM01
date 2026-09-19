using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C48_G03_EXAM01.Models
{
    public abstract class Question : ICloneable, IComparable<Question>
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }

        public Answer[] AnswerList { get; set; }
        public int CorrectAnswerId { get; set; }

        protected Question(string header, string body, int mark, Answer[] answerList, int correctAnswerId)
        {
            Header = header;
            Body = body;
            Mark = mark;
            AnswerList = answerList;
            CorrectAnswerId = correctAnswerId;
        }

        public abstract void DisplayQuestion();

        public bool CheckAnswer(int answerId)
        {
            return answerId == CorrectAnswerId;
        }

        public string GetAnswerText(int answerId)
        {
            foreach (var answer in AnswerList)
            {
                if (answer.AnswerId == answerId)
                    return answer.AnswerText;
            }
            return "N/A";
        }

        public string GetCorrectAnswerText() => GetAnswerText(CorrectAnswerId);

        public int CompareTo(Question? other)
        {
            if (other == null) return 1;
            return Mark.CompareTo(other.Mark);
        }

        public abstract object Clone();

        public override string ToString()
        {
            return $"{Body}   Mark {Mark}";
        }
    }

}
