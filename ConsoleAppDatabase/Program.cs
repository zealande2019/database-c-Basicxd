using System;
using System.Collections.Generic;

namespace ConsoleAppDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> listStudents = new List<Student>();
            listStudents = FacadeStudent.GetAllStudents();

            foreach (var mi in listStudents)
            {
                Console.WriteLine($"{mi.Navn} {mi.MobilNr}");
            }

            Console.WriteLine("-----------------------");

            List<Exam> listExams = new List<Exam>();
            listExams = FacadeStudent.GetSpecifikExam();

            foreach (var mi in listExams)
            {
                Console.WriteLine($"{mi.ExamId}");
            }

            FacadeStudent.DeleteExam(36);


            foreach (var mi in listExams)
            {
                Console.WriteLine($"{mi.ExamId}");
            }

            Console.ReadLine();

            Console.WriteLine("-----------------------");

            




        }
    }
}
