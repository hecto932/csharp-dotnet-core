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
      Dictionary<int, string> dictionary = new Dictionary<int, string> ();
      dictionary.Add(10, "hecto932");
      dictionary.Add(23, "Lorem Ipsum");

      foreach (var keyValPair in dictionary)
      {
          WriteLine($"Key: {keyValPair.Key}, Value: {keyValPair.Value}");
      }

      Printer.DrawTitle("Access to Dictionary");
      dictionary[0] = "Pokeman";
      WriteLine(dictionary[23]);
      WriteLine(dictionary[0]);

      Printer.DrawTitle("Another dictionary");
      var dic = new Dictionary<string, string>();
      dic["luna"] = "Cuerpo celeste que gira al rededor de la tierra.";
      // dic.Add("luna", "protagonista de soy luna"); // This is not going to work becase already exist.

      WriteLine(dic["luna"]);

      var dictmp = schoolEngine.GetObjDictionary();

      schoolEngine.PrintDictionary(dictmp);

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
