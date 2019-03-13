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

    public IEnumerable<Evaluation> GetEvaluationList() {
      if (_dictionary.TryGetValue(DictionaryKeys.Evaluation, out IEnumerable<ObjSchoolBase> list) == true) {
        return list.Cast<Evaluation>();
      } else {
        return new List<Evaluation>();
      }
    }

    public IEnumerable<string> GetSubjectList() {
      var listEvaluations = GetEvaluationList();

      return GetSubjectList(out var dummy);
    }

    public IEnumerable<string> GetSubjectList(out IEnumerable<Evaluation> listEvaluations) {
      listEvaluations = GetEvaluationList();

      return (from Evaluation ev in listEvaluations
              select ev.Subject.Name).Distinct();
    }

    public Dictionary<string, IEnumerable<Evaluation>> GetEvaluationDictBySubject () {
      var dicResponse = new Dictionary<string, IEnumerable<Evaluation>>();

      var listSubjects = GetSubjectList(out var listEval);

      foreach (var s in listSubjects)
      {
        var evalsSubj = from eval in listEval
                          where eval.Subject.Name == s
                          select eval;
                          
          dicResponse.Add(s, evalsSubj);
      }

      return dicResponse;
    }
  }
}