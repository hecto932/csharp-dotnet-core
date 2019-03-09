using System;
using System.Collections.Generic;
using CodeSchool.Util;
using CoreSchool.Entities;
using static System.Console;

namespace CoreSchool
{
  class Program
  {
    static void Main(string[] args)
    {
      var schoolEngine = new SchoolEngine();
      schoolEngine.initialization();
      Printer.DrawTitle("Welcome to the School");
      printSchoolCourses(schoolEngine.School);

      Printer.DrawLine(20);
      Printer.DrawLine(20);
      Printer.DrawLine(20);
      Printer.DrawTitle("Testing polimorfismo");
      var studentTest = new Student{Name="Claire Underwood"};

      ObjSchoolBase ob = studentTest;
      Printer.DrawTitle("Student");
      WriteLine($"Student: {studentTest.Name}");
      WriteLine($"Student: ${studentTest.UniqueId}");

      Printer.DrawTitle("ObjSchoolBase");
      WriteLine($"Student: {ob.Name}");
      WriteLine($"Student: {ob.UniqueId}");

      // var objDummy = new ObjSchoolBase(){Name="Frank Underwood"};

    }


    private static void printSchoolCourses(School school)
    {
      Printer.DrawTitle(school.Name);

      if (school != null && school.Courses != null) {
        foreach (var course in school.Courses)
        {
            WriteLine(course);
        }
      }
    }
  }
}
