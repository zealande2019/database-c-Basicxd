using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ConsoleAppDatabase
{
    public static class FacadeStudent
    {
        private static string conn = "Server=tcp:basic1997.database.windows.net,1433;Initial Catalog = Testing; Persist Security Info=False;User " +
                                     "ID = basic; Password=Miko1234; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;";

        public static List<Student> GetAllStudents()
        {
            string sql = "Select * from student";

            var result = new List<Student>();
            using (var databaseConnection = new SqlConnection(conn))
            {
                databaseConnection.Open();
                using (var selectCommand = new SqlCommand(sql, databaseConnection))
                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int studentid = reader.GetInt32(0);
                            string navn = reader.GetString(1);
                            string mobilnr = reader.GetString(2);

                            var Student = new Student()
                            {
                                StudentId = studentid,
                                Navn = navn,
                                MobilNr = mobilnr
                            };

                            result.Add(Student);
                        }
                    }
                }
                return result;
            }


        }

        public static List<Exam> GetSpecifikExam()
        {
            string sql = "SELECT ExamID from dbo.Exam";

            var SpecifikExamId = new List<Exam>();
            using (var databaseConnection = new SqlConnection(conn))
            {
                databaseConnection.Open();
                using (var selectCommand = new SqlCommand(sql, databaseConnection))
                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int examId = reader.GetInt32(0);

                            var Exam = new Exam()
                            {
                                ExamId = examId
                            };

                            SpecifikExamId.Add(Exam);
                        }
                    }
                }

                return SpecifikExamId;
            }
        }

        public static void DeleteExam(int ExamId)
        {
            string sql = "DELETE FROM Exam WHERE ExamId='@ExamId'";
            using (var databaseConnection = new SqlConnection(conn))
            {
                databaseConnection.Open();
                using (var  removeCommand = new SqlCommand(sql, databaseConnection))
                {
                    removeCommand.CommandType = System.Data.CommandType.Text;
                    removeCommand.Parameters.AddWithValue("@ExamId", ExamId);

                    int rowsaffected = removeCommand.ExecuteNonQuery();

                    Console.WriteLine($"$Remove : {rowsaffected}");

                }

            }
       
        }
    }
}