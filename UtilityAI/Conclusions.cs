using System;
using System.Collections.Generic;
using System.Linq;
using LeoECSLite.UtilityAI.AICortex.Log;

namespace LeoECSLite.UtilityAI.AICortex {
  public class Conclusions : List<Conclusion> {
    public void Add(
      Func<IAIAction, bool> appliesTo,
      Func<double>          input,
      Func<double, double>  score,
      string                name
    ) {
      Add(
        new Conclusion(
          appliesTo,
          input,
          score,
          name
        )
      );
    }



    public DecisionScore Score(IAIAction action) {
      return new DecisionScore(
        action,
        CalcScoreFor(action)
      );
    }

    private double CalcScoreFor(IAIAction action) {
      var scores = (
          from conclusion in this
          where conclusion.AppliesTo(action)
          let input = conclusion.GetInput()
          let score = conclusion.GetScore(input)
          select new ConclusionScore(conclusion.Name, score))
       .ToList();

      AILoggers.LogDetails(action, scores);

      return scores.Sum(s => s.Score);
    }
  }
}