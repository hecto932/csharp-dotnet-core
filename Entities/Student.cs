using System;
using System.Collections.Generic;

namespace CoreSchool.Entities
{
  public class Student: ObjSchoolBase
  {
    public List<Evaluation> Evaluations { get; set; } = new List<Evaluation>();
  }
}