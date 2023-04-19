using System.Collections.Generic;
using System.Linq;
using LeoECSLite.UtilityAI.AICortex.Extentions.IEnumerable;
using LeoECSLite.UtilityAI.AICortex.Log;

namespace LeoECSLite.UtilityAI.AICortex {
  public class Cortex : List<Conclusions> {
    public IAIAction GetBestDecision(IEnumerable<IAIAction> decisions) {
      var scoredDecisions = ScoreActions(decisions).ToList();
      
      AILoggers.LogScores(scoredDecisions);

      return scoredDecisions
            .FindMax(choice => choice.Score)
            .IaiAction;
    }

    private IEnumerable<DecisionScore> ScoreActions(IEnumerable<IAIAction> decisions) {
      return
        from decision in decisions
        from conclusions in this
        select conclusions.Score(decision);
    }
  }
}