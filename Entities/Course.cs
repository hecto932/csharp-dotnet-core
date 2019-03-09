using System;
using System.Collections.Generic;

namespace CoreSchool.Entities
{
    public class Course: ObjSchoolBase
    {
        public TypeWorkDay typeWorkDay { get; set; }
        public List<Subject> Subjects{ get; set; }
        public List<Student> Students { get; set; }
    }
}