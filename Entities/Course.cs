using System;
using System.Collections.Generic;
using CodeSchool.Util;

namespace CoreSchool.Entities
{
  public class Course : ObjSchoolBase, IPlace
  {
    public TypeWorkDay typeWorkDay { get; set; }
    public List<Subject> Subjects { get; set; }
    public List<Student> Students { get; set; }
    public string Address { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public void cleanPlace()
    {
      Printer.DrawLine();
      Console.WriteLine("Cleaning place...");
      Console.WriteLine("Course {Name} is clean...");
    }
  }
}