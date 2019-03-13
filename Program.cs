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
      var evalList = reporter.GetEvaluationList();
      var subjectList = reporter.GetSubjectList();
      var listEvaluationXsubject = reporter.GetEvaluationDictBySubject();
      var listAverageXSubject = reporter.GetStudentAverageBySubject();
      var last = reporter.getBestStudentsBySubjectAndPoint("Castellano", 4);

      Printer.DrawTitle("Captura de evauluacin por consola");
      var newEval = new Evaluation();
      string name, pointString;
      float point;

      Printer.pressEnter();
      name = Console.ReadLine();

      if (string.IsNullOrWhiteSpace(name))
      {
        throw new ArgumentException("Value of name cant be empty");
      }
      else
      {
        newEval.Name = name.ToLower();
        Printer.DrawTitle("Name correct.");
      }

      WriteLine("Point of evaluation");
      Printer.pressEnter();
      pointString = Console.ReadLine();

      if (string.IsNullOrWhiteSpace(pointString))
      {
        Printer.DrawTitle("The value is incorrect...");
      }
      else
      {
        try
        {
          newEval.Points = float.Parse(pointString);
          if (newEval.Points < 0 || newEval.Points > 5) {
            throw new ArgumentOutOfRangeException("The value must be between 0 and 5");
          }
          WriteLine("The evaluation name is correct");
        }
        catch(ArgumentOutOfRangeException arge) {
          WriteLine(arge.Message);
        }
        catch(Exception e)
        {
          WriteLine(e.Message);
        } finally {
          Printer.DrawTitle("The point value is not valid.");
        }
      }
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
