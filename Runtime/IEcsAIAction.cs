using LeoECSLite.UtilityAI.UtilityAI;
using Leopotam.EcsLite;

namespace LeoECSLite.UtilityAI {
  public interface IEcsAIAction : IAIAction {
    void Perform(int e, EcsWorld world);
  }
}