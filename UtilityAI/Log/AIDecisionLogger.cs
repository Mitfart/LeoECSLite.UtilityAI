using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LeoECSLite.UtilityAI.UtilityAI.Log {
  public class AIDecisionLogger : IDecisionLogger {
    public void LogDetails(IAIAction iaiAction, IEnumerable<ConclusionScore> scores) {
      scores = scores.ToList();

      foreach (ConclusionScore score in scores)
        Debug.Log(score);
    }

    public void LogScores(IEnumerable<DecisionScore> scoredDecisions) {
      scoredDecisions = scoredDecisions.ToList();

      foreach (DecisionScore scoredDecision in scoredDecisions)
        Debug.Log(scoredDecision);
    }
  }
}