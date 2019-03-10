using System;
using System.Collections.Generic;
using System.Linq;
using CoreSchool.Entities;

namespace CoreSchool
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

    public List<ObjSchoolBase> GetObjSchoolBases(
      bool getEvaluations = true,
      bool getStudents = true,
      bool getSubjets = true,
      bool getCourses = true
    )
    {
      return GetObjSchoolBases(out int dummy, out dummy, out dummy, out dummy);
    }

    public List<ObjSchoolBase> GetObjSchoolBases(
      out int countEvaluations,
      bool getEvaluations = true,
      bool getStudents = true,
      bool getSubjets = true,
      bool getCourses = true
    )
    {
      return GetObjSchoolBases(out countEvaluations, out int dummy, out dummy, out dummy);
    }

    public List<ObjSchoolBase> GetObjSchoolBases(
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

    public List<ObjSchoolBase> GetObjSchoolBases(
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

    public List<ObjSchoolBase> GetObjSchoolBases(
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

      return listObj;
    }
    #region Upload methods
    private void uploadEvaluations()
    {
      foreach (var course in School.Courses)
      {
        foreach (var subject in course.Subjects)
        {
          foreach (var student in course.Students)
          {
            var rnd = new Random(System.Environment.TickCount);

            for (int i = 0; i < 5; i++)
            {
              var ev = new Evaluation
              {
                Subject = subject,
                Name = $"{subject.Name} ev#{i + 1}",
                Points = (float)(5 * rnd.NextDouble()),
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

