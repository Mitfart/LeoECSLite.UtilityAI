using LeoECSLite.UtilityAI.AICortex;
using Leopotam.EcsLite;

namespace LeoECSLite.UtilityAI.Runtime {
  public interface IEcsAIAction : IAIAction {
    void Perform(int e, EcsWorld world);
  }
}