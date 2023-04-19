using LeoECSLite.UtilityAI.AICortex;
using Leopotam.EcsLite;

namespace LeoECSLite.UtilityAI.Runtime {
  public interface IEcsDecision : IDecision {
    void Perform(int e, EcsWorld world);
  }
}