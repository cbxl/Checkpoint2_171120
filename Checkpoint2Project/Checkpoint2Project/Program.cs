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
                Console.WriteLine(student.studentFirstName + " " + student.studentLastName + " : moyenne = " + student.average);
            }


            ICollection<Student> studentName = DataAbstractionLayer.SelectStudentByLastName("Bui");
            foreach (Student student in studentName)
            {
                Console.WriteLine(student.studentFirstName +" " + student.studentLastName);
            }

            ICollection<Class> promotions = DataAbstractionLayer.SelectAllPromotions();
            foreach (Class promotion in promotions)
            {
                Console.WriteLine(promotion.classLanguage + " " + " : moyenne = " + promotion.average);
            }

            DataAbstractionLayer.Disconnect();
        }
    }
}
