using System;
using System.Data.SqlClient;
using System.Collections.Generic;


namespace Checkpoint2Project
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
            stringBuilder.DataSource = "LOCALHOST\\SQLEXPRESS";
            stringBuilder.InitialCatalog = "Checkpoint2";
            stringBuilder.IntegratedSecurity = true;

            DataAbstractionLayer.Connect(stringBuilder);

            ICollection<Student> students = DataAbstractionLayer.SelectAllStudents();
            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }


            ICollection<Student> studentName = DataAbstractionLayer.SelectStudentByLastName("Bui");
            foreach (Student student in studentName)
            {
                Console.WriteLine(student);
            }

            DataAbstractionLayer.Disconnect();
        }
    }
}
