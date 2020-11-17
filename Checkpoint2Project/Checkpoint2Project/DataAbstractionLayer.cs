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
            command.CommandText = "SELECT * FROM Student";
            SqlDataReader reader = command.ExecuteReader();
            List<Student> students = new List<Student>();
            while (reader.Read())
            {
                Student student = new Student
                {
                    studentId = reader.GetInt32(0),
                    studentFirstName = reader.GetString(1),
                    studentLastName = reader.GetString(2),
                    classId = reader.GetInt32(3)                    
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
    }
}
