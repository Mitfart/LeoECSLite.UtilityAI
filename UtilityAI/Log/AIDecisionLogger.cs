using System.Collections.Generic;
using System.Linq;

namespace LeoECSLite.UtilityAI.AICortex.Log {
  public class AIDecisionLogger : IDecisionLogger {
    public void LogDetails(IAIAction iaiAction, IEnumerable<ConclusionScore> scores) {
      scores = scores.ToList();
      
      foreach (ConclusionScore score in scores)
        UnityEngine.Debug.Log(score);
    }

    public void LogScores(IEnumerable<DecisionScore> scoredDecisions) {
      scoredDecisions = scoredDecisions.ToList();
      
      foreach (DecisionScore scoredDecision in scoredDecisions)
        UnityEngine.Debug.Log(scoredDecision);
    }
  }
}