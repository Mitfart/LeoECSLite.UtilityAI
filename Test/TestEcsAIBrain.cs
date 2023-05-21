using LeoECSLite.UtilityAI.UtilityAI;
using LeoECSLite.UtilityAI.UtilityAI.CortexUtils;

namespace LeoECSLite.UtilityAI.Test {
  public sealed class TestEcsAIBrain : EcsAIBrain {
    protected override Cortex Cortex { get; } = new() { new Conclusions { { action => action is IEcsAIAction, EcsAIInput.Has<TestAIComp>, Score.AsIs, "Test log" }, { action => action is IEcsAIAction, EcsAIInput.Has<TestAIComp>, Score.AsIs, "Test log" }, { action => action is IEcsAIAction, EcsAIInput.Has<TestAIComp>, Score.AsIs, "Test log" } } };
  }
}