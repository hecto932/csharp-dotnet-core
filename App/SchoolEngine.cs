using System;
using System.Collections.Generic;
using System.Linq;
using CodeSchool.Util;
using CoreSchool.Entities;

namespace CoreSchool.App
{
  public sealed class SchoolEngine
  {
    public School School { get; set; }


    public SchoolEngine()
    {

    }

    public void initialization()
    {
      School = new School(
          "Platzi Academy",
          2012,
          TypeSchool.Primary,
          city: "Bogota",
          country: "Colombia"
      );

      uploadCourses();
      uploadSubjects();
      uploadEvaluations();
    }

    public void PrintDictionary(
      Dictionary<DictionaryKeys, IEnumerable<ObjSchoolBase>> dic,
      bool printEval = false
    )
    {
      foreach (var obj in dic)
      {
        Printer.DrawTitle(obj.Key.ToString());
        foreach (var value in obj.Value)
        {
          switch (obj.Key)
          {
              case DictionaryKeys.Evaluation:
                if (printEval) {
                  Console.WriteLine($"{obj.Key.ToString()}: {value}");
                }
              break;
              case DictionaryKeys.Student:
                Console.WriteLine($"{obj.Key.ToString()}: {value.Name}");
              break;
              case DictionaryKeys.Course:
                var courseTmp = value as Course;
                if (courseTmp != null) {
                  int count = courseTmp.Students.Count;
                  Console.WriteLine($"{obj.Key.ToString()}: {value.Name} Count: {count}");
                }
              break;
              default:
                Console.WriteLine($"{obj.Key.ToString()}: {value}");
              break;
          }
        }
      }
    }

    public Dictionary<DictionaryKeys, IEnumerable<ObjSchoolBase>> GetObjDictionary()
    {
      Dictionary<DictionaryKeys, IEnumerable<ObjSchoolBase>> dictionary = new Dictionary<DictionaryKeys, IEnumerable<ObjSchoolBase>>();

      dictionary.Add(DictionaryKeys.School, new[] { School });
      dictionary.Add(DictionaryKeys.Course, School.Courses.Cast<ObjSchoolBase>());

      var listEvaluationTmp = new List<Evaluation>();
      var listSubjetsTmp = new List<Subject>();
      var listStudentTmp = new List<Student>();

      foreach (var c in School.Courses)
      {
        listSubjetsTmp.AddRange(c.Subjects);
        listStudentTmp.AddRange(c.Students);

        foreach (var s in c.Students)
        {
          listEvaluationTmp.AddRange(s.Evaluations);
        }
      }

      dictionary.Add(DictionaryKeys.Subject, listSubjetsTmp.Cast<ObjSchoolBase>());
      dictionary.Add(DictionaryKeys.Student, listStudentTmp.Cast<ObjSchoolBase>());
      dictionary.Add(DictionaryKeys.Evaluation, listEvaluationTmp.Cast<ObjSchoolBase>());

      return dictionary;
    }

    public IReadOnlyList<ObjSchoolBase> GetObjSchoolBases(
      bool getEvaluations = true,
      bool getStudents = true,
      bool getSubjets = true,
      bool getCourses = true
    )
    {
      return GetObjSchoolBases(out int dummy, out dummy, out dummy, out dummy);
    }

    public IReadOnlyList<ObjSchoolBase> GetObjSchoolBases(
      out int countEvaluations,
      bool getEvaluations = true,
      bool getStudents = true,
      bool getSubjets = true,
      bool getCourses = true
    )
    {
      return GetObjSchoolBases(out countEvaluations, out int dummy, out dummy, out dummy);
    }

    public IReadOnlyList<ObjSchoolBase> GetObjSchoolBases(
      out int countEvaluations,
      out int countCourses,
      bool getEvaluations = true,
      bool getStudents = true,
      bool getSubjets = true,
      bool getCourses = true
    )
    {
      return GetObjSchoolBases(out countEvaluations, out countCourses, out int dummy, out dummy);
    }

    public IReadOnlyList<ObjSchoolBase> GetObjSchoolBases(
      out int countEvaluations,
      out int countCourses,
      out int countSubjects,
      bool getEvaluations = true,
      bool getStudents = true,
      bool getSubjets = true,
      bool getCourses = true
    )
    {
      return GetObjSchoolBases(out countEvaluations, out countCourses, out countSubjects, out int dummy);
    }

    public IReadOnlyList<ObjSchoolBase> GetObjSchoolBases(
      out int countEvaluations,
      out int countCourses,
      out int countSubjects,
      out int countStudent,
      bool getEvaluations = true,
      bool getStudents = true,
      bool getSubjets = true,
      bool getCourses = true
    )
    {
      var listObj = new List<ObjSchoolBase>();
      countEvaluations = 0;
      countStudent = 0;
      countCourses = 0;
      countSubjects = 0;

      listObj.Add(School);
      if (getCourses)
      {
        listObj.AddRange(School.Courses);
        countCourses = School.Courses.Count;
      }

      foreach (var c in School.Courses)
      {
        if (getStudents)
        {
          listObj.AddRange(c.Students);
          countStudent += c.Students.Count;
        }

        if (getSubjets)
        {
          listObj.AddRange(c.Subjects);
          countSubjects += c.Subjects.Count;
        }

        if (getEvaluations)
        {
          foreach (var s in c.Students)
          {
            listObj.AddRange(s.Evaluations);
            countEvaluations += s.Evaluations.Count;
          }
        }
      };

      return listObj.AsReadOnly();
    }
    #region Upload methods
    private void uploadEvaluations()
    {
      var rnd = new Random();
      foreach (var course in School.Courses)
      {
        foreach (var subject in course.Subjects)
        {
          foreach (var student in course.Students)
          {
            for (int i = 0; i < 5; i++)
            {
              var ev = new Evaluation
              {
                Subject = subject,
                Name = $"{subject.Name} ev#{i + 1}",
                Points = MathF.Round(5 * (float)rnd.NextDouble(), 2),
                Student = student
              };
              student.Evaluations.Add(ev);
            }
          }
        }
      }
    }

    private void uploadSubjects()
    {
      foreach (var course in School.Courses)
      {
        List<Subject> listSubjects = new List<Subject>(){
          new Subject{Name="Matematicas"},
          new Subject{Name="Educacion Fisica"},
          new Subject{Name="Castellano"},
          new Subject{Name="Ciencias Naturales"}
        };
        course.Subjects = listSubjects;
      }
    }

    private List<Student> generateStudents(int countPeople)
    {
      string[] name = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
      string[] lastname = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
      string[] secondName = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

      var listStudents = from n1 in name
                         from n2 in secondName
                         from l1 in lastname
                         select new Student { Name = $"{n1} {n2} {l1}" };

      return listStudents.OrderBy((st) => st.UniqueId).Take(countPeople).ToList();
    }

    public void uploadCourses()
    {

      School.Courses = new List<Course>() {
        new Course() { Name = "101", typeWorkDay=TypeWorkDay.Morning },
        new Course() { Name = "201", typeWorkDay=TypeWorkDay.Morning },
        new Course() { Name = "301", typeWorkDay=TypeWorkDay.Morning },
        new Course() { Name = "401", typeWorkDay=TypeWorkDay.Afternoon },
        new Course() { Name = "501", typeWorkDay=TypeWorkDay.Afternoon },
      };

      Random rand = new Random();
      foreach (var c in School.Courses)
      {
        int randomCount = rand.Next(5, 20);
        // System.Console.WriteLine(randomCount);
        c.Students = generateStudents(randomCount);
        // System.Console.WriteLine(c.Students);
      }
    }

    #endregion
  }
}

