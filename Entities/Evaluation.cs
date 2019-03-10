using System;

namespace CoreSchool.Entities
{
  public class Evaluation : ObjSchoolBase
  {
    public Student Student { get; set; }
    public Subject Subject { get; set; }

    public float Points { get; set; }

    public override string ToString() {
      return $"{Points}, {Student.Name}, {Subject.Name}";
    }
  }
}