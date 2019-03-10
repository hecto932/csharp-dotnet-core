using System;
using System.Collections.Generic;
using System.Linq;
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
      var listObjects = schoolEngine.GetObjSchoolBases();

      var listIPlace =  from obj in listObjects
                        where obj is Student
                        select (Student) obj;

      schoolEngine.School.cleanPlace();

      // Printer.DrawLine(20);
      // Printer.DrawLine(20);
      // Printer.DrawLine(20);
      // Printer.DrawTitle("Testing polymorphism");
      // var studentTest = new Student{Name="Claire Underwood"};

      // Printer.DrawTitle("Student");
      // WriteLine($"Student: {studentTest.Name}");
      // WriteLine($"Student: ${studentTest.UniqueId}");
      // WriteLine($"Student: {studentTest.GetType()}");

      // ObjSchoolBase ob = studentTest;
      // Printer.DrawTitle("ObjSchoolBase");
      // WriteLine($"Student: {ob.Name}");
      // WriteLine($"Student: ${ob.UniqueId}");
      // WriteLine($"Student: {ob.GetType()}");

      // var evaluationTest = new Evaluation(){ Name="Math Eval", Points=4.5f };
      // Printer.DrawTitle("Evaluation");
      // WriteLine($"Evaluation {evaluationTest.Name}");
      // WriteLine($"Evaluation {evaluationTest.UniqueId}");
      // WriteLine($"Evaluation {evaluationTest.Points}");
      // WriteLine($"Evaluation {evaluationTest.GetType()}");

      // // ob = evaluationTest;
      // // Printer.DrawTitle("ObjSchoolBase");
      // // WriteLine($"Student: {ob.Name}");
      // // WriteLine($"Student: ${ob.UniqueId}");
      // // WriteLine($"Student: {ob.GetType()}");

      // // this is an error
      // // studentTest = (Student) (ObjSchoolBase) evaluationTest;

      // // ob = evaluationTest;
      // if (ob is Student) {
      //   Student studentRest = (Student) ob;
      // }

      // Student studentRest2 = ob as Student;


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
