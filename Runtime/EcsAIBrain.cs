using System.Collections.Generic;
using LeoECSLite.UtilityAI.AICortex;
using Leopotam.EcsLite;

namespace LeoECSLite.UtilityAI.Runtime {
  public abstract class EcsAIBrain : Brain {
    public void RunFor(int e, EcsWorld world, IEnumerable<IAIAction> decisions) {
      EcsAIInput.Set(e, world);

      var finalDecision = (IEcsAIAction) Cortex.GetBestDecision(decisions);
      finalDecision.Perform(e, world);
    }
  }
}