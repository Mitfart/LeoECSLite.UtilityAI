using System.Collections.Generic;
using Leopotam.EcsLite;

namespace LeoECSLite.UtilityAI.Test {
  public class TestAISys : IEcsRunSystem {
    public void Run(IEcsSystems systems) {
      EcsWorld            world  = systems.GetWorld();
      EcsFilter           filter = world.Filter<TestAIComp>().End();
      EcsPool<TestAIComp> pool   = world.GetPool<TestAIComp>();

      foreach (int e in filter) {
        ref TestAIComp ai = ref pool.Get(e);

        ai.TestEcsAIBrain ??= new TestEcsAIBrain();

        if (ai.Decisions is not { Count: > 0 }) {
          ai.Decisions = new List<SimpleLogEcsAIAction>() {
            new(),
            new(),
            new(),
            new(),
          };
        }

        ai.TestEcsAIBrain.RunFor(e, world, ai.Decisions);
      }
    }
  }
}