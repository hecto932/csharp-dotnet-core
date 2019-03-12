using System;
using System.Linq;
using System.Collections.Generic;
using CoreSchool.Entities;

namespace CoreSchool.App
{
  public class Reporter {

    Dictionary<DictionaryKeys, IEnumerable<ObjSchoolBase>> _dictionary;
    public Reporter (Dictionary<DictionaryKeys, IEnumerable<ObjSchoolBase>> dicObjSchool) {
      if (dicObjSchool == null) {
        throw new ArgumentNullException(nameof(dicObjSchool));
      }
      _dictionary = dicObjSchool;
    }

    public IEnumerable<School> GetEvaluationList() {
      IEnumerable<School> response;
      if (_dictionary.TryGetValue(DictionaryKeys.School, out IEnumerable<ObjSchoolBase> list) == true) {
        response = list.Cast<School>();
      } else {
        response = null;
      }

      return response;
    }
  }
}