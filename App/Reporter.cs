using System;
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

    public IEnumerable<Evaluation> GetEvaluationList() {
      _dictionary[DictionaryKeys.Evaluation]
    }
  }
}