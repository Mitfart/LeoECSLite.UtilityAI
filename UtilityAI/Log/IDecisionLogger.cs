using System.Collections.Generic;

namespace LeoECSLite.UtilityAI.UtilityAI.Log {
  public interface IDecisionLogger {
    void LogDetails(IAIAction                 iaiAction, IEnumerable<ConclusionScore> scores);
    void LogScores(IEnumerable<DecisionScore> scoredDecisions);
  }
}