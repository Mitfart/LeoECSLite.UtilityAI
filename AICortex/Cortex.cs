using System.Collections.Generic;
using System.Linq;

namespace LeoECSLite.UtilityAI.AICortex {
  public class Cortex : List<Conclusions> {
    public IDecision GetFinalDecision(IEnumerable<IDecision> decisions) {
      IDecision[] decisionsArray = decisions as IDecision[] ?? decisions.ToArray();

      double    biggestScore  = double.MinValue;
      IDecision finalDecision = decisionsArray.First();

      foreach (IDecision decision in decisionsArray) {
        foreach (Conclusions conclusions in this) {
          double curScore = conclusions.GetScoreFor(decision);

          if (curScore < biggestScore)
            continue;

          biggestScore  = curScore;
          finalDecision = decision;
        }
      }

      return finalDecision;
    }
  }
}