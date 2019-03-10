using System;

namespace CoreSchool.Entities 
{
  public class ObjSchoolBase {
    public string UniqueId { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }

    public ObjSchoolBase () {
      UniqueId = Guid.NewGuid().ToString();
    }

    public override string ToString() {
      return $"{Name}, {UniqueId}";
    }
  }
}