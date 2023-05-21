using System.Collections.Generic;

namespace LeoECSLite.UtilityAI.UtilityAI.Log {
  public static class AILoggers {
    private static List<AIDecisionLogger> Registered { get; } = new() { new AIDecisionLogger() };



    public static void LogScores(IEnumerable<DecisionScore> scoredDecisions) {
      foreach (AIDecisionLogger decisionLogger in Registered)
        // ReSharper disable once PossibleMultipleEnumeration
        decisionLogger.LogScores(scoredDecisions);
    }

    public static void LogDetails(IAIAction iaiAction, IEnumerable<ConclusionScore> scores) {
      foreach (AIDecisionLogger decisionLogger in Registered)
        // ReSharper disable once PossibleMultipleEnumeration
        decisionLogger.LogDetails(iaiAction, scores);
    }
  }
}