﻿using System;

namespace Checkpoint2Project
{
    internal class Student
    {
        public Int32 studentId { get; set; }
        public String studentFirstName { get; set; }
        public String studentLastName { get; set; }
        public Int32 classId { get; set; }

        public override string ToString()
        {
            return studentFirstName + " " + studentLastName;
        }
    }
}
