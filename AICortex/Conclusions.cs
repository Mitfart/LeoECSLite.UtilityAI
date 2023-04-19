using System;
using System.Collections;
using System.Collections.Generic;

namespace LeoECSLite.UtilityAI.AICortex {
  public class Conclusions : IEnumerable<Conclusion> {
    private readonly List<Conclusion> _conclusions = new();
    private          Score            _score;


    public IEnumerator<Conclusion> GetEnumerator() {
      return _conclusions.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() {
      return GetEnumerator();
    }


    internal void Add(Func<IDecision, bool> when, double score, string title) {
      _conclusions.Add(new Conclusion(when, score, title));
    }


    public double GetScoreFor(IDecision decision) {
      _score.Reset();

      foreach (Conclusion convolution in _conclusions)
        if (convolution.When.Invoke(decision))
          _score.Change(convolution.Value);

      return _score.Value;
    }
  }
}