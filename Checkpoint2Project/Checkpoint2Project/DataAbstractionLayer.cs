using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Checkpoint2Project
{
    internal class DataAbstractionLayer
    {
        private static SqlConnection _connection = new SqlConnection();

        internal static void Connect(SqlConnectionStringBuilder stringBuilder)
        {
            _connection.ConnectionString = stringBuilder.ConnectionString;
            _connection.Open();
        }

        internal static void Disconnect()
        {
            _connection.Close();
        }

        internal static ICollection<Student> SelectAllStudents()
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT studentLastName, studentFirstName, AVG (assignmentNote) FROM Assignment INNER JOIN Student ON studentId = FK_studentId GROUP BY studentLastName, studentFirstName";
            SqlDataReader reader = command.ExecuteReader();
            List<Student> students = new List<Student>();
            while (reader.Read())
            {
                Student student = new Student
                {
                    
                    studentFirstName = reader.GetString(0),
                    studentLastName = reader.GetString(1),
                    average = reader.GetDouble(2)
                    
                };
                students.Add(student);
            }
            reader.Close();
            return students;
        }

        

        internal static ICollection<Student> SelectStudentByLastName(String studentLastName)
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT studentLastName, studentFirstName FROM Student WHERE studentLastName = '" + studentLastName + "' ";
            SqlDataReader reader = command.ExecuteReader();
            List<Student> students = new List<Student>();
            while (reader.Read())
            {
                Student student = new Student
                {
                    studentLastName = reader.GetString(0),
                    studentFirstName = reader.GetString(1),

                };
                students.Add(student);

            }

            reader.Close();
            return students;
        }

        internal static ICollection<Class> SelectAllPromotions()
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT classLanguage, AVG (assignmentNote) FROM Assignment INNER JOIN Student ON studentId = FK_studentId INNER JOIN Class ON classId = FK_classId GROUP BY classLanguage";
            SqlDataReader reader = command.ExecuteReader();
            List<Class> promotions = new List<Class>();
            while (reader.Read())
            {
                Class promotion = new Class
                {

                    classLanguage = reader.GetString(0),
                    average = reader.GetDouble(1)

                };
                promotions.Add(promotion);
            }
            reader.Close();
            return promotions;
        }
    }
}
