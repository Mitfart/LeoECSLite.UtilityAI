using System;
using System.Collections.Generic;
using LeoECSLite.UtilityAI.AICortex;
using Leopotam.EcsLite;

namespace LeoECSLite.UtilityAI.Runtime {
  public abstract class EcsAIBrain {
    private static readonly Dictionary<EcsWorld, Dictionary<Type, IEcsPool>> _WorldsPoolsCache = new();

    protected static int      Entity;
    protected static EcsWorld World;

    private Cortex _cortex;
    private Cortex Cortex => _cortex ??= CreateCortex();

    
    protected abstract Cortex CreateCortex();



    public void RunFor(int e, EcsWorld world, IEnumerable<IDecision> decisions) {
      if (!HasPoolsCacheFor(world))
        InitPoolsCacheFor(world);

      Entity = e;
      World  = world;

      var finalDecision = (IEcsDecision) Cortex.GetFinalDecision(decisions);
      finalDecision.Perform(e, world);
    }



    protected static bool Has<T>() where T : struct {
      return
        GetPool<T>()
         .Has(Entity);
    }

    protected static T Get<T>() where T : struct {
      return (T)
        GetPool<T>()
         .GetRaw(Entity);
    }

    protected static bool TryGet<T>(out T component) where T : struct {
      IEcsPool pool = GetPool<T>();

      if (pool.Has(Entity)) {
        component = (T) pool.GetRaw(Entity);
        return true;
      }

      component = default;
      return false;
    }



    private static bool HasPoolsCacheFor(EcsWorld world) {
      return _WorldsPoolsCache.TryGetValue(world, out Dictionary<Type, IEcsPool> pools)
          && pools != null;
    }

    private static void InitPoolsCacheFor(EcsWorld world) {
      _WorldsPoolsCache[world] = new Dictionary<Type, IEcsPool>(16);
    }


    private static IEcsPool GetPool<T>() where T : struct {
      return _WorldsPoolsCache[World].TryGetValue(typeof(T), out IEcsPool pool)
        ? pool
        : CachePool<T>();
    }

    private static IEcsPool CachePool<T>() where T : struct {
      return _WorldsPoolsCache[World][typeof(T)] = World.GetPool<T>();
    }
  }
}