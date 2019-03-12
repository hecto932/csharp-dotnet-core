using System;
using System.Collections.Generic;
using System.Linq;
using CodeSchool.Util;
using CoreSchool.App;
using CoreSchool.Entities;
using static System.Console;

namespace CoreSchool
{
  class Program
  {
    static void Main(string[] args)
    {
      AppDomain.CurrentDomain.ProcessExit += eventAction;
      AppDomain.CurrentDomain.ProcessExit += (o, s) => Console.WriteLine("Hola");

      var schoolEngine = new SchoolEngine();
      schoolEngine.initialization();
      Printer.DrawTitle("Welcome to the School");

      var reporter = new Reporter(schoolEngine.GetObjDictionary());
      reporter.GetEvaluationList();
    }

    private static void eventAction(object sender, EventArgs e)
    {
      Printer.DrawTitle("SALIENDO");
      // Printer.Beep(3000, 1000, 3);
      Printer.DrawTitle("SALIO");
    }

    private static void printSchoolCourses(School school)
    {
      Printer.DrawTitle(school.Name);

      if (school != null && school.Courses != null)
      {
        foreach (var course in school.Courses)
        {
          WriteLine(course);
        }
      }
    }
  }
}
