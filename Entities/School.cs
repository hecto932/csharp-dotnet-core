using System;
using System.Collections.Generic;
using CodeSchool.Util;

namespace CoreSchool.Entities
{
  public class School : ObjSchoolBase, IPlace
  {
    public int YearFundation { get; set; }

    public string Country { get; set; }
    public string City { get; set; }

    public string Address { get; set; }

    public TypeSchool TypeSchool { get; set; }

    public List<Course> Courses { get; set; } = new List<Course>();

    // Igualacion por Tuplas, clasico en lenguajes funcionales
    public School(string name, int year) => (Name, YearFundation) = (name, year);


    public School(string name, int year,
                   TypeSchool typeSchool,
                   string country = "", string city = "") : base()
    {
      (Name, YearFundation) = (name, year);
      Country = country;
      City = City;
    }

    public override string ToString()
    {
      return $"Name: \"{Name}\", TypeSchool: {TypeSchool} {System.Environment.NewLine}Country: {Country}, City: {City}";
    }

    public void cleanPlace()
    {
      Printer.DrawLine();
      Console.WriteLine("Cleaning school...");
      foreach (var c in Courses)
      {
          c.cleanPlace();
      }
      Console.WriteLine("School {Name} is clean...");
    }
  }
}