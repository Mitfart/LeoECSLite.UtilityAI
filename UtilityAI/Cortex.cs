using System.Collections.Generic;
using System.Linq;
using LeoECSLite.UtilityAI.UtilityAI.Extentions.IEnumerable;
using LeoECSLite.UtilityAI.UtilityAI.Log;

namespace LeoECSLite.UtilityAI.UtilityAI {
  public class Cortex : List<Conclusions> {
    public IAIAction GetBestDecision(IEnumerable<IAIAction> decisions) {
      var scoredDecisions = ScoreActions(decisions).ToList();

      AILoggers.LogScores(scoredDecisions);

      return scoredDecisions
            .FindMax(choice => choice.Score)
            .IaiAction;
    }

    private IEnumerable<DecisionScore> ScoreActions(IEnumerable<IAIAction> decisions)
      =>
        from decision in decisions
        from conclusions in this
        select conclusions.Score(decision);
  }
}