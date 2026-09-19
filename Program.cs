using C48_G03_EXAM01.Models;

namespace C48_G03_EXAM01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject(1, "OOP");

            subject.CreateExam();

            Console.Write("\nDo You Want To Start Exam (Y | N): ");
            string choice = Console.ReadLine();

            while (choice != "Y" && choice != "y" && choice != "N" && choice != "n")
            {
                Console.Write("Invalid input. Please enter Y or N: ");
                choice = Console.ReadLine();
            }

            if (choice == "Y" || choice == "y")
            {
                subject.Exam.ShowExam();
            }
            else
            {
                Console.WriteLine("Exam cancelled. Goodbye!");
            }
        }
    }
}
