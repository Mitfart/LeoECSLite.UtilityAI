using LeoECSLite.UtilityAI.Runtime;
using Leopotam.EcsLite;
using UnityEngine;

namespace LeoECSLite.UtilityAI {
  public class SimpleLogEcsDecision : IEcsDecision {
    public void Perform(int e, EcsWorld world) {
      Debug.Log($"Entity: {e} | EcsWorld: {world}");
    }
  }
}