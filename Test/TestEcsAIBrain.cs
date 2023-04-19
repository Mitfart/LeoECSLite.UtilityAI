using LeoECSLite.UtilityAI.AICortex;
using LeoECSLite.UtilityAI.Runtime;

namespace LeoECSLite.UtilityAI {
  public sealed class TestEcsAIBrain : EcsAIBrain {
    protected override Cortex CreateCortex() {
      return new Cortex {
        new() {
          { dec => dec is IEcsDecision, Has<TestAIComp>() ? 30 : -30, "TEST" },
        }
      };
    }
  }
}