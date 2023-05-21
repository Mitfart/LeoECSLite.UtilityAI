using Leopotam.EcsLite;
using UnityEngine;

namespace LeoECSLite.UtilityAI.Test {
  public class SimpleLogEcsAIAction : IEcsAIAction {
    public void Perform(int e, EcsWorld world) {
      Debug.Log($"Entity: {e} | EcsWorld: {world}");
    }
  }
}