using LeoECSLite.UtilityAI.AICortex;
using LeoECSLite.UtilityAI.AICortex.CortexUtils;
using LeoECSLite.UtilityAI.Runtime;

namespace LeoECSLite.UtilityAI.Test {
  public sealed class TestEcsAIBrain : EcsAIBrain {
    protected override Cortex Cortex { get; } = new() {
      new Conclusions {
        { action => action is IEcsAIAction, EcsAIInput.Has<TestAIComp>, Score.AsIs, "Test log" },
      }
    };
  }
}